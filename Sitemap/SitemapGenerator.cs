using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace BlazorSitemapper.Sitemap
{
    internal class SitemapGenerator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SitemapGenerator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<SitemapEntry> GenerateSitemapEntries()
        {
            List<SitemapEntry> sitemapEntries = new List<SitemapEntry>();
            HttpContext? httpContext = _httpContextAccessor.HttpContext;

            IEnumerable<Type> componentTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(ComponentBase).IsAssignableFrom(type));

            foreach (Type componentType in componentTypes)
            {
                SitemapUrlAttribute? sitemapAttribute = componentType.GetCustomAttribute<SitemapUrlAttribute>();

                if (sitemapAttribute != null)
                {
                    HostString domain = _httpContextAccessor.HttpContext.Request.Host;
                    // Create a sitemap entry for the component using the current route
                    SitemapEntry entry = new SitemapEntry
                    {
                        Url = domain + sitemapAttribute.Url,
                        LastModified = DateTime.UtcNow,
                        ChangeFrequency = sitemapAttribute.ChangeFreq,
                        Priority = sitemapAttribute.Priority
                    };

                    sitemapEntries.Add(entry);
                }
            }

            return sitemapEntries;
        }
    }
}