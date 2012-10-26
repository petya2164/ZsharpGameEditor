// Stephen Toub
// stoub@microsoft.com

using System;
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
}
