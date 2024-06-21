using Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.Shared.Services;

namespace Sample01.Blazor.MAUI.Hybrid.Web.Bootstrap.Web.Services;

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
