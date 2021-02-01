using System;

namespace HatTrick.DbEx.Sql
{
    public abstract class RuntimeEnvironmentSqlDatabase : IRuntimeEnvironmentSqlDatabase
    {
        public IRuntimeSqlDatabase Database { get; private set; }
        public ISqlDatabaseMetadataProvider Metadata { get; private set; }

        protected RuntimeEnvironmentSqlDatabase(IRuntimeSqlDatabase database, ISqlDatabaseMetadataProvider metadata)
        {
            Database = database ?? throw new ArgumentNullException($"{nameof(database)} is required.");
            Metadata = metadata ?? throw new ArgumentNullException($"{nameof(metadata)} is required.");
        }
    }
}
