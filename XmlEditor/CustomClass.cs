using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ZGE.XmlEditor
{
    #region PropertyChangedEvent
    public enum PropertyChangeAction
    {
        AttributesCollectionChanged,        
        ElementNodeRenamed,       
        NodeTextChanged
    }

    /// <summary>
    /// Provides a data for XmlNodeProperties.PropertyChanged event.
    /// </summary>
    /// <remarks>Used to pass information to the handler which 
    /// processes changes to the underlying object.
    /// </remarks>
    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangeAction Action { get; set; }
        public string NewValue { get; private set; }        
        
        protected PropertyChangedEventArgs(): base()
        {
        }
        
        public PropertyChangedEventArgs(string newValue): base()
        {            
            NewValue = newValue;
        }      
    }
    
    /// <summary>
    /// Represents the method that will handle the CustomClass.PropertyChanged event    
    /// </summary>
    public delegate void PropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e);
    #endregion
    
    /// <summary>
	/// CustomClass (Which is binding to property grid)
	/// </summary>
	public class CustomClass: CollectionBase,ICustomTypeDescriptor
	{
        /// <summary>
        /// Occurs when the node was renamed, or its attributes collection has changed.
        /// </summary>
        public event PropertyChangedEventHandler OnPropertyChanged;
        
        /// <summary>
		/// Add CustomProperty to Collectionbase List
		/// </summary>
		/// <param name="Value"></param>
		public void Add(CustomProperty Value)
		{
            Value.parent = this;
            base.List.Add(Value);
		}

		/// <summary>
		/// Remove item from List
		/// </summary>
		/// <param name="Name"></param>
		public void Remove(string Name)
		{
			foreach(CustomProperty prop in base.List)
			{
				if(prop.Name == Name)
				{
					base.List.Remove(prop);
					return;
				}
			}
		}

        public string GetValue(string propName)
        {
            foreach (CustomProperty prop in base.List)
            {
                if (prop.Name == propName)
                {
                    return prop.Value.ToString();                    
                }
            }
            return String.Empty;
        }

        public void SetValue(string propName, string value)
        {
            foreach (CustomProperty prop in base.List)
            {
                if (prop.Name == propName)
                {
                    prop.Value = value;
                }
            }            
        }

        internal void PropertyChanged(CustomProperty prop)
        {  
            if (OnPropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(prop.Value.ToString());
                if (prop.Name == "Type")
                    e.Action = PropertyChangeAction.ElementNodeRenamed;
                else if (prop.Name == "Code")
                    e.Action = PropertyChangeAction.NodeTextChanged;
                else
                    e.Action = PropertyChangeAction.AttributesCollectionChanged;
                OnPropertyChanged(this, e);
            }
        }

		/// <summary>
		/// Indexer
		/// </summary>
		public CustomProperty this[int index] 
		{
			get 
			{
				return (CustomProperty)base.List[index];
			}
			set
			{
				base.List[index] = (CustomProperty)value;
			}
		}


		#region "TypeDescriptor Implementation"
		/// <summary>
		/// Get Class Name
		/// </summary>
		/// <returns>String</returns>
		public String GetClassName()
		{
			return TypeDescriptor.GetClassName(this,true);
		}

		/// <summary>
		/// GetAttributes
		/// </summary>
		/// <returns>AttributeCollection</returns>
		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this,true);
		}

		/// <summary>
		/// GetComponentName
		/// </summary>
		/// <returns>String</returns>
		public String GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, true);
		}

		/// <summary>
		/// GetConverter
		/// </summary>
		/// <returns>TypeConverter</returns>
		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, true);
		}

		/// <summary>
		/// GetDefaultEvent
		/// </summary>
		/// <returns>EventDescriptor</returns>
		public EventDescriptor GetDefaultEvent() 
		{
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		/// <summary>
		/// GetDefaultProperty
		/// </summary>
		/// <returns>PropertyDescriptor</returns>
		public PropertyDescriptor GetDefaultProperty() 
		{
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		/// <summary>
		/// GetEditor
		/// </summary>
		/// <param name="editorBaseType">editorBaseType</param>
		/// <returns>object</returns>
		public object GetEditor(Type editorBaseType) 
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes) 
		{
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, true);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptor[] newProps = new PropertyDescriptor[this.Count];
			for (int i = 0; i < this.Count; i++)
			{
				CustomProperty  prop = (CustomProperty) this[i];
				newProps[i] = new CustomPropertyDescriptor(ref prop, attributes);
			}

			return new PropertyDescriptorCollection(newProps);
		}

		public PropertyDescriptorCollection GetProperties()
		{
			return TypeDescriptor.GetProperties(this, true);
		}

		public object GetPropertyOwner(PropertyDescriptor pd) 
		{
			return this;
		}
		#endregion
	
	}

	/// <summary>
	/// Custom property class 
	/// </summary>
	public class CustomProperty
	{
		private string sName = string.Empty;
		private bool bReadOnly = false;
		private bool bVisible = true;
		private object objValue = null;
        internal CustomClass parent = null;

		public CustomProperty(string sName, object value, Type type, bool bReadOnly, bool bVisible )
		{
			this.sName = sName;
			this.objValue = value;
			this.type = type;
			this.bReadOnly = bReadOnly;
			this.bVisible = bVisible;
		}

		private Type type;
		public Type Type
		{
			get { return type; }
		}

		public bool ReadOnly
		{
			get
			{
				return bReadOnly;
			}
		}

		public string Name
		{
			get
			{
				return sName;
			}
		}

		public bool Visible
		{
			get
			{
				return bVisible;
			}
		}

		public object Value
		{
			get
			{
				return objValue;
			}
			set
			{
				objValue = value;
                if (parent != null) parent.PropertyChanged(this);
			}
		}

	}


	/// <summary>
	/// Custom PropertyDescriptor
	/// </summary>
	public class CustomPropertyDescriptor: PropertyDescriptor
	{
		CustomProperty m_Property;
		public CustomPropertyDescriptor(ref CustomProperty myProperty, Attribute[] attrs): base(myProperty.Name, attrs)
		{
			m_Property = myProperty;
		}

		#region PropertyDescriptor specific
		
		public override bool CanResetValue(object component)
		{
			return false;
		}

		public override Type ComponentType
		{
			get { return null; }
		}

		public override object GetValue(object component)
		{
			return m_Property.Value;
		}

		public override string Description
		{
			get { return m_Property.Name; }
		}
		
		public override string Category
		{
			get	{ return (m_Property.Name == "Type") ? "Element" : string.Empty; }
		}

		public override string DisplayName
		{
			get { return m_Property.Name; }
		}

		public override bool IsReadOnly
		{
			get { return m_Property.ReadOnly; }
		}

		public override void ResetValue(object component)
		{
			//Have to implement
		}

		public override bool ShouldSerializeValue(object component)
		{
			return false;
		}

		public override void SetValue(object component, object value)
		{
			m_Property.Value = value;
		}

		public override Type PropertyType
		{
			get { return m_Property.Type; }
		}

		#endregion

			
	}
}
