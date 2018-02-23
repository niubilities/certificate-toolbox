using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertificateToolbox
{
    public class OcspServer
    {
        private HttpListener listener;

        public string OcspUrl { get; set; }

        public Func<RevocationStatus> GetStatus { get; set; }

        public Func<byte[]> GetOcsp { get; set; }

        public void Start()
        {
            Task.Run(() =>
            {
                try
                {
                    listener = new HttpListener();
                    var uri = new Uri(OcspUrl);
                    var baseUrl = $"{uri.Scheme}://{uri.Host}:{uri.Port}/";
                    listener.Prefixes.Add(baseUrl);
                    listener.Start();

                    while (listener.IsListening)
                    {
                        var context = listener.GetContext();

                        var status = GetStatus();

                        if (status == RevocationStatus.Unknown)
                        {
                            context.Response.StatusCode = 404;
                        }
                        else
                        {
                            var file = GetOcsp();
                            context.Response.ContentType = "application/ocsp-response";
                            context.Response.ContentLength64 = file.Length;
                            context.Response.OutputStream.Write(file, 0, file.Length);
                            context.Response.OutputStream.Close();
                        }

                        context.Response.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            });
        }

        public void Stop()
        {
            listener?.Stop();
        }
    }
}
