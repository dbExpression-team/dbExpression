using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace HTL.DbEx.ObjectMap
{
    public abstract class Model
    {
        #region internals
        private List<Entity> _entities;
        #endregion

        #region interface
        public string Name { get; protected set; }

        public List<Entity> Entities
        { get { return _entities; } }
        #endregion

        #region constructors
        public Model()
        {
            _entities = new List<Entity>();
        }
        #endregion

        #region methods
        public void AddEntity(Entity e)
        {
            _entities.Add(e);
        }
        #endregion
    }
}
