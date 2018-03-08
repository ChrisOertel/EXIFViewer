using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace de.coe.components.Image
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class GlobalizedPropertyAttribute : Attribute
    {
        private String msName = "";
        private string msDesc = "";

        public GlobalizedPropertyAttribute()
        {
        }

        public GlobalizedPropertyAttribute(string PropertyName, string Description)
        {
            msName = PropertyName;
            msDesc = Description;
        }

        public string PropertyName
        {
            get { return msName; }
            set { msName = value; }
        }

        public string Description
        {
            get { return msDesc; }
            set { msDesc = value; }
        }

    }

    /// <summary>
    /// GlobalizedPropertyDescriptor enhances the base class bay obtaining the display name for a property
    /// from the resource.
    /// </summary>
    internal class GlobalizedPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor basePropertyDescriptor;
        private String localizedName = "";
        private String localizedDescription = "";

        public GlobalizedPropertyDescriptor(PropertyDescriptor basePropertyDescriptor) : base(basePropertyDescriptor)
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

        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(this.localizedName))
                {
                    string ssResourceName = "";
                    foreach (Attribute oAttrib in this.basePropertyDescriptor.Attributes)
                    {
                        if (oAttrib.GetType().Equals(typeof(GlobalizedPropertyAttribute)))
                        {
                            ssResourceName = ((GlobalizedPropertyAttribute)oAttrib).PropertyName;
                        }
                    }
                    if (string.IsNullOrEmpty(ssResourceName))
                    {
                        ssResourceName = this.basePropertyDescriptor.DisplayName + "_Prop";
                    }
                    string ssName = Properties.Resources.ResourceManager.GetString(ssResourceName);
                    this.localizedName = (string.IsNullOrEmpty(ssName)) ? this.basePropertyDescriptor.DisplayName : ssName;
                }
                return this.localizedName;
            }
        }

        public override string Description
        {
            get
            {
                if (string.IsNullOrEmpty(this.localizedDescription))
                {
                string ssResourceName = "";
                foreach (Attribute oAttrib in this.basePropertyDescriptor.Attributes)
                {
                    if (oAttrib.GetType().Equals(typeof(GlobalizedPropertyAttribute)))
                    {
                        ssResourceName = ((GlobalizedPropertyAttribute)oAttrib).Description;
                    }
                }
                if (string.IsNullOrEmpty(ssResourceName))
                {
                    ssResourceName = this.basePropertyDescriptor.DisplayName + "_Desc";
                }
                string ssDesc = Properties.Resources.ResourceManager.GetString(this.basePropertyDescriptor.DisplayName + "_Desc");
                this.localizedDescription = (string.IsNullOrEmpty(ssDesc)) ? this.basePropertyDescriptor.DisplayName : ssDesc;  
                }
                return this.localizedDescription;
            }
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
    }

    /// <summary>
    /// GlobalizedObject implements ICustomTypeDescriptor to enable required functionality to describe a type (class).
    /// The main task of this class is to instantiate our own property descriptor of type GlobalizedPropertyDescriptor.  
    /// </summary>
    public class GlobalizedObject : ICustomTypeDescriptor
    {
        private PropertyDescriptorCollection globalizedProps;

        /// <summary>
        /// Returns the class name of this instance of a component. 
        /// </summary>
        /// <returns>The class name of this instance of a component. .</returns>
        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        /// <summary>
        /// Returns a collection of custom attributes for this instance of a component. 
        /// </summary>
        /// <returns>A collection of custom attributes for this instance of a component.</returns>
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        /// <summary>
        /// Returns the name of this instance of a component. 
        /// </summary>
        /// <returns>The name of this instance of a component. </returns>
        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        /// <summary>
        /// Returns a type converter for this instance of a component.
        /// </summary>
        /// <returns>A type converter for this instance of a component.</returns>
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        /// <summary>
        /// Returns the default event for this instance of a component. 
        /// </summary>
        /// <returns>The default event for this instance of a component. </returns>
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        /// <summary>
        /// Returns the default property for this instance of a component. 
        /// </summary>
        /// <returns>The default property for this instance of a component. </returns>
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        /// <summary>
        /// Returns an editor of the specified type for this instance of a component. 
        /// </summary>
        /// <param name="editorBaseType">A Type that represents the editor for this object. </param>
        /// <returns>An Object of the specified type that is the editor for this object, or nullNothingnullptra null reference (Nothing in Visual Basic) if the editor cannot be found.</returns>
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        /// <summary>
        /// Overloaded. Returns the events for this instance of a component using the specified attribute array as a filter. 
        /// </summary>
        /// <param name="attributes">An array of type Attribute that is used as a filter.</param>
        /// <returns>An EventDescriptorCollection that represents the filtered events for this component instance.</returns>
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        /// <summary>
        /// Overloaded. Returns the events for this instance of a component. 
        /// </summary>
        /// <returns>An EventDescriptorCollection that represents the events for this component instance.</returns>
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        /// <summary>
        /// Returns the properties for this instance of a component using the attribute array as a filter.
        /// </summary>
        /// <param name="attributes">An array of type Attribute that is used as a filter. </param>
        /// <returns>A PropertyDescriptorCollection that represents the filtered properties for this component instance. </returns>
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            if (globalizedProps == null)
            {
                PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, attributes, true);
                globalizedProps = new PropertyDescriptorCollection(null);
                foreach (PropertyDescriptor oProp in baseProps)
                {
                    globalizedProps.Add(new GlobalizedPropertyDescriptor(oProp));
                }
            }
            return globalizedProps;
        }

        /// <summary>
        /// Returns the properties for this instance of a component. 
        /// </summary>
        /// <returns>A PropertyDescriptorCollection that represents the properties for this component instance. </returns>
        public PropertyDescriptorCollection GetProperties()
        {
            if (globalizedProps == null)
            {
                PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, true);
                globalizedProps = new PropertyDescriptorCollection(null);
                foreach (PropertyDescriptor oProp in baseProps)
                {
                    globalizedProps.Add(new GlobalizedPropertyDescriptor(oProp));
                }
            }
            return globalizedProps;
        }

        /// <summary>
        /// Returns an object that contains the property described by the specified property descriptor. 
        /// </summary>
        /// <param name="pd">A PropertyDescriptor that represents the property whose owner is to be found.</param>
        /// <returns>An Object that represents the owner of the specified property. </returns>
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
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
            return Properties.Resources.ResourceManager.GetString(value);
        }
    }

}
