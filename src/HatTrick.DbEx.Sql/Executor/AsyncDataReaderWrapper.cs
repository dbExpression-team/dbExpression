using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public class AsyncDataReaderWrapper : IAsyncSqlRowReader
    {
        #region internals
        private bool disposed;
        private int currentRowIndex;
        protected SqlConnection SqlConnection { get; private set; }
        protected DbDataReader DataReader { get; private set; }
        protected CancellationToken CancellationToken { get; private set; }
        #endregion

        #region constructors
        public AsyncDataReaderWrapper(SqlConnection sqlConnection, DbDataReader dataReader) : this(sqlConnection, dataReader, CancellationToken.None) { }

        public AsyncDataReaderWrapper(SqlConnection sqlConnection, DbDataReader dataReader, CancellationToken ct)
        {
            SqlConnection = sqlConnection;
            DataReader = dataReader;
            CancellationToken = ct == null ? CancellationToken.None : ct;
            CancellationToken.Register(() => Dispose(true));
        }
        #endregion

        #region methods
        public async Task<ISqlRow> ReadRowAsync()
        {
            CancellationToken.ThrowIfCancellationRequested();

            try
            {

                if (await DataReader.ReadAsync())
                {
                    var row = new ISqlField[DataReader.FieldCount];
                    var values = new object[DataReader.FieldCount];
                    DataReader.GetValues(values);
                    for (int i = 0; i < values.Length; i++)
                    {
                        row[i] = new Field(i, DataReader.GetName(i), values[i] == DBNull.Value ? null : values[i]);
                    }
                    return new Row(currentRowIndex++, row);
                }
                //asking for a row and the reader has finished, proactively shut everything down.
                DataReader.Close();
                if (!SqlConnection.IsTransactional)
                    SqlConnection.Disconnect();
            }
            catch
            {
                if (DataReader != null && !DataReader.IsClosed)
                    DataReader.Close(); //redundant, but required for sqlCe before rollback...

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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (DataReader != null)
                    {
                        if (!DataReader.IsClosed)
                            DataReader.Close();
                        DataReader.Dispose();
                    }
                    if (SqlConnection != null)
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

        public void Dispose() => Dispose(true);
        #endregion
    }
}
