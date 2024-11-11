using System.Runtime.InteropServices;
using System.Security.Cryptography;

ECDsa ecdsa = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
    ? new ECDsaCng()
    : new ECDsaOpenSsl();

ecdsa.GenerateKey(ECCurve.CreateFromFriendlyName("ECDSA_P384"));

Console.WriteLine($"-----Private key-----{Environment.NewLine}{Convert.ToBase64String(ecdsa.ExportPkcs8PrivateKey())}{Environment.NewLine}");
Console.WriteLine($"-----Public key-----{Environment.NewLine}{Convert.ToBase64String(ecdsa.ExportSubjectPublicKeyInfo())}");

ecdsa.Dispose();