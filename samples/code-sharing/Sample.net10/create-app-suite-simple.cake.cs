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

string[] project_files =
                            [
                                "Directory.Build.*",
                                "Directory.Packages.*",
                            ];

foreach (string s in project_files)
{
    DeleteFiles($"./**/{s}");
    
}

string[] architecture_folders =
                            [
                                "source-libraries",
                                "source-libraries/business-domain-logic-models/",
                                "source-libraries/ui-user-interface/",
                                "source-libraries/utilities/",
                                "samples",
                                "docs",
                                "source-libraries/business-domain-logic-models/",
                                "source-libraries/ui-user-interface/",
                                "source-libraries/utilities/",
                                "tests",
                                "samples/apps",
                                "tests/common",
                                "tests/unit-tests",
                                "tests/unit-tests/business-domain-logic-models/",
                                "tests/unit-tests/ui-user-interface/",
                                "tests/unit-tests/utilities/",
                                "tests/benchmark-tests",
                                "tests/benchmark-tests/business-domain-logic-models/",
                                "tests/benchmark-tests/ui-user-interface/",
                                "tests/benchmark-tests/utilities/",
                            ];

string[] project_folders =
                            [
                                "App__MAUI",
                                "App__MAUI_Blazor",
                                "App_Web_ASP_net__Blazor",
                                "App_Web_ASP_net__Blazor_FluentUI",
                                "App_Web_ASP_net__BlazorWASM",
                                "App_Web_ASP_net__BlazorWASM_FluentUI",
                                "App_Web_ASP_net__BlazorWASM_PWA_FluentUI",
                                "AppAspire_Web_ASP_net__Blazor_FluentUI",
                                "AppAspire_Web_ASP_net__MAUI_Blazor_FluentUI",
                                "AppAspire.AppHost",
                                "AppAspire.AppHost.SingleFile",
                                "AppSuite__MAUI_Blazor_Web",
                                "App__Web_WASM_Browser",
                                "App__Web_WASM_Console",
                                "AppSuite__MAUI_Blazor_Web",
                                "AppMobileBlazorBindings",
                                "AppBlazorHybrid",
                                "Library.AspireServiceDefaults",
                                "RunnerTestsAspire.MSTest",
                                "RunnerTestsAspire.XUnit",
                                "RunnerTestsAspire.NUnit",
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
                                    classlib \
                                    --output \
                                        ./source-libraries/business-domain-logic-models/HolisticWare.BusinessDomainLogicModels
                                """,
                                """
                                new \
                                    mauilib \
                                    --output \
                                        ./source-libraries/ui-user-interface/HolisticWare.BusinessDomainLogicModels.UserInterface.MAUI
                                """,
                                """
                                new \
                                    razorclasslib \
                                    --output \
                                        ./source-libraries/ui-user-interface/HolisticWare.BusinessDomainLogicModels.UserInterface.Blazor.Razor
                                """,
                                """
                                new \
                                    maui \
                                        --output \
                                            ./samples/apps/App__MAUI
                                """,
                                """
                                new \
                                    maui-blazor \
                                        --output \
                                            ./samples/apps/App__MAUI_Blazor
                                """,
                                """
                                new \
                                    blazor \
                                        --output \
                                            ./samples/apps/App_Web_ASP_net__Blazor
                                """,
                                """
                                new \
                                    blazorwasm \
                                        --output \
                                            ./samples/apps/App_Web_ASP_net__BlazorWASM
                                """,
                                """
                                new \
                                    maui-blazor-web \
                                        --InteractivityPlatform Auto \
                                        --output \
                                            ./samples/apps/AppSuite__MAUI_Blazor_Web
                                """,
                                """
                                new \
                                    fluentblazor \
                                        --output \
                                            ./samples/apps/App_Web_ASP_net__Blazor_FluentUI \
                                """,
                                """
                                new \
                                    fluentblazorwasm \
                                        --output \
                                            ./samples/apps/App_Web_ASP_net__BlazorWASM_FluentUI
                                """,
                                """
                                new \
                                    fluentblazorwasm \
                                        --output \
                                            ./samples/apps/App_Web_ASP_net__BlazorWASM_PWA_FluentUI \
                                        --pwa
                                """,
                                """
                                new \
                                    fluentmaui-blazor-web \
                                        --output \
                                            ./samples/apps/AppAspire_Web_ASP_net__MAUI_Blazor_FluentUI
                                """,
                                """
                                new \
                                    fluentaspire-starter \
                                        --output \
                                            ./samples/apps/AppAspire_Web_ASP_net__Blazor_FluentUI
                                """,
                                """
                                new \
                                    aspire-servicedefaults \
                                        --output \
                                            ./source-libraries/utilities/Library.AspireServiceDefaults
                                """,
                                """
                                new \
                                    aspire-apphost \
                                        --output \
                                            ./samples/apps/AppAspire.AppHost
                                """,
                                """
                                new \
                                    aspire-apphost-singlefile \
                                        --output \
                                            ./samples/apps/AppAspire.AppHost.SingleFile
                                """,
                                """
                                new \
                                    aspire-mstest \
                                        --output \
                                            ./tests/unit-tests/utilities/RunnerTestsAspire.MSTest
                                """,
                                """
                                new \
                                    aspire-xunit \
                                        --output \
                                            ./tests/unit-tests/utilities/RunnerTestsAspire.XUnit
                                """,
                                """
                                new \
                                    aspire-nunit \
                                        --output \
                                            ./tests/unit-tests/utilities/RunnerTestsAspire.NUnit
                                """,
                                /*
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
                                */
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
    StartProcessDotnet
                    (
                        project_args_item
                            .Replace(@"\", " ")
                            .Replace(System.Environment.NewLine, " ")
                    );
}

Information("References to be removed");

project_args_list =
                [
                    """
                    reference \
                        remove \
                                ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj \
                            --project
                                ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.csproj \
                    """,
                    """
                    reference \
                        remove \
                                ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj \
                            --project
                                ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web/AppSuite__MAUI_Blazor_Web.Web.csproj \
                    """,
                    """
                    reference \
                        remove \
                                ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj \
                            --project
                                ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/AppSuite__MAUI_Blazor_Web.Web.Client.csproj \
                    """,
                    """
                    reference \
                        remove \
                                ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj \
                            --project
                                ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/ \
                    """,
                    /*
                    */
                ];

foreach (string project_args_item in project_args_list)
{
    StartProcessDotnet
                    (
                        project_args_item
                            .Replace(@"\", " ")
                            .Replace(System.Environment.NewLine, " ")
                    );
}

Information("References     removed");

(string, string, string, string)[] architecture_folders_locations =
                                [
                                    (
                                        // folder old
                                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/",
                                        // folder new
                                        "source-libraries/ui-user-interface/Library.RazorComponents.Shared/",
                                        // file old
                                        "source-libraries/ui-user-interface/Library.RazorComponents.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj",
                                        // file new
                                        "source-libraries/ui-user-interface/Library.RazorComponents.Shared/Library.RazorComponents.Shared.csproj"
                                    ),
                                    (
                                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web/",
                                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI/",
                                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI/AppSuite__MAUI_Blazor_Web.csproj",
                                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI/AppSuite__MAUI_Blazor_Web.MAUI.csproj"
                                    ),
                                    // (
                                    //     "./Library.AspireServiceDefaults/",
                                    //     "source-libraries/utilities/Library.AspireServiceDefaults/",
                                    //     "source-libraries/utilities/Library.AspireServiceDefaults/Library.AspireServiceDefaults.csproj",
                                    //     "source-libraries/utilities/Library.AspireServiceDefaults/Library.AspireServiceDefaults.csproj"
                                    // ),
                                    /*
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
                                    (
                                        "./App_Web_ASP_net__BlazorWASM/",
                                        "samples/apps/App_Web_ASP_net__BlazorWASM/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./App_Web_ASP_net__Blazor_FluentUI/",
                                        "samples/apps/App_Web_ASP_net__Blazor_FluentUI/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./App_Web_ASP_net__BlazorWASM_FluentUI/",
                                        "samples/apps/App_Web_ASP_net__BlazorWASM_FluentUI/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./App_Web_ASP_net__BlazorWASM_PWA_FluentUI/",
                                        "samples/apps/App_Web_ASP_net__BlazorWASM_PWA_FluentUI/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./AppAspire_Web_ASP_net__Blazor_FluentUI/",
                                        "samples/apps/AppAspire_Web_ASP_net__Blazor_FluentUI/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./AppAspire_Web_ASP_net__MAUI_Blazor_FluentUI/",
                                        "samples/apps/AppAspire_Web_ASP_net__MAUI_Blazor_FluentUI/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./AppAspire.AppHost/",
                                        "samples/apps/AppAspire.AppHost/",
                                        "",
                                        ""
                                    ),
                                    (
                                        "./AppAspire.AppHost.SingleFile/",
                                        "samples/apps/AppAspire.AppHostSingleFile/",
                                        "",
                                        ""
                                    ),                                    
                                    */
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

/*
https://raw.githubusercontent.com/github/gitignore/refs/heads/main/VisualStudio.gitignore
*/


(string, string, string, string)[]
    project_fixes_for_templates_replacements =
                [
                    (
                        "./",
                        "*.csproj",
                        "<TargetFramework>net9.0</TargetFramework>",
                        "<TargetFramework>net10.0</TargetFramework>"
                    ),
                    (
                        "./source-libraries/business-domain-logic-models/",
                        "*.csproj",
                        "<TargetFramework>net10.0</TargetFramework>",
                        "<TargetFrameworks>netstandard2.0;netstandard2.1;net9.0;net10.0</TargetFrameworks>"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "AppSuite__MAUI_Blazor_Web.MAUI.csproj",
                        """<TargetFrameworks>net9.0-android;net9.0-ios;net9.0-maccatalyst</TargetFrameworks>""",
                        """<TargetFrameworks>net10.0-android;net10.0-ios;net10.0-maccatalyst</TargetFrameworks>"""
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "AppSuite__MAUI_Blazor_Web.MAUI.csproj",
                        """<TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net9.0-windows10.0.19041.0</TargetFrameworks>""",
                        """<TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net10.0-windows10.0.19041.0</TargetFrameworks>"""
                    ),
                    (
                        "./source-libraries/ui-user-interface/Library.RazorComponents.Shared/",
                        "*.cs",
                        "AppSuite__MAUI_Blazor_Web",
                        "Library.RazorComponents"
                    ),
                    (
                        "./source-libraries/ui-user-interface/Library.RazorComponents.Shared/",
                        "*.razor",
                        "AppSuite__MAUI_Blazor_Web",
                        "Library.RazorComponents"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "*.cs",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "*.xaml",
                        "AppSuite__MAUI_Blazor_Web.Shared",
                        "Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI/",
                        "*.razor",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web/",
                        "*.razor",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web/",
                        "*.cs",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web/",
                        "Program.cs",
                        "AppSuite__MAUI_Blazor_Web.Shared._Imports",
                        "Library.RazorComponents.Shared._Imports"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web/",
                        "App.razor",
                        "_content/AppSuite__MAUI_Blazor_Web.Shared",
                        "_content/Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/",
                        "*.razor",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                    (
                        "./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/",
                        "*.cs",
                        "using AppSuite__MAUI_Blazor_Web.Shared",
                        "using Library.RazorComponents.Shared"
                    ),
                ];

foreach((string, string, string, string) t in project_fixes_for_templates_replacements)
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

project_args_list =
                [
                    // new
                    //--------------------------------------------------------------------------------------------------
                    // ui-user-interface
                    //--------------------------------------------------------------------------------------------------
                    // unit-tests
                    """
                    new \
                        classlib \
                        --output \
                            tests/common/business-domain-logic-models/Tests.Common
                    """,
                    """
                    new \
                        classlib \
                        --output \
                            tests/common/ui-user-interface/Tests.Common
                    """,
                    """
                    new \
                        nunit \
                        --output \
                            tests/unit-tests/business-domain-logic-models/RunnerTests.NUnit
                    """,
                    """
                    new \
                        nunit \
                        --output \
                            tests/unit-tests/ui-user-interface/RunnerTests.NUnit
                    """,
                    """
                    new \
                        mstest \
                        --output \
                            tests/unit-tests/business-domain-logic-models/RunnerTests.MSTest
                    """,
                    """
                    new \
                        mstest \
                        --output \
                            tests/unit-tests/ui-user-interface/RunnerTests.MSTest
                    """,
                    """
                    new \
                        xunit \
                        --output \
                            tests/unit-tests/business-domain-logic-models/RunnerTests.XUnit \
                    """,
                    """
                    new \
                        console \
                        --output \
                            tests/unit-tests/business-domain-logic-models/RunnerTests.TUnit
                    """,
                    """
                    new \
                        console \
                        --output \
                            tests/unit-tests/ui-user-interface/RunnerTests.TUnit
                    """,
                    //--------------------------------------------------------------------------------------------------
                    // benchmark-tests
                    """
                    new \
                        console \
                        --output \
                            tests/benchmark-tests/business-domain-logic-models/RunnerTests.BenchmarkDotNet \
                    """,
                    """
                    new \
                        console \
                        --output \
                            tests/benchmark-tests/ui-user-interface/RunnerTests.BenchmarkDotNet \
                    """,
                ];

foreach (string project_args_item in project_args_list)
{
    StartProcessDotnet
                    (
                        project_args_item
                            .Replace(@"\", " ")
                            .Replace(System.Environment.NewLine, " ")
                    );
}

project_args_list =
                [
                    // reference add
                    //--------------------------------------------------------------------------------------------------
                    // ui-user-interface
                    """
                    reference \
                        add \
                            ./source-libraries/business-domain-logic-models/HolisticWare.BusinessDomainLogicModels/
                        --project \
                            ./source-libraries/ui-user-interface/HolisticWare.BusinessDomainLogicModels.UserInterface.MAUI \
                            ./source-libraries/ui-user-interface/HolisticWare.BusinessDomainLogicModels.UserInterface.Blazor.Razor \
                    """,
                    """
                    reference \
                        add \
                            ./source-libraries/business-domain-logic-models/HolisticWare.BusinessDomainLogicModels/ \
                            --project \
                            ./source-libraries/ui-user-interface/Library.RazorComponents.Shared/ \
                    """,
                    """
                    reference \
                        add \
                            ./source-libraries/ui-user-interface/Library.RazorComponents.Shared/ \
                            ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/ \
                            --project \
                                ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web/ \
                    """,
                    """
                    reference \
                        add \
                            ./source-libraries/ui-user-interface/Library.RazorComponents.Shared/ \
                            --project \
                            ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI/ \
                    """,
                    """
                    reference \
                        add \
                            ./source-libraries/ui-user-interface/Library.RazorComponents.Shared/ \
                            --project \
                            ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/ \
                    """,
                    """
                    reference \
                        add \
                            ./source-libraries/ui-user-interface/Library.RazorComponents.Shared/ \
                            --project \
                            tests/common/ui-user-interface/Tests.Common
                    """,
                    //--------------------------------------------------------------------------------------------------
                    // unit-tests
                    """
                    reference \
                        add \
                            ./source-libraries/business-domain-logic-models/HolisticWare.BusinessDomainLogicModels
                        --project \
                            ./tests/unit-tests/ui-user-interface/RunnerTests.NUnit
                            ./tests/unit-tests/ui-user-interface/RunnerTests.MSTest
                            ./tests/unit-tests/ui-user-interface/RunnerTests.TUnit
                            ./tests/unit-tests/business-domain-logic-models/RunnerTests.NUnit
                            ./tests/unit-tests/business-domain-logic-models/RunnerTests.XUnit
                            ./tests/unit-tests/business-domain-logic-models/RunnerTests.MSTest
                            ./tests/unit-tests/business-domain-logic-models/RunnerTests.TUnit
                            ./tests/unit-tests/utilities/RunnerTestsAspire.XUnit
                            ./tests/unit-tests/utilities/RunnerTestsAspire.NUnit
                            ./tests/unit-tests/utilities/RunnerTestsAspire.MSTest
                    """,
                    """
                    reference \
                        add \
                            tests/common/business-domain-logic-models/Tests.Common \
                            --project \
                            tests/unit-tests/business-domain-logic-models/RunnerTests.MSTest \
                            tests/unit-tests/business-domain-logic-models/RunnerTests.NUnit
                            tests/unit-tests/business-domain-logic-models/RunnerTests.NUnit \
                    """,
                    """
                    reference \
                        add \
                            ./source-libraries/ui-user-interface/Library.RazorComponents.Shared/ \
                            --project \
                                tests/unit-tests/ui-user-interface/RunnerTests.MSTest \
                                tests/unit-tests/ui-user-interface/RunnerTests.NUnit \
                                tests/unit-tests/ui-user-interface/RunnerTests.NUnit \
                    """,
                    //--------------------------------------------------------------------------------------------------
                    // benchmark-tests
                    """
                    reference \
                        add \
                            ./source-libraries/ui-user-interface/Library.RazorComponents.Shared/ \
                        --project \
                            tests/benchmark-tests/ui-user-interface/RunnerTests.BenchmarkDotNet \
                    """,
                ];

foreach (string project_args_item in project_args_list)
{
    StartProcessDotnet
                    (
                        project_args_item
                            .Replace(@"\", " ")
                            .Replace(System.Environment.NewLine, " ")
                    );
}

project_args_list =
                [
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            ./source-libraries/business-domain-logic-models/HolisticWare.BusinessDomainLogicModels/
                        --solution-folder \
                            source-libraries/business-domain-logic-models/ \
                    """,
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            ./source-libraries/ui-user-interface/Library.RazorComponents.Shared/ \
                            ./source-libraries/ui-user-interface/HolisticWare.BusinessDomainLogicModels.UserInterface.Blazor.Razor/ \
                            ./source-libraries/ui-user-interface/HolisticWare.BusinessDomainLogicModels.UserInterface.MAUI/ \
                        --solution-folder \
                            source-libraries/ui-user-interface/ \
                    """,
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            --solution-folder \
                                source-libraries/utilities/ \
                                ./source-libraries/utilities/Library.AspireServiceDefaults/Library.AspireServiceDefaults.csproj
                    """,
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            --solution-folder \
                                samples/apps \
                                    ./samples/apps/App__MAUI/ \
                                    ./samples/apps/App__MAUI_Blazor \
                                    ./samples/apps/App_Web_ASP_net__Blazor \
                                    ./samples/apps/App_Web_ASP_net__BlazorWASM \
                                    ./samples/apps/App_Web_ASP_net__BlazorWASM_FluentUI \
                                    ./samples/apps/App_Web_ASP_net__BlazorWASM_PWA_FluentUI \
                                    ./samples/apps/App_Web_ASP_net__Blazor_FluentUI \
                                    ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.MAUI \
                                    ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web \
                                    ./samples/apps/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client \
                                    ./samples/apps/AppAspire.AppHost \
                    """,
                    """
                    package \
                        add \
                            BenchmarkDotNet \
                        --project \
                            tests/benchmark-tests/business-domain-logic-models/RunnerTests.BenchmarkDotNet/ \
                    """,
                    """
                    package \
                        add \
                            BenchmarkDotNet \
                        --project \
                            tests/benchmark-tests/ui-user-interface/RunnerTests.BenchmarkDotNet/ \
                    """,
                    """
                    package \
                        add \
                            TUnit \
                            --prerelease \
                        --project \
                            tests/unit-tests/business-domain-logic-models/RunnerTests.TUnit/ \
                    """,
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            --solution-folder \
                                tests/common/business-domain-logic-models/ \
                                tests/common/business-domain-logic-models/Tests.Common \
                    """,
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            --solution-folder \
                                tests/unit-tests/business-domain-logic-models/ \
                                tests/unit-tests/business-domain-logic-models/RunnerTests.TUnit \
                    """,
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            --solution-folder \
                                tests/unit-tests/business-domain-logic-models/ \
                                tests/unit-tests/business-domain-logic-models/RunnerTests.NUnit \
                    """,
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            --solution-folder \
                                tests/unit-tests/business-domain-logic-models/ \
                                tests/unit-tests/business-domain-logic-models/RunnerTests.XUnit \
                    """,
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            --solution-folder \
                                tests/unit-tests/business-domain-logic-models/ \
                                tests/unit-tests/business-domain-logic-models/RunnerTests.MSTest \
                    """,
                    """
                    sln \
                        AppSuite.slnx \
                        add \
                            --solution-folder \
                                tests/benchmark-tests/business-domain-logic-models/ \
                                tests/benchmark-tests/business-domain-logic-models/RunnerTests.BenchmarkDotNet \
                    """,
                    /*
                    */
                ];

foreach (string project_args_item in project_args_list)
{
    StartProcessDotnet
                    (
                        project_args_item
                            .Replace(@"\", " ")
                            .Replace(System.Environment.NewLine, " ")
                    );
}


System.IO.File.WriteAllText
                    (
                        "./Directory.Build.props", 
                        """
                        <Project>
                            <PropertyGroup>
                                <LangVersion>latest</LangVersion>
                            </PropertyGroup>
                        </Project>
                        """
                    );





StartProcess("open", "AppSuite.slnx");


static 
    void
                                        StartProcessDotnet
                                        (
                                            string args                                           
                                        )
{
    IEnumerable<string> redirectedStandardOutput;
    IEnumerable<string> redirectedErrorOutput;
    var exitCodeWithArgument = StartProcess
                                    (
                                        "dotnet",
                                        new ProcessSettings
                                        {
                                            Arguments = args,
                                            RedirectStandardOutput = true,
                                            RedirectStandardError = true
                                        },
                                        out redirectedStandardOutput,
                                        out redirectedErrorOutput
                                    );

    // Output last line of process output.
    Information("Last line of output:   {0}", string.Join(Environment.NewLine, redirectedStandardOutput));
    Information("Args                   {0}", args);

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

    return;
}
