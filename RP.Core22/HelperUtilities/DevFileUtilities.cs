using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RP.Core22.Pages.HelperUtilities
{
    public static class DevFileUtilities
    {
        public static string GetAssemblyFileName() => GetAssemblyPath().Split(@"\").Last();
        public static string GetAssemblyDir()
        {
            return Path.GetDirectoryName(GetAssemblyPath());
        }

        public static string GetAssemblyPath() => Assembly.GetExecutingAssembly().Location;
        public static string GetSolutionFileName() => GetSolutionPath().Split(@"\").Last();
        public static string GetSolutionDir() => Directory.GetParent(GetSolutionPath())?.FullName;
        
        public static string GetSolutionPath()
        {
            var currentDirPath = GetAssemblyDir();
            while (currentDirPath != null)
            {
                var fileInCurrentDir = Directory.GetFiles(currentDirPath).Select(f => f.Split(@"\").Last()).ToArray();
                var solutionFileName = fileInCurrentDir.SingleOrDefault(f => f.EndsWith(".sln", StringComparison.InvariantCultureIgnoreCase));
                if (solutionFileName != null)
                    return Path.Combine(currentDirPath, solutionFileName);

                currentDirPath = Directory.GetParent(currentDirPath)?.FullName;
            }

            throw new FileNotFoundException("Cannot find solution file path");
        }

        /// <summary>
        /// Get .NET Core Version in versions older than 3.0.0
        /// </summary>
        /// <remarks>// reference -https://stackoverflow.com/a/49309382/1068538</remarks>
        /// <returns></returns>
        public static string GetNetCoreVersion()
        {
            var assembly = typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly;
            var assemblyPath = assembly.CodeBase.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            int netCoreAppIndex = Array.IndexOf(assemblyPath, "Microsoft.NETCore.App");
            if (netCoreAppIndex > 0 && netCoreAppIndex < assemblyPath.Length - 2)
                return assemblyPath[netCoreAppIndex + 1];
            return null;
        }
    }
}
