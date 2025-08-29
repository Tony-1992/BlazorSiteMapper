using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace BlazorSitemapper.Sitemap
{
    /// <summary>
    /// Generates sitemap entries for components in the application that are decorated with the <see
    /// cref="SitemapUrlAttribute"/>.
    /// </summary>
    /// <remarks>This class scans the entry assembly for components that inherit from <see
    /// cref="ComponentBase"/>  and are annotated with the <see cref="SitemapUrlAttribute"/>. For each matching
    /// component, it creates  a <see cref="SitemapEntry"/> using the URL specified in the attribute and the current
    /// host information.</remarks>
    internal class SitemapGenerator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SitemapGenerator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Generates a list of sitemap entries based on components in the current application.
        /// </summary>
        /// <remarks>This method scans all components in the application's entry assembly that derive from
        /// <see cref="ComponentBase"/> and are decorated with the <see cref="SitemapUrlAttribute"/>. For each matching
        /// component, it creates a <see cref="SitemapEntry"/> using the URL and metadata specified in the attribute,
        /// along with the current host information.</remarks>
        /// <returns>A list of <see cref="SitemapEntry"/> objects representing the sitemap entries for the application. The list
        /// will be empty if no components are decorated with the <see cref="SitemapUrlAttribute"/>.</returns>
        public List<SitemapEntry> GenerateSitemapEntries()
        {
            List<SitemapEntry> sitemapEntries = new();
            HttpContext? httpContext = _httpContextAccessor.HttpContext;


            IEnumerable<Type> componentTypes = Assembly.GetEntryAssembly()
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
                        Url = $"https://{domain}{sitemapAttribute.Url}",
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