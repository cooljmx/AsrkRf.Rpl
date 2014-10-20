using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Subdivision.Cloud;

namespace AsrkRf.Rpl.Subdivision
{
    public class SubdivisionProvider: IProvider
    {
        private readonly ISessionHelper sessionHelper;
        public SubdivisionProvider(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }

        private Type GetTypeByName(string name)
        {
            foreach (var file in Directory.GetFiles("Providers\\bin").Where(x=>x.EndsWith(".dll")))
            {
                var assembly = Assembly.LoadFile(file);
                var type = assembly.GetType(name);
                if (type != null) return type;
            }
            throw new Exception();
        }

        public ICloud Get(decimal id)
        {
            using (var session = sessionHelper.NewSession())
            {
                try
                {
                    var entityFile =
                        EntityFile.LoadFromFile(Assembly.GetExecutingAssembly().Location +
                                                "\\Providers\\xml\\Firebird.Subdivision.xml");
                    foreach (var item in entityFile)
                    {
                        var type = GetTypeByName(item.ClassName);
                    }


                    return null;
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
        }

        public void Post(ICloud value)
        {
            try
            {
                /*var obj1 = new JavaScriptSerializer().Deserialize<CloudSubdivision>(value);
                var obj = (CloudSubdivision) obj1;*/
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
