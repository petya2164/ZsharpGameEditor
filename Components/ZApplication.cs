using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;

namespace ZGE.Components
{
    public class MouseDescriptor
    {
        public MouseDescriptor() {}

        readonly bool[] button_state = new bool[Enum.GetValues(typeof(MouseButton)).Length];
        //public int Clicks { get; }
        public MouseButton Button { get; set; } 
        public int WheelDelta { get; set; }       
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Gets a System.Boolean indicating the state of the specified MouseButton.
        /// </summary>
        /// <param name="button">The MouseButton to check.</param>
        /// <returns>True if the MouseButton is pressed, false otherwise.</returns>
        public bool this[MouseButton button]
        {
            get
            {
                return button_state[(int)button];
            }
            set
            {                
                button_state[(int)button] = value;               
            }
        }
    }

    public class MovingAverage
    {
        double[] values = new double[60];  // all 0's initially
        double sum = 0;
        int pos = 0;

        public MovingAverage() { }

        public void AddValue(double v)
        {
            sum -= values[pos];  // only need the array to subtract old value
            sum += v;
            values[pos] = v;
            pos = (pos + 1) % values.Length;
        }

        public double Average()
        {
            return sum / values.Length;
        }
    }


    [HideComponent]
    public class ZApplication : ZComponent
    {
        public string Title = "ZApplication";
        public string AssetsPath = "Assets/";

        public int Width = 800;
        public int Height = 600;
        [ReadOnlyAttribute(true)]
        public int CurrentWidth;
        [ReadOnlyAttribute(true)]
        public int CurrentHeight;
        [ReadOnlyAttribute(true)]
        public float AspectRatio;
        public GraphicsMode Mode = GraphicsMode.Default;

        public VSyncMode VSync = VSyncMode.Off;
        public double UpdateFrequency = 60.0;
        public Color ClearColor = Color.Black;

        public bool Lighting = true;
        public Vector4 LightPosition = new Vector4(0, 0, 1, 0);

        public Camera Camera;
        public MouseButton SelectButton = MouseButton.Left;
        public bool SelectionEnabled = true;
        public GameObject SelectedObject = null;

        public int RenderPasses = 1;
        [ReadOnlyAttribute(true)]
        public int CurrentRenderPass = 0;

        [ReadOnlyAttribute(true)]
        public double DeltaTime;
        [ReadOnlyAttribute(true)]
        public double Time;
        [ReadOnlyAttribute(true)]
        public double FpsCounter;
        [ReadOnlyAttribute(true)]
        public double FpsEstimated;
        [Browsable(false)]
        public Dictionary<Key, bool> IsKeyDown = new Dictionary<Key, bool>();

        List<double> times = new List<double>();
        Stopwatch stopwatch = new Stopwatch();
        double lastUpdate = 0.0;
        double lastRender = 0.0;
        MovingAverage fpsMA = new MovingAverage();
        internal Dictionary<string, ZComponent> nameMap = new Dictionary<string, ZComponent>();
        internal Dictionary<Type, List<ZComponent>> typeMap = new Dictionary<Type, List<ZComponent>>();

        [Browsable(false)]
        public Standalone frame = null;
        //public static ZApplication inst = null;

        // XML Branches
        [Browsable(false)]
        public List<ZCommand> OnLoad = new List<ZCommand>();
        [Browsable(false)]
        public List<ZCommand> OnUnload = new List<ZCommand>();
        [Browsable(false)]
        public List<ZCommand> OnResize = new List<ZCommand>();
        [Browsable(false)]
        public List<ZCommand> OnUpdate = new List<ZCommand>();
        [Browsable(false)]
        public List<ZCommand> OnRender = new List<ZCommand>();
        [Browsable(false)]
        public List<ZCommand> OnKeyDown = new List<ZCommand>();
        [Browsable(false)]
        public List<ZCommand> OnKeyUp = new List<ZCommand>();
        [Browsable(false)]
        public List<ZCommand> OnBeginRenderPass = new List<ZCommand>();

        [Browsable(false)]
        public List<ZComponent> Content = new List<ZComponent>();
        [Browsable(false)]
        public List<ZComponent> Scene = new List<ZComponent>();
        [Browsable(false)]
        public List<ZComponent> GUI = new List<ZComponent>();
        
        [Browsable(false)]
        public List<ZCode> code = new List<ZCode>();
        private List<ZContent> content = new List<ZContent>();

        /*public delegate void EmptyHandler();
        public delegate void FrameHandler(FrameEventArgs e);
        public delegate void ResizeHandler(int x, int y, int width, int height);
        public delegate void KeyboardHandler(object sender, KeyboardKeyEventArgs e);

        public event EmptyHandler OnLoad;
        public event EmptyHandler OnUnload;
        public event ResizeHandler OnResize;
        public event FrameHandler OnUpdate;
        public event FrameHandler OnRender;

        public event KeyboardHandler OnKeyDown;
        public event KeyboardHandler OnKeyUp;*/

        public ZApplication()
        {
            App = this; // there can be only one ZApplication at a time                     
            stopwatch.Start(); // start at application boot
        }

        public void AddComponent(ZComponent comp)
        {
            if (comp.HasName())
                nameMap[comp.Name] = comp;

            Type type = comp.GetType(); // TODO: consider all ancestor types
            if (!typeMap.ContainsKey(type))
                typeMap[type] = new List<ZComponent>();

            typeMap[type].Add(comp);
        }

        public ZComponent Find(string name)
        {
            ZComponent result = null;
            nameMap.TryGetValue(name, out result);
            return result;
        }

        public void RefreshName(ZComponent comp, string name)
        {
            // Remove the component from the nameMap - if necessary
            foreach (var item in nameMap.Where(kvp => kvp.Value == comp).ToList())
            {
                nameMap.Remove(item.Key);
            }
            if (comp.HasName())
                nameMap[comp.Name] = comp;
        }

        public List<String> ListComponentNames(Type type)
        {
            List<string> result = new List<string>();
            if (typeMap.ContainsKey(type))
                foreach (ZComponent comp in typeMap[type])
                    if (comp.HasName()) result.Add(comp.Name);

            return result;
        }

        public void AddContent(ZContent item)
        {
            if (!content.Contains(item))
                content.Add(item);
        }

        public void AddCode(ZCode item)
        {
            if (!code.Contains(item))
                code.Add(item);
        }

        public void AddToScene(Model model)
        {
            //Console.WriteLine("Model added to scene.");
            model.Active = true;
            Scene.Add(model);
        }

        public void RemoveFromScene(Model model)
        {
            model.Active = false;
            Scene.Remove(model);
        }

        public void RemoveAllModels()
        {
            Scene.Clear();
        }

        public virtual void KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            IsKeyDown[e.Key] = true;
            //if (OnKeyDown != null) OnKeyDown(sender, e);
            OnKeyDown.ExecuteAll(this);
        }

        public virtual void KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            IsKeyDown[e.Key] = false;
            //if (OnKeyDown != null) OnKeyDown(sender, e);
            OnKeyUp.ExecuteAll(this);
        }

        public virtual void MouseDown(object sender, MouseDescriptor e)
        {            
            // GUI has priority in handling mouse events

            // Then the camera
            if (Camera == null || Camera.MouseDown(e) == false)
            {
                // Selection & Dragbox Selection 
            }            
        }

        public virtual GameObject MouseUp(object sender, MouseDescriptor e)
        {
            // GUI has priority in handling mouse events
            
            // Then the camera
            if (Camera == null || Camera.MouseUp(e) == false)
            {            
                // Selection & Dragbox Selection                
                if (SelectionEnabled && e.Button == SelectButton)
                {
                    //  Do a hit test.
                    ZComponent comp = MousePick(e.X, e.Y);
                    if (comp != null)
                    {
                        Console.WriteLine("MousePick result: {0}", comp.Name);
                        SelectedObject = comp as GameObject;
                        return SelectedObject;
                    }
                }                
            }
            return null;
        }

        public virtual void MouseMove(object sender, MouseDescriptor e)
        {
            if (Camera != null) Camera.MouseMove(e);
        }

        public virtual void MouseWheel(object sender, MouseDescriptor e)
        {
            if (Camera != null) Camera.MouseWheel(e);
        }

        

        public virtual void Load()
        {
            Renderer.Init(this);

            //  Initialise the scene.
            //SharpGL.SceneGraph.Helpers.SceneHelper.InitialiseModelingScene(scene);

            // Initialize all content
            foreach (ZContent comp in content)
            {               
                if (comp != null) comp.RefreshFromProducers();
            }

            // Initialize all GameObjects in the scene
            foreach (ZComponent comp in Scene)
            {
                GameObject go = comp as GameObject;
                if (go != null) go.Init();
            }
            
            OnLoad.ExecuteAll(this);
        }

        public virtual void Resize(int x, int y, int width, int height)
        {
            this.CurrentWidth = width;
            this.CurrentHeight = height;           
            GL.Viewport(x, y, width, height);

            this.AspectRatio = width / (float) height;           
            OnResize.ExecuteAll(this);
        }

        public virtual void SetupGUI()
        {
            GL.MatrixMode(All.PROJECTION);            
            GL.LoadIdentity();
            GL.Ortho(0, CurrentWidth, 0, CurrentHeight, 1, -1);
            GL.MatrixMode(All.MODELVIEW);            
            GL.LoadIdentity(); 
        }

        public virtual void Update(FrameEventArgs e)
        {
            double now = stopwatch.Elapsed.TotalMilliseconds;
            double delta = now - lastUpdate;
            lastUpdate = now;
            DeltaTime = delta / 1000.0;
            Time = stopwatch.Elapsed.TotalSeconds;
            
            OnUpdate.ExecuteAll(this);
            foreach (ZComponent comp in Scene)
            {
                IUpdateable obj = comp as IUpdateable;
                if (obj != null) obj.Update();
            }
        }

        /// <summary>
        /// This function draws all of the objects in the scene.
        /// </summary>
        public virtual void Render(FrameEventArgs e)
        {
            double now = stopwatch.Elapsed.TotalMilliseconds;
            times.Add(now);
            while (times[0] < now - 1000.0)
                times.RemoveAt(0);
            FpsCounter = times.Count;
            double delta = now - lastRender;
            lastRender = now;
            DeltaTime = delta / 1000.0;
            fpsMA.AddValue(DeltaTime);
            FpsEstimated = 1.0 / fpsMA.Average();
            Time = stopwatch.Elapsed.TotalSeconds;
            //DeltaTime = e.Time;

            if (Camera == null) return;

            for (int i = 0; i < RenderPasses; i++)
            {
                CurrentRenderPass = i;
                OnBeginRenderPass.ExecuteAll(this);

                //if (ViewportRatio==vprCustom && CurrentRenderTarget=null) 
                //UpdateViewport();   

                //Use custom camera                 
                Camera.Apply();                

                //if (ClearScreenMode == 0 && CurrentRenderTarget = null)
                {
                    GL.ClearColor(ClearColor);
                    GL.Clear(All.COLOR_BUFFER_BIT | All.DEPTH_BUFFER_BIT | All.STENCIL_BUFFER_BIT);
                }

                if (Lighting)
                {
                    GL.Enable(All.LIGHTING);
                    //glLightModelfv(GL_LIGHT_MODEL_AMBIENT, AmbientLightColor);
                    //if (Scene.Lights.Count == 0)
                           //GL.Light(All.LIGHT0, All.POSITION, LightPosition);
//                     else
//                     {
//                         for (int j = 0; j < Scene.Lights.Count; j++)
//                             Scene.Lights[j].ApplyLight(j);
//                     }
                }
                else
                    GL.Disable(All.LIGHTING);

                Renderer.Begin();
                RenderScene();
                
                GL.PushMatrix();
                Renderer.ApplyDefaultMaterial();
                OnRender.ExecuteAll(this); // this should be first: rendering background or skybox
                Renderer.ApplyDefaultMaterial();
                //CurrentState.OnRender.ExecuteCommands;
                GL.PopMatrix();

                SetupGUI();
                foreach (ZComponent comp in GUI)
                {
                    IRenderable obj = comp as IRenderable;
                    if (obj != null) obj.Render();
                }
                Renderer.End();

                if (Lighting)
                {
//                     for (int j = 0; j < Scene.Lights.Count; j++)
//                         Scene.Lights[j].RemoveLight(j);
                }
            }
            GL.Flush();
        }

        public virtual void RenderScene()
        {
            foreach (ZComponent comp in Scene)
            {
                IRenderable obj = comp as IRenderable;
                if (obj != null) obj.Render();
            }

            // TODO: DepthSorting + ViewPos + FrustrumCulling

            /*DepthList.Clear;  
              glGetFloatv(GL_PROJECTION_MATRIX, @Matrix);
              glGetFloatv(GL_MODELVIEW_MATRIX, @TmpM);
              Matrix := MatrixMultiply(TmpM,Matrix);
              

              for I := 0 to Models.Cats.Count-1 do
              begin
                List := Models.Get(I);
                for J := 0 to List.Count-1 do
                begin
                  Model := TModel(List[J]);
                  if Model.RenderOrder=roDepthsorted then
                  begin
                    //Get screen Z-position
                    VectorTransform(Model.Position,Matrix,V);
                    Model.SortKey := V[2];
                    DepthList.Add(Model)
                  end
                  else
                    Renderer.RenderModel(Model);
                end;
              end;

              SortModels(DepthList);

              for I := DepthList.Count-1 downto 0 do
              begin
                Model := TModel(DepthList[I]);
                Renderer.RenderModel(Model);
              end;*/
        }

        public virtual ZComponent MousePick(int x, int y)
        {
            if (Camera == null) return null;
            
            //  Create a result set.
            List<ZComponent> resultSet = new List<ZComponent>();

            //  Create a hitmap.
            Dictionary<uint, ZComponent> hitMap = new Dictionary<uint, ZComponent>();            

            //	Create an array that will be the viewport.
            int[] viewport = new int[4];

            //	Get the viewport, then convert the mouse point to an opengl point.
            GL.GetInteger(All.VIEWPORT, viewport);
            y = viewport[3] - y;

            //	Create a select buffer.
            uint[] buffer = new uint[512];
            GL.SelectBuffer(512, buffer);

            //	Enter select mode.
            GL.RenderMode(All.SELECT);

            //	Initialise the names, and add the first name.
            GL.InitNames();
            GL.PushName(0);

            Matrix4 pickMatrix = Matrix4.CreatePickMatrix(x, y, 4, 4, viewport);
            Camera.Apply(ref pickMatrix);            

            //  Create the name.
            uint currentName = 1;

            // TODO: Set the render mode

            //  Render the scene for hit testing.            
            foreach (ZComponent comp in Scene)
            {               
                if (comp is IRenderable)
                    RenderComponentForHitTest(comp, hitMap, ref currentName);
            }
            GL.Flush();

            //	End selection.
            int hits = GL.RenderMode(All.RENDER);            

            if (hits > 0)
            {
                uint selectedId = 0;
                uint closest = uint.MaxValue;

                for (int i = 0; i < hits; i++)
                {
                    uint distance = buffer[i * 4 + 1];

                    if (distance <= closest)
                    {
                        closest = distance;
                        selectedId = buffer[i * 4 + 3];
                    }
                }

                if (selectedId != 0)
                {
                    Vector3 screen = new Vector3(x, y, 1.0f);                    
                    GL.ReadPixels<float>(x, y, 1, 1, All.DEPTH_COMPONENT, All.FLOAT, ref screen.Z);
                    Vector3 pos = MathHelper.UnProject(screen, ref Camera.ProjectionMatrix, ref Camera.ViewMatrix, viewport);
                    Console.WriteLine("Coordinates: {0}", pos.ToString());
                    return hitMap[selectedId];
                }
            }
            
            return null;
        }

        private void RenderComponentForHitTest(ZComponent comp,
            Dictionary<uint, ZComponent> hitMap, ref uint currentName)
        {
            //  If the element is disabled, we're done.
            //  Also, never hit test the current camera.
            if (comp.Enabled == false || comp is Camera)
                return;

            if (comp is Group)
            {
                //  Recurse through the children.
                foreach (var childElement in comp.Children)
                    RenderComponentForHitTest(childElement, hitMap, ref currentName); 
            }
            else if (comp is IRenderable)
            {
                //  Load and map the name.
                GL.LoadName(currentName);
                hitMap[currentName] = comp;

                //  Render the bounding volume.
                //((IVolumeBound) comp).BoundingVolume.Render(gl, RenderMode.HitTest);

                //  Render the object with no materials
                IRenderable obj = comp as IRenderable;
                if (obj != null) obj.Render();

                //  Increment the name.
                currentName++;                
            }
                      
        }
    }
}
