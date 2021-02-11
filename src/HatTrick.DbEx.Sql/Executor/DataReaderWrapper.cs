using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Executor
{
    public class DataReaderWrapper : ISqlRowReader
    {
        #region internals
        private bool disposed;
        private int currentRowIndex;
        protected ISqlConnection SqlConnection { get; private set; }
        protected IDataReader DataReader { get; private set; }
        protected IValueConverterFinder Converters { get; private set; }
        #endregion

        #region constructors
        public DataReaderWrapper(ISqlConnection sqlConnection, IDataReader dataReader, IValueConverterFinder converters)
        {
            SqlConnection = sqlConnection;
            DataReader = dataReader;
            Converters = converters;
        }
        #endregion

        #region methods
        public ISqlFieldReader ReadRow()
        {
            try
            {
                if (DataReader.Read())
                {
                    var row = new ISqlField[DataReader.FieldCount];
                    var values = new object[DataReader.FieldCount];
                    DataReader.GetValues(values);
                    for (int i = 0; i < values.Length; i++)
                    {
                        row[i] = new Field(
                            i, 
                            DataReader.GetName(i), 
                            DataReader.GetFieldType(i), 
                            values[i] == DBNull.Value ? null : values[i], 
                            Converters.FindConverter(i) ?? Converters.FindConverter(DataReader.GetFieldType(i))
                        );
                    }
                    return new Row(currentRowIndex++, row);
                }

                //asking for a row and the reader has finished, proactively shut everything down.
                Close();
            }
            catch
            {
                Close();
                throw;
            }

            return null;
        }

        public void Close()
        {
            if (DataReader is object && !DataReader.IsClosed)
                DataReader.Close();

            DataReader.Dispose();
            DataReader = null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    Close();

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
