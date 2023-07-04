using System.Security.Cryptography;
using KeyGen.Common.Enum;
using KeyGen.Common.Abstract;
using KeyGen.Common.Records;

namespace KeyGen.RSA;

public class RsaService : IKeyService<AsymmetricalKeyValue>
{
    public Algorithm Algorithm => Algorithm.Rsa;

    public AsymmetricalKeyValue CreateKeys()
    {
        using (var rsa = new RSACryptoServiceProvider(1024))
        {
            try
            {
                var privateKey = rsa.ExportRSAPrivateKeyPem();
                var publicKey = rsa.ExportRSAPublicKeyPem();

                return new AsymmetricalKeyValue(publicKey, privateKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                // key values will persist on local drives if this isn't set to false
                rsa.PersistKeyInCsp = false;
            }
        }
    }

    public void OutputKeys(AsymmetricalKeyValue keyValues)
    {
        Console.WriteLine(keyValues.PublicKeyPem);
        Console.WriteLine(keyValues.PrivateKeyPem);
    }
}