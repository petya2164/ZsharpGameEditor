using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Drawing;
using ZSGameEditor.Properties;
using System.Reflection;
using ZGE.Components;

namespace ZGE
{
    public class EventPropertyDescriptor : PropertyDescriptor
    {
        private EventInfo _event;
        public static Editor editor;

        public EventPropertyDescriptor(EventInfo ev) :
            base(ev.Name, (Attribute[]) ev.GetCustomAttributes(typeof(Attribute), true))
        {
            _event = ev;           
        }

        public EventInfo Event { get { return _event; } }

        public override bool Equals(object obj)
        {
            EventPropertyDescriptor other = obj as EventPropertyDescriptor;
            return other != null && other._event.Equals(_event);
        }

        public override int GetHashCode() { return _event.GetHashCode(); }

        public override bool IsReadOnly
        {
            get
            {
//                 object[] attributes = _event.GetCustomAttributes(typeof(ReadOnlyAttribute), true);
//                 foreach (ReadOnlyAttribute attribute in attributes)
//                     if (attribute.IsReadOnly) return true;

                return false;
            }
        }
        public override void ResetValue(object component) { }
        public override bool CanResetValue(object component) { return false; }
        public override bool ShouldSerializeValue(object component) { return true; }

        public override Type ComponentType { get { return _event.DeclaringType; } }
        public override Type PropertyType { get { return _event.EventHandlerType; } }

        public override object GetValue(object component)
        {
            if (ZComponent.App != null)
                return ZComponent.App.FindEvent(editor.SelectedComponent as ZComponent, _event.Name);
            return null;
            //_event.GetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            //_event.SetValue(component, value);
            OnValueChanged(component, EventArgs.Empty);
        }
    }

    public class EventsTab : PropertyTab
    {
        private Bitmap _bitmap;

        // the tooltip displayed in the grid
        public override string TabName
        {
            get
            {
                return "Events";
            }
        }

        // the icon displayed in the grid
        public override Bitmap Bitmap
        {
            get
            {
                if (_bitmap == null)
                {
                    // 1. create a file named "EventsTab.bmp". It must be a 16x16, 8-bit bitmap. Transparency pixel is magenta.
                    // 2. place it in the project aside this .cs
                    // 3. configure its build action to "Embedded Resource"
                    _bitmap = new Bitmap(Resources.EventsTab);
                    //_bitmap = new Bitmap(16, 16);
                }
                return _bitmap;
            }
        }

        // TODO: return the descriptor corresponding to the properties you want to show
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object component, Attribute[] attributes)
        {
            PropertyDescriptorCollection props = new PropertyDescriptorCollection(null);
            //Console.WriteLine("Events comp: " + component.GetType().FullName);
            FieldsProxy proxy = component as FieldsProxy;
            if (proxy.GetTarget() is Model)
            {
                Model model = proxy.GetTarget() as Model;
                if (model.Prototype == false) return props;  // GameObjects cannot have their own events 
            }

            if (proxy != null)
            {
                //                 foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(proxy.GetTarget(), false))
                //                 {
                //                     Console.WriteLine("Events prop: " + prop.Name);
                //                     if (prop.IsReadOnly == false)
                //                         props.Add(prop);
                //                 }
                foreach (FieldInfo field in proxy.GetTarget().GetType().GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance))
                {
                    if (field.FieldType.IsSubclassOf(typeof(CodeLike)))
                    {
                        FieldPropertyDescriptor fieldDesc = new FieldPropertyDescriptor(field);
                        props.Add(fieldDesc);
                    }
                }
                foreach (EventInfo ev in proxy.GetTarget().GetType().GetEvents(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance))
                {
                    EventPropertyDescriptor eventDesc = new EventPropertyDescriptor(ev);
                    props.Add(eventDesc);
                }
            }

            return props;
        }

        public override PropertyDescriptorCollection GetProperties(object component, Attribute[] attributes)
        {
            return GetProperties(null, component, attributes);
        }
    }
}
