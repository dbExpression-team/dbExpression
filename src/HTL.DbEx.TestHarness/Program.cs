using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using HTL.DbEx.Sql;
using HTL.DbEx.MsSql;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.MsSql.Expression;

namespace HTL.DbEx.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Physician physician = new Physician()
            {
                PatientReportId = 1,
                FullName = "John Jones",
                PatientRefId = "1111",
                Facility = "Primary",
                CreatedAt = DateTime.Now
            };

            Action<Physician, object[]> f = dbo.Physician.FillObject;

            PhysicianEntity<Physician> p = dbo.Physician;

            var e1 = db.Insert(physician).Into(p);

            var e2 = db.Insert(new Physician() { Id = 3 }).Into(p);

            var e3 = db.Select<Physician>().From(p);
            var e4 = db.Select().From(p).InnerJoin(p).On(p.Id == p.Id);

            var e5 = db.Select<int>(p.Id).From(p);

            var e6 = db.Select<string>((p.FullName + " " + p.PatientRefId).As("FullName")).From(p);

            var e7 = db.Update(p.FullName.Set("Jorge"), p.PatientRefId.Set("111221212")).From(p).Where(p.Id == 3);

            var e8 = db.Delete().From(p).Where(p.Id == 3);
        }

        #region db
        public static class db
        {
            public static string ConnectionStringName { get; } = "cquentia";

            #region internals
            private static MsSqlExpressionBuilderSelector _selector;
            #endregion

            #region constructors
            static db()
            {
                _selector = new MsSqlExpressionBuilderSelector(ConnectionStringName);
            }
            #endregion

            #region builder selectors
            public static IFromEntitySelector<T> Select<T>(params DBExpressionField[] fields)
            {
                return _selector.Select<T>(fields);
            }

            public static IFromEntitySelector<T> Select<T>(DBSelectExpression select)
            {
                return _selector.Select<T>();
            }

            public static IFromEntitySelector Select()
            {
                return _selector.Select();
            }

            public static IIntoEntitySelector<T> Insert<T>(T record)
            {
                return _selector.Insert<T>(record);
            }

            public static IFromEntitySelector Update(params DBAssignmentExpression[] assignmentExpressions)
            {
                return _selector.Update(assignmentExpressions);
            }

            public static IFromEntitySelector Delete()
            {
                return _selector.Delete();
            }
            #endregion
        }
        #endregion

        #region dbo
        public static class dbo
        {            
            #region db expression entities
            private static PhysicianEntity<Physician> _physician;

            public static PhysicianEntity<Physician> Physician { get { return _physician == null ? _physician = new PhysicianEntity<Physician>("dbo", "Physician") : _physician; } }
            #endregion
        }
        #endregion

        #region physician entity
        public class PhysicianEntity<T> : DBExpressionEntity<T>
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
            public PhysicianEntity(string schema, string entityName) : base(schema, entityName)
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
            //public SqlExpressionBuilder<Physician> Query()
            //{
            //    return kai.GetExpressionBuilder<Physician>(this)
            //        .WithSelectExpressionProvider(this.GetInclusiveSelectExpression)
            //        .WithFillCallback(this.FillObject)
            //        .WithInsertExpressionProvider(this.GetInclusiveInsertExpression);
            //}

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

            public override DBInsertExpressionSet GetInclusiveInsertExpression(T physician)
            {
                Physician p = physician as Physician;
                DBInsertExpressionSet expr = null;
                expr &= _patientReportId.Insert(p.PatientReportId);
                expr &= _fullName.Insert(p.FullName);
                expr &= _facility.Insert(p.Facility);
                expr &= _patientRefId.Insert(p.PatientRefId);
                expr &= _createdAt.Insert(p.CreatedAt);
                return expr;
            }

            public override void FillObject(T physician, object[] values)
            {
                Physician p = physician as Physician;
                //if the column allows null, do the dbnull check, else just cast in..???
                p.Id = (int)values[0];
                p.PatientReportId = (int)values[1];
                p.FullName = (string)values[2];
                p.Facility = (string)values[3];
                p.PatientRefId = (values[4] != DBNull.Value) ? (string)values[4] : default(string);
                p.CreatedAt = DateTime.SpecifyKind((DateTime)values[5], DateTimeKind.Utc);
            }
            #endregion
        }
        #endregion

        #region physician
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
    }
}
