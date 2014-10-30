using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Session;

namespace AsrkRf.Rpl
{
    public class CommonProvider
    {
        protected readonly ISessionHelper sessionHelper;
        protected readonly IUriHelper uriHelper;

        public CommonProvider(ISessionHelper sessionHelper, IUriHelper uriHelper)
        {
            this.sessionHelper = sessionHelper;
            this.uriHelper = uriHelper;
        }

        protected Type GetTypeByName(string name)
        {
            foreach (var file in Directory.GetFiles(uriHelper.BinPath, "*.dll"))
            {
                foreach (var typeInfo in Assembly.LoadFile(file).GetTypes())
                {
                    if (typeInfo.FullName.ToUpper() == name.ToUpper()) return typeInfo;
                }
            }
            //if (name == "Firebird.Entity.Podrazdelenie") return typeof(PODRAZDELENIE);
            //if (name == "Firebird.Entity.Test") return typeof(Test);
            throw new Exception("Не найден подходящий класс");
        }
    }
}
