#!/usr/local/share/dotnet/dotnet run

#:sdk Cake.Sdk@6.0.0

#:property langVersion=latest

#:package Cake.FileHelpers@7.0.0

using System;

/*
*   https://www.devlead.se/posts/2025/2025-07-28-migrating-to-cake-sdk

*   https://www.reddit.com/r/dotnet/comments/1mbsh0y/modernizing_cake_build_scripts_with_the_new_sdk/

*   https://cakebuild.net/blog/2025/07/dotnet-cake-cs    

*   GitHub Actions DevOps Pipelines as Code using C# and Cake SDK
    
    *   https://www.youtube.com/watch?v=e7hkKyQEcN8
    
    *   https://github.com/azurevoodoo/dotnetconf2025

*   https://cakebuild.net/dsl/process/

*   https://cakebuild.net/api/Cake.Common/ProcessAliases/34E38D20
*/


string[] architecture_folders =
                            [
                                "source-libraries",
                                "samples",
                                "docs",
                                "tests",
                                "samples/apps",
                                "tests/common",
                                "tests/unit-tests",
                                "tests/benchmark-tests",
                            ];

string[] project_folders =  
                            [
                                "App_Web_ASP_net__Blazor",
                                "App__MAUI_Blazor",
                                "App__MAUI",
                                "AppSuite__MAUI_Blazor_Web",
                                "App__Web_WASM_Browser",
                                "App__Web_WASM_Console",
                                "AppMobileBlazorBindings",
                                "AppBlazorHybrid",
                            ];

foreach (string project_folder in project_folders)
{
    Information($"Project Folder: {project_folder}");

    if (DirectoryExists(project_folder))
    {
        Information($"  Deleting");
        DeleteDirectory
            (
                project_folder, 
                new DeleteDirectorySettings 
                {
                    Recursive = true,
                    Force = true
                }
            );
    }
}

foreach (string architecture_folder in architecture_folders)
{
    Information($"Architecture Folder: {architecture_folder}");
    if (DirectoryExists(architecture_folder))
    {
        Information($"  Deleting");
        DeleteDirectory
            (
                architecture_folder, 
                new DeleteDirectorySettings 
                {
                    Recursive = true,
                    Force = true
                }
            );
    }

    Information($"  Creating");
    CreateDirectory(architecture_folder);
}

DeleteFiles("./AppSuite.sln*");

string[] project_args_list =
                            [
                                """
                                new \
                                    blazor \
                                        --output App_Web_ASP_net__Blazor
                                """,
                                """
                                new \
                                    maui-blazor-web \
                                        --InteractivityPlatform Auto \
                                        --output AppSuite__MAUI_Blazor_Web
                                """,
                                """
                                new \
                                    wasmbrowser \
                                        --output App__Web_WASM_Browser
                                """,
                                """
                                new \
                                    wasmconsole \
                                        --output App__Web_WASM_Console
                                """,                                
                                """
                                new \
                                    maui-blazor \
                                        --output App__MAUI_Blazor
                                """,
                                """
                                new \
                                    maui \
                                        --output App__MAUI
                                """,
                                """
                                new \
                                    sln \
                                        --name AppSuite
                                """,
                                """
                                sln \
                                    migrate \
                                        AppSuite.sln
                                """,
                            ];

foreach (string project_args_item in project_args_list)
{
    IEnumerable<string> redirectedStandardOutput;
    IEnumerable<string> redirectedErrorOutput;
    var exitCodeWithArgument = StartProcess
                                    (
                                        "dotnet",
                                        new ProcessSettings 
                                        {
                                            Arguments = project_args_item
                                                        .Replace(@"\", " ")
                                                        .Replace(System.Environment.NewLine, " ")
                                                        ,
                                            RedirectStandardOutput = true,
                                            RedirectStandardError = true
                                        },
                                        out redirectedStandardOutput,
                                        out redirectedErrorOutput
                                    );

    // Output last line of process output.
    Information("Last line of output: {0}", string.Join(Environment.NewLine, redirectedStandardOutput));

    // Throw exception if anything was written to the standard error.
    if (redirectedErrorOutput.Any())
    {
        throw new Exception
                        (
                            string.Format
                                (
                                    "Errors occurred: {0}",
                                    string.Join(Environment.NewLine, redirectedErrorOutput)
                                )
                        );
    }

    // This should output 0 as valid arguments supplied
    Information("Exit code: {0}", exitCodeWithArgument);
}

return;

project_args_list =
                            [
                                """
                                reference \
                                    remove \
                                        --project
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.csproj \
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj \
                                """,
                                """
                                reference \
                                    remove \
                                        --project
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web/AppSuite__MAUI_Blazor_Web.Web.csproj \
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/AppSuite__MAUI_Blazor_Web.Web.Client.csproj \
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj \
                                """,
                                """
                                reference \
                                    remove \
                                        --project
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/AppSuite__MAUI_Blazor_Web.Web.Client.csproj \
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj \
                                """,
                            ];

foreach (string project_args_item in project_args_list)
{
    IEnumerable<string> redirectedStandardOutput;
    IEnumerable<string> redirectedErrorOutput;
    var exitCodeWithArgument = StartProcess
                                    (
                                        "dotnet",
                                        new ProcessSettings 
                                        {
                                            Arguments = project_args_item
                                                        .Replace(@"\", " ")
                                                        .Replace(System.Environment.NewLine, " ")
                                                        ,
                                            RedirectStandardOutput = true,
                                            RedirectStandardError = true
                                        },
                                        out redirectedStandardOutput,
                                        out redirectedErrorOutput
                                    );

    // Output last line of process output.
    Information("Last line of output: {0}", string.Join(Environment.NewLine, redirectedStandardOutput));

    // Throw exception if anything was written to the standard error.
    if (redirectedErrorOutput.Any())
    {
        throw new Exception
                        (
                            string.Format
                                (
                                    "Errors occurred: {0}",
                                    string.Join(Environment.NewLine, redirectedErrorOutput)
                                )
                        );
    }

    // This should output 0 as valid arguments supplied
    Information("Exit code: {0}", exitCodeWithArgument);
}



(string, string, string, string)[] architecture_folders_locations =
                                [
                                    (
                                        "./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/",
                                        "source-libraries/Library.RazorComponents.Shared/",
                                        "source-libraries/Library.RazorComponents.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj",
                                        "source-libraries/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj"
                                    ),
                                    (
                                        "./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/",
                                        "samples/apps/AppSuite__MAUI_Blazor_Web.Web.Client/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web/",
                                        "samples/apps/AppSuite__MAUI_Blazor_Web.Web/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web/",
                                        "samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/",
                                        "samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/AppSuite__MAUI_Blazor_Web.csproj",
                                        "samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/AppSuite__MAUI_Blazor_Web.MAUI.csproj"
                                    ),
                                    (
                                        "./App__MAUI_Blazor/",
                                        "samples/apps/App__MAUI_Blazor/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./App__MAUI/",
                                        "samples/apps/App__MAUI/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./App_Web_ASP_net__Blazor/",
                                        "samples/apps/App_Web_ASP_net__Blazor/",
                                        "",
                                        ""
                                    ),
                                ];

foreach((string, string, string,string) t in architecture_folders_locations)
{
    if (DirectoryExists(t.Item2))
    {
        DeleteDirectory
            (
                t.Item2, 
                new DeleteDirectorySettings 
                {
                    Recursive = true,
                    Force = true
                }
            );
    }
    MoveDirectory(t.Item1, t.Item2);

    if (t.Item3 == "" || t.Item4=="")
    {
        continue;
    }
    MoveFile(t.Item3, t.Item4);
}
DeleteDirectory
            (
                "AppSuite__MAUI_Blazor_Web/", 
                new DeleteDirectorySettings 
                {
                    Recursive = true,
                    Force = true
                }
            );

/*
https://raw.githubusercontent.com/github/gitignore/refs/heads/main/VisualStudio.gitignore
*/

project_args_list =
                            [
                                """
                                sln \
                                    AppSuite.slnx \
                                    add \
                                        --solution-folder source-libraries \
                                            ./source-libraries/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj \
                                """,
                                """
                                sln \
                                    AppSuite.slnx \
                                    add \
                                        --solution-folder samples/apps \
                                            ./samples/apps/App__MAUI/App__MAUI.csproj \
                                            ./samples/apps/App__MAUI_Blazor/App__MAUI_Blazor.csproj \
                                            ./samples/apps/App_Web_ASP_net__Blazor/App_Web_ASP_net__Blazor.csproj \
                                            ./samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/AppSuite__MAUI_Blazor_Web.MAUI.csproj \
                                            ./samples/apps/AppSuite__MAUI_Blazor_Web.Web/AppSuite__MAUI_Blazor_Web.Web.csproj \
                                            ./samples/apps/AppSuite__MAUI_Blazor_Web.Web.Client/AppSuite__MAUI_Blazor_Web.Web.Client.csproj \
                                """,
                                """
                                reference \
                                    add \
                                        ./source-libraries/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj \
                                        ./samples/apps/AppSuite__MAUI_Blazor_Web.Web.Client/AppSuite__MAUI_Blazor_Web.Web.Client.csproj \
                                        --project \
                                            ./samples/apps/AppSuite__MAUI_Blazor_Web.Web/AppSuite__MAUI_Blazor_Web.Web.csproj \
                                """,
                                """
                                reference \
                                    add \
                                        ./source-libraries/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj \
                                        --project \
                                        ./samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/AppSuite__MAUI_Blazor_Web.MAUI.csproj \
                                """,
                                """
                                reference \
                                    add \
                                        ./source-libraries/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj \
                                        --project \
                                        ./samples/apps/AppSuite__MAUI_Blazor_Web.Web.Client/AppSuite__MAUI_Blazor_Web.Web.Client.csproj \
                                """,
                                """
                                new \
                                    classlib \
                                    --output \
                                        tests/common/Tests.Common
                                """,
                                """
                                reference \
                                    add \
                                        ./source-libraries/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj \
                                        --project \
                                        tests/common/Tests.Common
                                """,
                                """
                                new \
                                    nunit \
                                    --output \
                                        tests/unit-tests/Runner.NUnit
                                """,
                                """
                                reference \
                                    add \
                                        tests/common/Tests.Common \
                                        --project \
                                        tests/unit-tests/Runner.NUnit
                                """,
                                """
                                new \
                                    mstest \
                                    --output \
                                        tests/unit-tests/Runner.MSTest
                                """,
                                """
                                reference \
                                    add \
                                        tests/common/Tests.Common \
                                        --project \
                                        tests/unit-tests/Runner.MSTest \
                                """,
                                """
                                new \
                                    xunit \
                                    --output \
                                        tests/unit-tests/Runner.XUnit \
                                """,
                                """
                                reference \
                                    add \
                                        tests/common/Tests.Common \
                                        --project \
                                        tests/unit-tests/Runner.MSTest \
                                """,
                                """
                                reference \
                                    add \
                                        ./source-libraries/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj \
                                        --project \
                                        tests/unit-tests/Runner.NUnit \
                                """,
                                """
                                new \
                                    console \
                                    --output \
                                        tests/unit-tests/Runner.TUnit
                                """,
                                """
                                new \
                                    console \
                                    --output \
                                        tests/benchmark-tests/Runner.BenchmarkDotNet \
                                """,
                                """
                                package \
                                    add \
                                        BenchmarkDotNet \
                                    --project \
                                        tests/benchmark-tests/Runner.BenchmarkDotNet/Runner.BenchmarkDotNet.csproj \
                                """,
                                """
                                package \
                                    add \
                                        TUnit \
                                        --prerelease \
                                    --project \
                                        tests/unit-tests/Runner.TUnit/ \
                                """,
                                """
                                sln \
                                    AppSuite.slnx \
                                    add \
                                        --solution-folder \
                                            tests/common/ \
                                            tests/common/Tests.Common \
                                """,
                                """
                                sln \
                                    AppSuite.slnx \
                                    add \
                                        --solution-folder \
                                            tests/unit-tests/ \
                                            tests/unit-tests/Runner.TUnit \
                                """,
                                """
                                sln \
                                    AppSuite.slnx \
                                    add \
                                        --solution-folder \
                                            tests/unit-tests/ \
                                            tests/unit-tests/Runner.NUnit \
                                """,
                                """
                                sln \
                                    AppSuite.slnx \
                                    add \
                                        --solution-folder \
                                            tests/unit-tests/ \
                                            tests/unit-tests/Runner.XUnit \
                                """,
                                """
                                sln \
                                    AppSuite.slnx \
                                    add \
                                        --solution-folder \
                                            tests/unit-tests/ \
                                            tests/unit-tests/Runner.MSTest \
                                """,
                                """
                                sln \
                                    AppSuite.slnx \
                                    add \
                                        --solution-folder \
                                            tests/benchmark-tests/ \
                                            tests/benchmark-tests/Runner.BenchmarkDotNet \
                                """,
                                """
                                reference \
                                    add \
                                        ./source-libraries/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj \
                                        --project \
                                            tests/benchmark-tests/Runner.BenchmarkDotNet \
                                """,
                                """
                                reference \
                                    add \
                                        ./source-libraries/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj \
                                        --project \
                                            tests/unit-tests/Runner.MSTest \
                                """,
                            ];

foreach (string project_args_item in project_args_list)
{
    IEnumerable<string> redirectedStandardOutput;
    IEnumerable<string> redirectedErrorOutput;
    var exitCodeWithArgument = StartProcess
                                    (
                                        "dotnet",
                                        new ProcessSettings 
                                        {
                                            Arguments = project_args_item
                                                        .Replace(@"\", " ")
                                                        .Replace(System.Environment.NewLine, " ")
                                                        ,
                                            RedirectStandardOutput = true,
                                            RedirectStandardError = true
                                        },
                                        out redirectedStandardOutput,
                                        out redirectedErrorOutput
                                    );

    // Output last line of process output.
    Information("Last line of output: {0}", string.Join(Environment.NewLine, redirectedStandardOutput));

    // Throw exception if anything was written to the standard error.
    if (redirectedErrorOutput.Any())
    {
        throw new Exception
                        (
                            string.Format
                                (
                                    "Errors occurred: {0}",
                                    string.Join(Environment.NewLine, redirectedErrorOutput)
                                )
                        );
    }

    // This should output 0 as valid arguments supplied
    Information("Exit code: {0}", exitCodeWithArgument);
}

(string, string, string, string)[]  
    project_fixes_for_templates =
                [
                    (
                        "./samples/apps/",
                        "*.csproj",
                        "<TargetFramework>net9.0</TargetFramework>",
                        "<TargetFramework>net10.0</TargetFramework>"
                    ),  
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "AppSuite__MAUI_Blazor_Web.MAUI.csproj",
                        """<TargetFrameworks>net9.0-android;net9.0-ios;net9.0-maccatalyst</TargetFrameworks>""",
                        """<TargetFrameworks>net10.0-android;net10.0-ios;net10.0-maccatalyst</TargetFrameworks>"""
                    ),  
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "AppSuite__MAUI_Blazor_Web.MAUI.csproj",
                        """<TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net9.0-windows10.0.19041.0</TargetFrameworks>""",
                        """<TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net10.0-windows10.0.19041.0</TargetFrameworks>"""
                    ),
                    (
                        "./source-libraries/Library.RazorComponents.Shared/",
                        "*.cs",
                        "AppSuite__MAUI_Blazor_Web",
                        "Library.RazorComponents"
                    ),
                    (
                        "./source-libraries/Library.RazorComponents.Shared/",
                        "*.razor",
                        "AppSuite__MAUI_Blazor_Web",
                        "Library.RazorComponents"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "*.cs",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "*.xaml",
                        "AppSuite__MAUI_Blazor_Web.Shared",
                        "Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "*.razor",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.Web/",
                        "*.razor",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.Web/",
                        "*.cs",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.Web/",
                        "Program.cs",
                        "AppSuite__MAUI_Blazor_Web.Shared._Imports",
                        "Library.RazorComponents.Shared._Imports"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.Web/",
                        "App.razor",
                        "_content/AppSuite__MAUI_Blazor_Web.Shared",
                        "_content/Library.RazorComponents.Shared"
                    ),                    
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.Web.Client/",
                        "*.razor",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web.Web.Client/",
                        "*.cs",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                ];

foreach((string, string, string, string) t in project_fixes_for_templates)
{
    foreach(string f in System.IO.Directory.GetFiles(t.Item1, t.Item2, SearchOption.AllDirectories))
    {
        Information($"Replacing text in");
        Information($"      Folder:     {t.Item1}");
        Information($"      Pattern:    {t.Item2}");
        Information($"      old:        {t.Item3}");
        Information($"      new:        {t.Item4}");
        Information($"      f:          {f}");
        ReplaceTextInFiles(f, t.Item3, t.Item4);
    }
}

StartProcess("open", "AppSuite.slnx");
