using HatTrick.DbEx.CodeTemplating.Model;
using System;
using System.Collections.Generic;
using HatTrick.DbEx.CodeTemplating.Builder;

namespace HatTrick.DbEx.CodeTemplating.Builder
{
    public class ArithmeticBuilder
    {
        private static readonly ArithmeticOperationTemplateModel add = new ArithmeticOperationTemplateModel { ArithmeticOperatorName = "Add", ArithmeticOperatorSymbol = "+" };
        private static readonly ArithmeticOperationTemplateModel subtract = new ArithmeticOperationTemplateModel { ArithmeticOperatorName = "Subtract", ArithmeticOperatorSymbol = "-" };
        private static readonly ArithmeticOperationTemplateModel multiply = new ArithmeticOperationTemplateModel { ArithmeticOperatorName = "Multiply", ArithmeticOperatorSymbol = "*" };
        private static readonly ArithmeticOperationTemplateModel divide = new ArithmeticOperationTemplateModel { ArithmeticOperatorName = "Divide", ArithmeticOperatorSymbol = "/" };
        private static readonly ArithmeticOperationTemplateModel modulo = new ArithmeticOperationTemplateModel { ArithmeticOperatorName = "Modulo", ArithmeticOperatorSymbol = "%" };

        private IList<ArithmeticOperationTemplateModel> models = new List<ArithmeticOperationTemplateModel>();

        public ArithmeticBuilder InferArithmeticOperations(TypeModel sourceType, TypeModel targetType)
        {
            if (targetType.Type.In(typeof(bool), typeof(Guid)) || sourceType.Type.In(typeof(bool), typeof(Guid)))
            {
                //can't do math on bools or guids
                models = new List<ArithmeticOperationTemplateModel>();
            }
            else if (targetType.Type == typeof(string) && sourceType.Type == typeof(string))
            {
                //can add strings
                models = new List<ArithmeticOperationTemplateModel>
                    {
                        add
                    };
            }
            else if (targetType.Type == typeof(string) || sourceType.Type == typeof(string))
            {
                //can't do arithmetic if only 1 is a string
                models = new List<ArithmeticOperationTemplateModel>();
            }
            else if (targetType.In(typeof(DateTime), typeof(DateTimeOffset)) || sourceType.Type.In(typeof(DateTime), typeof(DateTimeOffset)))
            {
                models = new List<ArithmeticOperationTemplateModel>
                    {
                        add,
                        subtract
                    };
            }
            else
            {
                models = new List<ArithmeticOperationTemplateModel>
                    {
                        add,
                        subtract,
                        multiply,
                        divide,
                        modulo,
                    };
            }
            return this;
        }

        public static TypeModel InferReturnTypeByPrecedence(TypeModel sourceType, TypeModel operationType)
        {
            //precedence matters...

            if (typeof(DateTimeOffset).In(sourceType, operationType))
                return TypeBuilder.Get<DateTimeOffset>();

            if (typeof(DateTime).In(sourceType, operationType))
                return TypeBuilder.Get<DateTime>();

            if (typeof(decimal).In(sourceType, operationType))
                return TypeBuilder.Get<decimal>();

            if (typeof(double).In(sourceType, operationType))
                return TypeBuilder.Get<double>();

            if (typeof(float).In(sourceType, operationType))
                return TypeBuilder.Get<float>();

            if (typeof(long).In(sourceType, operationType))
                return TypeBuilder.Get<long>();

            if (typeof(int).In(sourceType, operationType))
                return TypeBuilder.Get<int>();

            if (typeof(short).In(sourceType, operationType))
                return TypeBuilder.Get<short>();

            return operationType;
        }

        public ArithmeticBuilder AddArithmeticAdd()
        {
            models.Add(add);
            return this;
        }

        public ArithmeticBuilder AddArithmeticSubtract()
        {
            models.Add(subtract);
            return this;
        }

        public IList<ArithmeticOperationTemplateModel> ToList() => models;

        public static ArithmeticBuilder CreateBuilder()
            => new ArithmeticBuilder();
    }
}
