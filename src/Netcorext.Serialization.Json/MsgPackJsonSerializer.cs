using MessagePack;
using Microsoft.Extensions.Logging;

namespace Netcorext.Serialization.Json;

public class MsgPackJsonSerializer : ISerializer<MsgPackJsonSerializer>
{
    private readonly MessagePackSerializerOptions _options;
    private readonly ILogger<MsgPackJsonSerializer> _logger;

    public MsgPackJsonSerializer(MessagePackSerializerOptions options, ILogger<MsgPackJsonSerializer> logger)
    {
        _options = options;
        _logger = logger;
    }

    public string? Serialize<T>(T value)
    {
        try
        {
            var bytes = MessagePackSerializer.Serialize(value, _options);

            return Convert.ToBase64String(bytes);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public async Task<string?> SerializeAsync<T>(T value, CancellationToken cancellationToken = default)
    {
        try
        {
            using var ms = new MemoryStream();

            await MessagePackSerializer.SerializeAsync(ms, value, _options, cancellationToken);

            ms.Seek(0, SeekOrigin.Begin);

            var bytes = ms.ToArray();

            return Convert.ToBase64String(bytes);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public byte[]? SerializeToUtf8Bytes<T>(T value)
    {
        try
        {
            return MessagePackSerializer.Serialize(value, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public async Task<byte[]?> SerializeToUtf8BytesAsync<T>(T value, CancellationToken cancellationToken = default)
    {
        try
        {
            using var ms = new MemoryStream();

            await MessagePackSerializer.SerializeAsync(ms, value, _options, cancellationToken);

            ms.Seek(0, SeekOrigin.Begin);

            return ms.ToArray();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public object? Deserialize(string utf8String, Type returnType)
    {
        try
        {
            var bytes = Convert.FromBase64String(utf8String);

            return MessagePackSerializer.Deserialize(returnType, bytes, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public T? Deserialize<T>(string utf8String)
    {
        try
        {
            var bytes = Convert.FromBase64String(utf8String);

            return MessagePackSerializer.Deserialize<T>(bytes, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public object? Deserialize(byte[] utf8Bytes, Type returnType)
    {
        try
        {
            return MessagePackSerializer.Deserialize(returnType, utf8Bytes, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public T? Deserialize<T>(byte[] utf8Bytes)
    {
        try
        {
            return MessagePackSerializer.Deserialize<T>(utf8Bytes, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public object? Deserialize(Stream utf8Stream, Type returnType)
    {
        try
        {
            if (utf8Stream.CanSeek)
                utf8Stream.Seek(0, SeekOrigin.Begin);

            return MessagePackSerializer.Deserialize(returnType, utf8Stream, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public T? Deserialize<T>(Stream utf8Stream)
    {
        try
        {
            if (utf8Stream.CanSeek)
                utf8Stream.Seek(0, SeekOrigin.Begin);

            return MessagePackSerializer.Deserialize<T>(utf8Stream, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public async Task<object?> DeserializeAsync(string utf8String, Type returnType, CancellationToken cancellationToken = default)
    {
        try
        {
            var bytes = Convert.FromBase64String(utf8String);

            using var ms = new MemoryStream(bytes);

            ms.Seek(0, SeekOrigin.Begin);

            return await MessagePackSerializer.DeserializeAsync(returnType, ms, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public async Task<T?> DeserializeAsync<T>(string utf8String, CancellationToken cancellationToken = default)
    {
        try
        {
            var bytes = Convert.FromBase64String(utf8String);

            using var ms = new MemoryStream(bytes);

            ms.Seek(0, SeekOrigin.Begin);

            return await MessagePackSerializer.DeserializeAsync<T>(ms, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public async Task<object?> DeserializeAsync(byte[] utf8Bytes, Type returnType, CancellationToken cancellationToken = default)
    {
        try
        {
            using var ms = new MemoryStream(utf8Bytes);

            ms.Seek(0, SeekOrigin.Begin);

            return await MessagePackSerializer.DeserializeAsync(returnType, ms, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public async Task<T?> DeserializeAsync<T>(byte[] utf8Bytes, CancellationToken cancellationToken = default)
    {
        try
        {
            using var ms = new MemoryStream(utf8Bytes);

            ms.Seek(0, SeekOrigin.Begin);

            return await MessagePackSerializer.DeserializeAsync<T>(ms, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public async Task<object?> DeserializeAsync(Stream utf8Stream, Type returnType, CancellationToken cancellationToken = default)
    {
        try
        {
            if (utf8Stream.CanSeek)
                utf8Stream.Seek(0, SeekOrigin.Begin);

            return await MessagePackSerializer.DeserializeAsync(returnType, utf8Stream, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public async Task<T?> DeserializeAsync<T>(Stream utf8Stream, CancellationToken cancellationToken = default)
    {
        try
        {
            if (utf8Stream.CanSeek)
                utf8Stream.Seek(0, SeekOrigin.Begin);

            return await MessagePackSerializer.DeserializeAsync<T>(utf8Stream, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }

    public string? ToJson(byte[] bytes)
    {
        try
        {
            MessagePackSerializer.ConvertToJson(bytes, _options);

            return MessagePackSerializer.ConvertToJson(bytes, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e.Message);

            return default;
        }
    }
}