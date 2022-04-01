using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace RazorPages.Core22.Areas.Identity.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IHostingEnvironment _env;
        public string OSDescription;
        public string ProcessArchitecture;

        public string ThisEnvironment { get; set; }
        public string MyApplicationName { get; set; }
        public string TargetFramework { get; set; }

        public AboutModel(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnGet()
        {
            ThisEnvironment = _env.EnvironmentName;
            MyApplicationName = _env.ApplicationName;

            OSDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ProcessArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();
           
            var atrib = Assembly.GetExecutingAssembly().CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            TargetFramework = atrib?.ConstructorArguments[0].Value.ToString();

        }
    }
}