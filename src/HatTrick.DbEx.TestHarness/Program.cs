using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Executor;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using db = HatTrick.DbEx.MsSql.Builder.MsSqlExpressionBuilder;

namespace HatTrick.DbEx.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            DbExpressionConfiguration.ConnectionStringSettings = new List<ConnectionStringSettings> { ConfigurationManager.ConnectionStrings["cq.genres"] };
            var factory = new MsSqlStatementBuilderFactory();
            factory.RegisterDefaultAssemblers();
            factory.RegisterDefaultPartAssemblers();
            factory.RegisterDefaultValueFormatters();
            DbExpressionConfiguration.StatementBuilderFactory = factory;
            DbExpressionConfiguration.ParameterBuilderFactory = new MsSqlParameterBuilderFactory();

            var executor = new MsSqlExecutorFactory();
            executor.RegisterDefaultExecutors();

            DbExpressionConfiguration.ExecutorFactory = executor;
            DbExpressionConfiguration.ConnectionFactory = new MsSqlConnectionFactory();
            DbExpressionConfiguration.AssemblerConfiguration.Minify = false;

            var mapperFactory = new MapperFactory();
            mapperFactory.RegisterDefaultMaps();
            DbExpressionConfiguration.MapperFactory = mapperFactory;

            //MySchema.Test();


            Physician physician = new Physician()
            {
                PatientReportId = 304,
                FullName = "John Jones",
                PatientRefId = "1111",
                Facility = "Primary",
                CreatedAt = DateTime.Now
            };

            

            //Action<Physician, object[]> f = kai.Physician.FillObject;

            var pr = kai.PatientReport;
            var p = kai.Physician;
            var aliasedPr = kai.PatientReport.As("pr");
            var aliasedP = kai.Physician.As("p");

            db.SelectAll(
                    aliasedP.Id, 
                    aliasedP.FullName, 
                    aliasedPr.ExternalId
                )
                .Distinct()
                .From(aliasedP)
                .InnerJoin(
                    db.SelectAll(aliasedPr.Id, aliasedPr.ExternalId)
                    .From(aliasedPr)
                    .Where(aliasedPr.ExternalId.Like("Foo%"))
                ).On(aliasedP.Id == aliasedPr.Id)
                .Skip(0)
                .Limit(100)
                .OrderBy(aliasedP.FullName.Asc, aliasedPr.ExternalId.Asc)
                .Execute();

            db.SelectAll(aliasedP.Id, aliasedP.FullName, aliasedPr.ExternalId)
                .Distinct()
                .From(aliasedP)
                .InnerJoin(aliasedPr).On(aliasedP.Id == aliasedPr.Id)
                .Where(aliasedPr.ExternalId.Like("Foo%"))
                .Skip(0)
                .Limit(100)
                .OrderBy(aliasedP.FullName.Asc, aliasedPr.ExternalId.Asc)
                .Execute();


            var exp = db.Select(p.Id, p.FullName).From(p);
            exp.InnerJoin(pr).On(p.Id == pr.Id);
            exp.Where(pr.ExternalId.Like("Foo%"));
            var data = exp.Execute();

            db.Select<Physician>().From(p).Where(p.Id == 1).Execute();

            SelectExpression s = new SelectExpression((FieldExpression)null);
            

            //DBFilterExpressionSet set = p.Id > 100;
            //set.
            IList<PatientReport> rpts = db.SelectAll<PatientReport>()
                                          .From(aliasedPr)
                                          .InnerJoin(aliasedP).On(aliasedP.PatientReportId == aliasedPr.Id)
                                          .Where(aliasedP.Id > 100)
                                          .OrderBy(aliasedPr.SampleId.Desc)
                                          .Skip(1).Limit(1)

                                          .Execute();




            IList<dynamic> sss = db.SelectAll(kai.Physician.FullName, kai.Physician.Id).From(p).Execute();

            IList<int> ids = db.SelectAll(kai.PatientReport.Id).From(pr).Execute();
            
            int id = db.Select(p.Id).From(p).Where(p.FullName == "HECTOR AMAYA").Execute();

            int e5 = db.Select(p.Id).From(p).Execute();

            var reference = db.Select<string>((p.FullName + " " + p.PatientRefId).As("FullName")).From(p).Execute();

            db.Insert(physician).Into(p).Execute();

            db.Update(p.FullName.Set("Jorge AVC"), p.PatientRefId.Set("111221212")).From(p).Where(p.Id == 1300).Execute();

            db.Delete().From(p).Where(p.Id == 1327).Execute();

            IList<Physician> e9 = db.SelectAll<Physician>().From(p).Where(p.Id > 0).Execute();
        }

        

        #region kai
        public class kai
        {
            #region db expression entities
            private static volatile kaiSchema _kaiSchema;
            private static volatile PhysicianEntity _physician;
            private static volatile PatientReportEntity _patientReport;

            public static PhysicianEntity Physician { get { return _physician == null ? _physician = new PhysicianEntity(_kaiSchema ?? (_kaiSchema = new kaiSchema()), "Physician") : _physician; } }
            public static PatientReportEntity PatientReport { get { return _patientReport == null ? _patientReport = new PatientReportEntity(_kaiSchema ?? (_kaiSchema = new kaiSchema()), "PatientReport") : _patientReport; } }
            #endregion
        }

        public class kaiSchema : SchemaExpression
        {
            public kaiSchema() : base("kai", "cq.genres") { }
        }
        #endregion

        #region patient report entity
        [Serializable]
        public partial class PatientReportEntity : EntityExpression<PatientReport>
        {
            #region internals
            private FieldExpression<int> _id;
            private FieldExpression<int> _sampleId;
            private FieldExpression<string> _externalId;
            private FieldExpression<string> _reportType;
            private FieldExpression<bool> _isCustom;
            private FieldExpression<string> _version;
            private FieldExpression<string> _panel;
            private FieldExpression<int> _heatmapTemplateSetId;
            private FieldExpression<string> _lifestyleFactorSet;
            private FieldExpression<string> _regimenRxCUISet;
            private FieldExpression<string> _regimenSpecificProductIdSet;
            private FieldExpression<string> _iCD10CodeSet;
            private FieldExpression<string> _geneExclusionSet;
            private FieldExpression<bool> _includeMH;
            private FieldExpression<bool> _includePD;
            private FieldExpression<bool> _includeGeneticRiskProfile;
            private FieldExpression<bool?> _includeGeneticRiskProfileRegimen;
            private FieldExpression<bool> _runReports;
            private FieldExpression<bool> _opioidsFlag;
            private FieldExpression<string> _cQVersion;
            private FieldExpression<int> _methodologyId;
            private FieldExpression<DateTime> _createdAt;
            #endregion

            #region interface properties
            public FieldExpression<int> Id { get { return _id; } }
            public FieldExpression<int> SampleId { get { return _sampleId; } }
            public FieldExpression<string> ExternalId { get { return _externalId; } }
            public FieldExpression<string> ReportType { get { return _reportType; } }
            public FieldExpression<bool> IsCustom { get { return _isCustom; } }
            public FieldExpression<string> Version { get { return _version; } }
            public FieldExpression<string> Panel { get { return _panel; } }
            public FieldExpression<int> HeatmapTemplateSetId { get { return _heatmapTemplateSetId; } }
            public FieldExpression<string> LifestyleFactorSet { get { return _lifestyleFactorSet; } }
            public FieldExpression<string> RegimenRxCUISet { get { return _regimenRxCUISet; } }
            public FieldExpression<string> RegimenSpecificProductIdSet { get { return _regimenSpecificProductIdSet; } }
            public FieldExpression<string> ICD10CodeSet { get { return _iCD10CodeSet; } }
            public FieldExpression<string> GeneExclusionSet { get { return _geneExclusionSet; } }
            public FieldExpression<bool> IncludeMH { get { return _includeMH; } }
            public FieldExpression<bool> IncludePD { get { return _includePD; } }
            public FieldExpression<bool> IncludeGeneticRiskProfile { get { return _includeGeneticRiskProfile; } }
            public FieldExpression<bool?> IncludeGeneticRiskProfileRegimen { get { return _includeGeneticRiskProfileRegimen; } }
            public FieldExpression<bool> RunReports { get { return _runReports; } }
            public FieldExpression<bool> OpioidsFlag { get { return _opioidsFlag; } }
            public FieldExpression<string> CQVersion { get { return _cQVersion; } }
            public FieldExpression<int> MethodologyId { get { return _methodologyId; } }
            public FieldExpression<DateTime> CreatedAt { get { return _createdAt; } }
            #endregion

            #region constructors
            public PatientReportEntity(SchemaExpression schema, string entityName) : this(schema, entityName, null)
            {

            }
            public PatientReportEntity(SchemaExpression schema, string entityName, string aliasName) : base(schema, entityName, aliasName)
            {
                _id = new FieldExpression<int>(this, "Id", 4);
                _sampleId = new FieldExpression<int>(this, "SampleId", 4);
                _externalId = new FieldExpression<string>(this, "ExternalId", 120);
                _reportType = new FieldExpression<string>(this, "ReportType", 25);
                _isCustom = new FieldExpression<bool>(this, "IsCustom", 1);
                _version = new FieldExpression<string>(this, "Version", 20);
                _panel = new FieldExpression<string>(this, "Panel", 40);
                _heatmapTemplateSetId = new FieldExpression<int>(this, "HeatmapTemplateSetId", 4);
                _lifestyleFactorSet = new FieldExpression<string>(this, "LifestyleFactorSet", 250);
                _regimenRxCUISet = new FieldExpression<string>(this, "RegimenRxCUISet", 250);
                _regimenSpecificProductIdSet = new FieldExpression<string>(this, "RegimenSpecificProductIdSet", 250);
                _iCD10CodeSet = new FieldExpression<string>(this, "ICD10CodeSet", 1000);
                _geneExclusionSet = new FieldExpression<string>(this, "GeneExclusionSet", 100);
                _includeMH = new FieldExpression<bool>(this, "IncludeMH", 1);
                _includePD = new FieldExpression<bool>(this, "IncludePD", 1);
                _includeGeneticRiskProfile = new FieldExpression<bool>(this, "IncludeGeneticRiskProfile", 1);
                _includeGeneticRiskProfileRegimen = new FieldExpression<bool?>(this, "IncludeGeneticRiskProfileRegimen", 1);
                _runReports = new FieldExpression<bool>(this, "RunReports", 1);
                _opioidsFlag = new FieldExpression<bool>(this, "OpioidsFlag", 1);
                _cQVersion = new FieldExpression<string>(this, "CQVersion", 15);
                _methodologyId = new FieldExpression<int>(this, "MethodologyId", 4);
                _createdAt = new FieldExpression<DateTime>(this, "CreatedAt", 8);
            }
            #endregion

            #region methods
            public PatientReportEntity As(string alias)
            {
                return new PatientReportEntity(Schema, EntityName, alias);
            }

            public override SelectExpressionSet GetInclusiveSelectExpression()
            {
                SelectExpressionSet select = null;
                select &= _id;
                select &= _sampleId;
                select &= _externalId;
                select &= _reportType;
                select &= _isCustom;
                select &= _version;
                select &= _panel;
                select &= _heatmapTemplateSetId;
                select &= _lifestyleFactorSet;
                select &= _regimenRxCUISet;
                select &= _regimenSpecificProductIdSet;
                select &= _iCD10CodeSet;
                select &= _geneExclusionSet;
                select &= _includeMH;
                select &= _includePD;
                select &= _includeGeneticRiskProfile;
                select &= _includeGeneticRiskProfileRegimen;
                select &= _runReports;
                select &= _opioidsFlag;
                select &= _cQVersion;
                select &= _methodologyId;
                select &= _createdAt;
                return select;
            }

            public override InsertExpressionSet GetInclusiveInsertExpression(PatientReport p)
            {
                InsertExpressionSet expr = null;
                expr &= _sampleId.Insert(p.SampleId);
                expr &= _externalId.Insert(p.ExternalId);
                expr &= _reportType.Insert(p.ReportType);
                expr &= _isCustom.Insert(p.IsCustom);
                expr &= _version.Insert(p.Version);
                expr &= _panel.Insert(p.Panel);
                expr &= _heatmapTemplateSetId.Insert(p.HeatmapTemplateSetId);
                expr &= _lifestyleFactorSet.Insert(p.LifestyleFactorSet);
                expr &= _regimenRxCUISet.Insert(p.RegimenRxCUISet);
                expr &= _regimenSpecificProductIdSet.Insert(p.RegimenSpecificProductIdSet);
                expr &= _iCD10CodeSet.Insert(p.ICD10CodeSet);
                expr &= _geneExclusionSet.Insert(p.GeneExclusionSet);
                expr &= _includeMH.Insert(p.IncludeMH);
                expr &= _includePD.Insert(p.IncludePD);
                expr &= _includeGeneticRiskProfile.Insert(p.IncludeGeneticRiskProfile);
                expr &= _includeGeneticRiskProfileRegimen.Insert(p.IncludeGeneticRiskProfileRegimen);
                expr &= _runReports.Insert(p.RunReports);
                expr &= _opioidsFlag.Insert(p.OpioidsFlag);
                expr &= _cQVersion.Insert(p.CQVersion);
                expr &= _methodologyId.Insert(p.MethodologyId);
                expr &= _createdAt.Insert(p.CreatedAt);
                return expr;
            }

            public override void FillObject(PatientReport p, SqlStatementExecutionResultSet.Row values)
            {
                //if the column allows null, do the dbnull check, else just cast in..???
                p.Id = values.GetValue<int>(0);
                p.SampleId = values.GetValue<int>(1);
                p.ExternalId = values.GetValue<string>(2);
                p.ReportType = values.GetValue<string>(3);
                p.IsCustom = values.GetValue<bool>(4);
                p.Version = values.GetValue<string>(5);
                p.Panel = values.GetValue<string>(6);
                p.HeatmapTemplateSetId = values.GetValue<int>(7);
                p.LifestyleFactorSet = values.GetValue<string>(8);
                p.RegimenRxCUISet = values.GetValue<string>(9);
                p.RegimenSpecificProductIdSet = values.GetValue<string>(10);
                p.ICD10CodeSet = values.GetValue<string>(11);
                p.GeneExclusionSet = values.GetValue<string>(21);
                p.IncludeMH = values.GetValue<bool>(13);
                p.IncludePD = values.GetValue<bool>(14);
                p.IncludeGeneticRiskProfile = values.GetValue<bool>(15);
                p.IncludeGeneticRiskProfileRegimen = values.GetValue<bool?>(16);
                p.RunReports = values.GetValue<bool>(17);
                p.OpioidsFlag = values.GetValue<bool>(18);
                p.CQVersion = values.GetValue<string>(19);
                p.MethodologyId = values.GetValue<int>(20);
                p.CreatedAt = DateTime.SpecifyKind(values.GetValue<DateTime>(21), DateTimeKind.Utc);
            }
            #endregion
        }
        #endregion

        #region physician entity
        [Serializable]
        public class PhysicianEntity : EntityExpression<Physician>
        {
            #region internals
            private FieldExpression<int> _id;
            private FieldExpression<int> _patientReportId;
            private FieldExpression<string> _fullName;
            private FieldExpression<string> _facility;
            private FieldExpression<string> _patientRefId;
            private FieldExpression<DateTime> _createdAt;
            #endregion

            #region interface properties
            public FieldExpression<int> Id { get { return _id; } }
            public FieldExpression<int> PatientReportId { get { return _patientReportId; } }
            public FieldExpression<string> FullName { get { return _fullName; } }
            public FieldExpression<string> Facility { get { return _facility; } }
            public FieldExpression<string> PatientRefId { get { return _patientRefId; } }
            public FieldExpression<DateTime> CreatedAt { get { return _createdAt; } }
            #endregion

            #region constructors
            public PhysicianEntity(SchemaExpression schema, string entityName) : this(schema, entityName, null)
            {

            }

            public PhysicianEntity(SchemaExpression schema, string entityName, string aliasName) : base(schema, entityName, aliasName)
            {
                _id = new FieldExpression<int>(this, "Id", 4);
                _patientReportId = new FieldExpression<int>(this, "PatientReportId", 4);
                _fullName = new FieldExpression<string>(this, "FullName", 100);
                _facility = new FieldExpression<string>(this, "Facility", 100);
                _patientRefId = new FieldExpression<string>(this, "PatientRefId", 30);
                _createdAt = new FieldExpression<DateTime>(this, "CreatedAt", 8);
            }
            #endregion

            #region methods
            public PhysicianEntity As(string alias)
            {
                return new PhysicianEntity(Schema, EntityName, alias);
            }

            public override SelectExpressionSet GetInclusiveSelectExpression()
            {
                SelectExpressionSet select = null;
                select &= _id;
                select &= _patientReportId;
                select &= _fullName;
                select &= _facility;
                select &= _patientRefId;
                select &= _createdAt;
                return select;
            }

            public override InsertExpressionSet GetInclusiveInsertExpression(Physician p)
            {
                InsertExpressionSet expr = null;
                expr &= _patientReportId.Insert(p.PatientReportId);
                expr &= _fullName.Insert(p.FullName);
                expr &= _facility.Insert(p.Facility);
                expr &= _patientRefId.Insert(p.PatientRefId);
                expr &= _createdAt.Insert(p.CreatedAt);
                return expr;
            }

            public override void FillObject(Physician p, SqlStatementExecutionResultSet.Row values)
            {
                //if the column allows null, do the dbnull check, else just cast in..???
                p.Id = values.GetValue<int>(0);
                p.PatientReportId = values.GetValue<int>(1);
                p.FullName = values.GetValue<string>(2);
                p.Facility = values.GetValue<string>(3);
                p.PatientRefId = values.GetValue<string>(4);
                p.CreatedAt = DateTime.SpecifyKind(values.GetValue<DateTime>(5), DateTimeKind.Utc);
            }
            #endregion
        }
        #endregion

        #region physician
        [Serializable]
        public class Physician : I32BitIdentityDbEntity
        {
            #region interface
            public int Id { get; set; }
            public int PatientReportId { get; set; }
            public string FullName { get; set; }
            public string Facility { get; set; }
            public string PatientRefId { get; set; }
            public DateTime CreatedAt { get; set; }
            #endregion

            #region constructor
            public Physician()
            {
                this.CreatedAt = DateTime.Now;
            }
            #endregion
        }
        #endregion

        #region patient report
        [Serializable]
        public partial class PatientReport : I32BitIdentityDbEntity
        {
            #region interface
            public int Id { get; set; }
            public int SampleId { get; set; }
            public string ExternalId { get; set; }
            public string ReportType { get; set; }
            public bool IsCustom { get; set; }
            public string Version { get; set; }
            public string Panel { get; set; }
            public int HeatmapTemplateSetId { get; set; }
            public string LifestyleFactorSet { get; set; }
            public string RegimenRxCUISet { get; set; }
            public string RegimenSpecificProductIdSet { get; set; }
            public string ICD10CodeSet { get; set; }
            public string GeneExclusionSet { get; set; }
            public bool IncludeMH { get; set; }
            public bool IncludePD { get; set; }
            public bool IncludeGeneticRiskProfile { get; set; }
            public bool? IncludeGeneticRiskProfileRegimen { get; set; }
            public bool RunReports { get; set; }
            public bool OpioidsFlag { get; set; }
            public string CQVersion { get; set; }
            public int MethodologyId { get; set; }
            public DateTime CreatedAt { get; set; }
            #endregion

            #region constructor
            public PatientReport()
            {
                this.CreatedAt = DateTime.Now;
            }
            #endregion
        }
        #endregion
    }
}
