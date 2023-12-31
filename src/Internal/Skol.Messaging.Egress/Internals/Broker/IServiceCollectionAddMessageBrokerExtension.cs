using System.Reflection;
using MassTransit;
using Skol.Messaging.Contracts;

namespace Microsoft.Extensions.DependencyInjection;

internal static class IServiceCollectionAddMessageBrokerExtension
{
    internal static IServiceCollection AddMessageBroker(this IServiceCollection services)
    {
        services.AddOptions<RabbitMqTransportOptions>();
        services.AddMassTransit(x =>
        {
            x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(includeNamespace: false));
            x.AddConsumers(Assembly.GetExecutingAssembly());

            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Message<MessageDigested>(ct => { ct.SetEntityName("digested-messages"); });
                cfg.ConfigureEndpoints(ctx);
            });
        });

        return services;
    }
}
