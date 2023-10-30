BlazorSiteMapper
===========================
[![NuGet version](https://img.shields.io/nuget/vpre/BlazorSiteMapper.svg?&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/BlazorSiteMapper/)
[![NuGet downloads](https://img.shields.io/nuget/dt/BlazorSiteMapper.svg?&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/BlazorSiteMapper) 

[Sitemap](https://en.wikipedia.org/wiki/Sitemaps) generator for Blazor. Please feel free to raise an issue if this does not work and I'll look into it. Thanks.


# Usage
Install Package
```
dotnet add package BlazorSiteMapper
```
Add the following to `Program.cs`
```csharp
using BlazorSiteMapper.Extensions;
```
Add the following to the `Program.cs`
```csharp
builder.Services.RegisterSitemapper();
```
Add the following after the `app.UseRouting();`
```csharp
app.CreateSitemap();
```

Once that is done, you should be able to navigate to `[your-domain]/sitemap.xml` and see a generated xml file with all pages you've annoted.

## Annotate your pages
```csharp
@page "/register"
@attribute [SitemapUrl("/register" changeFreq: ChangeFreq.Daily, priority: 1.0)]
```
