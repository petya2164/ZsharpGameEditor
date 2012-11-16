using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace ZGE.Components
{
    public interface IRenderable
    {
        void Render();
    }
    public interface IUpdateable
    {
        void Update();
    }
    public interface INeedRefresh
    {
        void Refresh();
    }

    // This attribute keeps certain components in
    [AttributeUsage(AttributeTargets.Class)]
    public class HideComponent : Attribute
    {
        public bool Hidden { get; private set; }

        public HideComponent()
        {
            Hidden = true;
        }

        public HideComponent(bool hidden)
        {
            Hidden = hidden;
        }
    }

    [HideComponent]
    public abstract class ZComponent
    {
        [Browsable(false)]
        public static ZApplication App = null; // there can be only one ZApplication at a time
        
        [CategoryAttribute("Component")]
        public string Name;
        [CategoryAttribute("Component")]
        public string Comment;
        [CategoryAttribute("Component")]
        public bool Enabled = true;
        [Browsable(false)]
        public ZComponent Owner;
        [Browsable(false)]
        public IList OwnerList;
        [Browsable(false)]
        public List<ZComponent> Children = new List<ZComponent>();
        [Browsable(false)]
        public object Tag;        

        public ZComponent(ZComponent parent)
        {
            Owner = parent;
            // It is important to register all components to the App
            if (App != null) App.AddNewComponent(this);           
        }

        ~ZComponent()
        {
            if (App != null) App.RemoveComponent(this);
            //Console.WriteLine("ZComponent finalized: " + Name);
        }

        public bool HasName()
        {
            return (Name != null && Name.Length > 0);    
        }

        public virtual void ReplaceOwner(ZComponent parent)
        {            
            Owner = parent;                
        }

        public virtual void SetOwner(ZComponent parent, IList parent_list)
        {
            if (parent != null)
            {
                Owner = parent;
                if (parent_list != null)
                {
                    OwnerList = parent_list;
                    parent_list.Add(this);
                    // components in member lists are not considered children!
                }
                else
                {
                    OwnerList = null;
                    parent.Children.Add(this);
                }
            }
            else
            {
                if (OwnerList != null)  // delete reference from OwnerList            
                    OwnerList.Remove(this);
                else if (Owner != null) // delete reference from Owner's Children            
                    Owner.Children.Remove(this);
                Owner = null;
                OwnerList = null;
            }
        }        

        //public virtual void Update() { } 

        public List<T> FindChildrenOfType<T>() where T : class
        {
            List<T> res = new List<T>();
            foreach (ZComponent child in Children)
            {
                if (child.GetType() == typeof(T))
                    res.Add(child as T);
            }

            return res;
        }
    }

    public class Group : ContentLike, IRenderable, IUpdateable
    {
        public Group(ZComponent parent) : base(parent) { }        

        public void Update()
        {
            if (!Enabled) return;
            foreach (ZComponent comp in Children)
            {
                IUpdateable obj = comp as IUpdateable;
                if (obj != null) obj.Update();
            }            
        }       

        public void Render()
        {
            if (!Enabled) return;
            foreach (ZComponent comp in Children)
            {
                IRenderable obj = comp as IRenderable;
                if (obj != null) obj.Render();
            }           
        }        
    }

    // This is a dummy parent class for all components that can be added to the GUI
    public abstract class GUIComponent : ZComponent
    {
        public GUIComponent(ZComponent parent): base(parent) { }
    }

    // This is a dummy parent class for all classes that can be added to app contents
    public abstract class ContentLike : ZComponent
    {
        public ContentLike(ZComponent parent) : base(parent) { }
    }

    

    //Content that can be produced from ContentProducers (used for bitmaps and meshes)
    [HideComponent]
    public abstract class ZContent : ContentLike, INeedRefresh
    {
        [Browsable(false)]
        public List<ZContentProducer> Producers = new List<ZContentProducer>();

        public ZContent(ZComponent parent)
            : base(parent)
        {
            App.AddContent(this);            
        }

        public void Refresh()
        {
            RefreshFromProducers();
        }

        public virtual void RefreshFromProducers()
        {
            foreach (var prod in Producers)
                prod.ProduceOutput(this);
        }
    }

    [HideComponent]
    public abstract class ZContentProducer: ZComponent, INeedRefresh
    {
        public ZContentProducer(ZComponent parent): base(parent) {}
        public void Refresh()
        {
            if (Owner == null) return;
            INeedRefresh obj = Owner as INeedRefresh;
            if (obj != null) obj.Refresh();
        }
        public abstract void ProduceOutput(ZContent content);
    } 
    
  
}
