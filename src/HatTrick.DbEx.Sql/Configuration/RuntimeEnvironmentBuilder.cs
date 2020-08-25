using System;
using System.ComponentModel;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeEnvironmentBuilder : IRuntimeEnvironmentBuilder
    {
        RuntimeSqlDatabaseConfigurationBuilder IRuntimeEnvironmentBuilder.ConfigureSqlDatabase(IRuntimeSqlDatabase database, Action<RuntimeSqlDatabaseConfigurationBuilder> configure)
        {
            database.Configuration = new RuntimeSqlDatabaseConfiguration();
            var builder = new RuntimeSqlDatabaseConfigurationBuilder(database);
            configure?.Invoke(builder);
            return builder;
        }

        #region hide System.Object members

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns> A string that represents the current object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///     Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object. </param>
        /// <returns> <see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///     Serves as the default hash function.
        /// </summary>
        /// <returns> A hash code for the current object. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        #endregion
    }
}
