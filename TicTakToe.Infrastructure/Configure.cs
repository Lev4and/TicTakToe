using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TicTakToe.Infrastructure.Pipelines;

namespace TicTakToe.Infrastructure
{
    public static class Configure
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Configure).Assembly);
            services.AddValidatorsFromAssembly(typeof(Configure).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));
        }
    }
}
