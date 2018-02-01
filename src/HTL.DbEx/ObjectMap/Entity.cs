using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace HTL.DbEx.ObjectMap
{
    public abstract class Entity
    {
        #region internals
        private string _schema;
        private string _name;
        private bool _isIgnored;
        private List<Field> _fields;
        private List<Index> _indexes;
        #endregion

        #region interface properties
        public string Schema
        {
            get
            {
                return _schema;
            }
            protected set
            {
                _schema = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            protected set
            {
                _name = value;
            }
        }

        public bool IsIgnored
        {
            get { return _isIgnored; }
            protected set { _isIgnored = value; }
        }

        public List<Field> Fields
        {
            get
            {
                return _fields;
            }
        }

        public List<Index> Indexes
        {
            get
            {
                return _indexes;
            }
        }
        #endregion

        #region constructors
        public Entity()
        {
            _fields = new List<Field>();
            _indexes = new List<Index>();
        }
        #endregion

        #region methods
        public void AddField(Field f)
        {
            _fields.Add(f);
        }

        public void AddIndex(Index idx)
        {
            _indexes.Add(idx);
        }

        public override string ToString()
        {
            return _name;
        }
        #endregion
    }
}
