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
using System.Data;

namespace HatTrick.DbEx.Sql.Executor
{
    public class DataReaderWrapper : IDisposable, ISqlRowReader, ISqlFieldReader, ISqlField
    {
        #region internals
        private bool disposed;
        private int currentRowIndex = -1;
        private int currentFieldIndex = -1;
        protected ISqlConnection SqlConnection { get; private set; }
        protected IDataReader DataReader { get; private set; }
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
        public DataReaderWrapper(ISqlConnection sqlConnection, IDataReader dataReader, IValueConverterProvider converters)
        {
            SqlConnection = sqlConnection ?? throw new ArgumentNullException(nameof(dataReader));
            DataReader = dataReader ?? throw new ArgumentNullException(nameof(dataReader));
            Converters = converters ?? throw new ArgumentNullException(nameof(converters));
            FieldCount = DataReader.FieldCount;
        }
        #endregion

        #region methods
        public ISqlFieldReader? ReadRow()
        {
            try
            {
                if (!DataReader.IsClosed && DataReader.Read())
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

            return null;
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
            var converter = Converters.FindConverter(index, typeof(T), RawValue)
                ?? throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution<T>());
            return (T)converter.ConvertFromDatabase(RawValue is DBNull ? null : RawValue)!;
        }

        public object? GetValue()
        {
            if (currentFieldIndex == -1)
                throw new InvalidOperationException($"{nameof(ReadField)} must be called prior to accessing field values.");
            var converter = Converters.FindConverter(currentFieldIndex, typeof(object), RawValue)
                ?? throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution<object>());
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
                currentFieldIndex= -1;
                currentRowIndex= -1;
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
