using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using HTL.DbEx.Utility;
using HTL.DbEx.Mongo.ObjectMap;

namespace HTL.DbEx.TestHarness
{
    public static class GenHelper
    {
        #region interface
        public static string MongoConnectionStringName { get; set; }
        public static string NamespaceRoot { get; set; }
        #endregion

        #region is list
        public static bool IsList(MongoField f)
        {
            return f.TypeText.StartsWith("List") || f.TypeText.StartsWith("IList");
        }
        #endregion

        #region is array
        public static bool IsArray(MongoField f)
        {
            return f.TypeText.EndsWith("[]");
        }
        #endregion

        #region get interface type
        public static string GetInterfaceType(MongoField field)
        {
            if (!field.IsMongoEntity && (!IsArray(field) && !IsList(field))) //MongoField<ObjectId> _id  [!IsMongoDoc && !IsArray]
            {
                return "MongoField<" + field.TypeText + ">";
            }
            else if (field.IsMongoEntity && (!IsList(field) && !IsArray(field))) //PostMetaDocument Meta [IsMongoDoc && (!IsList && !IsArray)]
            {
                return field.TypeText + "Document";
            }
            else if (!field.IsMongoEntity && (IsList(field) || IsArray(field))) //MongoArrayField<int> MyIntegers [!IsMongoDoc && (IsList || IsArray)]
            {
                return "MongoArrayField<" + field.TypeText + ">";
            }
            else if (field.IsMongoEntity && (IsList(field) || IsArray(field))) //PostCommentArrayDocument Comments  [IsMongoDoc && (IsList || IsArray)
            {
                    return field.Name + "ArrayDocument";
            }
            else
            {
                throw new InvalidOperationException("Could not determine interface type");
            }
        }
        #endregion

        #region get types requiring array mongo doc
        #endregion

        #region to camel case
        public static string ToCamelCase(string val)
        {
            return (val.Trim().Substring(0, 1).ToLower() + val.Substring(1));
        }
        #endregion

        #region insert space on capitalization
        public static string InsertSpaceOnCapitalization(string value)
        {
            value = value.Trim();
            MatchCollection matches = Regex.Matches(value, "[A-Z]");
            int adj = 0;
            foreach (Match m in matches)
            {
                if (!(m.Index == 0))
                {
                    value = value.Insert((m.Index + adj), " ");
                    adj++;
                }
            }
            return value;
        }
        #endregion

        #region ensure element name
        public static string EnsureElementName(MongoField field)
        {
            if (field.IsIdentity)
            {
                return "_id";
            }

            if (!string.IsNullOrEmpty(field.As))
            {
                return field.As;
            }

            return field.Name;
        }
        #endregion

        #region timestamp seeders
        public static string CreatedSeeder(MongoEntity e)
        {
            return (e.Fields.Find(f => f.Name == "DateCreated") != null) 
                ? "this.DateCreated = " 
                : string.Empty;
        }

        public static string UpdatedSeeder(MongoEntity e)
        {
            return (e.Fields.Find(f => f.Name == "DateUpdated") != null) 
                ? "this.DateUpdated = " 
                : string.Empty;
        }

        public static string DateSeeder(MongoEntity e)
        {
            return (e.Fields.Find(f => f.Name == "DateCreated") != null || e.Fields.Find(f => f.Name == "DateUpdated") != null) 
                ? "DateTime.Now;" 
                : string.Empty;
        }
        #endregion
    }
}
