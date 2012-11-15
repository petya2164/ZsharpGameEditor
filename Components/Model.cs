﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;

namespace ZGE.Components
{


    public class Model : ContentLike, ICloneable, IRenderable, IUpdateable, INeedRefresh
    {
        //[Browsable(false)]
        //public Model model;  //Used in GameObject
        //public GameObject Parent;
        [ReadOnly(true)]
        public bool Prototype = true; // Is this Model a prototype as a GameObject?
        public int Category;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Velocity;        
        public Vector3 Scale;
        public Vector3 AngularVelocity;
        public bool BillBoard = false;

        public bool GoToDestination = false;
        public Vector3 Destination;
        public float Speed = 1.0f;

        [Browsable(false)]
        public string GUID;

        //public delegate void EmptyHandler();
        //public event EmptyHandler OnRender;
        // XML Member lists
        [Browsable(false)]
        public List<Definition> Definitions = new List<Definition>();
        [Browsable(false)]
        public List<ZCommand> OnUpdate = new List<ZCommand>();
        [Browsable(false)]
        public List<ZCommand> OnRender = new List<ZCommand>();

        public Model()
        {            
            Scale = new Vector3(1, 1, 1);
            if (App != null) App.AddModel(this);
        }  
      
        ~Model()
        {
            if (App != null) App.RemoveModel(this);
            //Console.WriteLine("Model finalized: " + Name);
        }

        public void Refresh()
        {
            //CloneBehavior();
        }

        public object Clone()
        {
            Model clone = this.MemberwiseClone() as Model;
            clone.Prototype = false;    // a cloned Model automatically becomes a GameObject
            clone.Name = null;          // clones have no names per default
            //clone.GUID = this.GUID;   // a GameObject will inherit the GUID from its parent
            App.AddNewComponent(clone);
            App.AddModel(clone);
            return clone;
        }

        public Model CreateClone(ZComponent parent)
        {
            if (this.Prototype == false) return null; // you cannot clone a GameObject
            Model comp = (Model) this.Clone();
            
            // Use the application as a parent
            if (parent == null) parent = App;            
            comp.Owner = parent;
            if (parent == App)
            {
                comp.OwnerList = App.Scene;
                App.Scene.Add(comp);
                // components in member lists are not considered children!
            }
            else
                parent.Children.Add(comp);
            
            return comp;
        }

        /*public virtual void CloneBehavior()
        {            
            if (model == null) return;
           
            //Clone the behavior and the non-volatile properties of the model
            OnUpdate = model.OnUpdate;
            OnRender = model.OnRender;
            Category = model.Category;                        
        }*/

        public void Update()
        {
            if (!Enabled) return;

            if (GoToDestination)
            {
                if (Position != Destination)
                {
                    Vector3 dir = Destination - Position;
                    float maxDisp = Speed * (float) App.DeltaTime;
                    if (maxDisp >= dir.Length)
                        Destination = Position;
                    else
                        Position += maxDisp * dir.Normal();
                }
            }

            OnUpdate.ExecuteAll(this);
        }

        public void Render()
        {
            if (!Enabled) return;
            GL.PushMatrix();
            GL.Translate(Position);

            if (BillBoard)
            {
                // TODO: Apply the inverse of the 3x3 view matrix

            }
            else
            {
                //Reverse order to make XYZ-rotation  
                GL.Rotate(Rotation.Z, Vector3.UnitZ);
                GL.Rotate(Rotation.Y, Vector3.UnitY);
                GL.Rotate(Rotation.X, Vector3.UnitX);
            }        

            GL.Scale(Scale);

            Renderer.ApplyDefaultMaterial(false);
            OnRender.ExecuteAll(this);

            GL.PopMatrix();
        }
    }

    /*public class GameObject : Model, INeedRefresh
    {
        public Model Model;
        //public GameObject Parent;

        public GameObject()
        {            
        }

        public void Refresh()
        {
            Init();
        }

        public virtual void Init()
        {
            if (Model == null) return;
           
            //Clone the behavior and the non-volatile properties of the model
            OnUpdate = Model.OnUpdate;
            OnRender = Model.OnRender;
            Category = Model.Category;                        
        }
    }*/



    /*public enum SpawnStyle
    {
        Clone, Reference
    }*/

    public class SpawnModel : ZCommand
    {
        public Model Model;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale;
        //public SpawnStyle SpawnStyle;
        public bool UseSpawnerPosition;
        public bool SpawnerIsParent;  //Spawned model becomes child to currentmodel

        public SpawnModel()
        {
            //SpawnStyle = SpawnStyle.Clone;
            Scale = new Vector3(1, 1, 1);
            UseSpawnerPosition = false;
            SpawnerIsParent = false;
        }

        public override void Execute(ZComponent caller)
        {
            if (Model == null || Model.Prototype == false) return;
            Model spawned = null;
            Model currentModel = caller as Model;

            if (SpawnerIsParent)                
                spawned = Model.CreateClone(currentModel);
            else
                spawned = Model.CreateClone(null);            

            if (UseSpawnerPosition && currentModel != null)
                spawned.Position = currentModel.Position + Position;
            else
                spawned.Position = Position;

            spawned.Rotation = Rotation;
            spawned.Scale = Scale;

            // No need for this: A cloned Model is automatically added to the scene 
            // App.AddToScene(spawned);

            //if (SpawnerIsParent) 
            //{
            //    currentModel.ChildModelRefs.Add(spawned);
            //    spawned.ParentModel == currentModel;
            //}            
        }
    }

    public class RemoveModel : ZCommand
    {
        public Model Model;

        public RemoveModel()
        {
        }

        public override void Execute(ZComponent caller)
        {
            Model currentModel = caller as Model;
            if (currentModel != null)
                App.RemoveFromScene(currentModel);
        }
    }

    public class RemoveAllModels : ZCommand
    {
        public Model OfType;

        public RemoveAllModels()
        {
        }

        public override void Execute(ZComponent caller)
        {
            App.RemoveAllModels();
        }
    }
}
