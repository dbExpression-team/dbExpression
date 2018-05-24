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

            var p = dbo.Physician;

            db.Insert(physician).Into(p);

            db.Insert(new Physician() { Id = 3 }).Into(p);

            db.Select<Physician>().From(p);
            db.Select().From(p);

            db.Select<string>((p.FullName + " " + p.PatientRefId).As("FullName")).From(p);

            db.Update(p.FullName.Set("Jorge"), p.PatientRefId.Set("111221212")).From(p).Where(p.Id == 3);

            db.Delete().From(p).Where(p.Id == 3);
        }

        #region db
        public static class db
        {
            #region builder selectors
            public static IFromEntitySelector<T> Select<T>(params DBExpressionField[] fields)
            {
                return new EntitySelector<T>();
            }

            public static IFromEntitySelector<T> Select<T>(DBSelectExpression select)
            {
                return new EntitySelector<T>();
            }

            public static IFromEntitySelector Select()
            {
                return new EntitySelector();
            }

            public static IIntoEntitySelector<T> Insert<T>(T record)
            {
                return new EntitySelector<T>();
            }

            public static IFromEntitySelector Update(params DBAssignmentExpression[] assignmentExpressions)
            {
                return new EntitySelector();
            }

            public static IFromEntitySelector Delete()
            {
                return new EntitySelector();
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

        #region physician
        public class Physician// : I32BitIdentityDBEntity
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

        #region physician entity
        public class PhysicianEntity<T> : DBExpressionEntity<T> where T : Physician
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
                DBInsertExpressionSet expr = null;
                expr &= _patientReportId.Insert(physician.PatientReportId);
                expr &= _fullName.Insert(physician.FullName);
                expr &= _facility.Insert(physician.Facility);
                expr &= _patientRefId.Insert(physician.PatientRefId);
                expr &= _createdAt.Insert(physician.CreatedAt);
                return expr;
            }

            public override void FillObject(T physician, object[] values)
            {
                //if the column allows null, do the dbnull check, else just cast in..???
                physician.Id = (int)values[0];
                physician.PatientReportId = (int)values[1];
                physician.FullName = (string)values[2];
                physician.Facility = (string)values[3];
                physician.PatientRefId = (values[4] != DBNull.Value) ? (string)values[4] : default(string);
                physician.CreatedAt = DateTime.SpecifyKind((DateTime)values[5], DateTimeKind.Utc);
            }
            #endregion
        }
        #endregion
    }
}
