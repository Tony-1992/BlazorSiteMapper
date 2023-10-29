using BlazorSitemapper.Sitemap;
using Microsoft.AspNetCore.Builder;

namespace BlazorSiteMapper.Extensions
{
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Creates the sitemap.xml file at the location [your-host]/sitemap.xml
        /// </summary>
        /// <param name="app">Continues the IApplicationBuilder chain.</param>
        /// <returns></returns>
        public static IApplicationBuilder CreateSitemap(this IApplicationBuilder app)
        {
            app.UseMiddleware<SitemapMiddleware>();
            return app;
        }
    }
}
