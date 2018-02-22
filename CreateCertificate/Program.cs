using System;
using System.IO;
using Org.BouncyCastle.Asn1.X509;
using X509Certificate2 = System.Security.Cryptography.X509Certificates.X509Certificate2;
using X509KeyStorageFlags = System.Security.Cryptography.X509Certificates.X509KeyStorageFlags;
using X509ContentType = System.Security.Cryptography.X509Certificates.X509ContentType;

namespace CreateCertificate
{
    internal static class Program
    {
        private static int ShowUsage()
        {
            Console.WriteLine("CreateCertificate self subject-name subject.pfx");
            Console.WriteLine("CreateCertificate ca subject-name CA.pfx");
            Console.WriteLine("CreateCertificate issue CA.pfx subject-name subject.pfx");

            return -1;
        }

        private static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                return ShowUsage();
            }

            var mode = args[0];
            switch (mode.ToLower())
            {
                case "self":
                    {
                        if (args.Length != 3)
                            return ShowUsage();
                        
                        var outputFileName = args[2];

                        var generator = new Generator
                        {
                            SubjectName = args[1],
                            SubjectAlternativeNames = new[] {"server", "server.mydomain.com"},
                            Usages = new[] {KeyPurposeID.IdKPServerAuth}
                        };

                        var certificate = generator.Generate();
                        WriteCertificate(certificate, outputFileName);
                        return 0;
                    }

                case "ca":
                    {
                        if (args.Length != 3)
                            return ShowUsage();

                        var outputFileName = args[2];

                        var generator = new Generator
                        {
                            SubjectName = args[1],
                            IsCertificateAuthority = true
                        };

                        var certificate = generator.Generate();
                        WriteCertificate(certificate, outputFileName);
                        return 0;
                    }

                case "issue":
                    {
                        if (args.Length != 4)
                            return ShowUsage();

                        var issuerFileName = args[1];
                        var outputFileName = args[3];
                        
                        var generator = new Generator
                        {
                            SubjectName = args[2],
                            SubjectAlternativeNames = new[] { "server", "server.mydomain.com" },
                            Usages = new[] { KeyPurposeID.IdKPServerAuth },
                            Issuer = LoadCertificate(issuerFileName, "password")
                        };

                        var certificate = generator.Generate();
                        WriteCertificate(certificate, outputFileName);
                        return 0;
                    }

                default:
                    return ShowUsage();
            }
        }
        private static X509Certificate2 LoadCertificate(string issuerFileName, string password)
        {
            // We need to pass 'Exportable', otherwise we can't get the private key.
            var issuerCertificate = new X509Certificate2(issuerFileName, password, X509KeyStorageFlags.Exportable);
            return issuerCertificate;
        }

        private static void WriteCertificate(X509Certificate2 certificate, string outputFileName)
        {
            // This password is the one attached to the PFX file. Use 'null' for no password.
            const string password = "password";
            var bytes = certificate.Export(X509ContentType.Pfx, password);
            File.WriteAllBytes(outputFileName, bytes);
        }
    }
}