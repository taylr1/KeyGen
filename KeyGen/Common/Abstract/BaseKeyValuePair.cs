namespace KeyGen.Common.Abstract;

public record BaseKeyValuePair
{
    protected KeyType Type { get; }
    
    protected enum KeyType
    {
        Symmetric, 
        Asymmetric
    }
}