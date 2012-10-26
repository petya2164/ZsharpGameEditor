using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ZGE.Components;
using System.Globalization;


namespace ZGE
{    
    public class ComponentList : StringConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
        {
            if (destinationType == typeof(string)) return true;
            else return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is ZComponent)
            {
                ZComponent comp = value as ZComponent;
                
                //return string.Format("{0}, {1}, {2}", vec.X, vec.Y, vec.Z);
                return comp.Name;
            }
            else return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;            
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string strValue = value as string;

            if (strValue != null)
            {
                return ZComponent.App.Find(strValue);
            }
            return base.ConvertFrom(context, culture, value);
        }        
        
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<string> options = ZComponent.App.ListComponentNames(context.PropertyDescriptor.PropertyType);
            /*FieldsProxy proxy = context.Instance as FieldsProxy;
            if (proxy != null)
            {
                ZComponent comp = proxy.GetTarget() as ZComponent;
                options 
            } */       
            return new StandardValuesCollection(options);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
