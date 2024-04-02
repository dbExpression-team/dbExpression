#region license
// Copyright (c) dbExpression.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using DbExpression.Sql.Connection;
using DbExpression.Sql.Converter;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DbExpression.Sql.Executor
{
    public class AsyncDataReaderWrapper : IAsyncSqlRowReader, ISqlFieldReader, ISqlField
    {
        #region internals
        private bool disposed;
        private int currentRowIndex = -1;
        private int currentFieldIndex = -1;
        protected ISqlConnection SqlConnection { get; private set; }
        protected DbDataReader DataReader { get; private set; }
        protected CancellationToken CancellationToken { get; private set; }
        protected IValueConverterProvider Converters { get; private set; }
        #endregion

        #region interface
        public int Index => currentRowIndex;
        public int FieldCount { get; init; }
        public int CurrentFieldIndex => currentFieldIndex;
        public string Name => DataReader.GetName(CurrentFieldIndex);
        public Type DataType => DataReader.GetFieldType(CurrentFieldIndex);
        public object RawValue => DataReader.GetValue(CurrentFieldIndex);
        #endregion

        #region constructors
        public AsyncDataReaderWrapper(ISqlConnection sqlConnection, DbDataReader dataReader, IValueConverterProvider converters) : this(sqlConnection, dataReader, converters, CancellationToken.None) { }

        public AsyncDataReaderWrapper(ISqlConnection sqlConnection, DbDataReader dataReader, IValueConverterProvider converters, CancellationToken ct)
        {
            SqlConnection = sqlConnection ?? throw new ArgumentNullException(nameof(dataReader));
            DataReader = dataReader ?? throw new ArgumentNullException(nameof(dataReader));
            CancellationToken = ct;
            Converters = converters ?? throw new ArgumentNullException(nameof(converters));
            CancellationToken.Register(() => Dispose(true));
            FieldCount = DataReader.FieldCount;
        }
        #endregion

        #region methods
        public async Task<ISqlFieldReader?> ReadRowAsync()
        {
            CancellationToken.ThrowIfCancellationRequested();

            try
            {
                if (!DataReader.IsClosed && await DataReader.ReadAsync())
                {
                    currentRowIndex++;
                    currentFieldIndex = -1;
                    return this;
                }
                //asking for a row and the reader has finished, proactively shut everything down.
                Close();
            }
            catch
            {
                Close();
                throw;
            }
            return default;
        }

        public async IAsyncEnumerable<ISqlFieldReader> ReadRowAsyncEnumerable([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            try
            {
                while (await DataReader.ReadAsync())
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    currentRowIndex++;
                    currentFieldIndex = -1;
                    yield return this;
                }
            }
            finally
            {
                Close();
            }
            yield break;
        }

        public ISqlField? ReadField()
        {
            currentFieldIndex++;
            if (currentFieldIndex >= FieldCount)
            {
                currentFieldIndex = -1;
                return null;
            }
            return this;
        }

        public T GetValue<T>()
        {
            return GetValue<T>(CurrentFieldIndex);
        }

        public T GetValue<T>(int index)
        {
            if (index < 0)
                throw new ArgumentException($"{nameof(index)} must be greater than 0.");
            if (index >= FieldCount)
                throw new ArgumentException($"{nameof(index)} must be less than the number of fields.");
            if (currentFieldIndex == -1)
                throw new InvalidOperationException($"{nameof(ReadField)} must be called prior to accessing field values.");
            var converter = Converters.FindConverter(index, typeof(T), RawValue) ?? DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<IValueConverter>();
            return (T)converter.ConvertFromDatabase(RawValue is DBNull ? null : RawValue)!;
        }

        public object? GetValue()
        {
            if (currentFieldIndex == -1)
                throw new InvalidOperationException($"{nameof(ReadField)} must be called prior to accessing field values.");
            var converter = Converters.FindConverter(currentFieldIndex, typeof(object), RawValue) ?? DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<IValueConverter>();
            return converter.ConvertFromDatabase(RawValue is DBNull ? null : RawValue)!;
        }

        public void Close()
        {
            if (DataReader is not null)
            {
                if (!DataReader.IsClosed)
                    DataReader.Close();

                DataReader.Dispose();
                SqlConnection = null!;
                Converters = null!;
                currentFieldIndex = -1;
                currentRowIndex = -1;
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
