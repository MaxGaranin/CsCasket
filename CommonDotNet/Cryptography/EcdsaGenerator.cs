using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace CommonDotNet.Cryptography;

public class EcdsaGenerator
{
    public static void Main(string[] args)
    {
        using ECDsa ecdsa = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? new ECDsaCng()
            : new ECDsaOpenSsl();

        ecdsa.GenerateKey(ECCurve.CreateFromFriendlyName("ECDSA_P384"));

        Console.WriteLine($"-----Private key-----{Environment.NewLine}{ecdsa.ExportPkcs8PrivateKeyPem()}{Environment.NewLine}");
        Console.WriteLine($"-----Public key-----{Environment.NewLine}{ecdsa.ExportSubjectPublicKeyInfoPem()}");
    }
}