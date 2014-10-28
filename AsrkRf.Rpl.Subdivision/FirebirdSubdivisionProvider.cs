using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.Session;
using Cloud;
using FireBird.Entity;
using NHibernate.Transform;
using Noesis.Javascript;

namespace AsrkRf.Rpl.Subdivision
{
    public class FirebirdSubdivisionProvider: IFirebird
    {
        private readonly ISessionHelper sessionHelper;
        private readonly IUriHelper uriHelper;

        public FirebirdSubdivisionProvider(ISessionHelper sessionHelper, IUriHelper uriHelper)
        {
            this.sessionHelper = sessionHelper;
            this.uriHelper = uriHelper;
        }

        private Type GetTypeByName(string name)
        {
            if (name == "Firebird.Entity.Podrazdelenie") return typeof(Podrazdelenie);
            //if (name == "Firebird.Entity.Test") return typeof(Test);
            throw new Exception("Не найден подходящий класс");
        }

        public object Get(decimal id)
        {
            var entityPath = uriHelper.XmlPath + "\\Firebird.Subdivision.Get.xml";
            var entityFile = EntityFile.LoadFromFile(entityPath);
            var cloud = new CloudSubdivision();
            using (var context = new JavascriptContext())
            {
                context.SetParameter("cloud", cloud);
                foreach (var entity in entityFile)
                {
                    try
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
                    catch (Exception exception)
                    {
                        throw;
                    }
                }
                using (var reader = new StreamReader(uriHelper.ScriptsPath + "\\Firebird.Subdivision.Get.js"))
                {
                    var script = reader.ReadToEnd();
                    context.Run(script);
                    return cloud;
                }
            }
        }

        public void Post(string value)
        {
            var entityPath = uriHelper.XmlPath + "\\Firebird.Subdivision.Post.xml";
            var entityFile = EntityFile.LoadFromFile(entityPath);

            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(value);
                    writer.Flush();
                    stream.Position = 0;
                    
                    var serializer = new DataContractJsonSerializer(typeof (CloudSubdivision));
                    var cloud =(CloudSubdivision)serializer.ReadObject(stream);

                    using (var context = new JavascriptContext())
                    {
                        try
                        {
                            context.SetParameter("cloud", cloud);
                            foreach (var entity in entityFile)
                            {
                                var type = GetTypeByName(entity.ClassName);

                                if (entity.IsList)
                                {
                                    var obj = new object[0];//(IList) Activator.CreateInstance(typeof (List<>).MakeGenericType(type));
                                    context.SetParameter(entity.ObjectName, obj);
                                    context.SetParameter(entity.ItemName, Activator.CreateInstance(type));
                                }
                                else
                                {
                                    var obj = Activator.CreateInstance(type);
                                    context.SetParameter(entity.ObjectName, obj);
                                }
                            }
                            using (
                                var reader = new StreamReader(uriHelper.ScriptsPath + "\\Firebird.Subdivision.Post.js"))
                            {
                                var script = reader.ReadToEnd();
                                context.Run(script);
                            }

                            using (var session = sessionHelper.NewSession())
                            {
                                foreach (var entity in entityFile)
                                {
                                    var obj = context.GetParameter(entity.ObjectName);
                                    var type = GetTypeByName(entity.ClassName);

                                    if (entity.IsList)
                                    {
                                        foreach (var item in (IEnumerable) obj)
                                        {
                                            //var ent = Convert.ChangeType(item, type);
                                            session.SaveOrUpdate(item);
                                        }
                                    }
                                    //session.SaveOrUpdate();
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            throw;
                        }
                    }
                }
            }
        }
    }
}
