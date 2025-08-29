using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Text;

namespace BlazorSitemapper.Sitemap
{
    /// <summary>
    /// Middleware that handles requests for the sitemap.xml file and generates a dynamic sitemap response.
    /// </summary>
    /// <remarks>This middleware intercepts requests to the "/sitemap.xml" path and generates an XML sitemap
    /// based on the entries provided by the <see cref="SitemapGenerator"/>. If the request path does not match
    /// "/sitemap.xml", the middleware passes the request to the next middleware in the pipeline.</remarks>
    internal class SitemapMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SitemapGenerator _sitemapGenerator;

        public SitemapMiddleware(RequestDelegate next, SitemapGenerator sitemapGenerator)
        {
            _next = next;
            _sitemapGenerator = sitemapGenerator;
        }

        /// <summary>
        /// Handles HTTP requests and generates a sitemap XML response if the request path is "/sitemap.xml".
        /// </summary>
        /// <remarks>If the request path is "/sitemap.xml", this method generates a sitemap XML document
        /// using the  configured sitemap generator and writes it to the response with a content type of "text/xml". For
        /// all other request paths, the request is passed to the next middleware in the pipeline.</remarks>
        /// <param name="context">The <see cref="HttpContext"/> representing the current HTTP request and response.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
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

        /// <summary>
        /// Generates an XML sitemap string based on the provided list of sitemap entries.
        /// </summary>
        /// <remarks>The generated XML includes the URL, last modification date, change frequency, and
        /// priority for each entry. The output conforms to the sitemap protocol schema defined at <see
        /// href="http://www.sitemaps.org/schemas/sitemap/0.9"/>.</remarks>
        /// <param name="sitemapEntries">A list of <see cref="SitemapEntry"/> objects representing the URLs and metadata to include in the sitemap.</param>
        /// <returns>A string containing the XML representation of the sitemap, formatted according to the sitemap protocol.</returns>
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
