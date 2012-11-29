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
//using System.CodeDom.Compiler;
using ICSharpCode.TextEditor.Document;
using System.Collections.Specialized;


namespace ZGE
{
    public partial class Editor : Form
    {      
#region Fields
        bool loaded = false;
        ZApplication app = null;
        Project project;
        string loadThisProject = null;
        string DefaultFormTitle = "Z# Game Editor";
        bool idleLoop = true;

        CodeGenerator codegen = new CodeGenerator();
        TextBoxStreamWriter _writer = null;

        XmlEditorForm _xmlForm = new XmlEditorForm();
        CodeViewForm _codeForm = new CodeViewForm();
        MouseDescriptor md = new MouseDescriptor();
#endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Editor"/> class.
        /// </summary>
        public Editor()
        {
            InitializeComponent();
            CodeGenerator.editor = this;
            Project.editor = this;
            EventPropertyDescriptor.editor = this;

            // Use C# highlighting strategy
            codeBox.Document.HighlightingStrategy =
                        HighlightingStrategyFactory.CreateHighlightingStrategyForFile("dummy.cs");

            // TypeDescriptor magic to allow convenient editing for primitive vector types in PropertyGrid
            Type[] targets = { typeof(Vector2), typeof(Vector3), typeof(Vector4), typeof(Color4) };
            foreach (Type t in targets)
            {
                // To create a new instance of the struct
                TypeDescriptor.AddAttributes(t, new TypeConverterAttribute(typeof(StructConverter)));
                // To show the fields as properties
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
            catch (Exception)
            {
                int w = (int)(Screen.PrimaryScreen.Bounds.Width * 0.9);
                int h = (int)(Screen.PrimaryScreen.Bounds.Height * 0.9);
                this.Size = new Size(w, h);
            }           

            LoadToolboxComponents();
            EventsTab tab = new EventsTab();
            propertyGrid1.PropertyTabs.AddTabType(typeof(EventsTab), PropertyTabScope.Global);

            // What a shame that you cannot set this event handler from the designer ;)
            glControl1.MouseWheel += new MouseEventHandler(glControl1_MouseWheel);
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {            
            StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
            Console.SetOut(standardOutput);
            _writer.Dispose();
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

        public static bool IsToolboxItem(Type t)
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
            foreach (Type t in GetTypesFromNamespace(Assembly.GetAssembly(typeof(ZApplication)), "Gwen.Control"))
            {
                if (t.IsClass && t.IsPublic && typeof(Gwen.Control.GUIControl).IsAssignableFrom(t))
                {
                    TypeDescriptor.AddAttributes(t, new TypeConverterAttribute(typeof(ComponentList)));

                    if (t.IsAbstract == false && IsToolboxItem(t))
                    {
                        Console.WriteLine(t.FullName);
                        components.Add(t);
                    }
                }
            }
            toolbox1.AddTab("GUI Controls", components.ToArray());

            components.Clear();
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
                newNode.Text += " (No name)";
            nodes.Add(newNode);

            //  Add each child.
            //if (component.GetType() == typeof(Model))
            foreach (var element in component.Children)
                AddElementToTree(element, newNode.Nodes);
        }

        public void RefreshSceneTreeview()
        {            
            sceneTreeView.Nodes.Clear();
            foreach (ZComponent comp in app.Scene)
                AddElementToTree(comp, sceneTreeView.Nodes);
            sceneTreeView.ExpandAll();
            sceneTreeView.Invalidate();
        }

        public void SetFormTitle()
        {
            this.Text = DefaultFormTitle + " - " + project.Name;
        }

        internal void SetApplication(bool fullClear)
        {
            app = project.app;
            if (app != null)
            {
                SetFormTitle();
                app.Scene.CollectionChanged -= Scene_CollectionChanged;
                app.Scene.CollectionChanged += Scene_CollectionChanged;

                if (fullClear)
                {
                    glControl1.VSync = (app.VSync == VSyncMode.On);
                    Application.Idle -= Application_Idle;
                    Application.Idle += Application_Idle;
                }                
            }            
        }

        internal void Scene_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RefreshSceneTreeview();
        }

        private void closeProject(bool fullClear)
        {
            Application.Idle -= Application_Idle;
            SelectedComponent = null;
            if (fullClear) this.Text = DefaultFormTitle;
            sceneTreeView.Nodes.Clear();
            //sceneTreeView.Invalidate();
            xmlTree.Nodes.Clear();
            xmlTree.Invalidate();
            if (fullClear)
            {
                project = null;
                xmlTree.SetProject(null);
            }
            else
                project.ClearCode();
            app = null;
            ZComponent.App = null;
            codeBox.Text = "";
            codeBox.Refresh();
            SetCodeLabels(null);
            // TODO: All resources should be released at this point / verify finalizers!
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
                closeProject(true);          
                
                // Just a good practice - change the cursor to a wait cursor during processing
                this.Cursor = Cursors.WaitCursor;
                // Freeze the whole form - no interaction during project loading
                //this.Enabled = false;

                //Try to load the Xml document
                project = Project.CreateProject(filePath, xmlTree, codegen);
                if (project != null && project.app != null)
                {
                    SetApplication(true);
                    project.XMLChanged += project_XMLChanged;
                    RefreshSceneTreeview();

                    //glControl1_Load(this, null);
                    glControl1_Resize(this, null);
                    app.Pause();
                    SelectedComponent = app;
                    statusLabel.Text = "Project loaded.";
                    ZSGameEditor.Properties.Settings.Default.LastProjectPath = filePath;
                    ZSGameEditor.Properties.Settings.Default.Save();
                    this.Cursor = Cursors.Default;
                }
#if !DEBUG
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Exception occurred: " + ex.Message;
                Console.WriteLine(ex.ToString());
                closeProject(true);                
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
            dlg.RestoreDirectory = true; // for windows XP
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                openProject(dlg.FileName);
            }
        }

        private void newProjectBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Create new project file";
            dlg.FileName = "Untitled.xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            dlg.RestoreDirectory = true; // for windows XP
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
                    writer.Write(project.XMLText);                
                }
                statusLabel.Text = "Project saved.";
                Console.WriteLine("Project saved.");
            }
        }                 


        #region GLControl
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            if (app == null)
            {
                // Load the last project when the editor starts
                if (loadThisProject != null && loadThisProject.Length > 0)
                {
                    openProject(loadThisProject);
                    loadThisProject = null;
                }                
            }                      
        }

        public void Application_Idle(object sender, EventArgs e)
        {
            if (idleLoop == false) return;
            while (app != null && glControl1.IsIdle)
            {
                Animate();
                Render();
            }
        }

        private void Animate()
        {
            if (ZComponent.App != app) return;
            app.Update();
            
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

            if (ZComponent.App != app) return;
            app.Render();
            label1.Text = app.FpsCounter.ToString();


            glControl1.SwapBuffers();
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (app == null) return;
            //             if (e.KeyCode == Keys.Space)
            //             {                
            //                 glControl1.Invalidate();
            //             }
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
        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {            
            if (app == null) return;
            md.X = e.X; md.Y = e.Y;
            SetMouseButton(e.Button, false);            
            Model selected = app.MouseUp(sender, md);
            if (app.SelectionEnabled && selected != null)
                SelectedComponent = selected;       
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

        private void showXmlBtn_Click(object sender, EventArgs e)
        {
            _xmlForm.SetText(project.XMLText);
            _xmlForm.Show();
        }

        private void showCodeBtn_Click(object sender, EventArgs e)
        {
            if (project == null || project.xmlDoc == null) return;
            _codeForm.SetText(codegen.GenerateCodeFromXml(project.xmlDoc, true, true, project.nodeMap));
            _codeForm.Show();
        }

        private void runStandaloneBtn_Click(object sender, EventArgs e)
        {
            // Standalone compilation
            if (project == null || project.xmlDoc == null) return;
            //outputBox.Text = "";
            statusLabel.Text = "Compiling standalone game...";
            if (codegen.BuildStandaloneApplication(project.xmlDoc, Path.Combine(Application.StartupPath, project.Name+".exe")))            
            {
                statusLabel.Text = "Compilation successful.";
                
                // Disable render loop while the standalone app is running
                EventHandler onStart = (s, ev) => { Console.WriteLine("Standalone app started."); idleLoop = false; };
                EventHandler onExit = (s, ev) => { Console.WriteLine("Standalone app exited."); idleLoop = true; };
                codegen.Run(onStart, onExit);
            }
            else            
                statusLabel.Text = "Compilation failed.";
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (project == null) return;
            //outputBox.Text = ""; 
            statusLabel.Text = "Resetting project...";
            Console.WriteLine("Resetting project: "+project.Name);
#if !DEBUG
            try
            {
#endif
                closeProject(false);               
                this.Cursor = Cursors.WaitCursor;                

                //Try to rebuild project from the XML document stored in memory
                project.Reset(xmlTree, codegen);
                if (project.app != null)
                {
                    SetApplication(true);
                    RefreshSceneTreeview();
                    
                    glControl1_Resize(this, null);
                    app.Pause();
                    SelectedComponent = app;
                    statusLabel.Text = "Project reset.";                    
                    this.Cursor = Cursors.Default;
                }
#if !DEBUG
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Exception occurred: " + ex.Message;
                Console.WriteLine(ex.ToString());
                closeProject(true);                
            }            
            finally
            {                 
                this.Cursor = Cursors.Default; //Change the cursor back
            }
#endif
        }                

        public void compileCodeBtn_Click(object sender, EventArgs e)
        {            
            if (project == null || project.xmlDoc == null || project.app == null) return;
            //outputBox.Text = "";
            statusLabel.Text = "Recompiling project...";
#if !DEBUG
            try
            {
#endif
                this.Cursor = Cursors.WaitCursor;
                //project.ClearCode();
                //Console.WriteLine("SelectedComponent is {0}", SelectedComponent.GetType().AssemblyQualifiedName);
                if (project.RecompileApplication(codegen, xmlTree))
                {
                    SetApplication(false);
                    //app.Pause();                

                    RefreshSceneTreeview();
                    // The old ZApplication should be finalized at this point 
                    // All references should be cleared
                    GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                    
                    //SelectedComponent = app;  // the old selected component might be invalid
                    statusLabel.Text = "Project recompiled.";
                }
                else
                    statusLabel.Text = "Project recompilation failed.";
                this.Cursor = Cursors.Default;
#if !DEBUG
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Exception occurred: " + ex.Message;
                Console.WriteLine(ex.ToString());
                closeProject(true);                
            }            
            finally
            {                
                // Also unfreeze the form
                //this.Enabled = true;
                this.Cursor = Cursors.Default; //Change the cursor back
            }
#endif
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            app.Pause();
        }

        private void xmlTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (xmlTree.SelectedComponent == null) return;
            ZComponent comp = xmlTree.SelectedComponent as ZComponent;
            if (comp != null) SelectedComponent = comp;
        }        

        private void xmlTree_StatusStringChanged(object sender, EventArgs e)
        {
            statusLabel.Text = xmlTree.StatusString;
        }

        private void project_XMLChanged(object sender, EventArgs e)
        {
            if (_xmlForm.Visible && project != null)
                _xmlForm.SetText(project.XMLText);
        }

        private void propertyGrid1_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            //Console.WriteLine("Property Value Changed.");
            GridItem g = e.ChangedItem;
            //if (g.Parent != null)
                //Console.WriteLine("Parent: {0}",g.Parent.ToString());
            ZComponent comp = selectedComponent as ZComponent;
            if (comp != null && project != null)
            {
                ZNodeProperties nodeProps = comp.Tag as ZNodeProperties;                
                if (nodeProps != null)
                {
                    GridItem parent = g.Parent;                    
                    if (parent != null && parent.GridItemType == GridItemType.Property)
                        project.UpdateAttribute(nodeProps, parent.PropertyDescriptor.Name, parent.Value);
                    else
                        project.UpdateAttribute(nodeProps, g.PropertyDescriptor.Name, g.Value);                    
                }
                // This component might need a full refresh (e.g. MeshProducers)
                INeedRefresh obj = comp as INeedRefresh;
                if (obj != null) obj.Refresh();
                if (g.PropertyDescriptor.Name == "Name")
                {
                    ZComponent.App.RefreshName(comp, g.Value as string, e.OldValue as string);
                    if (nodeProps != null) xmlTree.UpdateNodeText(nodeProps);

                    // TODO: Also update named references in XML attributes
                }
                if (comp == app && g.PropertyDescriptor.Name == "VSync")
                    glControl1.VSync = (app.VSync == VSyncMode.On);
                if (comp == app && g.PropertyDescriptor.Name == "Title")
                    SetFormTitle();
            }
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            if (propertyGrid1.SelectedTab.TabName != "Events") return;
            
            //Console.WriteLine("GridItem Changed.");
            GridItem g = e.NewSelection;            
            
            if (typeof(CodeLike).IsAssignableFrom(g.PropertyDescriptor.PropertyType))
            {
                //Console.WriteLine("CodeLike selected.");
                CodeLike code = g.Value as CodeLike;
                if (code != null && project != null)
                {
                    project.ClearCode(); // prevent codeBox_TextChanged from changing the previously selected code                    
                    codeBox.Text = code.Text;
                    //codeBox.Invalidate();
                    codeBox.Refresh();
                    project.SetCode(code, selectedComponent as ZComponent, g.PropertyDescriptor.Name);
                    SetCodeLabels(g.PropertyDescriptor);
                }
            }
            else if (typeof(Delegate).IsAssignableFrom(g.PropertyDescriptor.PropertyType))
            {
                //Console.WriteLine("Event selected.");

                if (project != null)
                {
                    project.ClearCode(); // prevent codeBox_TextChanged from changing the previously selected code                                            
                    project.SetEventCode(selectedComponent as ZComponent, g.PropertyDescriptor.Name, codeBox);
                    codeBox.Refresh();
                    SetCodeLabels(g.PropertyDescriptor);
                }
            }
        }

        private void SetCodeLabels(PropertyDescriptor prop)
        {
            if (prop == null)
            {
                methodLabel.Text = "[Method Signature]";
                eventLabel.Text = "[Event Name]";
                return;
            }
            string methodName = prop.Name;
            ZComponent comp = selectedComponent as ZComponent;
            if (typeof(Delegate).IsAssignableFrom(prop.PropertyType))
            {                 
                methodLabel.Text = codegen.GetMethodHeader(methodName, prop.PropertyType, false);                
            }
            else if (typeof(CodeLike).IsAssignableFrom(prop.PropertyType))
            {
                methodLabel.Text = prop.PropertyType.Name;
            }
            if (comp != null)
            {
                if (comp.HasName())
                    eventLabel.Text = comp.Name + "/" + methodName.TrimEnd();
                else
                {
                    ZNodeProperties zprops = comp.Tag as ZNodeProperties;
                    if (zprops != null && zprops.xmlNode.ParentNode != null)
                        eventLabel.Text = String.Format("{0}/{1}/{2}", zprops.xmlNode.ParentNode.Name, comp.GetType().Name, methodName);
                    else
                        eventLabel.Text = String.Format("{0}/{1}", comp.GetType().Name, methodName);
                }
            }
            else
                eventLabel.Text = methodName;

            eventLabel.Left = codePanel.Width - eventLabel.Width;
        }

        private void codeBox_TextChanged(object sender, EventArgs e)
        {
            if (project != null)
                project.CodeChanged(codeBox.Text);
        }
          
    }
}