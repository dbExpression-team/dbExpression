#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

﻿using System;
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
        public bool TryCreateDirectory(string path, out string? msg)
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
            byte[] buffer = Array.Empty<byte>();
            using (FileStream fs = new(path, FileMode.Open, FileAccess.Read))
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
            string txt = File.ReadAllText(path, enc);
            return txt;
        }
        #endregion

        #region write file
        public void WriteFile(string fullPath, string content, Encoding encoding)
        {
            using FileStream fs = new(fullPath, FileMode.Create, FileAccess.Write);
            byte[] buffer = encoding.GetBytes(content);
            fs.Write(buffer, 0, buffer.Length);
        }
        #endregion
    }
}
