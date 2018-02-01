using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HTL.DbEx.Utility
{
    public static class CloneUtility
    {
        public static T DeepCopy<T>(T target) where T : class
        {
            T obj = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, target);
                ms.Position = 0;
                obj = (T)bf.Deserialize(ms);
            }
            return obj;
        }
    }
}
