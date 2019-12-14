using ErrorCenter.Application.ApplicationServices;
using ErrorCenter.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorCenter.CrossCuttingIoC
{
    public class RegisterIoC
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            // appServices
            serviceCollection.AddScoped<IEnvironmentService, EnvironmentService>();
            serviceCollection.AddScoped<IErrorOccurrenceService, ErrorOccurrenceService>();
            serviceCollection.AddScoped<IErrorService, ErrorService>();
            serviceCollection.AddScoped<ILevelService, LevelService>();
            serviceCollection.AddScoped<ISituationService, SituationService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<ISystemAuthenticationService, SystemAuthenticationService>();


            //// services
            //serviceCollection.AddScoped<IClienteService, ClienteService>();

            //// repositories
            //serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
