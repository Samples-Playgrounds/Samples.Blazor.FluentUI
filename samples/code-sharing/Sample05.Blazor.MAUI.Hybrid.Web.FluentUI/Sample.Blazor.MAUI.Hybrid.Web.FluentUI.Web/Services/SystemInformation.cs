using Cysharp.Text; 

using Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;

namespace Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Web.Services;

public partial class 
                                        SystemInformation
                                        :
                                        ISystemInformation
{
    public 
        string 
                                        FormFactor
    {
        get
        {
            string retval = null;

            using(Utf16ValueStringBuilder sb = ZString.CreateStringBuilder())
            {
                /*
                if (System.Web.Hosting.HostingEnvironment.IsHosted)
                {
                    // You are in a web application
                    sb.AppendLine("Web");
                }
                else
                {
                    // You are in a standalone application
                    sb.AppendLine("Standalone");
                }
                */
                //sb.AppendLine(System.Web.HttpContext.Current.Request.ApplicationPath);
                // and build final string
                
                sb.AppendLine("Web");

                retval = sb.ToString();
            }

            return retval;}
    }
}
