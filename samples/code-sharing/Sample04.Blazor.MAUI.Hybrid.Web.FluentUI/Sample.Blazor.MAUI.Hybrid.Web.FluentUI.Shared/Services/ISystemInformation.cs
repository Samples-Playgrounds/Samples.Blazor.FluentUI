using System.Runtime.InteropServices;

using Cysharp.Text; 

namespace Sample.Blazor.MAUI.Hybrid.Web.FluentUI.Shared.Services;

public interface 
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
                retval = sb.ToString();
            }

            return retval;}
    }

    public 
        string 
                                        Platform
    {
        get
        {
            return Environment.OSVersion.ToString();
        }
    }

    public 
        string 
                                        OperatingSystem
    {
        get
        {
            string retval = null;

            using(Utf16ValueStringBuilder sb = ZString.CreateStringBuilder())
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    sb.AppendLine("Windows");
                }
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    sb.AppendLine("macOSX");
                }
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    sb.AppendLine("Linux");
                }
                
                // and build final string
                retval = sb.ToString();
            }

            return retval;            
        }   
    }
}
