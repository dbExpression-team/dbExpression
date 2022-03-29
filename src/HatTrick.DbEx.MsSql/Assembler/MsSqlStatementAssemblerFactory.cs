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

﻿using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Assembler
{
    public class MsSqlStatementAssemblerFactory : SqlStatementAssemblerFactory
    {
        private static readonly MsSqlSelectSqlStatementAssembler selectSqlStatementAssembler = new();
        private static readonly MsSqlInsertSqlStatementAssembler insertManySqlStatementAssembler = new();
        private static readonly MsSqlDeleteSqlStatementAssembler deleteSqlStatementAssembler = new();
        private static readonly MsSqlUpdateSqlStatementAssembler updateSqlStatementAssembler = new();
        private static readonly MsSqlStoredProcedureSqlStatementAssembler storedProcedureSqlStaementAssembler = new();

        #region constructors
        public MsSqlStatementAssemblerFactory()
        {
            RegisterStatementAssembler<SelectQueryExpression, MsSqlSelectSqlStatementAssembler>(selectSqlStatementAssembler);
            RegisterStatementAssembler<InsertQueryExpression, MsSqlInsertSqlStatementAssembler>(insertManySqlStatementAssembler);
            RegisterStatementAssembler<DeleteQueryExpression, MsSqlDeleteSqlStatementAssembler>(deleteSqlStatementAssembler);
            RegisterStatementAssembler<UpdateQueryExpression, MsSqlUpdateSqlStatementAssembler>(updateSqlStatementAssembler);
            RegisterStatementAssembler<StoredProcedureQueryExpression, MsSqlStoredProcedureSqlStatementAssembler>(storedProcedureSqlStaementAssembler);
        }
        #endregion
    }
}
