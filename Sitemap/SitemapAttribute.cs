namespace BlazorSitemapper.Sitemap
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class SitemapUrlAttribute : Attribute
    {
        public ChangeFreq ChangeFreq { get; }
        public double Priority { get; }
        public string Url { get; }

        public SitemapUrlAttribute(string url, ChangeFreq changeFreq = ChangeFreq.Daily, double priority = 0.5)
        {
            Url = url;
            ChangeFreq = changeFreq;
            Priority = priority;
        }
    }
}
