using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HatTrick.DbEx.Tools.Service
{
    public class IOService
    {
        #region file exists
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
        #endregion

        #region directory exists
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
        #endregion

        #region try create directory
        public bool TryCreateDirectory(string path, out string msg)
        {
            msg = null;
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch(Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }
        #endregion

        #region get file
        public byte[] GetFile(string path)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (fs.Length > int.MaxValue)
                {
                    throw new InvalidOperationException($"Cannot read entire file into memory. Max file size: {int.MaxValue} bytes");
                }
                int len = (int)fs.Length;
                 buffer = new byte[len];
                fs.Read(buffer, 0, len);
            }

            return buffer;
        }
        #endregion

        #region get file text
        public string GetFileText(string path, Encoding enc)
        {
            byte[] buffer = this.GetFile(path);
            string txt = enc.GetString(buffer);
            return txt;
        }
        #endregion

        #region write file
        public void WriteFile(string fullPath, string content, Encoding encoding)
        {
            using (FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = encoding.GetBytes(content);
                fs.Write(buffer, 0, buffer.Length);
            }
        }
        #endregion
    }
}
