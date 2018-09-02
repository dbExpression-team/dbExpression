using System.Collections.Generic;

namespace HatTrick.DbEx.ObjectMap
{
    public abstract class Model
    {
        #region internals
        #endregion

        #region interface
        public string Name { get; protected set; }

        public IList<Entity> Entities { get; } = new List<Entity>();
        #endregion

        #region constructors
        #endregion

        #region methods
        public void AddEntity(Entity e) => Entities.Add(e);
        #endregion
    }
}
