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

            var e2 = db.Select<Physician>().From(p).Execute();

            var e4 = db.Select<int>(p.Id).From(p);

            var e5 = db.Select<dynamic>(p.Id).From(p);

            var e6 = db.Select<string>((p.FullName + " " + p.PatientRefId).As("FullName")).From(p);

            var e7 = db.Update(p.FullName.Set("Jorge"), p.PatientRefId.Set("111221212")).From(p).Where(p.Id == 3);

            var e8 = db.Delete().From(p).Where(p.Id == 3);

            var e9 = db.SelectAll<Physician>().From(p).Where(p.Id > 0);
        }

        #region db
        public static class db
        {
            public static string ConnectionStringName { get; } = "cquentia";

            #region constructors
            static db()
            {
            }
            #endregion

            #region builder selectors
            public static SelectValueDirective<Y> Select<Y>(params DBExpressionField[] fields)
            {
                return new SelectValueDirective<Y>(ConnectionStringName, fields);
            }

            public static SelectValueDirective<Y> Select<Y>(DBSelectExpression select)
            {
                return new SelectValueDirective<Y>(ConnectionStringName, select);
            }

            public static SelectValueDirective<Y> Select<Y>(DBSelectExpressionSet select)
            {
                return new SelectValueDirective<Y>(ConnectionStringName, select);
            }

            public static SelectManyValueDirective<Y> SelectAll<Y>(params DBExpressionField[] fields)
            {
                return new SelectManyValueDirective<Y>(ConnectionStringName, fields);
            }

            public static SelectManyValueDirective<Y> SelectAll<Y>(DBSelectExpression select)
            {
                return new SelectManyValueDirective<Y>(ConnectionStringName, select);
            }

            public static SelectManyValueDirective<Y> SelectALL<Y>(DBSelectExpressionSet select)
            {
                return new SelectManyValueDirective<Y>(ConnectionStringName, select);
            }

            public static SelectEntityDirective<T> Select<T>() where T : class, IDBEntity, new()
            {
                return new SelectEntityDirective<T>(ConnectionStringName);
            }

            public static SelectManyEntityDirective<T> SelectAll<T>() where T : class, IDBEntity, new()
            {
                return new SelectManyEntityDirective<T>(ConnectionStringName);
            }

            public static DBInsertDirective<T> Insert<T>(T record)
            {
                return new DBInsertDirective<T>(ConnectionStringName, record);
            }

            public static DBUpdateDirective Update(params DBAssignmentExpression[] assignments)
            {
                return new DBUpdateDirective(ConnectionStringName, assignments);
            }

            public static DBDeleteDirective Delete()
            {
                return new DBDeleteDirective(ConnectionStringName);
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
