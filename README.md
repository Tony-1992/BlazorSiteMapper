BlazorSiteMapper
===========================
[Sitemap](https://en.wikipedia.org/wiki/Sitemaps) generator for Blazor.

# Installation

# Usage

## Annotate your pages

```csharp
@page "/register"
@attribute [SitemapUrl("/register" changeFreq: ChangeFreq.Daily, priority: 1.0)]
```