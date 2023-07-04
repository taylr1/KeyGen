using KeyGen.Common.Abstract;

namespace KeyGen.Common.Records;

public record AsymmetricalKeyValue(string PublicKeyPem, string PrivateKeyPem) : BaseKeyValuePair;

public record SymmetricalKeyValue(string Key, byte[] InitializationVector) : BaseKeyValuePair;