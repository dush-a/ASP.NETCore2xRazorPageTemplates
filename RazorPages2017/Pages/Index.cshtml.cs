using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPages2017.Extras;

namespace RazorPages2017.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHostingEnvironment _env;
        public string OSDescription;
        public string ProcessArchitecture;
        public string version;
        public string ThisEnvironment { get; set; }
        public string CurrentRunTimeVersion { get; set; }
        public string MyApplicationName { get; set; }
        public string SolutionName { get; set; }

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
            CurrentRunTimeVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            OSDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ProcessArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();
            version = "Version: " + @System.Environment.Version + " from: " + @System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            _logger.LogInformation("Completed Index.OnGet, {ThisEnvironment}!", ThisEnvironment);
        }
    }
}
