using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;

using OpenTK;
using OpenTK.Graphics;
//using OpenTK.Graphics.OpenGL;
//using OpenTK.Input;

using System.IO;
using System.Collections;
using System.Reflection;
using ZGE.Components;
using System.CodeDom.Compiler;
using ICSharpCode.TextEditor.Document;


namespace ZGE
{
    public partial class Editor : Form
    {         
        bool loaded = false;
        ZApplication app = null;
        Project project;
        string loadThisProject = null;

        CodeGenerator codegen = new CodeGenerator();
        TextBoxStreamWriter _writer = null;

        XmlEditorForm _xmlForm = new XmlEditorForm();
        MouseDescriptor md = new MouseDescriptor();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Editor"/> class.
        /// </summary>
        public Editor()
        {
            InitializeComponent();

            // Use C# highlighting strategy
            codeBox.Document.HighlightingStrategy =
                        HighlightingStrategyFactory.CreateHighlightingStrategyForFile("dummy.cs");

            // TypeDescriptor magic to allow convenient editing for primitive vector types in PropertyGrid
            Type[] targets = { typeof(Vector2), typeof(Vector3), typeof(Vector4), typeof(Color4) };
            foreach (Type t in targets)
            {
                TypeDescriptor.AddAttributes(t, new TypeConverterAttribute(typeof(StructConverter)));
                TypeDescriptor.AddProvider(new FieldsToPropertiesTypeDescriptionProvider(t), t);
            }              

            // Instantiate the writer
            _writer = new TextBoxStreamWriter(outputBox);
            // Redirect the out Console stream
            Console.SetOut(_writer);

            try
            {
                Width = ZSGameEditor.Properties.Settings.Default.IDEWidth;
                Height = ZSGameEditor.Properties.Settings.Default.IDEHeight;                               

                Left = ZSGameEditor.Properties.Settings.Default.IDELeft;
                Top = ZSGameEditor.Properties.Settings.Default.IDETop;
                loadThisProject = ZSGameEditor.Properties.Settings.Default.LastProjectPath;
                if (File.Exists(loadThisProject) == false)
                {
                    loadThisProject = null;
                    ZSGameEditor.Properties.Settings.Default.LastProjectPath = null;
                    ZSGameEditor.Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                int w = (int)(Screen.PrimaryScreen.Bounds.Width * 0.9);
                int h = (int)(Screen.PrimaryScreen.Bounds.Height * 0.9);
                this.Size = new Size(w, h);
            }           

            LoadToolboxComponents();           

            glControl1.MouseWheel += new MouseEventHandler(glControl1_MouseWheel);
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ZSGameEditor.Properties.Settings.Default.IDEWidth = this.Width;
            ZSGameEditor.Properties.Settings.Default.IDEHeight = this.Height;
            ZSGameEditor.Properties.Settings.Default.IDELeft = this.Left;
            ZSGameEditor.Properties.Settings.Default.IDETop = this.Top;
            ZSGameEditor.Properties.Settings.Default.Save();
        }

        public static IEnumerable<Type> GetTypesFromNamespace(Assembly assembly,
                                               String myNamespace)
        {
            return assembly.GetTypes().Where(type => type.Namespace == myNamespace);            
        }

        public bool IsToolboxItem(Type t)
        {
            object[] attributes = t.GetCustomAttributes(typeof(HideComponent), false);
            foreach (HideComponent attribute in attributes)
            {
                if (attribute.Hidden) return false;                               
            }
            
            return true;
        }

        private void LoadToolboxComponents()
        {
            List<Type> components = new List<Type>();
            foreach (Type t in GetTypesFromNamespace(Assembly.GetAssembly(typeof(ZApplication)), "ZGE.Components"))
            {
                if (t.IsClass && t.IsPublic && typeof(ZComponent).IsAssignableFrom(t))
                {
                    TypeDescriptor.AddAttributes(t, new TypeConverterAttribute(typeof(ComponentList)));
                    
                    if (t.IsAbstract == false && IsToolboxItem(t))
                    {
                        Console.WriteLine(t.FullName);                        
                        components.Add(t);
                    }                   
                }
            }
            toolbox1.AddTab("Components", components.ToArray());
        }               

        /// <summary>
        /// The selected scene element.
        /// </summary>
        private object selectedComponent = null;

        /// <summary>
        /// Gets or sets the selected scene element.
        /// </summary>
        /// <value>
        /// The selected scene element.
        /// </value>
        public object SelectedComponent
        {
            get { return selectedComponent; }
            set
            {
                selectedComponent = value;
                OnSelectedSceneElementChanged();
            }
        }

        /// <summary>
        /// Called when [selected scene element changed].
        /// </summary>
        private void OnSelectedSceneElementChanged()
        {
            object target = selectedComponent;
            propertyGrid1.SelectedObject = (target != null) ? new FieldsProxy(target) : null;
        }                        
        

        private void sceneTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedComponent = e.Node.Tag as ZComponent;
        }

        private void showXmlBtn_Click(object sender, EventArgs e)
        {
            _xmlForm.SetText(xmlEditor.Content);
            _xmlForm.Show();
        }

        private void showCodeBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddElementToTree(ZComponent component, TreeNodeCollection nodes)
        {
            //  Add the element.
            TreeNode newNode = new TreeNode()
            {
                Tag = component
            };
            newNode.Text = component.GetType().Name;
            if (component.HasName())
                newNode.Text = newNode.Text + ": " + component.Name;
            else
                newNode.Text += " (Unnamed)";
            nodes.Add(newNode);

            //  Add each child.
            foreach (var element in component.Children)
                AddElementToTree(element, newNode.Nodes);
        } 

        private void openProject(string filePath)
        {
            outputBox.Text = ""; 
            statusLabel.Text = "Loading project...";
            Console.WriteLine("Loading project: "+filePath);
#if !DEBUG
            try
            {
#endif
                // TODO: All resources should be released at this point
                SelectedComponent = null;
                project = null;
                app = null;
                ZComponent.App = null;
                
                // Just a good practice - change the cursor to a wait cursor during processing
                this.Cursor = Cursors.WaitCursor;
                // Freeze the whole form - no interaction during project loading
                //this.Enabled = false;

                //Try to load the Xml document
                var zapp = Factory.Load(filePath, xmlEditor);
                if (zapp != null)
                {
                    project = new Project(filePath);                                     
                    codeBox.Text = "";                                      
                    app = zapp;

                    //  Add the element to the tree.
                    sceneTreeView.Nodes.Clear();
                    foreach(ZComponent comp in app.Scene)
                        AddElementToTree(comp, sceneTreeView.Nodes);
                    sceneTreeView.ExpandAll();
                    sceneTreeView.Invalidate();

                    glControl1_Load(this, null);
                    glControl1_Resize(this, null);
                    SelectedComponent = app;
                    statusLabel.Text = "Project loaded.";
                    ZSGameEditor.Properties.Settings.Default.LastProjectPath = filePath;
                    ZSGameEditor.Properties.Settings.Default.Save();
                }
#if !DEBUG
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Exception occurred: " + ex.Message;
                Console.WriteLine(ex.ToString());
                project = null;
                app = null;
                ZComponent.App = null;
                sceneTreeView.Nodes.Clear();
                xmlTreeView.Nodes.Clear();
            }            
            finally
            {                
                // Also unfreeze the form
                //this.Enabled = true;
                this.Cursor = Cursors.Default; //Change the cursor back
            }
#endif
        }

        private void openProjectBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open project file";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            dlg.InitialDirectory = Path.Combine(Application.StartupPath, "Projects");            
            dlg.FileName = "Island.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                openProject(dlg.FileName);
            }
        }

        private void newProjectBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Create new project file";
            dlg.FileName = "Project1.xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //exportToXml2(xmlTreeView, dlg.FileName);
                MessageBox.Show("Creating new projects is not yet supported :(");
            }
        } 

        private void saveProjectBtn_Click(object sender, EventArgs e)
        {
            if (project != null)
            {
                statusLabel.Text = "Saving project...";
                using (StreamWriter writer = new StreamWriter(project.filePath, false))
                {
                    writer.Write(xmlEditor.Content);                
                }
                statusLabel.Text = "Project saved.";
            }
        }                 


        #region GLControl
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            if (app == null)
            {
                if (loadThisProject != null && loadThisProject.Length > 0)
                {
                    openProject(loadThisProject);
                    loadThisProject = null;
                }
                return;
            }
            app.Load();
            glControl1.VSync = (app.VSync == VSyncMode.On);

            Application.Idle -= Application_Idle;
            Application.Idle += Application_Idle; // press TAB twice after +=            
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (app == null) return;
            //             if (e.KeyCode == Keys.Space)
            //             {                
            //                 glControl1.Invalidate();
            //             }
        }

        void Application_Idle(object sender, EventArgs e)
        {           
            while (app != null && glControl1.IsIdle)
            {
                Animate();
                Render();
            }
        }

        private void Animate()
        {            
            var fe = new FrameEventArgs();
            app.Update(fe);
            
            // Refresh the values shown in the PropertyGrid
            //propertyGrid1.Refresh();
            //propertyGrid1.RefreshTabs();
            //if (propertyGrid1.SelectedObject != null)
                //propertyGrid1.SelectedObject = xmlEditor.PropertiesForSelectedNode;  
        }        

        //         private void Accumulate(double milliseconds)
        //         {
        //             idleCounter++;
        //             accumulator += milliseconds;
        //             if (accumulator > 1000)
        //             {
        //                 label1.Text = idleCounter.ToString();
        //                 accumulator -= 1000;
        //                 idleCounter = 0; // don't forget to reset the counter!
        //             }
        //         }          

        private void glControl1_Resize(object sender, EventArgs e)
        {            
            int w = glControl1.Width;
            int h = glControl1.Height;
            if (app != null) app.Resize(0, 0, w, h);

            //scene.Resize(w, h);
            glControl1.Invalidate();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void Render()
        {
            if (!loaded) return;
            if (app == null || ZComponent.App == null)
            {
                glControl1.SwapBuffers();
                return;
            }

            var fe = new FrameEventArgs();
            app.Render(fe);
            label1.Text = app.FpsCounter.ToString();


            glControl1.SwapBuffers();
        }

        private void SetMouseButton(MouseButtons btn, bool value)
        {
            if (btn == MouseButtons.Left)
            {
                md[OpenTK.Input.MouseButton.Left] = value;
                md.Button = OpenTK.Input.MouseButton.Left;
            }
            else if (btn == MouseButtons.Right)
            {
                md[OpenTK.Input.MouseButton.Right] = value;
                md.Button = OpenTK.Input.MouseButton.Right;
            }
            else if (btn == MouseButtons.Middle)
            {
                md[OpenTK.Input.MouseButton.Middle] = value;
                md.Button = OpenTK.Input.MouseButton.Middle;
            }
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {           
            if (app == null) return;
            md.X = e.X; md.Y = e.Y;
            SetMouseButton(e.Button, true);
            app.MouseDown(sender, md);
            //SelectedSceneElement = null;            
        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {            
            if (app == null) return;
            md.X = e.X; md.Y = e.Y;
            SetMouseButton(e.Button, false);            
            app.MouseUp(sender, md);
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (app == null) return;
            md.X = e.X; md.Y = e.Y;
            app.MouseMove(sender, md);                        
        }

        private void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {            
            if (app == null) return;
            md.X = e.X; md.Y = e.Y;
            md.WheelDelta = e.Delta;
            app.MouseWheel(sender, md);            
        }

        

        #endregion
        private void toolboxBtn_Click(object sender, EventArgs e)
        {
            toolboxSplitter.Panel1Collapsed = !toolboxSplitter.Panel1Collapsed;
        }

        private void xmlEditor_ContentChanged(object sender, EventArgs e)
        {
            if (_xmlForm.Visible)
                _xmlForm.SetText(xmlEditor.Content);
        }

        private void xmlEditor_PropertiesSetChanged(object sender, EventArgs e)
        {
            if (xmlEditor.SelectedComponent == null) return;
            ZComponent comp = xmlEditor.SelectedComponent as ZComponent;
            if (comp != null) SelectedComponent = comp;        
        }

        private void xmlEditor_PropertiesWindowActivated(object sender, EventArgs e)
        {

        }

        private void xmlEditor_StatusStringChanged(object sender, EventArgs e)
        {
            statusLabel.Text = xmlEditor.StatusString;
        }

        private void runStandaloneBtn_Click(object sender, EventArgs e)
        {
            // Standalone compilation
            outputBox.Text = "";
            statusLabel.Text = "Compiling standalone game...";
            var res = codegen.BuildAssembly(Path.Combine(Application.StartupPath, "Small.exe"), codeBox.Text, false);

            if (res.Errors.HasErrors)
            {
                statusLabel.Text = "Compilation failed.";                
            }
            else
            {
                statusLabel.Text = "Compilation successful.";
                codegen.Run();
            }
        }

        private void playInEditorBtn_Click(object sender, EventArgs e)
        {
            outputBox.Text="";
            statusLabel.Text = "Starting code compilation...";
            if (codegen.GenerateGameCode(app))
                statusLabel.Text = "App running";
            else
                statusLabel.Text = "Compilation failed";          
            
            
//             var res = loader.BuildAssembly(Path.Combine(Application.StartupPath, "Small.exe"), codeBox.Text, true);            
//             if (res.Errors.HasErrors)
//             {
//                 statusLabel.Text = "Compilation failed.";
//                 string errors = "Errors during compile:\n\n";
// 
//                 foreach (CompilerError error in res.Errors)
//                 {
//                     errors += error.ErrorText + "\n";
//                 }
// 
//                 textBox1.Text = errors;
//                 //MessageBox.Show(errors, "Errors during compile.");
//             }
//             else
//             {
//                 statusLabel.Text = "Compilation successful.";
//                 // If there weren't any errors get an instance of "Small"           
//             
//                 var zapp = res.CompiledAssembly.CreateInstance("ZGE.Small") as ZApplication;
//                 if (zapp != null)
//                 {
//                     statusLabel.Text = "Loading app.";
//                     app = zapp;
//                     glControl1_Load(this, null);
//                     glControl1_Resize(this, null);
//                 }
//                 
//             }
        }

        private void propertyGrid1_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            Console.WriteLine("Property Value Changed.");
            GridItem g = e.ChangedItem;
            //if (g.Parent != null)
                //Console.WriteLine("Parent: {0}",g.Parent.ToString());
            ZComponent comp = selectedComponent as ZComponent;
            if (comp != null)
            {
                ZNodeProperties nodeProps = comp.Tag as ZNodeProperties;                
                if (nodeProps != null)
                {
                    GridItem parent = g.Parent;
                    PropertyChangedEventArgs ev = null;
                    if (parent != null && parent.GridItemType == GridItemType.Property)
                        ev = new PropertyChangedEventArgs(parent.PropertyDescriptor.Name, parent.Value);
                    else
                        ev = new PropertyChangedEventArgs(g.PropertyDescriptor.Name, g.Value);
                    ev.Action = PropertyChangeAction.AttributeChanged;
                    nodeProps.PropertyHolderChanged(sender, ev);
                }
                // This component might need a full refresh (e.g. MeshProducers)
                INeedRefresh obj = comp as INeedRefresh;
                if (obj != null) obj.Refresh();
                if (g.PropertyDescriptor.Name == "Name")
                    ZComponent.App.RefreshName(comp, g.Value as string);
                if (comp == app && g.PropertyDescriptor.Name == "VSync")
                    glControl1.VSync = (app.VSync == VSyncMode.On);
            }
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            //Console.WriteLine("GridItem Changed.");
            GridItem g = e.NewSelection;
            if (g.PropertyDescriptor.PropertyType == typeof(ZCode))
            {
                //Console.WriteLine("ZCode selected.");
                ZCode code = g.Value as ZCode;
                if (code != null && project != null)
                {
                    project.ClearCode(); // prevent codeBox_TextChanged from changing the previously selected code
                    codeBox.Text = code.Text;
                    project.SetCode(code, selectedComponent as ZComponent, g.PropertyDescriptor.Name);
                }
            }
        }

        private void codeBox_TextChanged(object sender, EventArgs e)
        {
            if (project != null)
                project.CodeChanged(codeBox.Text);            
        }

    }
}