using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Data.Common;
using HTL.DbEx.Utility;
using HTL.DbEx.Utility.Reflection;
using HTL.DbEx.MsSql.ObjectMap;
using HTL.DbEx.MsSql;
using System.Configuration;
using HTL.DbEx.MySql.ObjectMap;
using HTL.DbEx.MySql;
using HTL.DbEx.Mongo;
using HTL.DbEx.ObjectMap.Assembly;
using HTL.DbEx.Mongo.ObjectMap;
using HandlebarsDotNet;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            object[] objs = new object[] { "Value1", 2, (long)3, "Value 4", "Value 5" };

            string result;
            for (int i = 0; i < 15000; i++)
            {
                //result = StringInterpolationTest(objs);
                //result = StringFormatTest(objs);
                result = StringInterpolateNonLiteralTest(objs);
            }


            //Dictionary<string, object> dict = new Dictionary<string, object>()
            //{
            //    { "FirstName", "Jerrod" },
            //    { "LastName", "Eiman" },
            //    { "Age", 21 },
            //    { "Address", new
            //    {
            //        Line1 = "2550 Parkhaven Dr.",
            //        Line2 = default(object),
            //        City = "Plano",
            //        State = "TX",
            //        Zip = "75075",
            //        Test = new { Sub1 = "sub1", Sub2 = "sub2" }
            //    } }
            //};

            //var obj = new
            //{
            //    FirstName = "Jerrod",
            //    LastName = "Eiman",
            //    Age = 21,
            //    Address = new
            //    {
            //        Line1 = "2550 Parkhaven Dr.",
            //        Line2 = default(object),
            //        City = "Plano",
            //        State = "TX",
            //        Zip = "75075",
            //        Test = new { Sub1 = "sub1", Sub2 = "sub2" }
            //    }
            //};

            //object o = ReflectionHelper.Expression.ReflectItem(dict, "FirstName");
            //o = ReflectionHelper.Expression.ReflectItem(dict, "Age");
            //o = ReflectionHelper.Expression.ReflectItem(dict, "Address.City");
            //o = ReflectionHelper.Expression.ReflectItem(obj, "FirstName");
            //o = ReflectionHelper.Expression.ReflectItem(obj, "LastName");
            //o = ReflectionHelper.Expression.ReflectItem(obj, "Address.Test.Sub2");

            sw.Stop();
            Console.WriteLine($"Processed in {sw.ElapsedMilliseconds} milliseconds.");
            Console.ReadLine();
        }

        static string StringInterpolateNonLiteralTest(object[] vals)
        {
            Func<string, string> provider = (token) =>
            {
                if (token == "0") return vals[0].ToString();
                if (token == "1") return vals[1].ToString();
                if (token == "2") return vals[2].ToString();
                if (token == "3") return vals[3].ToString();
                if (token == "4") return vals[4].ToString();
                return string.Empty;
            };
            string val = StringInterpolation.Interpolate("This is just a test: 1 {0}, 2 {1}, 3 {2}, 4 {3}, 5 {4}", provider);
            return val;
        }

        static string StringFormatTest(object[] vals)
        {
            string value = string.Format("This is just a test: 1 {0}, 2 {1}, 3 {2}, 4 {3}, 5 {4}", vals[0], vals[1], vals[2], vals[3], vals[4]);
            return value;
        }

        static string StringInterpolationTest(object[] vals)
        {
            string template = $"This is just a test: 1 {vals[0]}, 2 {vals[1]}, 3 {vals[2]}, 4 {vals[3]}, 5 {vals[4]}";
            return template;
        }
    }
}
