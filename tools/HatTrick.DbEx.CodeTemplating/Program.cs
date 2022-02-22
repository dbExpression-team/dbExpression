using HatTrick.DbEx.CodeTemplating.CodeGenerator;
using HatTrick.DbEx.CodeTemplating.Model;

using generator = HatTrick.DbEx.CodeTemplating.CodeGenerator.CodeGenerator;

namespace HatTrick.DbEx.CodeTemplating
{
    class Program
    {
        private const string templateDirectory = @"Templates\Sql\Expression";
        private const string sqlSrcDirectory = @"src\HatTrick.DbEx.Sql\Expression";
        private const string msSqlSrcDirectory = @"src\HatTrick.DbEx.MsSql\Expression";
        private const string typedFunctionExpressionTemplatePath = @"Templates\Sql\Expression\_Function\TypedFunctionExpression.htt";
        private const string enumFunctionExpressionTemplatePath = @"Templates\Sql\Expression\_Function\EnumFunctionExpression.htt";
        private const string nullableEnumFunctionExpressionTemplatePath = @"Templates\Sql\Expression\_Function\NullableEnumFunctionExpression.htt";
        private const string nullableTypedFunctionExpressionTemplatePath = @"Templates\Sql\Expression\_Function\NullableTypedFunctionExpression.htt";
        private const string msSqlFunctionTemplatePath = @"Templates\Sql\Expression\_Function\FunctionExpression.htt";

        static void Main(string[] args)
        {
            generator.CreateGenerator()
                 //mediator
                .Generate<ExpressionMediatorCodeGenerator, TemplateModel>($@"{templateDirectory}\_Mediator\TypedExpressionMediator.htt", $@"{sqlSrcDirectory}\_Mediator")
                .Generate<NullableExpressionMediatorCodeGenerator, TemplateModel>($@"{templateDirectory}\_Mediator\NullableTypedExpressionMediator.htt", $@"{sqlSrcDirectory}\_Mediator")

                //field
                .Generate<FieldExpressionCodeGenerator, TemplateModel>($@"{templateDirectory}\_Field\TypedFieldExpression.htt", $@"{sqlSrcDirectory}\_Field")
                .Generate<NullableFieldExpressionCodeGenerator, TemplateModel>($@"{templateDirectory}\_Field\NullableTypedFieldExpression.htt", $@"{sqlSrcDirectory}\_Field")

                //alias
                .Generate<AliasExpressionCodeGenerator, TemplateModel>($@"{templateDirectory}\AliasExpression.htt", $@"{sqlSrcDirectory}")

                 //aggregate function
                .Generate<AverageFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Average")
                .Generate<NullableAverageFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Average")

                .Generate<CountFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Count")

                .Generate<MaximumFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Maximum")
                .Generate<NullableMaximumFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Maximum")

                .Generate<MinimumFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Minimum")
                .Generate<NullableMinimumFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Minimum")

                .Generate<PopulationStandardDeviationFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_PopulationStandardDeviation")
                .Generate<NullablePopulationStandardDeviationFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_PopulationStandardDeviation")

                .Generate<PopulationVarianceFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_PopulationVariance")
                .Generate<NullablePopulationVarianceFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_PopulationVariance")

                .Generate<StandardDeviationFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_StandardDeviation")
                .Generate<NullableStandardDeviationFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_StandardDeviation")

                .Generate<SumFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Sum")
                .Generate<NullableSumFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Sum")

                .Generate<VarianceFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Variance")
                .Generate<NullableVarianceFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Variance")

                 //conversion
                .Generate<CastFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Conversion\_Cast")
                .Generate<NullableCastFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Conversion\_Cast")

                .Generate<DateDiffFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Conversion\_DateDiff")
                .Generate<NullableDateDiffFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Conversion\_DateDiff")

                .Generate<DatePartFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Conversion\_DatePart")
                .Generate<NullableDatePartFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Conversion\_DatePart")

                .Generate<LengthFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Conversion\_Length")
                .Generate<NullableLengthFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Conversion\_Length")

                ////data type
                .Generate<CoalesceFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Coalesce")
                .Generate<EnumCoalesceFunctionExpressionCodeGenerator, FunctionTemplateModel>(enumFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Coalesce")
                .Generate<NullableEnumCoalesceFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableEnumFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Coalesce")

                .Generate<ConcatFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Concat")

                .Generate<CurrentTimestampFunctionExpressionCodeGenerator, FunctionTemplateModel>($@"{templateDirectory}\_Function\FunctionExpression.htt", $@"{sqlSrcDirectory}\_Function\_DataType\_CurrentTimestamp")

                .Generate<DateAddFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_DateAdd")
                .Generate<NullableDateAddFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_DateAdd")

                .Generate<IsNullFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_IsNull")
                .Generate<EnumIsNullFunctionExpressionCodeGenerator, FunctionTemplateModel>(enumFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_IsNull")
                .Generate<NullableIsNullFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_IsNull")
                .Generate<NullableEnumIsNullFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableEnumFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_IsNull")

                .Generate<FloorFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Floor")
                .Generate<NullableFloorFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Floor")

                .Generate<CeilingFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Ceil")
                .Generate<NullableCeilingFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Ceil")

                .Generate<TrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Trim")
                .Generate<NullableTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Trim")
                .Generate<LTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_LTrim")
                .Generate<NullableLTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_LTrim")
                .Generate<RTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_RTrim")
                .Generate<NullableRTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_RTrim")

                .Generate<LeftFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Left")
                .Generate<NullableLeftFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Left")
                .Generate<RightFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Right")
                .Generate<NullableRightFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Right")

                .Generate<AbsFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Abs")
                .Generate<NullableAbsFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Abs")

                .Generate<SubstringFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Substring")
                .Generate<NullableSubstringFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Substring")

                .Generate<ReplaceFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Replace")
                .Generate<NullableReplaceFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DataType\_Replace")

                //mssql function
                .Generate<GetDateFunctionExpressionCodeGenerator, FunctionTemplateModel>(msSqlFunctionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_GetDate")
                .Generate<GetUtcDateFunctionExpressionCodeGenerator, FunctionTemplateModel>(msSqlFunctionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_GetUtcDate")
                .Generate<NewIdFunctionExpressionCodeGenerator, FunctionTemplateModel>(msSqlFunctionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_NewId")
                .Generate<SysDateTimeFunctionExpressionCodeGenerator, FunctionTemplateModel>(msSqlFunctionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_SysDateTime")
                .Generate<SysDateTimeOffsetFunctionExpressionCodeGenerator, FunctionTemplateModel>(msSqlFunctionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_SysDateTimeOffset")
                .Generate<SysUtcDateTimeFunctionExpressionCodeGenerator, FunctionTemplateModel>(msSqlFunctionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_SysUtcDateTime")

                .Generate<PatIndexFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_PatIndex")
                .Generate<NullablePatIndexFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_PatIndex")

                .Generate<CharIndexFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_CharIndex")
                .Generate<NullableCharIndexFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_CharIndex")

                .Generate<RoundFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_Round")
                .Generate<NullableRoundFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_Round");

        }
    }
}
