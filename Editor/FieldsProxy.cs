﻿// Stephen Toub
// stoub@microsoft.com

using System;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace ZGE
{
    public class FieldPropertyDescriptor : PropertyDescriptor
    {
        private FieldInfo _field;

        public FieldPropertyDescriptor(FieldInfo field) :
            base(field.Name, (Attribute[]) field.GetCustomAttributes(typeof(Attribute), true))
        {
            _field = field;
        }

        public FieldInfo Field { get { return _field; } }

        public override bool Equals(object obj)
        {
            FieldPropertyDescriptor other = obj as FieldPropertyDescriptor;
            return other != null && other._field.Equals(_field);
        }

        public override int GetHashCode() { return _field.GetHashCode(); }

        public override bool IsReadOnly
        {
            get
            {
                object[] attributes = _field.GetCustomAttributes(typeof(ReadOnlyAttribute), true);
                foreach (ReadOnlyAttribute attribute in attributes)
                    if (attribute.IsReadOnly) return true;

                return false;
            }
        }
        public override void ResetValue(object component) { }
        public override bool CanResetValue(object component) { return false; }
        public override bool ShouldSerializeValue(object component) { return true; }

        public override Type ComponentType { get { return _field.DeclaringType; } }
        public override Type PropertyType { get { return _field.FieldType; } }

        public override object GetValue(object component)
        { return _field.GetValue(component); }

        public override void SetValue(object component, object value)
        {
            _field.SetValue(component, value);
            OnValueChanged(component, EventArgs.Empty);
        }
    }

    public class FieldsProxy : ICustomTypeDescriptor
    {
        private object _target;

        public override string ToString()
        {
            return _target.ToString();
        }

        public FieldsProxy(object target)
        {
            if (target == null) throw new ArgumentNullException("target");
            _target = target;
        }

        public object GetTarget()
        {
            return _target;
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return _target;
        }

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(_target, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(_target, true);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(_target, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(_target, true);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(_target, true);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(_target, true);
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(_target, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(_target, attributes, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(_target, true);
        }

        private PropertyDescriptorCollection _propCache;
        private FilterCache _filterCache;

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor) this).GetProperties(null);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            bool filtering = (attributes != null && attributes.Length > 0);
            PropertyDescriptorCollection props = _propCache;
            FilterCache cache = _filterCache;

            // Use a cached version if we can
            if (filtering && cache != null && cache.IsValid(attributes))
            {
                return cache.FilteredProperties;
            }
            else if (!filtering && props != null)
            {
                return props;
            }

            // Create the property collection and filter if necessary
            props = new PropertyDescriptorCollection(null);
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(_target, attributes, true))
            {
                props.Add(prop);
            }
            foreach (FieldInfo field in _target.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                FieldPropertyDescriptor fieldDesc = new FieldPropertyDescriptor(field);
                if (!filtering || fieldDesc.Attributes.Contains(attributes)) props.Add(fieldDesc);
            }

            // Store the computed properties
            if (filtering)
            {
                cache = new FilterCache();
                cache.Attributes = attributes;
                cache.FilteredProperties = props;
                _filterCache = cache;
            }
            else _propCache = props;

            return props;
        }

        private class FilterCache
        {
            public Attribute[] Attributes;
            public PropertyDescriptorCollection FilteredProperties;
            public bool IsValid(Attribute[] other)
            {
                if (other == null || Attributes == null) return false;
                if (Attributes.Length != other.Length) return false;
                for (int i = 0; i < other.Length; i++)
                {
                    if (!Attributes[i].Match(other[i])) return false;
                }
                return true;
            }
        }
    }
}