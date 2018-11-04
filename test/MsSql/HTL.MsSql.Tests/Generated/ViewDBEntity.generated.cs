using System;
using System.Collections.Generic;
using System.Data;
using HTL.DbEx.Utility;
using HTL.DbEx.Sql.Expression;

namespace HTL.MsSql.MsSqlTest.dbo.DataService
{
	using Data;

	public static partial class dbo
	{
		#region person total purchases view
		public partial class PersonTotalPurchasesViewEntity : DBExpressionEntity
		{
			#region internals
			private DBExpressionField<int> _id;
			private DBExpressionField<decimal?> _totalPurchases;
			#endregion

			#region interface properties
			public DBExpressionField<int> Id { get { return _id; } }
			public DBExpressionField<decimal?> TotalPurchases { get { return _totalPurchases; } }
			#endregion

			#region constructors
			public PersonTotalPurchasesViewEntity(string schema, string entityName) : base(schema, entityName)
			{
				_id = new DBExpressionField<int>(this, "Id", 4);
				_totalPurchases = new DBExpressionField<decimal?>(this, "TotalPurchases", 17);
			}
			#endregion

			#region methods
			public new PersonTotalPurchasesViewEntity Correlate(string alias)
            {
                return new PersonTotalPurchasesViewEntity(base.Schema, base.Name) { IsCorrelated = true, AliasName = alias };
            }

			public new PersonTotalPurchasesViewEntity As(string alias)
            {
                return new PersonTotalPurchasesViewEntity(base.Schema, base.Name) { IsAliased = true, AliasName = alias };
            }

			public PersonTotalPurchasesView Clone(PersonTotalPurchasesView personTotalPurchasesView)
			{
				return CloneUtility.DeepCopy<PersonTotalPurchasesView>(personTotalPurchasesView);
			}

			public SqlExpressionBuilder<PersonTotalPurchasesView> Query()
			{
				return dbo.GetExpressionBuilder<PersonTotalPurchasesView>(this)
					.WithSelectExpressionProvider(this.GetInclusiveSelectExpression)
					.WithFillCallback(this.FillObject);
			}

			public DBSelectExpressionSet GetInclusiveSelectExpression()
			{
				DBSelectExpressionSet select = null;
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
