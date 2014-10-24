using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Session;
using Cloud;
using FireBird.Entity;
using FluentNHibernate.Testing.Values;
using NHibernate.Transform;
using Noesis.Javascript;

namespace AsrkRf.Rpl.Subdivision
{
    public class FirebirdSubdivisionProvider: IFirebird
    {
        private readonly ISessionHelper sessionHelper;

        public FirebirdSubdivisionProvider(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }

        private Type GetTypeByName(string name)
        {
            if (name == "Firebird.Entity.Podrazdelenie") return typeof(Podrazdelenie);
            if (name == "Firebird.Entity.Test") return typeof(Test);
            return null;
        }

        public object Get(decimal id)
        {
            const string entityPath = "H:\\GitHub\\AsrkRf.Rpl\\AsrkRf.Rpl.WebServer\\bin\\Debug\\Xml\\Subdivision.xml";
            var entityFile = EntityFile.LoadFromFile(entityPath);
            var cloud = new CloudSubdivision();
            using (var context = new JavascriptContext())
            {
                context.SetParameter("cloud", cloud);
                //context.SetParameter("console", new SystemConsole());
                foreach (var entity in entityFile)
                {
                    var type = GetTypeByName(entity.ClassName);
                    using (var session = sessionHelper.NewSession())
                    {
                        var data = session.CreateSQLQuery(entity.SqlText)
                            .SetParameter("id", Convert.ToInt64(id))
                            .SetResultTransformer(Transformers.AliasToBean(type))
                            .List();

                        if (entity.IsList)
                        {
                            var obj = (IList) Activator.CreateInstance(typeof (List<>).MakeGenericType(type));
                            foreach (var dataItem in data)
                            {
                                obj.Add(dataItem);
                            }
                            context.SetParameter(entity.ObjectName, obj);
                        }
                        else
                        {
                            var obj = Convert.ChangeType(data[0], type);
                            context.SetParameter(entity.ObjectName, obj);
                        }
                    }
                }
                using (var reader = new StreamReader("H:\\GitHub\\AsrkRf.Rpl\\AsrkRf.Rpl.WebServer\\bin\\Debug\\Scripts\\Firebird.Subdivision.Get.js"))
                {
                    var script = reader.ReadToEnd();
                    context.Run(script);
                    return cloud;
                }
            }
        }

        public void Post(string value)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(value);
                    writer.Flush();
                    stream.Position = 0;
                    
                    var serializer = new DataContractJsonSerializer(typeof (CloudSubdivision));
                    var obj =(CloudSubdivision)serializer.ReadObject(stream);
                    Console.WriteLine(obj);
                }
            }
        }
    }
}
