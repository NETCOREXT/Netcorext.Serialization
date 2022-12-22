using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Netcorext.Serialization.Json;

public class SystemJsonSerializer : ISerializer<SystemJsonSerializer>
{
    private readonly JsonSerializerOptions _options;
    private readonly ILogger<SystemJsonSerializer> _logger;

    public SystemJsonSerializer(JsonSerializerOptions options, ILogger<SystemJsonSerializer> logger)
    {
        _options = options;
        _logger = logger;
    }

    public string? Serialize<T>(T value)
    {
        try
        {
            return JsonSerializer.Serialize(value, _options);
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

            await JsonSerializer.SerializeAsync(ms, value, _options, cancellationToken);

            var bytes = ms.ToArray();

            return Encoding.UTF8.GetString(bytes);
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
            return JsonSerializer.SerializeToUtf8Bytes(value, _options);
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

            await JsonSerializer.SerializeAsync(ms, value, _options, cancellationToken);

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
            return JsonSerializer.Deserialize(utf8String, returnType, _options);
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
            return JsonSerializer.Deserialize<T>(utf8String, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public object? Deserialize(byte[] utf8Bytes, Type returnType)
    {
        try
        {
            using var ms = new MemoryStream(utf8Bytes);

            ms.Seek(0, SeekOrigin.Begin);

            return JsonSerializer.Deserialize(ms, returnType, _options);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public T? Deserialize<T>(byte[] utf8Bytes)
    {
        try
        {
            using var ms = new MemoryStream(utf8Bytes);

            ms.Seek(0, SeekOrigin.Begin);

            return JsonSerializer.Deserialize<T>(ms, _options);
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

            return JsonSerializer.Deserialize(utf8Stream, returnType, _options);
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

            return JsonSerializer.Deserialize<T>(utf8Stream, _options);
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
            using var ms = new MemoryStream();
            await using var sw = new StreamWriter(ms);
            await sw.WriteAsync(utf8String);
            
            ms.Seek(0, SeekOrigin.Begin);

            return await JsonSerializer.DeserializeAsync(ms, returnType, _options, cancellationToken);
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
            using var ms = new MemoryStream();
            await using var sw = new StreamWriter(ms);
            await sw.WriteAsync(utf8String);

            ms.Seek(0, SeekOrigin.Begin);

            return await JsonSerializer.DeserializeAsync<T>(ms, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public async Task<object?> DeserializeAsync(byte[] utf8Bytes, Type returnType, CancellationToken cancellationToken = default)
    {
        try
        {
            using var ms = new MemoryStream(utf8Bytes);

            ms.Seek(0, SeekOrigin.Begin);

            return await JsonSerializer.DeserializeAsync(ms, returnType, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }

    public async Task<T?> DeserializeAsync<T>(byte[] utf8Bytes, CancellationToken cancellationToken = default)
    {
        try
        {
            using var ms = new MemoryStream(utf8Bytes);

            ms.Seek(0, SeekOrigin.Begin);

            return await JsonSerializer.DeserializeAsync<T>(ms, _options, cancellationToken);
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

            return await JsonSerializer.DeserializeAsync(utf8Stream, returnType, _options, cancellationToken);
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

            return await JsonSerializer.DeserializeAsync<T>(utf8Stream, _options, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Message}", e);

            return default;
        }
    }
}