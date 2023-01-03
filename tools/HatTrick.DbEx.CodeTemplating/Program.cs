using HatTrick.DbEx.CodeTemplating.CodeGenerator;
using HatTrick.DbEx.CodeTemplating.Model;

using Generator = HatTrick.DbEx.CodeTemplating.CodeGenerator.CodeGenerator;

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
            Generator.CreateGenerator()
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
                .Generate<NullableCountFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Aggregate\_Count")

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

                .Generate<DateDiffFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DateAndTime\_DateDiff")
                .Generate<NullableDateDiffFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DateAndTime\_DateDiff")

                .Generate<DatePartFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DateAndTime\_DatePart")
                .Generate<NullableDatePartFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DateAndTime\_DatePart")

                .Generate<LengthFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Length")
                .Generate<NullableLengthFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Length")

                //mathematical
                .Generate<AbsFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Abs")
                .Generate<NullableAbsFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Abs")

                .Generate<SinFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Sin")
                .Generate<NullableSinFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Sin")

                .Generate<ASinFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_ASin")
                .Generate<NullableASinFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_ASin")

                .Generate<TanFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Tan")
                .Generate<NullableTanFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Tan")

                .Generate<ATanFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_ATan")
                .Generate<NullableATanFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_ATan")

                .Generate<CeilingFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Ceil")
                .Generate<NullableCeilingFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Ceil")

                .Generate<CosFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Cos")
                .Generate<NullableCosFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Cos")

                .Generate<ACosFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_ACos")
                .Generate<NullableACosFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_ACos")

                .Generate<CotFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Cot")
                .Generate<NullableCotFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Cot")

                .Generate<FloorFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Floor")
                .Generate<NullableFloorFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Floor")

                .Generate<SqrtFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Sqrt")
                .Generate<NullableSqrtFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Sqrt")

                .Generate<ExpFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Exp")
                .Generate<NullableExpFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Exp")

                .Generate<LogFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Log")
                .Generate<NullableLogFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Log")

                .Generate<SquareFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Square")
                .Generate<NullableSquareFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Mathematical\_Square")

                .Generate<CoalesceFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Expression\_Coalesce")
                .Generate<NullableCoalesceFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Expression\_Coalesce")
                .Generate<EnumCoalesceFunctionExpressionCodeGenerator, FunctionTemplateModel>(enumFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Expression\_Coalesce")
                .Generate<NullableEnumCoalesceFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableEnumFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Expression\_Coalesce")

                .Generate<ConcatFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Concat")

                .Generate<CurrentTimestampFunctionExpressionCodeGenerator, FunctionTemplateModel>($@"{templateDirectory}\_Function\FunctionExpression.htt", $@"{sqlSrcDirectory}\_Function\_DateAndTime\_CurrentTimestamp")

                .Generate<DateAddFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DateAndTime\_DateAdd")
                .Generate<NullableDateAddFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_DateAndTime\_DateAdd")

                .Generate<IsNullFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Expression\_IsNull")
                .Generate<EnumIsNullFunctionExpressionCodeGenerator, FunctionTemplateModel>(enumFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Expression\_IsNull")
                .Generate<NullableIsNullFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Expression\_IsNull")
                .Generate<NullableEnumIsNullFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableEnumFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_Expression\_IsNull")

                .Generate<TrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Trim")
                .Generate<NullableTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Trim")
                .Generate<LTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_LTrim")
                .Generate<NullableLTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_LTrim")
                .Generate<RTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_RTrim")
                .Generate<NullableRTrimFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_RTrim")

                .Generate<LeftFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Left")
                .Generate<NullableLeftFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Left")
                .Generate<RightFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Right")
                .Generate<NullableRightFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Right")

                .Generate<SubstringFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Substring")
                .Generate<NullableSubstringFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Substring")

                .Generate<ReplaceFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Replace")
                .Generate<NullableReplaceFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{sqlSrcDirectory}\_Function\_String\_Replace")

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
                .Generate<NullableRoundFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_Round")

                .Generate<SoundexFunctionExpressionCodeGenerator, FunctionTemplateModel>(typedFunctionExpressionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_Soundex")
                .Generate<NullableSoundexFunctionExpressionCodeGenerator, FunctionTemplateModel>(nullableTypedFunctionExpressionTemplatePath, $@"{msSqlSrcDirectory}\_Function\_Soundex");
        }
    }
}
