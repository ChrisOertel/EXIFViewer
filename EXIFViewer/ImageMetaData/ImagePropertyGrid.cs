using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace de.coe.Tools.Image.PropertyGrid
{
    public partial class ImagePropertyGrid : System.Windows.Forms.PropertyGrid
    {
        public ImagePropertyGrid()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// Localized version of the Category attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    internal class SRCategoryAttribute : CategoryAttribute
    {
        /// <summary>
        /// Construct the attribute
        /// </summary>
        /// <param name="name"></param>
        public SRCategoryAttribute(string name) : base(name) { }

        /// <summary>
        /// Return the localized version of the passed string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override string GetLocalizedString(string value)
        {
            return SR.GetString(value);
        }
    }

    /// <summary>
    /// Localized description attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    internal class SRDescriptionAttribute : DescriptionAttribute
    {
        /// <summary>
        /// Store a flag indicating whether this has been localized
        /// </summary>
        private bool _localized;
        
        /// <summary>
        /// Construct the description attribute
        /// </summary>
        /// <param name="text"></param>
        public SRDescriptionAttribute(string text) : base(text)
        {
            _localized = false;
        }

        /// <summary>
        /// Override the return of the description text to localize the text
        /// </summary>
        public override string Description
        {
            get
            {
                if (!_localized)
                {
                    _localized = true;
                    this.DescriptionValue = SR.GetString(this.DescriptionValue);
                }

                return base.Description;
            }
        }
    }

    /// <summary>
    /// Localized property attribute
    /// </summary>
    internal class SRPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor basePropertyDescriptor;
        private string localizedName = "";

        public SRPropertyDescriptor(PropertyDescriptor basePropertyDescriptor) : base(basePropertyDescriptor)
        { 
            this.basePropertyDescriptor = basePropertyDescriptor;
        }

        public override bool CanResetValue(object component)
        {
            return basePropertyDescriptor.CanResetValue(component);
        }

        public override Type ComponentType
        {
            get { return basePropertyDescriptor.ComponentType; }
        }

        public override object GetValue(object component)
        {
            return this.basePropertyDescriptor.GetValue(component);
        }

        public override bool IsReadOnly
        {
            get { return this.basePropertyDescriptor.IsReadOnly; }
        }

        public override string Name
        {
            get { return this.basePropertyDescriptor.Name; }
        }

        public override Type PropertyType
        {
            get { return this.basePropertyDescriptor.PropertyType; }
        }

        public override void ResetValue(object component)
        {
            this.basePropertyDescriptor.ResetValue(component);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return this.basePropertyDescriptor.ShouldSerializeValue(component);
        }

        public override void SetValue(object component, object value)
        {
            this.basePropertyDescriptor.SetValue(component, value);
        }

        public override string Description
        {
            get { return basePropertyDescriptor.Description; }
        }

        public override string DisplayName
        {
            get
            {

                string displayNameKey = string.Empty;
                foreach (Attribute oAttrib in this.basePropertyDescriptor.Attributes)
                {
                    //if (oAttrib.GetType().Equals(typeof(GlobalPropertyAttribute)))
                    //{
                    //    displayNameKey = (oAttrib as GlobalPropertyAttribute).NameKey;
                    //    break;
                    //}
                }
                if (string.IsNullOrEmpty(displayNameKey))
                    displayNameKey = basePropertyDescriptor.DisplayName;
                //this.localizedName = PropertyNames.ResourceManager.GetString(displayNameKey);
                //this.localizedName = SR.GetString(this.basePropertyDescriptor.);
                if (string.IsNullOrEmpty(this.localizedName))
                    this.localizedName = basePropertyDescriptor.DisplayName;
                return this.localizedName;
            }
        }
    }

    /// <summary>
    /// Class which exposes string resources
    /// </summary>
    internal sealed class SR
    {
        private ResourceManager _rm;

#region Instance methods and data

        /// <summary>
        /// Private constructor
        /// </summary>
        private SR()
        {
            _rm = new System.Resources.ResourceManager("de.coe.Tools.Image.ImgGrid", this.GetType().Assembly);
        }

        /// <summary>
        /// Return the resource manager for the assembly
        /// </summary>
        private ResourceManager Resources
        {
            get { return _rm; }
        }

#endregion

#region Static methods and data

        /// <summary>
        /// Return the static loader instance
        /// </summary>
        /// <returns></returns>
        private static SR GetLoader()
        {
            if (null == _loader)
            {
                lock (_lock)
                {
                    if (null == _loader)
                        _loader = new SR();
                }
            }

            return _loader;
        }

        /// <summary>
        /// Get a string resource
        /// </summary>
        /// <param name="name">The resource name</param>
        /// <returns>The localized resource</returns>
        public static string GetString(string name)
        {
            SR loader = GetLoader();
            string localized = null;

            if (null != loader)
                localized = loader.Resources.GetString(name, null);

            return localized;
        }

        /// <summary>
        /// Get the localized string for a particular culture
        /// </summary>
        /// <param name="culture">The culture for which the string is desired</param>
        /// <param name="name">The resource name</param>
        /// <returns>The localized resource</returns>
        public static string GetString(CultureInfo culture, string name)
        {
            SR loader = GetLoader();
            string localized = null;

            if (null != loader)
                localized = loader.Resources.GetString(name, culture);

            return localized;
        }

        /// <summary>
        /// Cache the one and only instance of the loader
        /// </summary>
        private static SR _loader = null;

        /// <summary>
        /// Object used to lock
        /// </summary>
        private static object _lock = new object();

#endregion
    }

}
