using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPages.Core21.Extras;

namespace RazorPages.Core21.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHostingEnvironment _env;
        public string OSDescription;
        public string ProcessArchitecture;
        public string VersionText;
        public string DotNetCoreVersion;
        
        public string ThisEnvironment { get; set; }
        public string MyApplicationName { get; set; }
        public string SolutionName { get; set; }
        public string TargetFramework { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public void OnGet()
        {
            SolutionName = DevFileUtilities.GetSolutionFileName();
            ThisEnvironment = _env.EnvironmentName;
            MyApplicationName = _env.ApplicationName;

            var asembli = Assembly.GetExecutingAssembly();
            var atrib = asembli.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            TargetFramework = atrib?.ConstructorArguments[0].Value.ToString();

            OSDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ProcessArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();

            VersionText = "Version: " + DevFileUtilities.GetNetCoreVersion() + " installed in: " + @System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();

            DotNetCoreVersion = DevFileUtilities.GetNetCoreVersion();


        }
    }
}
