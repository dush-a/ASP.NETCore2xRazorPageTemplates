using Microsoft.Win32;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;

namespace RP.Core22.Pages.HelperUtilities
{
    public static class SystemHelpers
    {
        public static string getCoreVersion(string myString)
        {
            string toBeSearched = "Version=v";
                        
            int ix = myString.IndexOf(toBeSearched);

            string code = String.Empty;
            if (ix != -1)
            {
                code = myString.Substring(ix + toBeSearched.Length);
            }
            return code;
        }

        public static string getCoreVersion()
        {
            var atrib = Assembly.GetExecutingAssembly().CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            string toBeSearched = "Version=v";

            string TargetFramework = atrib.ConstructorArguments[0].Value.ToString();

            int ix = TargetFramework.IndexOf(toBeSearched);
            //int ix = myString.IndexOf(toBeSearched);

            string code = String.Empty;
            if (ix != -1)
            {
                //code = myString.Substring(ix + toBeSearched.Length);
                code = TargetFramework.Substring(ix + toBeSearched.Length);
            }
            return code;
        }

        public static string GetInstalledDotNetFrameworkVersion()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
#pragma warning disable CA1416 // Validate platform compatibility
            using (var ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    return $".NET Framework Version: {CheckFor45PlusVersion((int)ndpKey.GetValue("Release"))}";
                    //Original code for above line
                    // return $".NET Framework Version: {CheckFor45PlusVersion((int)ndpKey.GetValue("Release")!)}";
                    //but ! is not recognised in 2.2
                }
                else
                {
                    return ".NET Framework Version 4.5 or later is not detected.";
                }
            }
#pragma warning restore CA1416 // Validate platform compatibility
        }


        // Checking the version using >= enables forward compatibility.
        private static string CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 528040)
                return "4.8 or later";
            if (releaseKey >= 461808)
                return "4.7.2";
            if (releaseKey >= 461308)
                return "4.7.1";
            if (releaseKey >= 460798)
                return "4.7";
            if (releaseKey >= 394802)
                return "4.6.2";
            if (releaseKey >= 394254)
                return "4.6.1";
            if (releaseKey >= 393295)
                return "4.6";
            if (releaseKey >= 379893)
                return "4.5.2";
            if (releaseKey >= 378675)
                return "4.5.1";
            if (releaseKey >= 378389)
                return "4.5";
            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "No 4.5 or later version detected";
        }
    }
}
