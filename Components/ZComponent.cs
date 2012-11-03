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
    public class ZComponent
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

        public ZComponent()
        {           
            //if (App != null) App.AddComponent(this);           
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

    public class Group : ZComponent, IRenderable, IUpdateable
    {
        public Group() { }        

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

    

    //Content that can be produced from ContentProducers (used for bitmaps and meshes)
    [HideComponent]
    public class ZContent : ZComponent, INeedRefresh
    {
        [Browsable(false)]
        public List<ZContentProducer> Producers = new List<ZContentProducer>();

        public ZContent()
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
        public void Refresh()
        {
            if (Owner == null) return;
            INeedRefresh obj = Owner as INeedRefresh;
            if (obj != null) obj.Refresh();
        }
        public abstract void ProduceOutput(ZContent content);
    } 
    
  
}
