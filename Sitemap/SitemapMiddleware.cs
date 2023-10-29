using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Text;

namespace BlazorSitemapper.Sitemap
{
    internal class SitemapMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SitemapGenerator _sitemapGenerator;

        public SitemapMiddleware(RequestDelegate next, SitemapGenerator sitemapGenerator)
        {
            _next = next;
            _sitemapGenerator = sitemapGenerator;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/sitemap.xml")
            {
                List<SitemapEntry> sitemapEntries = _sitemapGenerator.GenerateSitemapEntries();

                context.Response.ContentType = "text/xml";
                await context.Response.WriteAsync(GenerateSitemapXml(sitemapEntries));
            }
            else
            {
                await _next(context);
            }
        }

        private string GenerateSitemapXml(List<SitemapEntry> sitemapEntries)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

            foreach (var entry in sitemapEntries)
            {
                sb.AppendLine("  <url>");
                sb.AppendLine($"    <loc>{entry.Url}</loc>");
                sb.AppendLine($"    <lastmod>{entry.LastModified:yyyy-MM-ddTHH:mm:ssZ}</lastmod>");
                sb.AppendLine($"    <changefreq>{entry.ChangeFrequency.ToString().ToLower()}</changefreq>");
                sb.AppendLine($"    <priority>{entry.Priority.ToString("F1", CultureInfo.InvariantCulture)}</priority>");
                sb.AppendLine("  </url>");
            }

            sb.AppendLine("</urlset>");

            return sb.ToString();
        }
    }
}
