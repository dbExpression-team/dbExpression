using System;

namespace DataService
{
    using Data.dbo;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;
    using HatTrick.DbEx.Utility;

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
            private PersonTotalPurchasesViewEntity(EntityExpressionMetadata metadata) : base(metadata)
            {
                _id = new FieldExpression<int>(this, "Id", 4);
                _totalPurchases = new FieldExpression<decimal?>(this, "TotalPurchases", 17);

            }

            public PersonTotalPurchasesViewEntity(SchemaExpression schema, string entityName) : this(new EntityExpressionMetadata(schema, entityName))
            {
            }

            public PersonTotalPurchasesViewEntity(SchemaExpression schema, string entityName, string aliasName) : this(new EntityExpressionMetadata(schema, entityName, aliasName))
            {
            }
            #endregion

            #region methods
            public PersonTotalPurchasesViewEntity As(string name)
            {
                var meta = (this as IExpressionMetadataProvider<EntityExpressionMetadata>).Metadata;
                var newMeta = CloneUtility.DeepCopy(meta);
                newMeta.AliasName = name;
                return new PersonTotalPurchasesViewEntity(newMeta);
            }

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
