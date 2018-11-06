using System;
using System.Collections.Generic;
using System.Data;

namespace DataService
{
	using Data;
    using Data.dbo;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;

    public static partial class dbo
	{
		#region person total purchases view
		public partial class PersonTotalPurchasesViewEntity : EntityExpression<PersonTotalPurchasesView>
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

            public override void FillObject(SqlStatementExecutionResultSet.Row row, PersonTotalPurchasesView personTotalPurchasesView, IValueMapper mapper)
            {
                personTotalPurchasesView.Id = mapper.Map<int>("PersonTotalPurchasesView.Id", row.Fields[0]);
                personTotalPurchasesView.TotalPurchases = mapper.Map<decimal>("PersonTotalPurchasesView.TotalPurchases", row.Fields[1]);
            }

            public override InsertExpressionSet GetInclusiveInsertExpression(PersonTotalPurchasesView entity)
            {
                //return null?
                throw new NotImplementedException();
            }

            public override AssignmentExpressionSet GetAssignmentExpression(PersonTotalPurchasesView from, PersonTotalPurchasesView to)
            {
                //return null?
                throw new NotImplementedException();
			}
			#endregion
		}
		#endregion
	}
}
