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

using System;

namespace DbExpression.Sql.Expression
{
    public partial class StringExpressionMediator :
        ExpressionMediator<string>,
        StringElement,
        IEquatable<StringExpressionMediator>
    {
        #region constructors
        private StringExpressionMediator()
        {
        }

        public StringExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }
        #endregion

        #region as
        public new StringElement As(string alias)
            => new StringSelectExpression(this, alias);
        #endregion

        #region like
        public FilterExpression Like(string phrase)
            => new FilterExpression<bool>(this, new LikeExpression(phrase), FilterExpressionOperator.None);
        #endregion

        #region equals
        public bool Equals(StringExpressionMediator? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is StringExpressionMediator exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region arithmetic operators
        public static StringExpressionMediator operator +(StringExpressionMediator a, StringExpressionMediator b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae)
            {
                if (ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
                {
                    ae.Expression.Args.Add(b);
                    return a;
                }
            }
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be)
            {
                if (be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
                {
                    be.Expression.Args.Insert(0, a);
                    return b;
                }
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }
        #endregion
    }
}
