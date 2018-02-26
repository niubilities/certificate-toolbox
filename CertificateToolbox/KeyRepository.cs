using System.IO;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace CertificateToolbox
{
    public class KeyRepository
    {
        private static readonly StreamReader reader;
        private static readonly PemReader pem;

        static KeyRepository()
        {
            const string filename = "private.keys";

            if (File.Exists(filename))
            {
                reader = new StreamReader(filename);
                pem = new PemReader(reader);
            }
        }

        public static AsymmetricCipherKeyPair Next()
        {
            if (pem != null)
            {
                return (AsymmetricCipherKeyPair)pem.ReadObject();
            }

            var random = new SecureRandom(new CryptoApiRandomGenerator());
            var keyGenerationParameters = new KeyGenerationParameters(random, 2048);
            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            return keyPairGenerator.GenerateKeyPair();
        }
    }
}
