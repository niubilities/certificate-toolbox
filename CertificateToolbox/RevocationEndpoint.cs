using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Org.BouncyCastle.Math;

namespace CertificateToolbox
{
    public partial class RevocationEndpoint : UserControl
    {
        private HttpListener[] listeners;

        public string RevocationType
        {
            get { return groupBox2.Text; }
            set { groupBox2.Text = value; }
        }

        public string ContentType { get; set; }

        public Func<RevocationStatus, byte[]> GetResponse { get; set; }

        public RevocationEndpoint()
        {
            InitializeComponent();
            RevocationStatusColumn.DataSource = Enum.GetValues(typeof(RevocationStatus));
            RevocationStatusColumn.ValueType = typeof(RevocationStatus);
        }

        private static int counter = 9090;

        public void Add()
        {
            dataGridView1.Rows.Add(++counter, RevocationStatus.Valid);
        }
        
        public void Start()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null)
                {
                    continue;
                }
                var listener = new HttpListener();
                var baseUrl = string.Format("http://{0}:{1}/", Environment.MachineName, row.Cells[0].Value);
                listener.Prefixes.Add(baseUrl);
                listener.Start();
                listener.BeginGetContext(ListenerCallback, new MyState
                {
                    Listener = listener, Status = (RevocationStatus)row.Cells[1].Value
                });
            }
        }

        private bool stopRequested;

        public class MyState
        {
            public HttpListener Listener { get; set; }
            public RevocationStatus Status { get; set; }
        }

        public void Stop()
        {
            stopRequested = true;
            foreach (var listener in listeners)
            {
                listener.Close();
            }
        }

        private void ListenerCallback(IAsyncResult asyncResult)
        {
            MyState state = (MyState) asyncResult.AsyncState;
            HttpListener listener = state.Listener;

            try
            {
                if (stopRequested) return;

                HttpListenerContext context = listener.EndGetContext(asyncResult);

                var response = GetResponse(state.Status);
                context.Response.ContentType = ContentType;
                context.Response.ContentLength64 = response.Length;
                context.Response.OutputStream.Write(response, 0, response.Length);
                context.Response.OutputStream.Close();

                File.AppendAllText("revocation.log", Environment.NewLine);

                context.Response.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                if (!stopRequested)
                {
                    listener.BeginGetContext(ListenerCallback, listener);
                }
            }
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = ++counter;
            e.Row.Cells[1].Value = RevocationStatus.Valid;
        }
    }
}
