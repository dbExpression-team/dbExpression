using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class AssemblyContext
    {
        #region internals
        private Stack<FieldExpressionAppendStyle> fieldStyles = new Stack<FieldExpressionAppendStyle>();
        private Stack<EntityExpressionAppendStyle> entityStyles = new Stack<EntityExpressionAppendStyle>();
        #endregion

        #region interface
        public DbExpressionAssemblerConfiguration Configuration { get; set; } = new DbExpressionAssemblerConfiguration();
        public FieldExpression Field { get; set; }
        public FieldExpressionAppendStyle FieldExpressionAppendStyle { get; private set; }
        public EntityExpressionAppendStyle EntityExpressionAppendStyle { get; private set; }
        #endregion

        #region constructors
        public AssemblyContext()
        {
            //set default styles
            fieldStyles.Push(FieldExpressionAppendStyle.None);
            entityStyles.Push(EntityExpressionAppendStyle.None);
        }
        #endregion

        #region methods
        public void PushAppendStyles(EntityExpressionAppendStyle entityAppendStyle, FieldExpressionAppendStyle fieldAppendStyle)
        {
            EntityExpressionAppendStyle = entityAppendStyle;
            entityStyles.Push(entityAppendStyle);
            FieldExpressionAppendStyle = fieldAppendStyle;
            fieldStyles.Push(fieldAppendStyle);
        }

        public void PushAppendStyle(FieldExpressionAppendStyle fieldAppendStyle)
            => PushAppendStyles(EntityExpressionAppendStyle, fieldAppendStyle);

        public void PushAppendStyle(EntityExpressionAppendStyle entityAppendStyle)
            => PushAppendStyles(entityAppendStyle, FieldExpressionAppendStyle);

        public void PopAppendStyles()
        {
            PopEntity();
            PopField();
        }        

        private void PopField()
        {
            FieldExpressionAppendStyle = fieldStyles.Pop();
        }

        private void PopEntity()
        {
            EntityExpressionAppendStyle = entityStyles.Pop();
        }
        #endregion
    }
}
