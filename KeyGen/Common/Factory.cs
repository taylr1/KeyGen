using KeyGen.AES;
using KeyGen.Common.Abstract;
using KeyGen.Common.Records;
using KeyGen.RSA;

namespace KeyGen.Common;

public static class Factory
{
    public static IKeyService<T> CreateKeyService<T>() where T : BaseKeyValuePair
    {
        if (typeof(T) == typeof(SymmetricalKeyValue))
            return (IKeyService<T>) new AesService();

        if (typeof(T) == typeof(AsymmetricalKeyValue))
            return (IKeyService<T>) new RsaService();

        throw new Exception("Provided type not supported");
    }
}