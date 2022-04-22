namespace CertificateToolbox
{
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto.Prng;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;

    public class KeyRepository
    {
        private static readonly PemReader Pem;
        private static readonly StreamReader Reader;

        static KeyRepository()
        {
            const string filename = "private.keys";

            if (File.Exists(filename))
            {
                Reader = new StreamReader(filename);
                Pem = new PemReader(Reader);
            }
        }

        public static AsymmetricCipherKeyPair Next()
        {
            if (Pem != null)
            {
                var keyPair = (AsymmetricCipherKeyPair)Pem.ReadObject();

                if (keyPair != null) return keyPair;

                Reader.DiscardBufferedData();
                Reader.BaseStream.Seek(0, SeekOrigin.Begin);

                return (AsymmetricCipherKeyPair)Pem.ReadObject();
            }

            var random = new SecureRandom(new CryptoApiRandomGenerator());
            var keyGenerationParameters = new KeyGenerationParameters(random, 2048);
            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);

            return keyPairGenerator.GenerateKeyPair();
        }
    }
}