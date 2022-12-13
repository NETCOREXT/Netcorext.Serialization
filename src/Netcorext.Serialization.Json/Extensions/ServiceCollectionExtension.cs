using System.Text.Json;
using System.Text.Json.Serialization;
using MessagePack;
using MessagePack.Resolvers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Netcorext.Serialization;
using Netcorext.Serialization.Json;
using Netcorext.Serialization.Json.MessagePack.Formatters;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddJsonSerializer<TSerializer>(this IServiceCollection services)
        where TSerializer : class, ISerializer<TSerializer>
    {
        services.AddSingleton<ISerializer, TSerializer>();

        services.AddSingleton<ISerializer<TSerializer>, TSerializer>();

        return services;
    }

    public static IServiceCollection AddOrReplaceJsonSerializer<TSerializer>(this IServiceCollection services)
        where TSerializer : class, ISerializer<TSerializer>
    {
        services.AddOrReplace<ISerializer, TSerializer>(ServiceLifetime.Singleton);

        services.AddOrReplace<ISerializer<TSerializer>, TSerializer>(ServiceLifetime.Singleton);

        return services;
    }

    public static void TryAddJsonSerializer<TSerializer>(this IServiceCollection services)
        where TSerializer : class, ISerializer<TSerializer>
    {
        services.TryAddSingleton<ISerializer, TSerializer>();

        services.TryAddSingleton<ISerializer<TSerializer>, TSerializer>();
    }

    public static IServiceCollection AddSystemJsonSerializer(this IServiceCollection services, Action<IServiceProvider, JsonSerializerOptions>? configure = null)
    {
        services.AddSingleton<ISerializer, SystemJsonSerializer>(provider =>
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

                                                                     var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                                     var logger = loggerFactory.CreateLogger<SystemJsonSerializer>();

                                                                     return new SystemJsonSerializer(options, logger);
                                                                 });

        services.AddSingleton<ISerializer<SystemJsonSerializer>, SystemJsonSerializer>(provider =>
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

                                                                                           var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                                                           var logger = loggerFactory.CreateLogger<SystemJsonSerializer>();

                                                                                           return new SystemJsonSerializer(options, logger);
                                                                                       });

        return services;
    }

    public static IServiceCollection AddOrReplaceSystemJsonSerializer(this IServiceCollection services, Action<IServiceProvider, JsonSerializerOptions>? configure = null)
    {
        services.AddOrReplace(typeof(ISerializer), provider =>
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

                                                       var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                       var logger = loggerFactory.CreateLogger<SystemJsonSerializer>();

                                                       return new SystemJsonSerializer(options, logger);
                                                   }, ServiceLifetime.Singleton);

        services.AddOrReplace(typeof(ISerializer<SystemJsonSerializer>), provider =>
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

                                                                             var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                                             var logger = loggerFactory.CreateLogger<SystemJsonSerializer>();

                                                                             return new SystemJsonSerializer(options, logger);
                                                                         }, ServiceLifetime.Singleton);

        return services;
    }

    public static void TryAddSystemJsonSerializer(this IServiceCollection services, Action<IServiceProvider, JsonSerializerOptions>? configure = null)
    {
        services.TryAddSingleton<ISerializer>(provider =>
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

                                                  var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                  var logger = loggerFactory.CreateLogger<SystemJsonSerializer>();

                                                  return new SystemJsonSerializer(options, logger);
                                              });

        services.TryAddSingleton<ISerializer<SystemJsonSerializer>>(provider =>
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

                                                                        var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                                        var logger = loggerFactory.CreateLogger<SystemJsonSerializer>();

                                                                        return new SystemJsonSerializer(options, logger);
                                                                    });
    }

    public static IServiceCollection AddMsgPackJsonSerializer(this IServiceCollection services, Action<IServiceProvider, MessagePackSerializerOptions>? configure = null)
    {
        services.AddSingleton<ISerializer, MsgPackJsonSerializer>(provider =>
                                                                  {
                                                                      var dateTimeResolver = CompositeResolver.Create(new DateTimeFormatter(),
                                                                                                                      new NullableDateTimeFormatter(),
                                                                                                                      new DateTimeOffsetFormatter(),
                                                                                                                      new NullableDateTimeOffsetFormatter());

                                                                      var resolver = CompositeResolver.Create(dateTimeResolver, TypelessContractlessStandardResolver.Instance);

                                                                      var options = TypelessContractlessStandardResolver.Options
                                                                                                                        .WithResolver(resolver)
                                                                                                                        .WithCompression(MessagePackCompression.Lz4BlockArray);

                                                                      configure?.Invoke(provider, options);

                                                                      var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                                      var logger = loggerFactory.CreateLogger<MsgPackJsonSerializer>();

                                                                      return new MsgPackJsonSerializer(options, logger);
                                                                  });

        services.AddSingleton<ISerializer<MsgPackJsonSerializer>, MsgPackJsonSerializer>(provider =>
                                                                                         {
                                                                                             var dateTimeResolver = CompositeResolver.Create(new DateTimeFormatter(),
                                                                                                                                             new NullableDateTimeFormatter(),
                                                                                                                                             new DateTimeOffsetFormatter(),
                                                                                                                                             new NullableDateTimeOffsetFormatter());

                                                                                             var resolver = CompositeResolver.Create(dateTimeResolver, TypelessContractlessStandardResolver.Instance);

                                                                                             var options = TypelessContractlessStandardResolver.Options
                                                                                                                                               .WithResolver(resolver)
                                                                                                                                               .WithCompression(MessagePackCompression.Lz4BlockArray);

                                                                                             configure?.Invoke(provider, options);

                                                                                             var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                                                             var logger = loggerFactory.CreateLogger<MsgPackJsonSerializer>();

                                                                                             return new MsgPackJsonSerializer(options, logger);
                                                                                         });

        return services;
    }

    public static IServiceCollection AddOrReplaceMsgPackJsonSerializer(this IServiceCollection services, Action<IServiceProvider, MessagePackSerializerOptions>? configure = null)
    {
        services.AddOrReplace(typeof(ISerializer), provider =>
                                                   {
                                                       var dateTimeResolver = CompositeResolver.Create(new DateTimeFormatter(),
                                                                                                       new NullableDateTimeFormatter(),
                                                                                                       new DateTimeOffsetFormatter(),
                                                                                                       new NullableDateTimeOffsetFormatter());

                                                       var resolver = CompositeResolver.Create(dateTimeResolver, TypelessContractlessStandardResolver.Instance);

                                                       var options = TypelessContractlessStandardResolver.Options
                                                                                                         .WithResolver(resolver)
                                                                                                         .WithCompression(MessagePackCompression.Lz4BlockArray);

                                                       configure?.Invoke(provider, options);

                                                       var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                       var logger = loggerFactory.CreateLogger<MsgPackJsonSerializer>();

                                                       return new MsgPackJsonSerializer(options, logger);
                                                   }, ServiceLifetime.Singleton);

        services.AddOrReplace(typeof(ISerializer<MsgPackJsonSerializer>), provider =>
                                                                          {
                                                                              var dateTimeResolver = CompositeResolver.Create(new DateTimeFormatter(),
                                                                                                                              new NullableDateTimeFormatter(),
                                                                                                                              new DateTimeOffsetFormatter(),
                                                                                                                              new NullableDateTimeOffsetFormatter());

                                                                              var resolver = CompositeResolver.Create(dateTimeResolver, TypelessContractlessStandardResolver.Instance);

                                                                              var options = TypelessContractlessStandardResolver.Options
                                                                                                                                .WithResolver(resolver)
                                                                                                                                .WithCompression(MessagePackCompression.Lz4BlockArray);

                                                                              configure?.Invoke(provider, options);

                                                                              var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                                              var logger = loggerFactory.CreateLogger<MsgPackJsonSerializer>();

                                                                              return new MsgPackJsonSerializer(options, logger);
                                                                          }, ServiceLifetime.Singleton);

        return services;
    }

    public static void TryAddMsgPackJsonSerializer(this IServiceCollection services, Action<IServiceProvider, MessagePackSerializerOptions>? configure = null)
    {
        services.TryAddSingleton<ISerializer>(provider =>
                                              {
                                                  var dateTimeResolver = CompositeResolver.Create(new DateTimeFormatter(),
                                                                                                  new NullableDateTimeFormatter(),
                                                                                                  new DateTimeOffsetFormatter(),
                                                                                                  new NullableDateTimeOffsetFormatter());

                                                  var resolver = CompositeResolver.Create(dateTimeResolver, TypelessContractlessStandardResolver.Instance);

                                                  var options = TypelessContractlessStandardResolver.Options
                                                                                                    .WithResolver(resolver)
                                                                                                    .WithCompression(MessagePackCompression.Lz4BlockArray);

                                                  configure?.Invoke(provider, options);

                                                  var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                  var logger = loggerFactory.CreateLogger<MsgPackJsonSerializer>();

                                                  return new MsgPackJsonSerializer(options, logger);
                                              });

        services.TryAddSingleton<ISerializer<MsgPackJsonSerializer>>(provider =>
                                                                     {
                                                                         var dateTimeResolver = CompositeResolver.Create(new DateTimeFormatter(),
                                                                                                                         new NullableDateTimeFormatter(),
                                                                                                                         new DateTimeOffsetFormatter(),
                                                                                                                         new NullableDateTimeOffsetFormatter());

                                                                         var resolver = CompositeResolver.Create(dateTimeResolver, TypelessContractlessStandardResolver.Instance);

                                                                         var options = TypelessContractlessStandardResolver.Options
                                                                                                                           .WithResolver(resolver)
                                                                                                                           .WithCompression(MessagePackCompression.Lz4BlockArray);

                                                                         configure?.Invoke(provider, options);

                                                                         var loggerFactory = provider.GetRequiredService<ILoggerFactory>();
                                                                         var logger = loggerFactory.CreateLogger<MsgPackJsonSerializer>();

                                                                         return new MsgPackJsonSerializer(options, logger);
                                                                     });
    }
}