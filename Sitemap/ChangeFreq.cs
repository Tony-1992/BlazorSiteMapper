namespace BlazorSitemapper.Sitemap
{
    /// <summary>
    /// Specifies the frequency with which a page is likely to change. 
    /// Used in sitemaps to help search engines understand how often a page's content is updated.
    /// </summary>
    public enum ChangeFreq
    {
        /// <summary>
        /// The page is updated every time it is accessed. This should be used only if the content changes every time the page is loaded.
        /// <para>Example: A page displaying real-time stock market data.</para>
        /// </summary>
        Always,

        /// <summary>
        /// The page is updated every hour. Use this for pages that have content updated on an hourly basis.
        /// <para>Example: A news portal's homepage which aggregates the latest news every hour.</para>
        /// </summary>
        Hourly,

        /// <summary>
        /// The page is updated every day. Suitable for pages with daily updates.
        /// <para>Example: A blog that publishes a new post daily.</para>
        /// </summary>
        Daily,

        /// <summary>
        /// The page is updated every week. Best for pages that have weekly content updates.
        /// <para>Example: A website section featuring a weekly newsletter or column.</para>
        /// </summary>
        Weekly,

        /// <summary>
        /// The page is updated every month. Use this for pages with monthly updates.
        /// <para>Example: An events calendar that is updated monthly with upcoming events.</para>
        /// </summary>
        Monthly,

        /// <summary>
        /// The page is updated every year. Suitable for pages that change annually.
        /// <para>Example: A yearly report or review page, such as a "Year in Review" article.</para>
        /// </summary>
        Yearly,

        /// <summary>
        /// The page is never updated. Use this for pages that do not change once published.
        /// <para>Example: An archived news article or a historical document.</para>
        /// </summary>
        Never
    }
}
