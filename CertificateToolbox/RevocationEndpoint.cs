using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CertificateToolbox
{
    public partial class RevocationEndpoint : UserControl
    {
        private HttpListener listener;
        private RevocationStatus status;

        public string EndpointUrl
        {
            get { return include.Checked ? url.Text : null; }
            set { url.Text = value; }
        }
        
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
            
            result.DataSource = Enum.GetValues(typeof(RevocationStatus));
        }
        
        public void Start()
        {
            listener = new HttpListener();
            var uri = new Uri(EndpointUrl);
            var baseUrl = string.Format("{0}://{1}:{2}/", uri.Scheme, uri.Host, uri.Port);
            listener.Prefixes.Add(baseUrl);
            listener.Start();
            listener.BeginGetContext(ListenerCallback, listener);
        }

        private bool stopRequested;

        public void Stop()
        {
            stopRequested = true;
            listener.Close();
        }

        private void ListenerCallback(IAsyncResult asyncResult)
        {
            try
            {
                if (stopRequested) return;

                HttpListenerContext context = listener.EndGetContext(asyncResult);

                if (status == RevocationStatus.Unknown)
                {
                    context.Response.StatusCode = 404;
                }
                else
                {
                    var response = GetResponse(status);
                    context.Response.ContentType = ContentType;
                    context.Response.ContentLength64 = response.Length;
                    context.Response.OutputStream.Write(response, 0, response.Length);
                    context.Response.OutputStream.Close();
                }

                File.AppendAllText("revocation.log", EndpointUrl + Environment.NewLine);

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

        private void result_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = (RevocationStatus)result.SelectedItem;
        }
    }
}
