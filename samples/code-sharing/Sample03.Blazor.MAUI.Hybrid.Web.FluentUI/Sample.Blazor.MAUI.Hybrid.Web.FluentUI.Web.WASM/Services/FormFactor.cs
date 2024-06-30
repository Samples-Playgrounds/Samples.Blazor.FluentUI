using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;

namespace Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Web.WASM.Services;

public class FormFactor : IFormFactor
{
    public string GetFormFactor()
    {
        return "Web";
    }

    public string GetPlatform()
    {
        return Environment.OSVersion.ToString();
    }
}
