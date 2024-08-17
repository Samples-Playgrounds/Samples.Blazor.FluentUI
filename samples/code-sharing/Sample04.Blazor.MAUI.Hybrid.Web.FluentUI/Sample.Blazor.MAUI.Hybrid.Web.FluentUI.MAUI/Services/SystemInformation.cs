using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;

namespace Sample.Blazor.MAUI.Hybrid.Web.FluentUI.MAUI.Services;

public class 
                                        SystemInformation 
                                        : 
                                        ISystemInformation
{
    public string GetFormFactor()
    {
        return DeviceInfo.Idiom.ToString();
    }

    public string GetPlatform()
    {
        return DeviceInfo.Platform.ToString() + " - " + DeviceInfo.VersionString;
    }
}
