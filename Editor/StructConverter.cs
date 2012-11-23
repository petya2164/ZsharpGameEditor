using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using System.ComponentModel;
using System.Collections;
using System.Reflection;

namespace ZGE
{
    public class StructConverter : ExpandableObjectConverter
    {
        /*public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
        {
            if (destinationType == typeof(Vector3)) return true;
            else return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(string) && value is Vector3)
            {
                Vector3 vec = (Vector3) value;
                return string.Format("{0}, {1}, {2}", vec.X, vec.Y, vec.Z);
            }
            else return base.ConvertTo(context, culture, value, destinationType);
        }*/

        /// <devdoc> 
        ///      Determines if changing a value on this object should require a call to
        ///      CreateInstance to create a new value. 
        /// </devdoc>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <devdoc> 
        ///      Creates an instance of this type given a set of property values 
        ///      for the object.  This is useful for objects that are immutable, but still
        ///      want to provide changable properties. 
        /// </devdoc>
        //[SuppressMessage("Microsoft.Performance", "CA1808:AvoidCallsThatBoxValueTypes")]
        //[SuppressMessage("Microsoft.Security", "CA2102:CatchNonClsCompliantExceptionsInGeneralHandlers")]
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }
            if (context.PropertyDescriptor == null)
                throw new ArgumentNullException("Missing PropertyDescriptor");

            Type type = context.PropertyDescriptor.PropertyType;
            object ret = Activator.CreateInstance(type);

            if (ret == null)
                throw new ArgumentException("Cannot Create Instance");
            
            foreach (DictionaryEntry de in propertyValues)
            {
                if (de.Value != null)
                {
                    PropertyInfo pi = type.GetProperty((string) de.Key, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                    if (pi != null && de.Value.GetType() == pi.PropertyType)
                        pi.SetValue(ret, de.Value, null);
                    else
                    {
                        FieldInfo fi = type.GetField((string) de.Key, BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                        if (fi != null && de.Value.GetType() == fi.FieldType)
                            fi.SetValue(ret, de.Value);
                    }
                }
            }

            return ret;
            // 
            //             object x = propertyValues["X"];
            //             object y = propertyValues["Y"];
            //             object z = propertyValues["Z"];            
            // 
            //             if (x == null || y == null || z == null ||
            //                 !(x is float) || !(y is float) || !(z is float))
            //             {
            //                 throw new ArgumentException("Invalid arguments in CreateInstance");
            //             }
            //             return new Vector3((float) x, (float) y, (float) z);
        }
    }
}
