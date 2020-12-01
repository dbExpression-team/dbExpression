using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssemblyContext
    {
        #region internals
        private readonly Stack<FieldExpressionAppendStyle> fieldStyles = new Stack<FieldExpressionAppendStyle>();
        private readonly Stack<EntityExpressionAppendStyle> entityStyles = new Stack<EntityExpressionAppendStyle>();
        private readonly Stack<FieldExpression> fields = new Stack<FieldExpression>();
        private readonly IDictionary<Type,object> state = new ConcurrentDictionary<Type,object>();
        #endregion

        #region interface
        public SqlStatementAssemblerConfiguration Configuration { get; set; } = new SqlStatementAssemblerConfiguration();
        public FieldExpression Field => fields.FirstOrDefault(f => f is object);
        public FieldExpressionAppendStyle FieldExpressionAppendStyle => fieldStyles.FirstOrDefault();
        public EntityExpressionAppendStyle EntityExpressionAppendStyle => entityStyles.FirstOrDefault();
        #endregion

        #region constructors
        public AssemblyContext(SqlStatementAssemblerConfiguration configuration)
        {
            //set defaults
            fieldStyles.Push(FieldExpressionAppendStyle.None);
            entityStyles.Push(EntityExpressionAppendStyle.None);
            Configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }
        #endregion

        #region methods
        public void PushAppendStyles(EntityExpressionAppendStyle entityAppendStyle, FieldExpressionAppendStyle fieldAppendStyle)
        {
            entityStyles.Push(entityAppendStyle);
            fieldStyles.Push(fieldAppendStyle);
        }

        public void PushAppendStyle(FieldExpressionAppendStyle fieldAppendStyle)
            => fieldStyles.Push(fieldAppendStyle);

        public void PushAppendStyle(EntityExpressionAppendStyle entityAppendStyle)
            => entityStyles.Push(entityAppendStyle);

        public void PushField(FieldExpression field)
            => fields.Push(field);

        public void PopAppendStyles()
        {
            if (entityStyles.Any())
                entityStyles.Pop();
            if (fieldStyles.Any())
                fieldStyles.Pop();
        }

        public void PopField()
            => fields.Pop();

        public void SetState<T>()
            where T : class, new()
            => this.state.Add(typeof(T), new T());

        public void SetState<T>(T state)
            where T : class
            => this.state.Add(typeof(T), state);

        public T GetState<T>()
            where T : class
        {
            if (state.TryGetValue(typeof(T), out var s))
                return s as T;
            return default;
        }

        public T RemoveState<T>()
            where T : class
        {
            var existing = GetState<T>();
            if (existing is object)
                state.Remove(typeof(T));
            return existing;
        }
        #endregion
    }
}
