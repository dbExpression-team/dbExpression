using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Executor
{
    public class DataReaderWrapper : ISqlRowReader
    {
        #region internals
        private bool disposed;
        private int currentRowIndex;
        protected ISqlConnection SqlConnection { get; private set; }
        protected DbDataReader DataReader { get; private set; }
        protected IValueConverterFinder Converters { get; private set; }
        #endregion

        #region constructors
        public DataReaderWrapper(ISqlConnection sqlConnection, DbDataReader dataReader, IValueConverterFinder converters)
        {
            SqlConnection = sqlConnection;
            DataReader = dataReader;
            Converters = converters;
        }
        #endregion

        #region methods
        public ISqlRow ReadRow()
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

                if (SqlConnection.IsTransactional)
                {
                    SqlConnection.RollbackTransaction();
                }
                else
                {
                    SqlConnection.Disconnect();
                }
                throw;
            }

            return null;
        }

        public void Close()
        {
            if (DataReader is object && !DataReader.IsClosed)
                DataReader.Close();

            if (!SqlConnection.IsTransactional)
                SqlConnection.Disconnect();
        }

		protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (DataReader is object)
                    {
                        if (!DataReader.IsClosed)
                            DataReader.Close();
                        DataReader.Dispose();
                    }
                    if (SqlConnection is object)
                    {
                        if (!SqlConnection.IsTransactional)
                            SqlConnection.Disconnect();
                    }
                }
                DataReader = null;
                SqlConnection = null;
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
