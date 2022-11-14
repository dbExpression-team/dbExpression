#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using System;
using System.Collections.Generic;
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
        private readonly Dictionary<int, IValueConverter> fieldConverters = new();
        protected ISqlConnection SqlConnection { get; private set; }
        protected DbDataReader DataReader { get; private set; }
        protected CancellationToken CancellationToken { get; private set; }
        protected IValueConverterProvider Converters { get; private set; }
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
        }
        #endregion

        #region methods
        public async Task<ISqlFieldReader?> ReadRowAsync()
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
                            values[i],
                            FindConverter
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
            return default;
        }

        public async IAsyncEnumerable<ISqlFieldReader> ReadRowAsyncEnumerable()
        {
            CancellationToken.ThrowIfCancellationRequested();

            try
            {
                while (await DataReader.ReadAsync())
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
                            values[i],
                            FindConverter
                        );
                    }
                    yield return new Row(currentRowIndex++, row);
                }
                //asking for a row and the reader has finished, proactively shut everything down.
                Close();
            }
            finally
            {
                Close();
            }
        }

        protected IValueConverter? FindConverter(ISqlField field, Type requestedType)
        {
            if (fieldConverters.ContainsKey(field.Index))
                return fieldConverters[field.Index];

            if (requestedType == typeof(object))
                requestedType = field.DataType.IsConvertibleToNullableType() ? typeof(Nullable<>).MakeGenericType(field.DataType) : field.DataType;

            var converter = Converters.FindConverter(field.Index, requestedType, field.RawValue);

            if (converter is not null)
                fieldConverters.Add(field.Index, converter);

            return converter;
        }

        public void Close()
        {
            if (DataReader is not null)
            {
                if (!DataReader.IsClosed)
                    DataReader.Close();

                DataReader.Dispose();
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
