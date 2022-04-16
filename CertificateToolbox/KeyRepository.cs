namespace CertificateToolbox
{
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto.Prng;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;

    public class KeyRepository
    {
        private static readonly PemReader pem;
        private static readonly StreamReader reader;

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
                var keyPair = (AsymmetricCipherKeyPair)pem.ReadObject();

                if (keyPair != null) return keyPair;

                reader.DiscardBufferedData();
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

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