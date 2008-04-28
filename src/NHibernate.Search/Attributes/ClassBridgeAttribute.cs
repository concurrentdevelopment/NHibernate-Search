using System;

namespace NHibernate.Search.Attributes
{
    /// <summary>
    /// This annotation allows a user to apply an implementation
    /// class to a Lucene document to manipulate it in any way
    /// the user sees fit.
    /// </summary>
    /// <remarks>We allow multiple instances of this attribute rather than having a ClassBridgesAttribute as per Java</remarks>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ClassBridgeAttribute : Attribute
    {
        private readonly System.Type impl;
        private readonly object[] parameters;
        private System.Type analyzer;
        private float boost = 1.0F;
        private Index index = Index.Tokenized;
        private string name = null;
        private Store store = Store.No;

        #region Constructors

        public ClassBridgeAttribute(System.Type impl, params object[] parameters)
        {
            this.impl = impl;
            this.parameters = parameters;
        }

        #endregion

        #region Property methods

        /// <summary>
        /// Field name, default to the property name.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Should the value be stored in the document.
        /// defaults to no.
        /// </summary>
        public Store Store
        {
            get { return store; }
            set { store = value; }
        }

        /// <summary>
        /// Defines how the Field should be indexed
        /// defaults to tokenized.
        /// </summary>
        public Index Index
        {
            get { return index; }
            set { index = value; }
        }

        /// <summary>
        /// Define an analyzer for the field, default to
        /// the inherited analyzer.
        /// </summary>
        /// TODO: Java has this as the AnalyzerAttribute - can we do this in .NET?
        public System.Type Analyzer
        {
            get { return analyzer; }
            set { analyzer = value; }
        }

        /// <summary>
        /// A float value of the amount of lucene defined
        /// boost to apply to a field.
        /// </summary>
        public float Boost
        {
            get { return boost; }
            set { boost = value; }
        }

        /// <summary>
        /// User supplied class to manipulate document in
        /// whatever mysterious ways they wish to.
        /// </summary>
        public System.Type Impl
        {
            get { return impl; }
        }

        /// <summary>
        /// Array of fields to work with. The imnpl class
        /// above will work on these fields.
        /// </summary>
        public object[] Parameters
        {
            get { return parameters; }
        }

        #endregion
    }
}