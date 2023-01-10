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
    public class DataReaderWrapper : ISqlRowReader
    {
        #region internals
        private bool disposed;
        private int currentRowIndex = -1;
        private FieldTemplatedValueConverterProviderDecorator? templatedValueConverterProvider;
        protected ISqlConnection SqlConnection { get; private set; }
        protected IDataReader DataReader { get; private set; }
        protected IValueConverterProvider Converters { get; private set; }
        #endregion

        #region constructors
        public DataReaderWrapper(ISqlConnection sqlConnection, IDataReader dataReader, IValueConverterProvider converters)
        {
            SqlConnection = sqlConnection ?? throw new ArgumentNullException(nameof(dataReader));
            DataReader = dataReader ?? throw new ArgumentNullException(nameof(dataReader));
            Converters = converters ?? throw new ArgumentNullException(nameof(converters));
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
                    var row = new ISqlField[DataReader.FieldCount];
                    var values = new object[DataReader.FieldCount];
                    DataReader.GetValues(values);
                    for (int i = 0; i < values.Length; i++)
                    {
                        row[i] = new Field(
                            ref i,
                            DataReader.GetName(i),
                            DataReader.GetFieldType(i),
                            values[i],
                            templatedValueConverterProvider ??= new FieldTemplatedValueConverterProviderDecorator(row, Converters)
                        );
                    }
                    return new Row(ref currentRowIndex, row);
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

        #region classes
        private readonly struct TypeDictionaryKey : IEquatable<TypeDictionaryKey>
        {
            #region interface
            public readonly IntPtr Ptr;
            #endregion

            #region constructors
            public TypeDictionaryKey(IntPtr key) => Ptr = key;
            #endregion

            #region methods
            public bool Equals(TypeDictionaryKey other)
                => Ptr == other.Ptr;

            public override int GetHashCode() => Ptr.GetHashCode();

            public override bool Equals(object? obj)
                => obj is TypeDictionaryKey other && Equals(other);
            #endregion
        }
        #endregion
    }
}
