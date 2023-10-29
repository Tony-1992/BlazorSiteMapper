namespace BlazorSitemapper.Sitemap
{
    internal class SitemapEntry
    {
        public string Url { get; set; }
        public DateTime LastModified { get; set; }
        public ChangeFreq ChangeFrequency { get; set; }
        public double Priority { get; set; }
    }
}
