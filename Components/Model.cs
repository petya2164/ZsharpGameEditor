using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.Reflection;

namespace ZGE.Components
{
    // Ensure that only one Prototype exists for any given Model
    // Similarly to the Singleton pattern
//     public class Prototype<T>: Model where T : class
//     {
//         class SingletonCreator
//         {
//             static SingletonCreator() { }
// 
//             private static T CreateInstance()
//             {
//                 ConstructorInfo constructorInfo = typeof(T).GetConstructor(BindingFlags.Instance |
//                     BindingFlags.NonPublic, Type.DefaultBinder, Type.EmptyTypes, null);
// 
//                 if (constructorInfo != null)
//                 {
//                     return constructorInfo.Invoke(null) as T;
//                 }
//                 else
//                 {
//                     // alternatively, throw an exception indicating the type parameter
//                     // should have a private parameterless constructor
//                     return null;
//                 }
//             }
// 
//             internal static readonly T instance = CreateInstance();
//         }       
// 
//         protected Prototype(): base(null) { }
// 
//         public static T CreatePrototype()
//         {
//             return SingletonCreator.instance;
//             //return new T();
//         }
//         public new T CreateClone(ZComponent parent)
//         {
//             return (base.CreateClone(parent) as T);
//         }
//     }


    public class Model : ContentLike, ICloneable, IRenderable, IUpdateable, INeedRefresh
    {
        //[Browsable(false)]
        //public Model model;  //Used in GameObject
        //public GameObject Parent;
        [ReadOnly(true)]
        public bool Prototype = true; // Is this Model a Prototype or a GameObject in the scene?

        public System.Drawing.Color Color = System.Drawing.Color.White;
        public Material Material;
        public Mesh Mesh;

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

        public delegate void EmptyHandler();
        public event EmptyHandler OnUpdate;
        public event EmptyHandler OnRender;
        // XML Member lists
        //[Browsable(false)]
        //public List<Definition> Definitions = new List<Definition>();
        //[Browsable(false)]
        //public List<ZCommand> OnUpdate = new List<ZCommand>();
        //[Browsable(false)]
        //public List<ZCommand> OnRender = new List<ZCommand>();

        [Browsable(false), CategoryAttribute("Expressions")]
        public CustomCodeDefinition CustomCode = new CustomCodeDefinition();

        //public delegate void ModelMethod(ZComponent caller);
        //[Browsable(false), CategoryAttribute("Expressions")]
        //[MethodSignature("public override void OnUpdate()")]
        //public VirtualMethod OnUpdateExpr = new VirtualMethod();
        //[Browsable(false), CategoryAttribute("Expressions")]
        //[MethodSignature("public override void OnRender()")]
        //public VirtualMethod OnRenderExpr = new VirtualMethod();


        public Model(ZComponent parent)
            : base(parent)
        {
            Scale = new Vector3(1, 1, 1);
            BindCallbacks();
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

        // This is implemented by custom Model classes to bind event handlers
        public virtual void BindCallbacks()
        {   
        }

        public object Clone()
        {
            // Perform a shallow copy
            Model clone = this.MemberwiseClone() as Model;
            clone.Prototype = false;    // a cloned Model automatically becomes a GameObject
            clone.Name = null;          // clones have no names per default
            clone.Comment = null;
            clone.Tag = null;
            clone.Children = new List<ZComponent>();
            //clone.GUID = this.GUID;   // a GameObject will inherit the GUID from its parent
            clone.BindCallbacks();
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

            if (parent == App)
                comp.SetOwner(parent, App.Scene);
            else
                comp.SetOwner(parent, null);

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

        public virtual void Update()
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

            //OnUpdate.ExecuteAll(this);
            if (OnUpdate != null)            
                OnUpdate();
            //OnUpdate();
        }        

        // Default rendering
        // Can be overridden in child classes
        public virtual void RenderModel()
        {
            if (Material != null)
                Material.Apply();
            else
            {
                Renderer.ApplyDefaultMaterial(false);
                GL.Color3(Color);
            }
            if (Mesh != null) 
                Mesh.Render();
        }

        public virtual void Render()
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

            //OnRender();
            
            if (OnRender != null)
            {
                //Renderer.ApplyDefaultMaterial(false);
                OnRender();
            }
            else
                RenderModel();             

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

//     public class SpawnModel : ZCommand
//     {
//         public Model Model;
//         public Vector3 Position;
//         public Vector3 Rotation;
//         public Vector3 Scale;
//         //public SpawnStyle SpawnStyle;
//         public bool UseSpawnerPosition;
//         public bool SpawnerIsParent;  //Spawned model becomes child to currentmodel
// 
//         public SpawnModel(ZComponent parent)
//             : base(parent)
//         {
//             //SpawnStyle = SpawnStyle.Clone;
//             Scale = new Vector3(1, 1, 1);
//             UseSpawnerPosition = false;
//             SpawnerIsParent = false;
//         }
// 
//         public override void Execute(ZComponent caller)
//         {
//             if (Model == null || Model.Prototype == false) return;
//             Model spawned = null;
//             Model currentModel = caller as Model;
// 
//             if (SpawnerIsParent)
//                 spawned = Model.CreateClone(currentModel);
//             else
//                 spawned = Model.CreateClone(null);
// 
//             if (UseSpawnerPosition && currentModel != null)
//                 spawned.Position = currentModel.Position + Position;
//             else
//                 spawned.Position = Position;
// 
//             spawned.Rotation = Rotation;
//             spawned.Scale = Scale;
// 
//             // No need for this: A cloned Model is automatically added to the scene 
//             // App.AddToScene(spawned);
// 
//             //if (SpawnerIsParent) 
//             //{
//             //    currentModel.ChildModelRefs.Add(spawned);
//             //    spawned.ParentModel == currentModel;
//             //}            
//         }
//     }
// 
//     public class RemoveModel : ZCommand
//     {
//         public Model Model;
// 
//         public RemoveModel(ZComponent parent)
//             : base(parent)
//         {
//         }
// 
//         public override void Execute(ZComponent caller)
//         {
//             Model currentModel = caller as Model;
//             if (currentModel != null)
//                 App.RemoveFromScene(currentModel);
//         }
//     }
// 
//     public class RemoveAllModels : ZCommand
//     {
//         public Model OfType;
// 
//         public RemoveAllModels(ZComponent parent) : base(parent) { }
// 
//         public override void Execute(ZComponent caller)
//         {
//             App.RemoveAllModels();
//         }
//     }
}
