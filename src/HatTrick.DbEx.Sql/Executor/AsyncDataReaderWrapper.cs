using HatTrick.DbEx.Sql.Connection;
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
        protected ISqlConnection SqlConnection { get; private set; }
        protected DbDataReader DataReader { get; private set; }
        protected CancellationToken CancellationToken { get; private set; }
        protected IValueConverterFinder Converters { get; private set; }
        #endregion

        #region constructors
        public AsyncDataReaderWrapper(ISqlConnection sqlConnection, DbDataReader dataReader, IValueConverterFinder converters) : this(sqlConnection, dataReader, converters, CancellationToken.None) { }

        public AsyncDataReaderWrapper(ISqlConnection sqlConnection, DbDataReader dataReader, IValueConverterFinder converters, CancellationToken ct)
        {
            SqlConnection = sqlConnection;
            DataReader = dataReader;
            CancellationToken = ct == null ? CancellationToken.None : ct;
            Converters = converters;
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
                DataReader.Close();
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
            if (DataReader is object)
            {
                if (!DataReader.IsClosed)
                    DataReader.Close();

                DataReader.Dispose();
                DataReader = null;
            }
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
