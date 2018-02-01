using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using HTL.DbEx.Utility;

namespace HTL.DbEx.ObjectMap
{
    public abstract class Field
    {
        #region internals
        private string _name;
        private Type _assemblyType;
        private Type _assemblyTypeOverride;
        private string _unknownAssemblyTypeOverride;
        private bool _isIdentity;
        private string _sqlType;
        private bool _isIgnored;
        private bool _isRequired;
        private int? _maxLength;
        private int? _precision;
        private int? _scale;
        private List<Relationship> _relationships;
        private bool _isComputed;
        #endregion

        #region interface properties
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

        public Type AssemblyType
        {
            get { return _assemblyType; }
            protected set { _assemblyType = value; }
        }

        public Type AssemblyTypeOverride
        {
            get { return _assemblyTypeOverride; }
            protected set { _assemblyTypeOverride = value; }
        }

        public string UnknownAssemblyTypeOverride
        {
            get { return _unknownAssemblyTypeOverride; }
            protected set { _unknownAssemblyTypeOverride = value; }
        }

        public string AssemblyTypeShorthandText
        {
            get
            {
                return (_assemblyTypeOverride != null)
                    ? TypeUtility.GetAssemblyTypeShorthandText(this.AssemblyTypeOverride)
                    : (_unknownAssemblyTypeOverride != null)
                        ? _unknownAssemblyTypeOverride
                        : TypeUtility.GetAssemblyTypeShorthandText(this.AssemblyType);
            }
        }

        public bool IsIdentity
        {
            get
            {
                return _isIdentity;
            }
            protected set
            {
                _isIdentity = value;
            }
        }

        public string SqlTypeDefinition
        {
            get { return _sqlType; }
            protected set { _sqlType = value; }
        }

        public bool IsIgnored
        {
            get { return _isIgnored; }
            protected set { _isIgnored = value; }
        }

        public bool IsRequired
        {
            get { return _isRequired; }
            protected set { _isRequired = value; }
        }

        public int? MaxLength
        {
            get { return _maxLength; }
            protected set { _maxLength = value; }
        }

        public int? Precision
        {
            get { return _precision; }
            protected set { _precision = value; }
        }

        public int? Scale
        {
            get { return _scale; }
            protected set { _scale = value; }
        }

        public bool IsForeignKey
        {
            get { return _relationships.Count > 0; }
        }

        public bool IsRangeable
        {
            get
            {
                return TypeUtility.IsRangeableType(_assemblyType);
            }
        }

        public bool IsSizeConstrictable
        {
            get
            {
                return TypeUtility.IsSizeConstrictableType(_assemblyType);
            }
        }

        public bool SupportsPrecisionAndScale
        {
            get
            {
                return TypeUtility.IsFloatingPointType(_assemblyType);
            }
        }

        public List<Relationship> Relationships
        {
            get
            {
                return _relationships;
            }
        }

        public bool IsComputed
        {
            get { return _isComputed; }
            protected set { _isComputed = value; }
        }

        public string AttributeDefinitions
        { get; protected set; }
        #endregion

        #region constructors
        public Field()
        {
            _relationships = new List<Relationship>();
        }
        #endregion

        #region methods
        public void AddRelationship(Relationship relationship)
        {
            _relationships.Add(relationship);
        }

        public override string ToString()
        {
            return _name;
        }
        #endregion
    }
}
