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

#nullable enable

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class GuidIsNullFunctionExpression
    {
        #region implicit operators
        public static implicit operator GuidExpressionMediator(GuidIsNullFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region bool



        #endregion
        
        #region byte



        #endregion
        
        #region decimal



        #endregion
        
        #region DateTime



        #endregion
        
        #region DateTimeOffset



        #endregion
        
        #region double



        #endregion
        
        #region float



        #endregion
        
        #region Guid



        #endregion
        
        #region short



        #endregion
        
        #region int



        #endregion
        
        #region long



        #endregion
        
        #region string?



        #endregion
        
        #region TimeSpan



        #endregion
        
        #endregion

        #region fields
        #region bool

        #endregion        
        #region byte

        #endregion        
        #region decimal

        #endregion        
        #region DateTime

        #endregion        
        #region DateTimeOffset

        #endregion        
        #region double

        #endregion        
        #region float

        #endregion        
        #region Guid

        #endregion        
        #region short

        #endregion        
        #region int

        #endregion        
        #region long

        #endregion        
        #region string?

        #endregion        
        #region TimeSpan

        #endregion        
        #endregion

        #region mediators
        #region bool

        #endregion        
        #region byte

        #endregion        
        #region decimal

        #endregion        
        #region DateTime

        #endregion        
        #region DateTimeOffset

        #endregion        
        #region double

        #endregion        
        #region float

        #endregion        
        #region Guid

        #endregion        
        #region short

        #endregion        
        #region int

        #endregion        
        #region long

        #endregion        
        #region string?

        #endregion        
        #region TimeSpan

        #endregion        
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region data types
        #region Guid
        public static FilterExpressionSet operator ==(GuidIsNullFunctionExpression a, Guid b) => new(new FilterExpression<bool>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidIsNullFunctionExpression a, Guid b) => new(new FilterExpression<bool>(a, new LiteralExpression<Guid>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(Guid a, GuidIsNullFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid a, GuidIsNullFunctionExpression b) => new(new FilterExpression<bool>(new LiteralExpression<Guid>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(GuidIsNullFunctionExpression a, Guid? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidIsNullFunctionExpression a, Guid? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<Guid?>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(Guid? a, GuidIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Guid? a, GuidIsNullFunctionExpression b) => new(new FilterExpression<bool?>(new LiteralExpression<Guid?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(GuidIsNullFunctionExpression a, GuidFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidIsNullFunctionExpression a, GuidFieldExpression b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        
        public static FilterExpressionSet operator ==(GuidIsNullFunctionExpression a, NullableGuidFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidIsNullFunctionExpression a, NullableGuidFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(GuidIsNullFunctionExpression a, GuidExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidIsNullFunctionExpression a, GuidExpressionMediator b) => new(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(GuidIsNullFunctionExpression a, NullableGuidExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidIsNullFunctionExpression a, NullableGuidExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(GuidIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidIsNullFunctionExpression a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(GuidIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(GuidIsNullFunctionExpression a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}
