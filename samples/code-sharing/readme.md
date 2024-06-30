# Code Sharing

# RCL Razor Class Library

*   https://learn.microsoft.com/en-us/aspnet/core/blazor/components/class-libraries

# Sample01

BlazorWeb + MAUI Hyhbrid

-   Beth Massi

*   https://github.com/BethMassi/HybridSharedUI/tree/master

    *   https://github.com/BethMassi/BethTimeUntil

*   https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/maui-blazor-web-app?view=aspnetcore-8.0

*   https://github.com/iceHub82/IceNet.Shared

```bash
dotnet new maui-blazor-web -o Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap
```

dotnet watch \
    --project \
        Sample01.Blazor.MAUI.Hybrid.Web/Sample01.Blazor.MAUI.Hybrid.Web.Web/Sample01.Blazor.MAUI.Hybrid.Web.Web.csproj


```bash
dotnet new maui-blazor-web -o Sample02.Blazor.MAUI.Hybrid.Web.FluentUI
```

## Aspire for Testing/Debugging

```
dotnet new aspire -o Sample.AppAspire
```

```
dotnet sln \
    Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap/Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.sln  \
    add \
        --solution-folder Sample.AppAspire \
        Sample.AppAspire/Sample.AppAspire.AppHost/Sample.AppAspire.AppHost.csproj \
        Sample.AppAspire/Sample.AppAspire.ServiceDefaults/Sample.AppAspire.ServiceDefaults.csproj \
```

```
dotnet add \
    Sample.AppAspire/Sample.AppAspire.AppHost/Sample.AppAspire.AppHost.csproj \
        reference \
            Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap/Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.Web/Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.Web.csproj
```

Adding MAUI project will not work

```
dotnet add \
    Sample.AppAspire/Sample.AppAspire.AppHost/Sample.AppAspire.AppHost.csproj \
        reference \
            Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap/Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap/Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.csproj

```


## Fluent UI

*   https://www.fluentui-blazor.net/

*   https://www.nuget.org/packages/Microsoft.FluentUI.AspNetCore.Components/

    ```xml
    <ItemGroup>
        <PackageReference Include="Microsoft.FluentUI.AspNetCore.Components" Version="4.8.0" />
    </ItemGroup>
    ```

```bash
dotnet new maui-blazor-web -o Sample02.Blazor.MAUI.Hybrid.Web.FluentUI
```

*   https://medium.com/medialesson/building-a-data-driven-appwith-blazor-and-fluent-ui-85b6f1cfc818

## Aspire

```
dotnet sln \
    Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.sln  \
    add \
        --solution-folder Sample.AppAspire \
        Sample.AppAspire/Sample.AppAspire.AppHost/Sample.AppAspire.AppHost.csproj \
        Sample.AppAspire/Sample.AppAspire.ServiceDefaults/Sample.AppAspire.ServiceDefaults.csproj \
```

```
dotnet add \
    Sample.AppAspire/Sample.AppAspire.AppHost/Sample.AppAspire.AppHost.csproj \
        reference \
            Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Web/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Web.csproj
```

Adding MAUI project will not work

```
dotnet add \
    Sample.AppAspire/Sample.AppAspire.AppHost/Sample.AppAspire.AppHost.csproj \
        reference \
            Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap/Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap/Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.csproj

```

FluentUI

```
dotnet add \
    Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.csproj \
        package \
            Microsoft.FluentUI.AspNetCore.Components

dotnet add \
    Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Web/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Web.csproj \
        package \
            Microsoft.FluentUI.AspNetCore.Components

dotnet add \
    Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.csproj \
        package \
            Microsoft.FluentUI.AspNetCore.Components.Icons

dotnet add \
    Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Web/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Web.csproj \
        package \
            Microsoft.FluentUI.AspNetCore.Components.Icons

dotnet add \
    Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.csproj \
        package \
            Microsoft.FluentUI.AspNetCore.Components.Emoji

dotnet add \
    Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Web/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Web.csproj \
        package \
            Microsoft.FluentUI.AspNetCore.Components.Emoji
```


```
dotnet add \
    Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI/Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.csproj \
        package \
            Microsoft.FluentUI.AspNetCore.Components
```


### Scripts

These components are implemented in a script file which is included in the library itself and does 
not have to be downloaded or pulled from a CDN.

*   depending on type of project script needs to be added to your 

    *   `index.html` or 

    *   `App.razor` 

*   if SSR used,

    *   need to include the web components script. 
    
        As there is no Blazor script being loaded/used, our script will also not get loaded.

### Styles

In order for this library to work as expected, you will need to add the composed scoped CSS file 
for the components. This can be done by adding the following line to the <head> section of your 

    index.html, 
    _Layout.cshtml or 
    App.razor 
    
<link rel="stylesheet" href="{PROJECT_NAME}.styles.css" />

Reboot
Reboot is a collection of element-specific CSS changes in a single file to help kickstart building a site with the Fluent UI Blazor components.

<link rel="stylesheet" href="_content/Microsoft.FluentUI.AspNetCore.Components/css/reboot.css" />


### Diverse

*   https://learn.microsoft.com/en-us/fluent-ui/web-components/integrations/blazor

    *   Microsoft.FluentUI.AspNetCore.Templates

        templates blazor fluentui web-assembly

        Project templates for creating a Blazor Web app or Blazor WebAssembly app that uses the Fluent UI Blazor library. 
        These templates can be used for web apps with rich dynamic user interfaces (UIs).

        dotnet new install Microsoft.FluentUI.AspNetCore.Templates

    *   Microsoft.Fast.Templates.FluentUI

        templates blazor fluentui web-components web-assembly

        Project templates for creating a Blazor Server or Blazor WebAssembly app that uses the Fluent UI Web Components 
        for Blazor library. These templates can be used for web apps with rich dynamic user interfaces...

        dotnet new install Microsoft.Fast.Templates.FluentUI


## WASM

dotnet new \
    blazorwasm \
        -o AppBlazor.WASM
dotnet new \
    fluentblazorwasm \
        -o AppBlazor.WASM.Fluent
dotnet new \
    fluentuiblazorwasm \
        -o AppBlazor.WASM.FluentUI
dotnet new \
    wasmbrowser \
        -o AppBlazor.WASM.Browser
dotnet new \
    wasmconsole \
        -o AppBlazor.WASM.Console



