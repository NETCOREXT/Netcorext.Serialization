using MessagePack;
using Microsoft.Extensions.Logging;

namespace Netcorext.Serialization.Json;

public class MsgPackJsonSerializer : ISerializer
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
            return MessagePackSerializer.SerializeToJson(value, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

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

            return MessagePackSerializer.ConvertToJson(bytes, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

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
            _logger.LogError(e, "{Message}", e);

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
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public object? Deserialize(string utf8String, Type returnType)
    {
        try
        {
            var bytes = MessagePackSerializer.ConvertFromJson(utf8String, _options);
            
            return MessagePackSerializer.Deserialize(returnType, bytes, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public T? Deserialize<T>(string utf8String)
    {
        try
        {
            var bytes = MessagePackSerializer.ConvertFromJson(utf8String, _options);
            
            return MessagePackSerializer.Deserialize<T>(bytes, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public object? Deserialize(Stream utf8Stream, Type returnType)
    {
        try
        {
            if (utf8Stream.CanSeek)
                utf8Stream.Seek(0, SeekOrigin.Begin);

            using var sr = new StreamReader(utf8Stream);

            var json = sr.ReadToEnd();
            
            var bytes = MessagePackSerializer.ConvertFromJson(json, _options);
            
            return MessagePackSerializer.Deserialize(returnType, bytes, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public T? Deserialize<T>(Stream utf8Stream)
    {
        try
        {
            if (utf8Stream.CanSeek)
                utf8Stream.Seek(0, SeekOrigin.Begin);

            using var sr = new StreamReader(utf8Stream);

            var json = sr.ReadToEnd();
            
            var bytes = MessagePackSerializer.ConvertFromJson(json, _options);
            
            return MessagePackSerializer.Deserialize<T>(bytes, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public async Task<object?> DeserializeAsync(string utf8String, Type returnType, CancellationToken cancellationToken = default)
    {
        try
        {
            var bytes = MessagePackSerializer.ConvertFromJson(utf8String, _options, cancellationToken);

            using var ms = new MemoryStream();
            
            await ms.WriteAsync(bytes, cancellationToken);

            ms.Seek(0, SeekOrigin.Begin);
            
            return await MessagePackSerializer.DeserializeAsync(returnType, ms, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public async Task<T?> DeserializeAsync<T>(string utf8String, CancellationToken cancellationToken = default)
    {
        try
        {
            var bytes = MessagePackSerializer.ConvertFromJson(utf8String, _options, cancellationToken);

            using var ms = new MemoryStream();
            
            await ms.WriteAsync(bytes, cancellationToken);

            ms.Seek(0, SeekOrigin.Begin);
            
            return await MessagePackSerializer.DeserializeAsync<T>(ms, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public async Task<object?> DeserializeAsync(Stream utf8Stream, Type returnType, CancellationToken cancellationToken = default)
    {
        try
        {
            if (utf8Stream.CanSeek)
                utf8Stream.Seek(0, SeekOrigin.Begin);

            using var sr = new StreamReader(utf8Stream);

            var json = await sr.ReadToEndAsync();
            
            var bytes = MessagePackSerializer.ConvertFromJson(json, _options, cancellationToken);
            
            using var ms = new MemoryStream();
            
            await ms.WriteAsync(bytes, cancellationToken);

            ms.Seek(0, SeekOrigin.Begin);
            
            return await MessagePackSerializer.DeserializeAsync(returnType, ms, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public async Task<T?> DeserializeAsync<T>(Stream utf8Stream, CancellationToken cancellationToken = default)
    {
        try
        {
            if (utf8Stream.CanSeek)
                utf8Stream.Seek(0, SeekOrigin.Begin);

            using var sr = new StreamReader(utf8Stream);

            var json = await sr.ReadToEndAsync();
            
            var bytes = MessagePackSerializer.ConvertFromJson(json, _options, cancellationToken);

            using var ms = new MemoryStream();
            
            await ms.WriteAsync(bytes, cancellationToken);

            ms.Seek(0, SeekOrigin.Begin);
            
            return await MessagePackSerializer.DeserializeAsync<T>(ms, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }
}