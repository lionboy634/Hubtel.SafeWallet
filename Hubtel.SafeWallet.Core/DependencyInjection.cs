using FluentValidation;
using Hubtel.SafeWallet.Core.Data;
using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Domain.Repository;
using Hubtel.SafeWallet.Core.Features.Wallet.AddWallet;
using Hubtel.SafeWallet.Core.Services;
using Hubtel.SafeWallet.Core.Services.Middleware;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace Hubtel.SafeWallet.Core
{
    public static  class DependencyInjection
    {
        public static IServiceCollection RegisterCoreDIServices(this IServiceCollection services)
        {

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddTransient<ErrorHandlingMiddleware>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddScoped<IDataHasher, DataHasher>();

            return services;
        }
    }

}