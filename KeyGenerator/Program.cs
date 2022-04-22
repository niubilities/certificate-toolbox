namespace KeyGenerator
{
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Generators;
    using Org.BouncyCastle.Crypto.Prng;
    using Org.BouncyCastle.OpenSsl;
    using Org.BouncyCastle.Security;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var filename = args[0];
            var count = int.Parse(args[1]);

            const int bitLength = 2048;

            var random = new SecureRandom(new CryptoApiRandomGenerator());
            var keyGenerationParameters = new KeyGenerationParameters(random, bitLength);
            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);

            using var writer = new StreamWriter(filename);
            var pemWriter = new PemWriter(writer);

            for (var i = 0; i < count; i++)
            {
                var keyPair = keyPairGenerator.GenerateKeyPair();
                pemWriter.WriteObject(keyPair.Private);
            }

            writer.Close();
        }
    }
}