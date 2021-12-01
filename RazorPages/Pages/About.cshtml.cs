using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Extras;

namespace RazorPages.Pages
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

        }
    }
}