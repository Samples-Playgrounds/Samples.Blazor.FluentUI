#!/bin/bash

rm AppSuiteBlazor.sln*
rm -fr App_Web_ASP_net__Blazor
rm -fr AppSuite__MAUI_Blazor_Web
rm -fr App__MAUI_Blazor
rm -fr App__MAUI
rm -fr AppMobileBlazorBindings
rm -fr AppBlazorHybrid


dotnet \
    new \
        blazor \
            --output App_Web_ASP_net__Blazor

dotnet \
    new \
        maui-blazor-web \
            --InteractivityPlatform Auto \
            --output AppSuite__MAUI_Blazor_Web


dotnet \
    new \
        maui-blazor \
            --output App__MAUI_Blazor

dotnet \
    new \
        maui \
            --output App__MAUI

dotnet \
    new \
        sln \
            --name AppSuite

dotnet \
    sln \
        migrate \
            AppSuite.sln

rm AppSuite.sln

dotnet \
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

open AppSuite.slnx
