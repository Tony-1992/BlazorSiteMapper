namespace BlazorSitemapper.Sitemap
{

    /// <summary>
    /// Attribute to specify metadata for sitemap URLs, used to help search engines 
    /// understand how often a page is updated and its priority relative to other pages.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class SitemapUrlAttribute : Attribute
    {
        public ChangeFreq ChangeFreq { get; }
        public double Priority { get; }
        public string Url { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="SitemapUrlAttribute"/> class.
        /// </summary>
        /// <param name="url">The URL of the page.</param>
        /// <param name="changeFreq">The frequency with which the page is likely to change. Defaults to <see cref="ChangeFreq.Daily"/>.</param>
        /// <param name="priority">The priority of the page relative to other pages on the site. Defaults to 0.5.</param>
        public SitemapUrlAttribute(string url, ChangeFreq changeFreq = ChangeFreq.Daily, double priority = 0.5)
        {
            Url = url;
            ChangeFreq = changeFreq;
            Priority = priority;
        }
    }
}
