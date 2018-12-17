using System;

namespace DataService.EntityExpression.dbo
{
    using Data.dbo;
    using HatTrick.DbEx.MsSql.Expression;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;
    using HatTrick.DbEx.Utility;
    using System.Data;

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
            _id = new FieldExpression<int>(new MsSqlFieldExpressionMetadata(this, "Id", SqlDbType.Int, 4));
            _totalPurchases = new FieldExpression<decimal?>(new MsSqlFieldExpressionMetadata(this, "TotalPurchases", SqlDbType.Decimal, 12, 2));

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

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                _id,
                _totalPurchases
            );
        }

        protected override void HydrateEntity(PersonTotalPurchasesView personTotalPurchasesView, IFieldReader reader, IValueMapper mapper)
        {
            personTotalPurchasesView.Id = mapper.Map<int>(_id, reader.Read());
            personTotalPurchasesView.TotalPurchases = mapper.Map<decimal>(_totalPurchases, reader.Read());
        }

        protected override InsertExpressionSet GetInclusiveInsertExpression(PersonTotalPurchasesView entity)
        {
            //return null?
            throw new NotImplementedException();
        }

        protected override AssignmentExpressionSet GetAssignmentExpression(PersonTotalPurchasesView from, PersonTotalPurchasesView to)
        {
            //return null?
            throw new NotImplementedException();
        }
        #endregion
    }
    #endregion
}
