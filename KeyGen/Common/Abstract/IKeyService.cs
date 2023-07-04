using KeyGen.Common;
using KeyGen.Common.Enum;

namespace KeyGen.Common.Abstract;

public interface IKeyService<TKeyType> where TKeyType : BaseKeyValuePair
{
    public Algorithm Algorithm { get; }
    
    public TKeyType CreateKeys();

    public void OutputKeys(TKeyType keyValues);
}