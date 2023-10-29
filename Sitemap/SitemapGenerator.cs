using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace BlazorSitemapper.Sitemap
{
    internal class SitemapGenerator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SitemapGenerator(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {
            _serviceProvider = serviceProvider;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<SitemapEntry> GenerateSitemapEntries()
        {
            var sitemapEntries = new List<SitemapEntry>();

            var httpContext = _httpContextAccessor.HttpContext;

            var componentTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(ComponentBase).IsAssignableFrom(type));

            foreach (var componentType in componentTypes)
            {
                var sitemapAttribute = componentType.GetCustomAttribute<SitemapUrlAttribute>();

                if (sitemapAttribute != null)
                {
                    var domain = _httpContextAccessor.HttpContext.Request.Host;
                    // Create a sitemap entry for the component using the current route
                    var entry = new SitemapEntry
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
