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

using System;
using TinyIoC;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class TinyIoCServiceProvider : IServiceProvider
    {
        private readonly TinyIoCContainer _container;

        public TinyIoCServiceProvider(TinyIoCContainer container)
        { 
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public object? GetService(Type serviceType)
        {
            if (_container.TryResolve(serviceType, out object? it))
            {
                return it;
            }
            return null;
        }
    }
}
