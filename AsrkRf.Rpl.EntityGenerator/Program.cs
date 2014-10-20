using System;
using System.Linq;
using NHibernate.Criterion;

namespace AsrkRf.Rpl.EntityGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AsrkRf replic entity generator (.Net 4.0)");

            var connectionString = string.Empty;
            var connectionProvider = string.Empty;
            var genResult = "dll"; // "classes"
            var tables = "podrazdelenie";
            var allTables = false;
            var path = ".";

            if (!args.Any() || args.FirstOrDefault(x => x.ToUpper().StartsWith("/HELP")) != null ||
                args.FirstOrDefault(x => x.StartsWith("/?")) != null)
            {
                Console.WriteLine("Справка:");
                Console.WriteLine("\tAsrkRf.Rpl.EntityGenerator.exe [/h|/Help] [/ConnectionProvider={Firebird|MsSqlServer}] [/ConnectionString={...}] [/GenResult={Dll|Classes}] [/Tables={...}] [/AllTables] [/OutputPath={...}]");
                Console.WriteLine("\t/h or /Help - этот контекст");
                Console.WriteLine("\t/ConnectionProvider - имя провайдера БД");
                Console.WriteLine("\t/ConnectionString - строка подключения к БД");
                Console.WriteLine("\t/GenResult - тип результата (Dll - библиотека, Classes - cs-файлы)");
                Console.WriteLine("\t/Tables - список таблиц через разделитель ';'");
                Console.WriteLine("\t/AllTables - параметр, указывающий на генерацию для всех таблиц БД");
                Console.WriteLine("\t/OutputPath - каталог для генерации");

                Console.ReadKey();
                return;
            }

            var str = args.FirstOrDefault(x => x.ToUpper().StartsWith("/CONNECTIONSTRING"));
            if (str != null) connectionString = str.Substring(18);

            str = args.FirstOrDefault(x => x.ToUpper().StartsWith("/CONNECTIONPROVIDER"));
            if (str != null) connectionProvider = str.Split('=')[1].ToLower();

            str = args.FirstOrDefault(x => x.ToUpper().StartsWith("/GENRESULT"));
            if (str != null) genResult = str.Split('=')[1];

            str = args.FirstOrDefault(x => x.ToUpper().StartsWith("/TABLES"));
            if (str != null) tables = str.Split('=')[1];

            str = args.FirstOrDefault(x => x.ToUpper().Contains("/ALLTABLES"));
            if (str != null) allTables = true;

            str = args.FirstOrDefault(x => x.ToUpper().Contains("/OUTPUTPATH"));
            if (str != null) path = str.Split('=')[1];

            var employer = new Employer(connectionString, connectionProvider, genResult, tables, allTables, path);
            employer.Generate();
        }
    }
}
