using HTL.DbEx.MsSql.Assembler;
using HTL.DbEx.MsSql.Connection;
using HTL.DbEx.MsSql.Executor;
using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Assembler;
using HTL.DbEx.Sql.Builder;
using HTL.DbEx.Sql.Executor;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using db = HTL.DbEx.MsSql.Builder.MsSqlBuilder;

namespace HTL.DbEx.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            DBExpressionConfiguration.ConnectionStringSettings = new List<ConnectionStringSettings> { ConfigurationManager.ConnectionStrings["cq.genres"] };
            var assemblerFactory = new MsSqlAssemblerFactory();
            assemblerFactory.RegisterDefaultAssemblers();
            assemblerFactory.RegisterDefaultPartAssemblers();
            assemblerFactory.RegisterDefaultValueFormatters();
            DBExpressionConfiguration.AssemblerFactory = assemblerFactory;
            DBExpressionConfiguration.ParameterBuilderFactory = new MsSqlParameterBuilderFactory();

            var executor = new MsSqlExecutorFactory();
            executor.RegisterDefaultExecutors();

            DBExpressionConfiguration.ExecutorFactory = executor;
            DBExpressionConfiguration.ConnectionFactory = new MsSqlConnectionFactory();
            DBExpressionConfiguration.Minify = false;

            var mapperFactory = new MapperFactory();
            mapperFactory.RegisterDefaultMaps();
            DBExpressionConfiguration.MapperFactory = mapperFactory;

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

            var exp = db.Select(p.Id, p.FullName).From(p);
            exp.InnerJoin(pr).On(p.Id == pr.Id);
            exp.Where(pr.ExternalId.Like("Foo%"));
            var data = exp.Execute();

            db.Select<Physician>().From(p).Where(p.Id == 1).Execute();

            DBSelectExpression s = new DBSelectExpression((DBExpressionField)null);
            

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

        public class kaiSchema : DBExpressionSchema
        {
            public kaiSchema() : base("kai", "cq.genres") { }
        }
        #endregion

        #region patient report entity
        [Serializable]
        public partial class PatientReportEntity : DBExpressionEntity<PatientReport>
        {
            #region internals
            private DBExpressionField<int> _id;
            private DBExpressionField<int> _sampleId;
            private DBExpressionField<string> _externalId;
            private DBExpressionField<string> _reportType;
            private DBExpressionField<bool> _isCustom;
            private DBExpressionField<string> _version;
            private DBExpressionField<string> _panel;
            private DBExpressionField<int> _heatmapTemplateSetId;
            private DBExpressionField<string> _lifestyleFactorSet;
            private DBExpressionField<string> _regimenRxCUISet;
            private DBExpressionField<string> _regimenSpecificProductIdSet;
            private DBExpressionField<string> _iCD10CodeSet;
            private DBExpressionField<string> _geneExclusionSet;
            private DBExpressionField<bool> _includeMH;
            private DBExpressionField<bool> _includePD;
            private DBExpressionField<bool> _includeGeneticRiskProfile;
            private DBExpressionField<bool?> _includeGeneticRiskProfileRegimen;
            private DBExpressionField<bool> _runReports;
            private DBExpressionField<bool> _opioidsFlag;
            private DBExpressionField<string> _cQVersion;
            private DBExpressionField<int> _methodologyId;
            private DBExpressionField<DateTime> _createdAt;
            #endregion

            #region interface properties
            public DBExpressionField<int> Id { get { return _id; } }
            public DBExpressionField<int> SampleId { get { return _sampleId; } }
            public DBExpressionField<string> ExternalId { get { return _externalId; } }
            public DBExpressionField<string> ReportType { get { return _reportType; } }
            public DBExpressionField<bool> IsCustom { get { return _isCustom; } }
            public DBExpressionField<string> Version { get { return _version; } }
            public DBExpressionField<string> Panel { get { return _panel; } }
            public DBExpressionField<int> HeatmapTemplateSetId { get { return _heatmapTemplateSetId; } }
            public DBExpressionField<string> LifestyleFactorSet { get { return _lifestyleFactorSet; } }
            public DBExpressionField<string> RegimenRxCUISet { get { return _regimenRxCUISet; } }
            public DBExpressionField<string> RegimenSpecificProductIdSet { get { return _regimenSpecificProductIdSet; } }
            public DBExpressionField<string> ICD10CodeSet { get { return _iCD10CodeSet; } }
            public DBExpressionField<string> GeneExclusionSet { get { return _geneExclusionSet; } }
            public DBExpressionField<bool> IncludeMH { get { return _includeMH; } }
            public DBExpressionField<bool> IncludePD { get { return _includePD; } }
            public DBExpressionField<bool> IncludeGeneticRiskProfile { get { return _includeGeneticRiskProfile; } }
            public DBExpressionField<bool?> IncludeGeneticRiskProfileRegimen { get { return _includeGeneticRiskProfileRegimen; } }
            public DBExpressionField<bool> RunReports { get { return _runReports; } }
            public DBExpressionField<bool> OpioidsFlag { get { return _opioidsFlag; } }
            public DBExpressionField<string> CQVersion { get { return _cQVersion; } }
            public DBExpressionField<int> MethodologyId { get { return _methodologyId; } }
            public DBExpressionField<DateTime> CreatedAt { get { return _createdAt; } }
            #endregion

            #region constructors
            public PatientReportEntity(DBExpressionSchema schema, string entityName) : this(schema, entityName, null)
            {

            }
            public PatientReportEntity(DBExpressionSchema schema, string entityName, string aliasName) : base(schema, entityName, aliasName)
            {
                _id = new DBExpressionField<int>(this, "Id", 4);
                _sampleId = new DBExpressionField<int>(this, "SampleId", 4);
                _externalId = new DBExpressionField<string>(this, "ExternalId", 120);
                _reportType = new DBExpressionField<string>(this, "ReportType", 25);
                _isCustom = new DBExpressionField<bool>(this, "IsCustom", 1);
                _version = new DBExpressionField<string>(this, "Version", 20);
                _panel = new DBExpressionField<string>(this, "Panel", 40);
                _heatmapTemplateSetId = new DBExpressionField<int>(this, "HeatmapTemplateSetId", 4);
                _lifestyleFactorSet = new DBExpressionField<string>(this, "LifestyleFactorSet", 250);
                _regimenRxCUISet = new DBExpressionField<string>(this, "RegimenRxCUISet", 250);
                _regimenSpecificProductIdSet = new DBExpressionField<string>(this, "RegimenSpecificProductIdSet", 250);
                _iCD10CodeSet = new DBExpressionField<string>(this, "ICD10CodeSet", 1000);
                _geneExclusionSet = new DBExpressionField<string>(this, "GeneExclusionSet", 100);
                _includeMH = new DBExpressionField<bool>(this, "IncludeMH", 1);
                _includePD = new DBExpressionField<bool>(this, "IncludePD", 1);
                _includeGeneticRiskProfile = new DBExpressionField<bool>(this, "IncludeGeneticRiskProfile", 1);
                _includeGeneticRiskProfileRegimen = new DBExpressionField<bool?>(this, "IncludeGeneticRiskProfileRegimen", 1);
                _runReports = new DBExpressionField<bool>(this, "RunReports", 1);
                _opioidsFlag = new DBExpressionField<bool>(this, "OpioidsFlag", 1);
                _cQVersion = new DBExpressionField<string>(this, "CQVersion", 15);
                _methodologyId = new DBExpressionField<int>(this, "MethodologyId", 4);
                _createdAt = new DBExpressionField<DateTime>(this, "CreatedAt", 8);
            }
            #endregion

            #region methods
            public PatientReportEntity As(string alias)
            {
                return new PatientReportEntity(Schema, EntityName, alias);
            }

            public override DBSelectExpressionSet GetInclusiveSelectExpression()
            {
                DBSelectExpressionSet select = null;
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

            public override DBInsertExpressionSet GetInclusiveInsertExpression(PatientReport p)
            {
                DBInsertExpressionSet expr = null;
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

            public override void FillObject(PatientReport p, ResultSet.Row values)
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
        public class PhysicianEntity : DBExpressionEntity<Physician>
        {
            #region internals
            private DBExpressionField<int> _id;
            private DBExpressionField<int> _patientReportId;
            private DBExpressionField<string> _fullName;
            private DBExpressionField<string> _facility;
            private DBExpressionField<string> _patientRefId;
            private DBExpressionField<DateTime> _createdAt;
            #endregion

            #region interface properties
            public DBExpressionField<int> Id { get { return _id; } }
            public DBExpressionField<int> PatientReportId { get { return _patientReportId; } }
            public DBExpressionField<string> FullName { get { return _fullName; } }
            public DBExpressionField<string> Facility { get { return _facility; } }
            public DBExpressionField<string> PatientRefId { get { return _patientRefId; } }
            public DBExpressionField<DateTime> CreatedAt { get { return _createdAt; } }
            #endregion

            #region constructors
            public PhysicianEntity(DBExpressionSchema schema, string entityName) : this(schema, entityName, null)
            {

            }

            public PhysicianEntity(DBExpressionSchema schema, string entityName, string aliasName) : base(schema, entityName, aliasName)
            {
                _id = new DBExpressionField<int>(this, "Id", 4);
                _patientReportId = new DBExpressionField<int>(this, "PatientReportId", 4);
                _fullName = new DBExpressionField<string>(this, "FullName", 100);
                _facility = new DBExpressionField<string>(this, "Facility", 100);
                _patientRefId = new DBExpressionField<string>(this, "PatientRefId", 30);
                _createdAt = new DBExpressionField<DateTime>(this, "CreatedAt", 8);
            }
            #endregion

            #region methods
            public PhysicianEntity As(string alias)
            {
                return new PhysicianEntity(Schema, EntityName, alias);
            }

            public override DBSelectExpressionSet GetInclusiveSelectExpression()
            {
                DBSelectExpressionSet select = null;
                select &= _id;
                select &= _patientReportId;
                select &= _fullName;
                select &= _facility;
                select &= _patientRefId;
                select &= _createdAt;
                return select;
            }

            public override DBInsertExpressionSet GetInclusiveInsertExpression(Physician p)
            {
                DBInsertExpressionSet expr = null;
                expr &= _patientReportId.Insert(p.PatientReportId);
                expr &= _fullName.Insert(p.FullName);
                expr &= _facility.Insert(p.Facility);
                expr &= _patientRefId.Insert(p.PatientRefId);
                expr &= _createdAt.Insert(p.CreatedAt);
                return expr;
            }

            public override void FillObject(Physician p, ResultSet.Row values)
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
        public class Physician : I32BitIdentityDBEntity
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
        public partial class PatientReport : I32BitIdentityDBEntity
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
