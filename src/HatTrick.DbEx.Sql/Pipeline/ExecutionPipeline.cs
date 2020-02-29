using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public abstract class ExecutionPipeline
    {
        protected readonly DatabaseConfiguration Database;

        protected ExecutionPipeline(
            DatabaseConfiguration database
        )
        {
            Database = database ?? throw new DbExpressionConfigurationException($"Database configuration is required, please review and ensure the correct configuration for DbExpression.");
        }

        protected SqlConnection CreateConnection(ExpressionSet expression)
        {
            try
            {
                return Database.ConnectionFactory.CreateSqlConnection();
            }
            catch (Exception e)
            {
                throw new DbExpressionException($"Could not create a connection for entity '{expression.BaseEntity}', please review and ensure the correct configuration and startup initialization for DbExpression.", e);
            }
        }

        protected void ManageValueListReader<T>(ISqlRowReader reader, Action<T> manage)
        {
            var mapper = Database.MapperFactory.CreateValueMapper<T>();

            ISqlRow row;
            while ((row = reader.ReadRow()) != null)
            {
                var field = row.ReadField();
                if (field != null)
                {
                    manage(mapper.Map(field.Value));
                }
            }
        }

        protected async Task ManageValueListReaderWithActionAsync<T>(IAsyncSqlRowReader reader, Action<T> manage, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var mapper = Database.MapperFactory.CreateValueMapper<T>();

            ISqlRow row;
            while ((row = await reader.ReadRowAsync()) != null)
            {
                ct.ThrowIfCancellationRequested();
                var field = row.ReadField();
                if (field != null)
                {
                    manage(mapper.Map(field.Value));
                }
            }
        }

        protected async Task ManageValueListReaderWithFuncAsync<T>(IAsyncSqlRowReader reader, Func<T, Task> manage, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var mapper = Database.MapperFactory.CreateValueMapper<T>();

            ISqlRow row;
            while ((row = await reader.ReadRowAsync()) != null)
            {
                ct.ThrowIfCancellationRequested();
                var field = row.ReadField();
                if (field != null)
                {
                    await manage(mapper.Map(field.Value));
                }
            }
        }

        protected void ManageTypeListReader<T>(ISqlRowReader reader, Action<T> manage, EntityExpression<T> entityExpression)
            where T : class, IDbEntity, new()
        {
            ISqlRow row;
            var mapper = Database.MapperFactory.CreateEntityMapper(entityExpression);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            while ((row = reader.ReadRow()) != null)
            {
                var entity = Database.EntityFactory.CreateEntity<T>();
                mapper.Map(entity, row, valueMapper);
                manage(entity);
            }
        }

        protected async Task ManageTypeListReaderWithActionAsync<T>(IAsyncSqlRowReader reader, EntityExpression<T> entityExpression, Action<T> manage, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            ct.ThrowIfCancellationRequested();
            ISqlRow row;
            var mapper = Database.MapperFactory.CreateEntityMapper(entityExpression);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            while ((row = await reader.ReadRowAsync()) != null)
            {
                ct.ThrowIfCancellationRequested();
                var entity = Database.EntityFactory.CreateEntity<T>();
                mapper.Map(entity, row, valueMapper);
                manage(entity);
            }
        }

        protected async Task ManageTypeListReaderWithFuncAsync<T>(IAsyncSqlRowReader reader, EntityExpression<T> entityExpression, Func<T, Task> manage, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            ct.ThrowIfCancellationRequested();
            ISqlRow row;
            var mapper = Database.MapperFactory.CreateEntityMapper(entityExpression);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            while ((row = await reader.ReadRowAsync()) != null)
            {
                ct.ThrowIfCancellationRequested();
                var entity = Database.EntityFactory.CreateEntity<T>();
                mapper.Map(entity, row, valueMapper);
                await manage(entity);
            }
        }

        protected void ManageTypeReader<T>(ISqlRowReader reader, Action<T> manage, EntityExpression<T> entityExpression)
            where T : class, IDbEntity, new()
        {
            var row = reader.ReadRow();
            if (row == null)
                return;

            var mapper = Database.MapperFactory.CreateEntityMapper(entityExpression);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            var entity = Database.EntityFactory.CreateEntity<T>();

            mapper.Map(entity, row, valueMapper);

            manage(entity);
        }

        protected async Task ManageTypeReaderWithActionAsync<T>(IAsyncSqlRowReader reader, EntityExpression<T> entityExpression, Action<T> manage, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            ct.ThrowIfCancellationRequested();
            var row = await reader.ReadRowAsync();
            if (row == null)
                return;

            var mapper = Database.MapperFactory.CreateEntityMapper(entityExpression);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            var entity = Database.EntityFactory.CreateEntity<T>();

            mapper.Map(entity, row, valueMapper);

            ct.ThrowIfCancellationRequested();
            manage(entity);
        }

        protected async Task ManageTypeReaderWithFuncAsync<T>(IAsyncSqlRowReader reader, EntityExpression<T> entityExpression, Func<T, Task> manage, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            ct.ThrowIfCancellationRequested();
            var row = await reader.ReadRowAsync();
            if (row == null)
                return;

            var mapper = Database.MapperFactory.CreateEntityMapper(entityExpression);
            var valueMapper = Database.MapperFactory.CreateValueMapper();
            var entity = Database.EntityFactory.CreateEntity<T>();

            mapper.Map(entity, row, valueMapper);

            ct.ThrowIfCancellationRequested();
            await manage(entity);
        }

        protected void ManageDynamicListReader(ISqlRowReader reader, Action<ExpandoObject> manage)
        {
            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();

            ISqlRow row;
            while ((row = reader.ReadRow()) != null)
            {
                var value = new ExpandoObject();
                mapper.Map(value, row);
                manage((dynamic)value);
            }
        }

        protected async Task ManageDynamicListReaderWithActionAsync(IAsyncSqlRowReader reader, Action<ExpandoObject> manage, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
            var values = new List<dynamic>();

            ISqlRow row;
            while ((row = await reader.ReadRowAsync()) != null)
            {
                ct.ThrowIfCancellationRequested();
                var value = new ExpandoObject();
                mapper.Map(value, row);
                manage((dynamic)value);
            }
        }

        protected async Task ManageDynamicListReaderWithFuncAsync(IAsyncSqlRowReader reader, Func<ExpandoObject, Task> manage, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
            var values = new List<dynamic>();

            ISqlRow row;
            while ((row = await reader.ReadRowAsync()) != null)
            {
                ct.ThrowIfCancellationRequested();
                var value = new ExpandoObject();
                mapper.Map(value, row);
                await manage((dynamic)value);
            }
        }

        protected void ManageDynamicReader(ISqlRowReader reader, Action<dynamic> manage)
        {
            var value = new ExpandoObject();

            var row = reader.ReadRow();
            if (row == null)
                return;

            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
            mapper.Map(value, row);

            manage((dynamic)value);
        }

        protected async Task ManageDynamicReaderWithActionAsync(IAsyncSqlRowReader reader, Action<ExpandoObject> manage, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var value = new ExpandoObject();

            var row = await reader.ReadRowAsync();
            if (row == null)
                return;

            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
            mapper.Map(value, row);

            ct.ThrowIfCancellationRequested();
            manage((dynamic)value);
        }

        protected async Task ManageDynamicReaderWithFuncAsync(IAsyncSqlRowReader reader, Func<ExpandoObject, Task> manage, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var value = new ExpandoObject();

            var row = await reader.ReadRowAsync();
            if (row == null)
                return;

            var mapper = Database.MapperFactory.CreateExpandoObjectMapper();
            mapper.Map(value, row);

            ct.ThrowIfCancellationRequested();
            await manage((dynamic)value);
        }

        protected void ManageValueReader<T>(ISqlRowReader reader, Action<T> manage)
        {
            var mapper = Database.MapperFactory.CreateValueMapper<T>();
            var field = reader.ReadRow()?.ReadField();
            if (field == null)
                return;

            manage(mapper.Map(field.Value));
        }

        protected async Task ManageValueReaderWithActionAsync<T>(IAsyncSqlRowReader reader, Action<T> manage, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            var mapper = Database.MapperFactory.CreateValueMapper<T>();
            var field = (await reader.ReadRowAsync())?.ReadField();
            if (field == null)
                return;
            var value = mapper.Map(field.Value);
            ct.ThrowIfCancellationRequested();
            manage(value);
        }
    }
}
