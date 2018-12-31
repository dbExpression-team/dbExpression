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

        private FieldExpression<int> _id;
        private FieldExpression<decimal?> _totalPurchases;
        #endregion

        #region interface properties
        public FieldExpression<int> Id { get { return _id; } }
        public FieldExpression<decimal?> TotalPurchases { get { return _totalPurchases; } }
        #endregion

        #region constructors
        public PersonTotalPurchasesViewEntity(
            SchemaExpression schema,
            ISqlEntityMetadata entity,
            string alias
        ) : this(
                schema,
                entity,
                new Dictionary<string, ISqlFieldMetadata>
                {
                    { _idFieldName, entity.Fields[_idFieldName]},
                    { _totalPurchasesFieldName, entity.Fields[_totalPurchasesFieldName] }
                },
                alias
        )
        {
        }

        private PersonTotalPurchasesViewEntity(
            SchemaExpression schema,
            ISqlEntityMetadata metadata, 
            IDictionary<string, ISqlFieldMetadata> fields, 
            string alias)
            : base(schema, metadata, fields, alias)
        {
            _id = new FieldExpression<int>(this, Fields[_idFieldName]);
            _totalPurchases = new FieldExpression<decimal?>(this, Fields[_totalPurchasesFieldName]);
        }
        #endregion

        #region methods
        public PersonTotalPurchasesViewEntity As(string name)
        {
            return new PersonTotalPurchasesViewEntity(this.Schema, this.Metadata, this.Fields, name);
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
