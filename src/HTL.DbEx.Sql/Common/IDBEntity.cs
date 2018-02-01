using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTL.DbEx.Sql
{
    #region identity
    public interface IIdentityDBEntity
    {
    }
    #endregion

    #region 32 bit
    public interface I32BitIdentityDBEntity : IIdentityDBEntity
    {
        int Id { get; set; }
    }
    #endregion

    #region 64 bit
    public interface I64BitIdentityDBEntity : IIdentityDBEntity
    {
        long Id { get; set; }
    }
    #endregion

    #region U 32 bit
    public interface IU32BitIdentityDBEntity : IIdentityDBEntity
    {
        uint Id { get; set; }
    }
    #endregion

    #region U 64 bit
    public interface IU64BitIdentityDBEntity : IIdentityDBEntity
    {
        ulong Id { get; set; }
    }
    #endregion
}
