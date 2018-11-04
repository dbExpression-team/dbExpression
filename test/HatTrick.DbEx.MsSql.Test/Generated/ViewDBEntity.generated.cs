using System;
using System.Collections.Generic;
using System.Data;

namespace DataService
{
	using Data;
    using HatTrick.DbEx.Sql.Expression;

    public static partial class dbo
	{
		#region person total purchases view
		public partial class PersonTotalPurchasesViewEntity : EntityExpression
		{
			#region internals
			private FieldExpression<int> _id;
			private FieldExpression<decimal?> _totalPurchases;
			#endregion

			#region interface properties
			public FieldExpression<int> Id { get { return _id; } }
			public FieldExpression<decimal?> TotalPurchases { get { return _totalPurchases; } }
            #endregion

            #region constructors
            public PersonTotalPurchasesViewEntity(SchemaExpression schema, string entityName) : this(schema, entityName, null)
            {
            }

            public PersonTotalPurchasesViewEntity(SchemaExpression schema, string entityName, string aliasName) : base(schema, entityName, aliasName)
			{
				_id = new FieldExpression<int>(this, "Id", 4);
				_totalPurchases = new FieldExpression<decimal?>(this, "TotalPurchases", 17);
			}
			#endregion

			#region methods

			public override SelectExpressionSet GetInclusiveSelectExpression()
			{
				SelectExpressionSet select = null;
           		select &= _id;
           		select &= _totalPurchases;
				return select;
			}

			public void FillObject(PersonTotalPurchasesView personTotalPurchasesView, object[] values)
			{
				//if the column allows null, do the dbnull check, else just cast in..???
				personTotalPurchasesView.Id = (int)values[0];
				personTotalPurchasesView.TotalPurchases = (values[1] != DBNull.Value) ? (decimal)values[1] : default(decimal?);
			}
			#endregion
		}
		#endregion
	}
}
