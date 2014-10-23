using System;
using System.IO;
using System.Reflection;

namespace AsrkRf.Rpl.WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var executingAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var providersPath = executingAssemblyPath + "\\Providers";
            var entitiesPath = executingAssemblyPath + "\\Entities";
            var cloudsPath = executingAssemblyPath + "\\Clouds";
            var scriptsPath = executingAssemblyPath + "\\Scripts";
            if (!Directory.Exists(providersPath)) Directory.CreateDirectory(providersPath);
            if (!Directory.Exists(entitiesPath)) Directory.CreateDirectory(entitiesPath);
            if (!Directory.Exists(cloudsPath)) Directory.CreateDirectory(cloudsPath);
            if (!Directory.Exists(scriptsPath)) Directory.CreateDirectory(scriptsPath);

            using (var server = new WebApiServer(8003))
            {
                server.Start();
                Console.ReadKey();
            }
        }
    }
}
