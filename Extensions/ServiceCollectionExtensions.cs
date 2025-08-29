using BlazorSitemapper.Sitemap;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSiteMapper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the services required for generating sitemaps.
        /// </summary>
        /// <remarks>This method adds the required dependencies for sitemap generation, including an HTTP
        /// context accessor  and a singleton instance of <see cref="SitemapGenerator"/>.</remarks>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the sitemap generation services will be added.</param>
        /// <returns>The same <see cref="IServiceCollection"/> instance, allowing for method chaining.</returns>
        public static IServiceCollection RegisterSitemapper(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<SitemapGenerator>();

            return services;
        }
    }
}
