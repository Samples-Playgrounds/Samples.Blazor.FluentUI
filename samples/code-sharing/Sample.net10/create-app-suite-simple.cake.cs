#!/usr/local/share/dotnet/dotnet run

#:sdk Cake.Sdk@6.0.0

#:property langVersion=latest

#:package Cake.FileHelpers@7.0.0

using System;

/*
https://www.devlead.se/posts/2025/2025-07-28-migrating-to-cake-sdk
https://www.reddit.com/r/dotnet/comments/1mbsh0y/modernizing_cake_build_scripts_with_the_new_sdk/
https://cakebuild.net/blog/2025/07/dotnet-cake-cs    
GitHub Actions DevOps Pipelines as Code using C# and Cake SDK
    https://www.youtube.com/watch?v=e7hkKyQEcN8
    https://github.com/azurevoodoo/dotnetconf2025

https://cakebuild.net/dsl/process/
https://cakebuild.net/api/Cake.Common/ProcessAliases/34E38D20
*/


string[] project_folders =  
                            [
                                "App_Web_ASP_net__Blazor",
                                "AppSuite__MAUI_Blazor_Web",
                                "App__MAUI_Blazor",
                                "App__MAUI",
                                "AppMobileBlazorBindings",
                                "AppBlazorHybrid",
                            ];

foreach (string project_folder in project_folders)
{
    if (DirectoryExists(project_folder))
    {
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
                                """
                                sln \
                                    AppSuite.slnx \
                                    add \
                                        --in-root \
                                            ./App_Web_ASP_net__Blazor/App_Web_ASP_net__Blazor.csproj \
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.csproj \
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Shared/AppSuite__MAUI_Blazor_Web.Shared.csproj \
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web/AppSuite__MAUI_Blazor_Web.Web.csproj \
                                            ./AppSuite__MAUI_Blazor_Web/AppSuite__MAUI_Blazor_Web.Web.Client/AppSuite__MAUI_Blazor_Web.Web.Client.csproj \
                                            ./App__MAUI_Blazor/App__MAUI_Blazor.csproj \
                                            ./App__MAUI/App__MAUI.csproj \
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
}

StartProcess
            (
                "open",
                "AppSuite.slnx"
            );