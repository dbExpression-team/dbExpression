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

﻿using HatTrick.DbEx.Sql.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ArithmeticExpression :
        IExpressionElement,
        IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements>,
        IEquatable<ArithmeticExpression>
    {
        #region internals
        private static readonly Lazy<Dictionary<ArithmeticExpressionOperator, string>> operatorMap = new(() => typeof(ArithmeticExpressionOperator).GetValuesAndArithmeticOperators().ToDictionary(k => k.Key, v => v.Value!));
        private readonly ArithmeticExpressionElements elements;
        #endregion

        #region interface
        ArithmeticExpressionElements IExpressionProvider<ArithmeticExpressionElements>.Expression => elements;
        #endregion

        #region constructors
        public ArithmeticExpression(IExpressionElement leftArg, IExpressionElement rightArg, ArithmeticExpressionOperator arithmeticOperator)
        {
            elements = new ArithmeticExpressionElements(leftArg ?? throw new ArgumentNullException(nameof(leftArg)), rightArg ?? throw new ArgumentNullException(nameof(rightArg)), arithmeticOperator);
        }
        #endregion

        #region to string
        public override string? ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < elements.Args.Count(); i++)
            {
                ArithmeticExpression? isArithmeticExpression = elements.Args[i] as ArithmeticExpression ?? (elements.Args[i] as ExpressionMediator)?.Expression as ArithmeticExpression;
                if (isArithmeticExpression is not null)
                    sb.Append('(');
                sb.Append(elements.Args[i].ToString());
                if (isArithmeticExpression is not null)
                    sb.Append(')');
                if (i < elements.Args.Count - 1)
                {
                    sb.Append(' ');
                    sb.Append(operatorMap.Value[elements.ArithmeticOperator]);
                    sb.Append(' ');
                }
            }
            return sb.ToString();
        }
        #endregion

        #region equals
        public bool Equals(ArithmeticExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (!elements.Equals(obj.elements)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is ArithmeticExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int @base = (int)2166136261;
                const int multiplier = 16777619;

                int hash = @base;
                hash = (hash * multiplier) ^ (elements is not null ? elements.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region implicit operators
        public static ArithmeticExpression operator +(ArithmeticExpression a, ArithmeticExpression? b)
            => Operator(a, b, ArithmeticExpressionOperator.Add);

        public static ArithmeticExpression operator -(ArithmeticExpression a, ArithmeticExpression? b)
            => Operator(a, b, ArithmeticExpressionOperator.Subtract);

        public static ArithmeticExpression operator *(ArithmeticExpression a, ArithmeticExpression? b)
            => Operator(a, b, ArithmeticExpressionOperator.Multiply);

        public static ArithmeticExpression operator /(ArithmeticExpression a, ArithmeticExpression? b)
            => Operator(a, b, ArithmeticExpressionOperator.Divide);

        private static ArithmeticExpression Operator(ArithmeticExpression? a, ArithmeticExpression? b, ArithmeticExpressionOperator expressionOperator)
        {
            if (a is null && b is null) throw new ArgumentNullException(nameof(a));
            if (b is null) return a!;

            if (a!.elements.ArithmeticOperator == b.elements.ArithmeticOperator)
            {
                foreach(var be in b.elements.Args)
                    a.elements.Args.Add(be);
                return a;
            }
            return new ArithmeticExpression(a, b, expressionOperator);
        }
        #endregion

        #region classes
        public class ArithmeticExpressionElements : IExpressionElement, IEquatable<ArithmeticExpressionElements>
        {
            #region interface
            public ArithmeticExpressionOperator ArithmeticOperator { get; set; }
            public IList<IExpressionElement> Args { get; } = new List<IExpressionElement>();
            #endregion

            #region constructors
            public ArithmeticExpressionElements(IExpressionElement leftArg, IExpressionElement? rightArg, ArithmeticExpressionOperator arithmeticOperator)
            {
                ArithmeticOperator = arithmeticOperator;

                Args.Add(leftArg);
                if (rightArg is not null)
                    Args.Add(rightArg);
            }
            #endregion

            #region equals
            public bool Equals(ArithmeticExpressionElements? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (!Args.SequenceEqual(obj.Args)) return false;
                if (ArithmeticOperator != obj.ArithmeticOperator) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is ArithmeticExpressionElements exp && Equals(exp);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int @base = (int)2166136261;
                    const int multiplier = 16777619;

                    int hash = @base;
                    foreach (var exp in Args)
                        hash = (hash * multiplier) ^ (exp is not null ? exp.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ ArithmeticOperator.GetHashCode();
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
