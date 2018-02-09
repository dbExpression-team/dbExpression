using System;
using System.Collections.Generic;
using HTL.DbEx.Utility;

namespace HTL.DbEx.ObjectMap
{
    public abstract class Field
    {
        #region interface properties
        public string Name { get; set; }

        public Type AssemblyType { get; set; }

        public Type AssemblyTypeOverride { get; set; }

        public string UnknownAssemblyTypeOverride { get; set; }

        public string AssemblyTypeShorthandText
        {
            get
            {
                return (AssemblyTypeOverride != null)
                    ? TypeUtility.GetAssemblyTypeShorthandText(this.AssemblyTypeOverride)
                    : (UnknownAssemblyTypeOverride != null)
                        ? UnknownAssemblyTypeOverride
                        : TypeUtility.GetAssemblyTypeShorthandText(this.AssemblyType);
            }
        }

        public bool IsIdentity { get; set; }

        public string SqlTypeDefinition { get; set; }

        public bool IsIgnored { get; set; }

        public bool IsRequired { get; set; }

        public int? MaxLength { get; set; }

        public int? Precision { get; set; }

        public int? Scale { get; set; }

        public bool IsForeignKey
        {
            get { return Relationships.Count > 0; }
        }

        public bool IsRangeable
        {
            get
            {
                return TypeUtility.IsRangeableType(AssemblyType);
            }
        }

        public bool IsSizeConstrictable
        {
            get
            {
                return TypeUtility.IsSizeConstrictableType(AssemblyType);
            }
        }

        public bool SupportsPrecisionAndScale
        {
            get
            {
                return TypeUtility.IsFloatingPointType(AssemblyType);
            }
        }

        public IList<Relationship> Relationships { get; set; } = new List<Relationship>();
    
        public bool IsComputed { get; protected set; }

        public string AttributeDefinitions { get; protected set; }
        #endregion

        #region constructors
        #endregion

        #region methods
        public void AddRelationship(Relationship relationship) => Relationships.Add(relationship);

        public override string ToString() => Name;
        #endregion
    }
}
