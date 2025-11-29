# AppSuite Project Structure

readme.md

Code sharing architecture and project structure playground and templates:

*   libraries

    *   Businnes/Domain Logic - Models

    *   UI User Interface

    *   Utilities

        *   Aspire

*   Apps

    *   Client

        *   MAUI

        *   Console

            *   TUI

        *   WASM

        *   TODO:
        
            *   Avalonia

            *   Uno Platform

    *   Server

        *   ASP.net Blazor

            *   Bootstrap

            *   FluentUI

```bash
dotnet \
    workload \
        install \
            wasm-tools \
            wasm-experimental
```

*   https://learn.microsoft.com/en-us/aspnet/core/client-side/dotnet-interop/wasm-browser-app

```bash
dotnet \
    new \
        install \
            Microsoft.NET.Runtime.WebAssembly.Templates
```

```bash
The following template packages will be installed:
   Aspire.ProjectTemplates

Aspire.ProjectTemplates (version 13.0.0) is already installed, it will be replaced with latest version.
Aspire.ProjectTemplates::13.0.0 was successfully uninstalled.
Success: Aspire.ProjectTemplates::13.0.1 installed the following templates:
Template Name                 Short Name                 Language  Tags                                                                      
----------------------------  -------------------------  --------  --------------------------------------------------------------------------
Aspire AppHost                aspire-apphost             [C#]      Common/Aspire/Cloud                                                       
Aspire Empty App              aspire                     [C#]      Common/Aspire/Cloud/Web/Web API/API/Service                               
Aspire Python Starter App     aspire-py-starter          [C#]      Common/Aspire/Cloud/Web/Web API/API/Service/Python/JavaScript             
Aspire Service Defaults       aspire-servicedefaults     [C#]      Common/Aspire/Cloud/Web/Web API/API/Service                               
Aspire Single-File App Host   aspire-apphost-singlefile  [C#]      Common/Aspire/AppHost/SingleFile                                          
Aspire Starter App            aspire-starter             [C#]      Common/Aspire/Blazor/Web/Web API/API/Service/Cloud/Test/MSTest/NUnit/xUnit
Aspire Test Project (MSTest)  aspire-mstest              [C#]      Common/Aspire/Cloud/Web/Web API/API/Service/Test/MSTest                   
Aspire Test Project (NUnit)   aspire-nunit               [C#]      Common/Aspire/Cloud/Web/Web API/API/Service/Test/NUnit                    
Aspire Test Project (xUnit)   aspire-xunit               [C#]      Common/Aspire/Cloud/Web/Web API/API/Service/Test/xUnit                    
```



```bash
dotnet \
    new \
        uninstall \
            Microsoft.FluentUI.AspNetCore.Templatesdotnet
dotnet \
    new \
        install \
            Microsoft.FluentUI.AspNetCore.Templates
```


```bash
The following template packages will be installed:
   Microsoft.FluentUI.AspNetCore.Templates

Success: Microsoft.FluentUI.AspNetCore.Templates::4.13.2 installed the following templates:
Template Name                               Short Name             Language  Tags                                                                                
------------------------------------------  ---------------------  --------  ------------------------------------------------------------------------------------
Fluent .NET MAUI Blazor Hybrid and Web App  fluentmaui-blazor-web  [C#]      MAUI/Android/iOS/macOS/Mac Catalyst/Windows/Tizen/Blazor/Blazor Hybrid/Mobile/Fluent
Fluent Aspire Starter App                   fluentaspire-starter   [C#]      Common/Aspire/Blazor/Web/Web API/API/Service/Cloud/Fluent/Test/MSTest/NUnit/xUnit   
Fluent Blazor Web App                       fluentblazor           [C#]      Web/Fluent/Blazor/WebAssembly                                                       
Fluent Blazor WebAssembly Standalone App    fluentblazorwasm       [C#]      Web/Fluent/Blazor/WebAssembly/PWA                                                   
```

*   https://aspire.dev/testing/write-your-first-test/?testing-framework=xunit

*   How To Create a Progressive Web App with Blazor WebAssembly

    *   https://www.youtube.com/watch?v=Ph9ReSnyGJc

*   Blazor Progressive Web Apps. Part 1 - The Basics.

    *   https://www.youtube.com/watch?v=-aLbUderrus

    *   https://github.com/JasperKent/Basic-PWA-Demo

*   How to convert .NET 8 Blazor WebAssembly App to PWA (Progressive Web Application)

    *   https://www.youtube.com/watch?v=BdVJXP1nDU4