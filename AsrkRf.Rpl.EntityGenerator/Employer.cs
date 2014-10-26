using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.CSharp;
using NHibernate;
using NHibernate.Linq.Functions;
using NHibernate.Transform;

namespace AsrkRf.Rpl.EntityGenerator
{
    internal class TableInfo
    {
        public string TableName { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
    }
    
    internal class Employer
    {
        private readonly ISessionFactory sessionFactory;
        private readonly string sql;
        private readonly List<string> tableList;
        private readonly bool allTables = false;
        private readonly string genResult;
        private readonly string nameSpace;
        private readonly string path;

        private readonly List<TableInfo> tableInfoList = new List<TableInfo>();
        private readonly Dictionary<string,string> codeList = new Dictionary<string, string>();

        internal Employer(string connectionString, string connectionProvider, string genResult, string tables, bool allTables, string path)
        {
            IPersistenceConfigurer cfg = null;

            switch (connectionProvider)
            {
                case "firebird":
                    cfg = (new FirebirdConfiguration()).ConnectionString(connectionString).ShowSql();
                    #region Sql
                    sql = @"select trim(r.rdb$relation_name) ""TableName"", trim(rf.rdb$field_name) ""FieldName"",
    trim(case
        --when f.rdb$field_type in (16) and f.rdb$field_scale = 0 then 'long'
        when f.rdb$field_type in (16) /*and f.rdb$field_scale < 0*/ then 'decimal'
        when f.rdb$field_type in (7,10,27) then 'decimal'
        when f.rdb$field_type in (12,13,35) then 'DateTime'
        when f.rdb$field_type in (14,37) then 'string'
        when f.rdb$field_type in (8) then 'int'
        when f.rdb$field_type in (261) and f.rdb$field_sub_type = 1 then 'string'
        else 'object'
    end) ""FieldType""
from rdb$relations r
    join rdb$relation_fields rf on rf.rdb$relation_name = r.rdb$relation_name
    join rdb$fields f on f.rdb$field_name = rf.rdb$field_source
where
    r.rdb$system_flag is distinct from 1
    and r.rdb$view_source is null
    and r.rdb$relation_name not starting with 'IBE$'
    and ((:all_tables = 1) or (upper(r.rdb$relation_name) = upper(:table_name)));";
                    #endregion
                    nameSpace = "FireBird";
                    break;
                case "mssqlserver":
                    cfg = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql();
                    nameSpace = "MsSql";
                    break;
            }

            try
            {
                sessionFactory = Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .Diagnostics(x => x.Enable())
                    .BuildSessionFactory();

                tableList = new List<string>(tables.Split(';'));
                this.allTables = allTables;
                this.genResult = genResult.ToLower();
                this.path = path;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private string ResharpName(string value)
        {
            try
            {
                return value.Replace("__", "_").Split('_')
                    .Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1).ToLower())
                    .Aggregate((a, b) => a + b);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        private void FetchFromDb()
        {
            using (var session = sessionFactory.OpenSession())
            {
                if (allTables)
                {
                    var query = session.CreateSQLQuery(sql)
                        .SetParameter("all_tables", 1)
                        .SetParameter("table_name", "")
                        .SetResultTransformer(Transformers.AliasToBean(typeof (TableInfo)))
                        .List<TableInfo>();
                    tableInfoList.AddRange(query);
                }
                else
                {
                    foreach (var table in tableList)
                    {
                        var query = session.CreateSQLQuery(sql)
                            .SetParameter("all_tables", 0)
                            .SetParameter("table_name", table)
                            .SetResultTransformer(Transformers.AliasToBean(typeof(TableInfo)))
                            .List<TableInfo>();
                        tableInfoList.AddRange(query);
                    }
                }
            }
        }

        private void GenClasses()
        {
            foreach (var tableName in tableInfoList.Select(x=>x.TableName).Distinct())
            {
                var className = ResharpName(tableName);
                var properties =
                    tableInfoList.Where(x => x.TableName == tableName)
                        .OrderBy(x => x.FieldName)
                        .Select(x => "\t\tpublic " + x.FieldType + " " + ResharpName(x.FieldName) + " { get; set; } /* Original name " + x.FieldName + "*/")
                        .Aggregate((a, b) => a + "\n" + b);
                var code = "using AsrkRf.Rpl.Common;\nnamespace " + nameSpace + "\n{\n\tpublic class " + className + " : IFirebird\n\t{\n" + properties + "\n\t}\n}";
                var mapCode = "\n";
                codeList.Add(className,code);
            }
        }

        private void SaveClasses()
        {
            foreach (var item in codeList)
            {
                using (var file = new StreamWriter(path + "\\" + nameSpace + "." + item.Key + ".cs"))
                {
                    file.WriteLine(item.Value);
                }
                
            }
        }

        private void GenDll()
        {
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            foreach (var item in codeList)
            {
                parameters.OutputAssembly = path + "\\" + nameSpace + "." + item.Key + ".dll";
                provider.CompileAssemblyFromSource(parameters, item.Value);
            }
        }

        public void Generate()
        {
            FetchFromDb();
            GenClasses();
            switch (genResult)
            {
                case "classes": 
                    SaveClasses();
                    break;
                case "dll":
                    GenDll();
                    break;
            }
        }
    }
}
