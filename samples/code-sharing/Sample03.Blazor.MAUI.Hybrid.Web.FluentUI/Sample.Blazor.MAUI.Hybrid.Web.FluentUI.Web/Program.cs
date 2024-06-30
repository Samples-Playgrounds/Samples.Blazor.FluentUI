using Microsoft.FluentUI.AspNetCore.Components;

using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Web.Components;
using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;
using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
                .AddRazorComponents()
                .AddInteractiveServerComponents()
                ;

builder.Services
            .AddHttpClient()            // if SSR HttpClient must be registered before FLuentUI
            .AddFluentUIComponents();

// Add device-specific services used by the Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared._Imports).Assembly);

app.Run();
