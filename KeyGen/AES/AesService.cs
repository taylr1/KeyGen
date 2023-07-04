using System.Security.Cryptography;
using KeyGen.Common.Abstract;
using KeyGen.Common.Enum;
using KeyGen.Common.Records;

namespace KeyGen.AES;

public class AesService : IKeyService<SymmetricalKeyValue>
{
    public Algorithm Algorithm => Algorithm.Aes;
    public SymmetricalKeyValue CreateKeys()
    {
        try
        {
            var aes = Aes.Create();
            
            // the IV (Initialization Vector) is utilized to provide the algorithm an initial state
            // this number is typically generated at random to ensure unpredictability 
            aes.GenerateIV();
            aes.GenerateKey();

            return new SymmetricalKeyValue(Convert.ToBase64String(aes.Key), aes.IV);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public void OutputKeys(SymmetricalKeyValue keyValues)
    {
        Console.WriteLine("Base 64 Encoded AES Key");
        Console.WriteLine(keyValues.Key);
    }
}