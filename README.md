# BlazorSiteMapper

[![NuGet version](https://img.shields.io/nuget/vpre/BlazorSiteMapper.svg?&label=nuget%20version&logo=nuget&style=flat-square)](https://www.nuget.org/packages/BlazorSiteMapper/)
[![NuGet downloads](https://img.shields.io/nuget/dt/BlazorSiteMapper.svg?&label=downloads&logo=nuget&style=flat-square)](https://www.nuget.org/packages/BlazorSiteMapper) 

BlazorSiteMapper is a sitemap generator for Blazor applications. It helps search engines understand the structure and update frequency of your site's pages.

## Features
- Easy integration with Blazor applications.
- Automatic sitemap generation.
- Supports setting change frequency and priority for each page.

# Usage
Install Package
```
dotnet add package BlazorSiteMapper
```

Add the following `using` to your `Program.cs`
```csharp
using BlazorSiteMapper.Extensions;
```

Add the following to the `Program.cs`
```csharp
builder.Services.RegisterSitemapper();
```

Add the following to the `Program.cs` above your `app.Run();`
```csharp
app.CreateSitemap();
```

Add the following to the `_Imports.razor`
```razor
@using BlazorSitemapper.Sitemap
```

Once that is done, you should be able to navigate to `[your-domain]/sitemap.xml` and see a generated xml file with all pages you've annoted.

## Annotate your pages (example)
```csharp
@page "/register"
@attribute [SitemapUrl("/register", changeFreq: ChangeFreq.Daily, priority: 1.0)]
```
