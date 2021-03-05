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
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace HatTrick.DbEx.Tools
{
    #region resource accessor
    public class ResourceAccessor
    {
        #region get template short names
        public string[] GetTemplateShortNames()
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            string[] names = assem.GetManifestResourceNames().ToList()
                .FindAll(n => n.StartsWith("HatTrick.DbEx.Tools.Resources.Templates") && !n.Contains(".Partials"))
                .ToArray();

            for (int i = 0; i < names.Length; i++)
            {
                var (shortName, extension) = this.ParseShortName(names[i]);
                names[i] = $"{shortName}.{extension}";
            }
            return names;
        }
        #endregion

        #region parse short name
        private (string,string) ParseShortName(string fullName)
        {
            var lastSegment = fullName.EndsWith(".htt") ? 2 : 1;

            var segments = fullName.Split('.');
            var shortName = string.Join('.', segments.Skip(5).Take(segments.Length - (5 + lastSegment)));

            var extension = segments[segments.Length - lastSegment];

            return (shortName, extension);
        }
        #endregion

        #region get template
        public Resource GetTemplate(string shortName)
        {
            string fullName = $"HatTrick.DbEx.Tools.Resources.Templates.{shortName}.htt";
            return this.Get(fullName);
        }
        #endregion

        #region get template partial
        public Resource GetTemplatePartial(string shortName)
        {
            string fullName = $"HatTrick.DbEx.Tools.Resources.Templates.Partials.{shortName}.htt";
            return this.Get(fullName);
        }
        #endregion

        #region get
        public Resource Get(string fullName)
        {
            Assembly assem = Assembly.GetExecutingAssembly();

            var (shortName, extension) = this.ParseShortName(fullName);

            string output = null;
            using (Stream stream = assem.GetManifestResourceStream(fullName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    output = reader.ReadToEnd();
                }
            }
            var resource = new Resource()
            {
                Name = shortName,
                FullName = fullName,
                Value = output,
                Extension = extension.StartsWith("_") ? extension.Substring(1) : extension
            };
            return resource;
        }
        #endregion
    }
    #endregion

    #region resource
    public class Resource
    {
        #region interface
        public string Name { get; set; }

        public string FullName { get; set; }

        public string Value { get; set; }

        public string Extension { get; set; }
        #endregion
    }
    #endregion
}