namespace Netcorext.Serialization;

public interface ISerializer
{
    string? Serialize<T>(T value);
    Task<string?> SerializeAsync<T>(T value, CancellationToken cancellationToken = default);
    byte[]? SerializeToUtf8Bytes<T>(T value);
    Task<byte[]?> SerializeToUtf8BytesAsync<T>(T value, CancellationToken cancellationToken = default);


    object? Deserialize(string utf8String, Type returnType);
    T? Deserialize<T>(string utf8String);
    object? Deserialize(Stream utf8Stream, Type returnType);
    T? Deserialize<T>(Stream utf8Stream);
    Task<object?> DeserializeAsync(string utf8String, Type returnType, CancellationToken cancellationToken = default);
    Task<T?> DeserializeAsync<T>(string utf8String, CancellationToken cancellationToken = default);
    Task<object?> DeserializeAsync(Stream utf8Stream, Type returnType, CancellationToken cancellationToken = default);
    Task<T?> DeserializeAsync<T>(Stream utf8Stream, CancellationToken cancellationToken = default);
}