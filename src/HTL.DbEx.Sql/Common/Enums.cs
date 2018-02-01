using System;

namespace HTL.DbEx.Sql
{
    #region db command type
    public enum DbCommandType
    {
        Sproc = 0,
        SqlText = 1
    }
    #endregion

    #region sql db client type
    public enum SqlDbClientType
    {
        SqlServer = 0
    }
    #endregion
}