using BlazorSitemapper.Sitemap;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSiteMapper.Extensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the sitemapper generator as a singleton.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterSitemapper(this IServiceCollection services)
        {
            services.AddSingleton<SitemapGenerator>();

            return services;
        }
    }
}
