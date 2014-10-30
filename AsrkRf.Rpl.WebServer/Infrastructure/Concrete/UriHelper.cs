using System.Configuration;
using AsrkRf.Rpl.Common;

namespace AsrkRf.Rpl.WebServer.Infrastructure.Concrete
{
    public class UriHelper : IUriHelper
    {
        private readonly string rootPath;
        private readonly string scriptsPath;
        private readonly string xmlPath;
        private readonly string binPath;

        public UriHelper()
        {
            rootPath = ConfigurationManager.AppSettings["RootPath"];
            scriptsPath = ConfigurationManager.AppSettings["ScriptsPath"];
            xmlPath = ConfigurationManager.AppSettings["XmlPath"];
            binPath = ConfigurationManager.AppSettings["BinPath"];
        }

        public string RootPath { get { return rootPath; } }
        public string ScriptsPath { get { return rootPath + '\\' + scriptsPath; } }
        public string XmlPath { get { return rootPath + '\\' + xmlPath; } }
        public string BinPath { get { return rootPath + '\\' + binPath; } }
    }
}
