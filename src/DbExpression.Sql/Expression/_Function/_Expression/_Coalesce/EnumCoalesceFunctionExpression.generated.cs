#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion


#nullable disable

namespace DbExpression.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class EnumCoalesceFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator EnumExpressionMediator<TEnum>(EnumCoalesceFunctionExpression<TEnum> a) => new(new EnumExpressionMediator<TEnum>(a));
        #endregion

        #region filter operators
        public static FilterExpression<bool?> operator ==(EnumCoalesceFunctionExpression<TEnum> a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(EnumCoalesceFunctionExpression<TEnum> a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(NullElement a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullElement a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);       
        
        public static FilterExpression<bool> operator ==(EnumCoalesceFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<bool>(a, new LiteralExpression<TEnum>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(EnumCoalesceFunctionExpression<TEnum> a, TEnum b) => new FilterExpression<bool>(a, new LiteralExpression<TEnum>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator ==(TEnum a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<bool>(new LiteralExpression<TEnum>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool> operator !=(TEnum a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<bool>(new LiteralExpression<TEnum>(a), b, FilterExpressionOperator.NotEqual);
 
        public static FilterExpression<bool?> operator ==(EnumCoalesceFunctionExpression<TEnum> a, TEnum? b) => new FilterExpression<bool?>(a, new LiteralExpression<TEnum?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(EnumCoalesceFunctionExpression<TEnum> a, TEnum? b) => new FilterExpression<bool?>(a, new LiteralExpression<TEnum?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(TEnum? a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new LiteralExpression<TEnum?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(TEnum? a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new LiteralExpression<TEnum?>(a), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new AliasExpression<TEnum?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, EnumCoalesceFunctionExpression<TEnum> b) => new FilterExpression<bool?>(new AliasExpression<TEnum?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator ==(EnumCoalesceFunctionExpression<TEnum> a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TEnum?>(b), FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(EnumCoalesceFunctionExpression<TEnum> a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<TEnum?>(b), FilterExpressionOperator.NotEqual);
        #endregion
    }
}
