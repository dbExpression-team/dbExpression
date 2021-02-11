﻿using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ByteArrayFieldExpression<TEntity> : ByteArrayFieldExpression,
        IEquatable<ByteArrayFieldExpression<TEntity>>
        where TEntity : class, IDbEntity
    {
        #region constructors
        public ByteArrayFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override ByteArrayElement As(string alias)
            => new ByteArraySelectExpression(this).As(alias);
        #endregion

        #region in value set
        public override FilterExpressionSet In(params byte[][] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new LiteralExpression<byte[][]>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<byte[]> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new LiteralExpression<IEnumerable<byte[]>>(value), FilterExpressionOperator.None)) : null;
        #endregion

        #region equals
        public bool Equals(ByteArrayFieldExpression<TEntity> obj)
            => obj is ByteArrayFieldExpression<TEntity> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ByteArrayFieldExpression<TEntity> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
