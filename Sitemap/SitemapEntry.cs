namespace BlazorSitemapper.Sitemap
{
    /// <summary>
    /// Represents an entry in a sitemap, containing information about a specific URL and its metadata.
    /// </summary>
    /// <remarks>A sitemap entry provides details about a URL, including its last modification date,  the
    /// frequency with which it changes, and its priority relative to other URLs.  This information is typically used by
    /// search engines to optimize crawling and indexing.</remarks>
    internal class SitemapEntry
    {
        public string Url { get; set; }
        public DateTime LastModified { get; set; }
        public ChangeFreq ChangeFrequency { get; set; }
        public double Priority { get; set; }
    }
}
