using MediatR;
using Self.CleanArchitecture.Persistence;
using Self.CleanArchitecture.Usecase;
using System.Reflection;

namespace Self.CleanArchitecture.Web
{
    public static class ServiceSetup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IReadRepository, CSVFileDataStore>();
             var mediatRAssemblies = new[]
{
  Assembly.GetAssembly(typeof(CountryGWPQuery)), // UseCases, 
  Assembly.GetExecutingAssembly()
};


            services.AddMediatR(cfg =>
            {
                
                cfg.RegisterServicesFromAssemblies(mediatRAssemblies!);
            });

            return services;
        }
    }
}
