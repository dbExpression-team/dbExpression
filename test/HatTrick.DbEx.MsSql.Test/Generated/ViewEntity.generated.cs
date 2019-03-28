using System;

namespace DataService.EntityExpression.dbo
{
    using Data.dbo;
    using HatTrick.DbEx.MsSql.Expression;
    using HatTrick.DbEx.Sql;
    using HatTrick.DbEx.Sql.Executor;
    using HatTrick.DbEx.Sql.Expression;
    using HatTrick.DbEx.Sql.Mapper;
    using HatTrick.DbEx.Utility;
    using System.Collections.Generic;
    using System.Data;

    #region person total purchases view
    public partial class PersonTotalPurchasesViewEntity : EntityExpression<PersonTotalPurchasesView>
    {
        #region internals
        private const string _idFieldName = "Id";
        private const string _totalPurchasesFieldName = "TotalPurchases";
        #endregion

        #region interface properties
        public Int32FieldExpression<PersonTotalPurchasesView> Id { get { return Fields[_idFieldName].Value as Int32FieldExpression<PersonTotalPurchasesView>; } }
        public NullableDecimalFieldExpression<PersonTotalPurchasesView> TotalPurchases { get { return Fields[_totalPurchasesFieldName].Value as NullableDecimalFieldExpression<PersonTotalPurchasesView>; } }
        #endregion

        #region constructors
        public PersonTotalPurchasesViewEntity(SchemaExpression schema, ISqlEntityMetadata metadata) : this(schema, metadata, null)
        {
        }

        private PersonTotalPurchasesViewEntity(SchemaExpression schema, ISqlEntityMetadata metadata, string alias) : base(schema, metadata, alias)
        {
            Fields.Add(_idFieldName, new Lazy<FieldExpression>(() => new Int32FieldExpression<PersonTotalPurchasesView>(this, metadata.Fields[_idFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_idFieldName}'"), x => x.Id)));
            Fields.Add(_totalPurchasesFieldName, new Lazy<FieldExpression>(() => new NullableDecimalFieldExpression<PersonTotalPurchasesView>(this, metadata.Fields[_totalPurchasesFieldName] ?? throw new DbExpressionConfigurationException($"Configuration for entity '{metadata.Name}' does not contain field metadata for '{_totalPurchasesFieldName}'"), x => x.TotalPurchases)));
        }
        #endregion

        #region methods
        public PersonTotalPurchasesViewEntity As(string name)
        {
            return new PersonTotalPurchasesViewEntity(this.Schema, this.Metadata, name);
        }

        protected override SelectExpressionSet GetInclusiveSelectExpression()
        {
            return new SelectExpressionSet(
                Id,
                TotalPurchases
            );
        }

        protected override void HydrateEntity(PersonTotalPurchasesView personTotalPurchasesView, ISqlFieldReader reader, IValueMapper mapper)
        {
            personTotalPurchasesView.Id = mapper.Map<int>(Id, reader.ReadField());
            personTotalPurchasesView.TotalPurchases = mapper.Map<decimal>(TotalPurchases, reader.ReadField());
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
