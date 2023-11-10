using Hubtel.SafeWallet.Core.Data;
using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Domain.Repository;
using Hubtel.SafeWallet.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hubtel.SafeWallet.Core
{
    public static  class DependencyInjection
    {
        public static IServiceCollection RegisterCoreDIServices(this IServiceCollection services)
        {
            //services.AddMediatR(typeof(MediatRModule).Assembly);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<IIdentityService, IdentityService>();
            return services;
        }
    }

}