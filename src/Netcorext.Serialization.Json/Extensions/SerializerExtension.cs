using Netcorext.Serialization;
using Netcorext.Serialization.Json;

namespace Microsoft.Extensions.DependencyInjection;

public static class SerializerExtension
{
    public static string? ToJson(this ISerializer serializer, byte[]? bytes)
    {
        if (bytes is null || bytes.Length == 0)
            return default;

        if (serializer is not MsgPackJsonSerializer msgpack)
            throw new ArgumentException("Serializer must be of type MsgPackJsonSerializer", nameof(serializer));

        return msgpack.ToJson(bytes);
    }
}