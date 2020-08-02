using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using EmergentSoftware.Models;

namespace EmergentSoftware
{
    public class Software
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public static class SoftwareManager
    {
        public static string FillSoftwareVersion(string version)
        {
            string[] newVersionArray = Enumerable.Repeat("0", 4).ToArray();
            string[] versionArray = version.Split('.');
            versionArray.CopyTo(newVersionArray, 0);

            while (Array.IndexOf(newVersionArray, "") > -1)
            {
                newVersionArray[Array.IndexOf(newVersionArray, "")] = "0";
            }

            return string.Join('.', newVersionArray);
        }

        public static IEnumerable<Software> GreaterSoftwareVersion(IEnumerable<Software> softwares, string softwareVersion)
        {
            List<Software> greaterSoftwareVersions = new List<Software>();
            var rootVersion = new Version(softwareVersion);
            
            foreach(Software software in softwares)
            {
                var version = new Version(FillSoftwareVersion(software.Version));
                var result = version.CompareTo(rootVersion);
                if (!(result < 0))
                    greaterSoftwareVersions.Add(software);
            }

            return greaterSoftwareVersions;
        }

        public static IEnumerable<Software> GetSoftwares(IEnumerable<Software> softwares, Func<Software, bool> versionResolver)
        {
            foreach (Software software in softwares)
                if (versionResolver(software))
                    yield return software;
        }
        public static IEnumerable<Software> GetAllSoftware()
        {
            return new List<Software>
            {
                new Software
                {
                    Name = "MS Word",
                    Version = "13.2.1."
                },
                new Software
                {
                    Name = "AngularJS",
                    Version = "1.7.1"
                },
                new Software
                {
                    Name = "Angular",
                    Version = "8.1.13"
                },
                new Software
                {
                    Name = "React",
                    Version = "0.0.5"
                },
                new Software
                {
                    Name = "Vue.js",
                    Version = "2.6"
                },
                new Software
                {
                    Name = "Visual Studio",
                    Version = "2017.0.1"
                },
                new Software
                {
                    Name = "Visual Studio",
                    Version = "2019.1"
                },
                new Software
                {
                    Name = "Visual Studio Code",
                    Version = "1.35"
                },
                new Software
                {
                    Name = "Blazor",
                    Version = "0.7"
                }
            };
        }
    }
}
