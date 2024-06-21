using Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;

namespace Sample02.Blazor.MAUI.Hybrid.Web.FluentUI.Web.Services;

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
