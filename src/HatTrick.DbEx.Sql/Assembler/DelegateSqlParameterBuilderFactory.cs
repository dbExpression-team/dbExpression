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

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateSqlParameterBuilderFactory : ISqlParameterBuilderFactory
    {
        #region internals
        private readonly Func<ISqlParameterBuilder> factory;
        #endregion

        #region constructors
        public DelegateSqlParameterBuilderFactory(Func<ISqlParameterBuilder> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Parameter Builder."); ;
        }

        public DelegateSqlParameterBuilderFactory(Func<ISqlParameterBuilderFactory> factory)
        {
            if (factory is null)
                throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a Sql Parameter Builder.");

            this.factory = () => factory()?.CreateSqlParameterBuilder() ?? throw new DbExpressionException("Cannot create a Sql Parameter Builder: The factory returned a null value.");
        }
        #endregion

        #region methods
        public ISqlParameterBuilder CreateSqlParameterBuilder()
            => factory();
        #endregion
    }
}
