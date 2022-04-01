using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using RazorPagesCore22_1.Extras;
using System.Reflection;
using System.Runtime.Versioning;

namespace RazorPagesCore22_1.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IHostingEnvironment _env;
        public string OSDescription;
        public string ProcessArchitecture;
        public string version;
        public string ThisEnvironment { get; set; }
        public string CurrentRunTimeVersion { get; set; }
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
            CurrentRunTimeVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            OSDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ProcessArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();
            version = "Version: " + @System.Environment.Version + " from: " + @System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();


            var atrib = Assembly.GetExecutingAssembly().CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            TargetFramework = atrib?.ConstructorArguments[0].Value.ToString();

        }

    }
}