using BlazorSitemapper.Sitemap;
using Microsoft.AspNetCore.Builder;

namespace BlazorSiteMapper.Extensions
{
    public static class ApplicationExtensions
    {
        public static IApplicationBuilder CreateSitemap(this IApplicationBuilder app)
        {
            app.UseMiddleware<SitemapMiddleware>();
            return app;
        }
    }
}
