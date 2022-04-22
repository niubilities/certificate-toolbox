namespace CertificateToolbox
{
    using System.Net;

    public partial class RevocationEndpoint : UserControl
    {
        private static int _counter = 9090;
        private readonly List<HttpListener> _listeners;

        private bool _stopRequested;

        public RevocationEndpoint()
        {
            InitializeComponent();
            _listeners = new List<HttpListener>();
            RevocationStatusColumn.DataSource = Enum.GetValues(typeof(RevocationStatus));
            RevocationStatusColumn.ValueType = typeof(RevocationStatus);
        }

        public string ContentType { get; set; }

        public Func<RevocationStatus, byte[]> GetResponse { get; set; }

        public string RevocationType
        {
            get => groupBox2.Text;
            set => groupBox2.Text = value;
        }

        public string[] Urls =>
            (from DataGridViewRow row in dataGridView1.Rows
                where row.Cells[0].Value != null && !row.IsNewRow
                select GetUrl(row.Cells[0].Value.ToString())).ToArray();

        public void Add()
        {
            dataGridView1.Rows.Add(++_counter, RevocationStatus.Valid);
        }

        public void Start()
        {
            _stopRequested = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null) continue;

                var listener = new HttpListener();
                _listeners.Add(listener);
                var baseUrl = GetUrl(row.Cells[0].Value.ToString());
                listener.Prefixes.Add(baseUrl);
                listener.Start();

                listener.BeginGetContext(
                    ListenerCallback,
                    new MyState
                    {
                        Listener = listener, GetStatus = () => (RevocationStatus)row.Cells[1].Value
                    });
            }
        }

        public void Stop()
        {
            _stopRequested = true;
            foreach (var listener in _listeners) listener.Close();
            _listeners.Clear();
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = ++_counter;
            e.Row.Cells[1].Value = RevocationStatus.Valid;
        }

        private string GetUrl(string? port)
        {
            return $@"http://{Environment.MachineName}:{port}/";
        }

        private void ListenerCallback(IAsyncResult asyncResult)
        {
            var state = asyncResult.AsyncState as MyState;
            var listener = state!.Listener;

            try
            {
                if (_stopRequested) return;

                var context = listener.EndGetContext(asyncResult);

                var status = state.GetStatus();
                var response = GetResponse(status);
                context.Response.ContentType = ContentType;
                context.Response.ContentLength64 = response.Length;
                context.Response.OutputStream.Write(response, 0, response.Length);
                context.Response.OutputStream.Close();

                File.AppendAllText("revocation.log", context.Request.Url + status.ToString() + Environment.NewLine);

                context.Response.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                if (!_stopRequested) listener.BeginGetContext(ListenerCallback, state);
            }
        }

        public class MyState
        {
            public Func<RevocationStatus> GetStatus { get; set; }
            public HttpListener Listener { get; set; }
        }
    }
}