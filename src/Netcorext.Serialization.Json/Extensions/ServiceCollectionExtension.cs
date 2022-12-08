using System.Text.Json;
using System.Text.Json.Serialization;
using MessagePack;
using MessagePack.Resolvers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Netcorext.Serialization;
using Netcorext.Serialization.Json;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddJsonSerializer<TSerializer>(this IServiceCollection services)
        where TSerializer : class, ISerializer
    {
        services.AddSingleton<ISerializer, TSerializer>();

        return services;
    }

    public static IServiceCollection AddSystemJsonSerializer(this IServiceCollection services, Action<IServiceProvider, JsonSerializerOptions>? configure = null)
    {
        services.TryAddSingleton<JsonSerializerOptions>(provider =>
                                                        {
                                                            var options = new JsonSerializerOptions
                                                                          {
                                                                              PropertyNameCaseInsensitive = true,
                                                                              DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                                                                              WriteIndented = false,
                                                                              PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                                                              ReferenceHandler = ReferenceHandler.IgnoreCycles,
                                                                              NumberHandling = JsonNumberHandling.AllowReadingFromString
                                                                          };

                                                            configure?.Invoke(provider, options);

                                                            return options;
                                                        });

        services.AddSingleton<ISerializer, SystemJsonSerializer>();

        return services;
    }

    public static IServiceCollection AddMsgPackJsonSerializer(this IServiceCollection services, Action<IServiceProvider, MessagePackSerializerOptions>? configure = null)
    {
        services.TryAddSingleton<MessagePackSerializerOptions>(provider =>
                                                               {
                                                                   var options = new MessagePackSerializerOptions(new DynamicContractlessObjectResolverAllowPrivate());

                                                                   options.WithCompression(MessagePackCompression.Lz4Block);

                                                                   configure?.Invoke(provider, options);

                                                                   return options;
                                                               });

        services.AddSingleton<ISerializer, MsgPackJsonSerializer>();

        return services;
    }
}