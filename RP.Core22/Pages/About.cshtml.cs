using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using System.Runtime.Versioning;
using RP.Core22.Pages.HelperUtilities;

namespace RP.Core22.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IHostingEnvironment _env;
        public string OSDescription;
        public string ProcessArchitecture;
        public string VersionText;
        public string DotNetCoreVersion;
        public string NetFrameworkVer;

        public string ThisEnvironment { get; set; }
        //  public string CurrentRunTimeVersion { get; set; }
        public string MyApplicationName { get; set; }
        public string SolutionName { get; set; }
        public string TargetFramework { get; set; }



        public AboutModel(IHostingEnvironment env)
        {
            _env = env;
        }
        public void OnGet()
        {
            SolutionName = DevFileUtilities.GetSolutionFileName();
            ThisEnvironment = _env.EnvironmentName;
            MyApplicationName = _env.ApplicationName;

            var atrib = Assembly.GetExecutingAssembly().CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            TargetFramework = atrib?.ConstructorArguments[0].Value.ToString();

            OSDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ProcessArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();

            VersionText = "Version: " + DevFileUtilities.GetNetCoreVersion() + " installed in: " + @System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();

           // DotNetCoreVersion = DevFileUtilities.GetNetCoreVersion();
            DotNetCoreVersion = SystemHelpers.getCoreVersion(TargetFramework);

            NetFrameworkVer = SystemHelpers.GetInstalledDotNetFrameworkVersion();
        }

    }
}