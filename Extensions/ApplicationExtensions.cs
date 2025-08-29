using BlazorSitemapper.Sitemap;
using Microsoft.AspNetCore.Builder;

namespace BlazorSiteMapper.Extensions
{
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Configures the application to use the <see cref="SitemapMiddleware"/> for generating and serving sitemaps.
        /// </summary>
        /// <remarks>This extension method adds the <see cref="SitemapMiddleware"/> to the application's
        /// request pipeline. Ensure that the middleware is added in the appropriate order relative to other middleware
        /// components.</remarks>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance to configure.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance, to allow for method chaining.</returns>
        public static IApplicationBuilder CreateSitemap(this IApplicationBuilder app)
        {
            app.UseMiddleware<SitemapMiddleware>();
            return app;
        }
    }
}
