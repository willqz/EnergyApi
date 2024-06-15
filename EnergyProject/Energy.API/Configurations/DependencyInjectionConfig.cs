using Energy.Application.App;
using Energy.Application.Interface;
using Energy.Domain.Interface;
using Energy.Infra.Repository;

namespace Energy.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericsBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IDistributor, RepositoryDistributor>();
            services.AddScoped<IAppDistributor, AppDistributor>();

            return services;
        }
    }
}
