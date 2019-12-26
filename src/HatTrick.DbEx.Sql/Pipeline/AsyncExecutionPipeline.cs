using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AsyncExecutionPipeline : ExecutionPipeline
    {
        private AsyncPipeline<BeforeAssemblyContext> BeforeAssembly { get; set; }
        private AsyncPipeline<AfterAssemblyContext> AfterAssembly { get; set; }
        private AsyncPipeline<BeforeInsertContext> BeforeInsert { get; set; }
        private AsyncPipeline<AfterInsertContext> AfterInsert { get; set; }

        public AsyncExecutionPipeline(
            DbExpressionRuntimeConfiguration config,
            DatabaseConfiguration database,
            AsyncPipeline<BeforeAssemblyContext> beforeAssembly,
            AsyncPipeline<AfterAssemblyContext> afterAssembly,
            AsyncPipeline<BeforeInsertContext> beforeInsert,
            AsyncPipeline<AfterInsertContext> afterInsert
        ) : base(config, database)
        {
            BeforeAssembly = beforeAssembly;
            AfterAssembly = afterAssembly;
            BeforeInsert = beforeInsert;
            AfterInsert = afterInsert;
        }

        #region TerminationExpressionBuilder
        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder)
            => await DoExecuteVoidAsync(builder, null, _ => { }, CancellationToken.None);

        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder, SqlConnection connection)
            => await DoExecuteVoidAsync(builder, connection, _ => { }, CancellationToken.None);

        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder, int commandTimeout)
            => await DoExecuteVoidAsync(builder, null, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => await DoExecuteVoidAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder, CancellationToken ct)
            => await DoExecuteVoidAsync(builder, null, _ => { }, ct);

        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder, SqlConnection connection, CancellationToken ct)
            => await DoExecuteVoidAsync(builder, connection, _ => { }, ct);

        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder, int commandTimeout, CancellationToken ct)
            => await DoExecuteVoidAsync(builder, null, c => c.CommandTimeout = commandTimeout, ct);

        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await DoExecuteVoidAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct);

        public async Task ExecuteVoidAsync(ITerminationExpressionBuilder builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await DoExecuteVoidAsync(builder, connection, configureCommand, ct);

        private async Task DoExecuteVoidAsync(ITerminationExpressionBuilder builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await DoExecuteAsync(builder, connection, configureCommand, null, ct);
        #endregion

        #region ValueTerminationExpressionBuilder
        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder)
            => await DoExecuteValueAsync(builder, null, _ => { }, CancellationToken.None);

        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await DoExecuteValueAsync(builder, connection, _ => { }, CancellationToken.None);

        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            => await DoExecuteValueAsync(builder, null, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => await DoExecuteValueAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await DoExecuteValueAsync(builder, null, _ => { }, ct);

        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            => await DoExecuteValueAsync(builder, connection, _ => { }, ct);

        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            => await DoExecuteValueAsync(builder, null, c => c.CommandTimeout = commandTimeout, ct);

        public async Task<T> ExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await DoExecuteValueAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct);

        private async Task<T> DoExecuteValueAsync<T>(IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            T t = default;
            await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageValueReaderWithActionAsync<T>(reader, v => t = v, ct), ct);
            return t;
        }
        #endregion

        #region ValueListTerminationExpressionBuilder
        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder)
            => await DoExecuteValueListAsync(builder, null, _ => { }, CancellationToken.None);

        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await DoExecuteValueListAsync(builder, connection, _ => { }, CancellationToken.None);

        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => await DoExecuteValueListAsync(builder, null, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => await DoExecuteValueListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, null, _ => { }, ct);

        public async Task<IList<T>> ExecuteValueListAsyncExecuteAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, connection, _ => { }, ct);

        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, null, c => c.CommandTimeout = commandTimeout, ct);

        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, connection, _ => { }, ct);

        public async Task<IList<T>> ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct);

        private async Task<IList<T>> DoExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            var list = new List<T>();
            await DoExecuteValueListAsync(builder, connection, configureCommand, t => { list.Add(t); return Task.CompletedTask; }, ct);
            return list;
        }

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, Action<T> onValueMaterialized)
            => await DoExecuteValueListAsync(builder, null, _ => { }, onValueMaterialized, CancellationToken.None);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onValueMaterialized)
            => await DoExecuteValueListAsync(builder, connection, _ => { }, onValueMaterialized, CancellationToken.None);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onValueMaterialized)
            => await DoExecuteValueListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onValueMaterialized, CancellationToken.None);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onValueMaterialized)
            => await DoExecuteValueListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onValueMaterialized, CancellationToken.None);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, Action<T> onValueMaterialized, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, null, _ => { }, onValueMaterialized, ct);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onValueMaterialized, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, connection, _ => { }, onValueMaterialized, ct);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onValueMaterialized, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onValueMaterialized, ct);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onValueMaterialized, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onValueMaterialized, ct);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, Func<T, Task> onValueMaterialized)
            => await DoExecuteValueListAsync(builder, null, _ => { }, onValueMaterialized, CancellationToken.None);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Func<T, Task> onValueMaterialized)
            => await DoExecuteValueListAsync(builder, connection, _ => { }, onValueMaterialized, CancellationToken.None);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Func<T, Task> onValueMaterialized)
            => await DoExecuteValueListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onValueMaterialized, CancellationToken.None);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Func<T, Task> onValueMaterialized)
            => await DoExecuteValueListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onValueMaterialized, CancellationToken.None);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, Func<T, Task> onValueMaterialized, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, null, _ => { }, onValueMaterialized, ct);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Func<T, Task> onValueMaterialized, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, connection, _ => { }, onValueMaterialized, ct);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Func<T, Task> onValueMaterialized, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onValueMaterialized, ct);

        public async Task ExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Func<T, Task> onValueMaterialized, CancellationToken ct)
            => await DoExecuteValueListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onValueMaterialized, ct);

        private async Task DoExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, Action<T> onValueMaterialized, CancellationToken ct)
            => await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageValueListReaderWithActionAsync(reader, onValueMaterialized, ct), ct);

        private async Task DoExecuteValueListAsync<T>(IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, Func<T, Task> onValueMaterialized, CancellationToken ct)
            => await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageValueListReaderWithFuncAsync(reader, onValueMaterialized, ct), ct);
        #endregion

        #region ValueTerminationExpressionBuilder
        public async Task<dynamic> ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => await DoExecuteDynamicAsync(builder, null, _ => { }, CancellationToken.None);

        public async Task<dynamic> ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await DoExecuteDynamicAsync(builder, connection, _ => { }, CancellationToken.None);

        public async Task<dynamic> ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await DoExecuteDynamicAsync(builder, null, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<dynamic> ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => await DoExecuteDynamicAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<dynamic> ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, null, _ => { }, ct);

        public async Task<dynamic> ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, connection, _ => { }, ct);

        public async Task<dynamic> ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, null, c => c.CommandTimeout = commandTimeout, ct);

        public async Task<dynamic> ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct);

        private async Task<dynamic> DoExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            dynamic t = default;
            await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageDynamicReaderWithActionAsync(reader, v => t = v, ct), ct);
            return t;
        }

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, Action<ExpandoObject> onDynamicMaterialized)
            => await DoExecuteDynamicAsync(builder, null, _ => { }, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<ExpandoObject> onDynamicMaterialized)
            => await DoExecuteDynamicAsync(builder, connection, _ => { }, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => await DoExecuteDynamicAsync(builder, null, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => await DoExecuteDynamicAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, null, _ => { }, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, connection, _ => { }, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, null, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await DoExecuteDynamicAsync(builder, null, _ => { }, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await DoExecuteDynamicAsync(builder, connection, _ => { }, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await DoExecuteDynamicAsync(builder, null, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await DoExecuteDynamicAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, null, _ => { }, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, connection, _ => { }, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, null, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, ct);

        private async Task DoExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, Action<ExpandoObject>  onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageDynamicReaderWithActionAsync(reader, onDynamicMaterialized, ct), ct);

        private async Task DoExecuteDynamicAsync(IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageDynamicReaderWithFuncAsync(reader, onDynamicMaterialized, ct), ct);
        #endregion

        #region ValueListTerminationExpressionBuilder
        public async Task<IList<dynamic>> ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => await DoExecuteDynamicListAsync(builder, null, _ => { }, CancellationToken.None);

        public async Task<IList<dynamic>> ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await DoExecuteDynamicListAsync(builder, connection, _ => { }, CancellationToken.None);

        public async Task<IList<dynamic>> ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await DoExecuteDynamicListAsync(builder, null, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<IList<dynamic>> ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => await DoExecuteDynamicListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<IList<dynamic>> ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, null, _ => { }, ct);

        public async Task<IList<dynamic>> ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, connection, _ => { }, ct);

        public async Task<IList<dynamic>> ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, null, c => c.CommandTimeout = commandTimeout, ct);

        public async Task<IList<dynamic>> ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct);

        private async Task<IList<dynamic>> DoExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
        {
            var list = new List<dynamic>();
            await DoExecuteDynamicListAsync(builder, connection, configureCommand, t => { list.Add(t); return Task.CompletedTask; }, ct);
            return list;
        }

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<ExpandoObject> onDynamicMaterialized)
            => await DoExecuteDynamicListAsync(builder, null, _ => { }, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<ExpandoObject> onDynamicMaterialized)
            => await DoExecuteDynamicListAsync(builder, connection, _ => { }, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => await DoExecuteDynamicListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => await DoExecuteDynamicListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, null, _ => { }, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, connection, _ => { }, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await DoExecuteDynamicListAsync(builder, null, _ => { }, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await DoExecuteDynamicListAsync(builder, connection, _ => { }, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await DoExecuteDynamicListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await DoExecuteDynamicListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, CancellationToken.None);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, null, _ => { }, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, connection, _ => { }, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, ct);

        public async Task ExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteDynamicListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onDynamicMaterialized, ct);

        private async Task DoExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageDynamicListReaderWithActionAsync(reader, onDynamicMaterialized, ct), ct);

        private async Task DoExecuteDynamicListAsync(IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageDynamicListReaderWithFuncAsync(reader, onDynamicMaterialized, ct), ct);
        #endregion

        #region TypeTerminationExpressionBuilder
        public async Task<T> ExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeAsync(builder, null, _ => { }, CancellationToken.None);

        public async Task<T> ExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeAsync(builder, connection, _ => { }, CancellationToken.None);

        public async Task<T> ExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeAsync(builder, null, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<T> ExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<T> ExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeAsync(builder, null, _ => { }, ct);

        public async Task<T> ExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeAsync(builder, connection, _ => { }, ct);

        public async Task<T> ExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeAsync(builder, null, c => c.CommandTimeout = commandTimeout, ct);

        public async Task<T> ExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct);

        private async Task<T> DoExecuteTypeAsync<T>(ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            T t = default;
            await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageTypeReaderWithActionAsync(reader, (builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>, v => t = v, ct), ct);
            return t;
        }
        #endregion

        #region TypeListTerminationExpressionBuilder
        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, _ => { }, CancellationToken.None);

        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, _ => { }, CancellationToken.None);

        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, CancellationToken.None);

        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, _ => { }, ct);

        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, _ => { }, ct);

        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, c => c.CommandTimeout = commandTimeout, ct);

        public async Task<IList<T>> ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, ct);

        private async Task<IList<T>> DoExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            var list = new List<T>();
            await DoExecuteTypeListAsync(builder, connection, configureCommand, t => { list.Add(t); return Task.CompletedTask; }, ct);
            return list;
        }

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, _ => { }, onEntityMaterialized, CancellationToken.None);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onEntityMaterialized, CancellationToken.None);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, _ => { }, onEntityMaterialized, CancellationToken.None);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onEntityMaterialized, CancellationToken.None);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, Action<T> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, _ => { }, onEntityMaterialized, ct);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, _ => { }, onEntityMaterialized, ct);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onEntityMaterialized, ct);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onEntityMaterialized, ct);

        private async Task DoExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, Action<T> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageTypeListReaderWithActionAsync(reader, (builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>, onEntityMaterialized, ct), ct);

        private async Task DoExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, Func<T, Task> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteAsync(builder, connection, configureCommand, async reader => await ManageTypeListReaderWithFuncAsync(reader, (builder as IDbExpressionSetProvider).Expression.BaseEntity as EntityExpression<T>, onEntityMaterialized, ct), ct);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, Func<T, Task> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, _ => { }, onEntityMaterialized, CancellationToken.None);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Func<T, Task> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, _ => { }, onEntityMaterialized, CancellationToken.None);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Func<T, Task> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onEntityMaterialized, CancellationToken.None);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Func<T, Task> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onEntityMaterialized, CancellationToken.None);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, Func<T, Task> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, _ => { }, onEntityMaterialized, ct);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Func<T, Task> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, _ => { }, onEntityMaterialized, ct);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Func<T, Task> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, null, c => c.CommandTimeout = commandTimeout, onEntityMaterialized, ct);

        public async Task ExecuteTypeListAsync<T>(ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Func<T, Task> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await DoExecuteTypeListAsync(builder, connection, c => c.CommandTimeout = commandTimeout, onEntityMaterialized, ct);
        #endregion

        private async Task DoExecuteAsync(
            ITerminationExpressionBuilder builder,
            SqlConnection connection,
            Action<DbCommand> configureCommand,
            Func<IAsyncSqlRowReader, Task> transform,
            CancellationToken ct
        )
        {
            if (ct == null)
                throw new ArgumentNullException("Cancellation token cannot be null");

            ct.ThrowIfCancellationRequested();

            var expression = (builder as IDbExpressionSetProvider).Expression;

            //assembly
            await BeforeAssembly.InvokeAsync(new Lazy<BeforeAssemblyContext>(() => new BeforeAssemblyContext(expression)), ct).ConfigureAwait(false);

            var appender = Database.AppenderFactory.CreateAppender();
            var parameterBuilder = Database.ParameterBuilderFactory.CreateSqlParameterBuilder();
            var statementBuilder = Database.StatementBuilderFactory.CreateSqlStatementBuilder(Database.AssemblerConfiguration, expression, appender, parameterBuilder);

            await AfterAssembly.InvokeAsync(new Lazy<AfterAssemblyContext>(() => new AfterAssemblyContext(expression, statementBuilder)), ct).ConfigureAwait(false);

            var statement = statementBuilder.CreateSqlStatement();

            switch (expression.StatementExecutionType)
            {
                case SqlStatementExecutionType.Insert:
                    await BeforeInsert.InvokeAsync(new Lazy<BeforeInsertContext>(() => new BeforeInsertContext(expression, appender, parameterBuilder)), ct).ConfigureAwait(false);
                    break;
                case SqlStatementExecutionType.Update:
                case SqlStatementExecutionType.Delete:
                case SqlStatementExecutionType.SelectOneValue:
                case SqlStatementExecutionType.SelectOneType:
                case SqlStatementExecutionType.SelectOneDynamic:
                case SqlStatementExecutionType.SelectManyValue:
                case SqlStatementExecutionType.SelectManyType:
                case SqlStatementExecutionType.SelectManyDynamic:
                    break;
                default: throw new NotImplementedException($"'{expression.StatementExecutionType}' statement execution type has not been implemented.");
            }

            var executor = Database.ExecutorFactory.CreateSqlStatementExecutor(expression);

            if (connection == null)
                connection = CreateConnection(expression);

            if (transform == null)
            {
                await executor.ExecuteNonQueryAsync(statement, connection, configureCommand, ct);

                switch (expression.StatementExecutionType)
                {
                    case SqlStatementExecutionType.Insert:
                        await AfterInsert.InvokeAsync(new Lazy<AfterInsertContext>(() => new AfterInsertContext(expression, parameterBuilder, Database.MapperFactory)), ct).ConfigureAwait(false);
                        break;
                    case SqlStatementExecutionType.Update:
                    case SqlStatementExecutionType.Delete:
                    case SqlStatementExecutionType.SelectOneValue:
                    case SqlStatementExecutionType.SelectOneType:
                    case SqlStatementExecutionType.SelectOneDynamic:
                    case SqlStatementExecutionType.SelectManyValue:
                    case SqlStatementExecutionType.SelectManyType:
                    case SqlStatementExecutionType.SelectManyDynamic:
                        break;
                    default: throw new NotImplementedException($"'{expression.StatementExecutionType}' statement execution type has not been implemented.");
                }

                return;
            }

            var reader = await executor.ExecuteQueryAsync(statement, connection, configureCommand, ct);
            //run post-execute pipeline, need switch on type to build up correct wrapper; i.e. (new AfterInsertExecutionContext(executionContext, statement)
            if (reader == null)
                return;
            await transform(reader);
        }
    }
}
