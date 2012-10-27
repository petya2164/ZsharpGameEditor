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
using Loader;
using ZGE.Components;
using System.CodeDom.Compiler;
using ICSharpCode.TextEditor.Document;


namespace ZGE
{
    public partial class Editor : Form
    {       
        //Cube cube;
        //ArcBallCamera camera;
        
        bool loaded = false;
        ZApplication app = null;
        string projectFileName = null;
        //ModelBehavior behavior = null;
        //Scene scene = new Scene();

        ZNodeProperties codeProperties = null;
        string codePropertyName = null;
        ZCode currentCode = null;

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

            codeBox.Document.HighlightingStrategy =
                        HighlightingStrategyFactory.CreateHighlightingStrategyForFile("dummy.cs");

            Type[] targets = { typeof(Vector2), typeof(Vector3), typeof(Vector4), typeof(Color4) };
            foreach (Type t in targets)
            {
                TypeDescriptor.AddAttributes(t, new TypeConverterAttribute(typeof(StructConverter)));
                TypeDescriptor.AddProvider(new FieldsToPropertiesTypeDescriptionProvider(t), t);
            }            
            //propertyGrid1.SelectedObject = v1;
            

            // Instantiate the writer
            _writer = new TextBoxStreamWriter(outputBox);
            // Redirect the out Console stream
            Console.SetOut(_writer);

            int w = (int)(Screen.PrimaryScreen.Bounds.Width * 0.9);
            int h = (int)(Screen.PrimaryScreen.Bounds.Height * 0.9);
            this.Size = new Size(w, h);

            LoadToolboxComponents();

            //app = new Small();
            //glControl1.VSync = (app.VSync == VSyncMode.On);

            glControl1.MouseWheel += new MouseEventHandler(glControl1_MouseWheel);
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

        private void openXmlBtn_Click(object sender, EventArgs e)
        {
            //openXml();
            
//             StreamReader sr = new StreamReader("Small.xml");
//             string xml = sr.ReadToEnd();
// 
//             xmlEditor.LoadXml(xml);
//             textBox1.Text = xmlEditor.Content;
            //codeBox.Text = new StreamReader("Editor/Small.cs").ReadToEnd();


            outputBox.Text = ""; 
            statusLabel.Text = "Loading XML...";
            //try
            {
                statusLabel.Text = "Loading app...";
                string file = "Small.xml";
                var zapp = Factory.Load(file, xmlEditor);
                if (zapp != null)
                {                    
                    currentCode = null;
                    codeProperties = null;
                    codePropertyName = null;
                    codeBox.Text = "";
                    propertyGrid1.Tag = null;
                    propertyGrid1.SelectedObject = null;

                    projectFileName = file;
                    app = zapp;

                    //  Add the element to the tree.
                    sceneTreeView.Nodes.Clear();
                    foreach(ZComponent comp in app.Scene)
                        AddElementToTree(comp, sceneTreeView.Nodes);
                    sceneTreeView.ExpandAll();
                    sceneTreeView.Invalidate();

                    glControl1_Load(this, null);
                    glControl1_Resize(this, null);
                    statusLabel.Text = "App loaded.";
                }
            }
            /*catch (Exception exception)
            {
                //this.Nodes.Clear();
                statusLabel.Text = exception.Message;
                throw (exception);
            }*/
        }
        private void saveXmlBtn_Click(object sender, EventArgs e)
        {
            if (projectFileName != null)
            {
                statusLabel.Text = "Saving project...";
                using (StreamWriter writer = new StreamWriter(projectFileName, false))
                {
                    writer.Write(xmlEditor.Content);                
                }
                statusLabel.Text = "Project saved.";
            }
        }

        #region Treeview Population
        private void openXml()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open XML Document";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            dlg.FileName = "Small.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Just a good practice -- change the cursor to a wait cursor while the nodes populate
                    this.Cursor = Cursors.WaitCursor;

                    //First, we'll load the Xml document
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(dlg.FileName);

                    //Now, clear out the treeview, and add the first (root) node
                    xmlTreeView.Nodes.Clear();
                    xmlTreeView.Nodes.Add(new TreeNode(xDoc.DocumentElement.Name));
                    TreeNode tNode = new TreeNode();
                    tNode = (TreeNode) xmlTreeView.Nodes[0];

                    //We make a call to AddNode, where we'll add all of our nodes
                    addTreeNode(xDoc.DocumentElement, tNode);

                    //Expand the treeview to show all nodes
                    xmlTreeView.ExpandAll();

                }
                catch (XmlException xExc) //Exception is thrown is there is an error in the Xml
                {
                    MessageBox.Show(xExc.Message);
                }
                catch (Exception ex) //General exception
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default; //Change the cursor back
                }
            }
        }

        //This function is called recursively until all nodes are loaded
        private void addTreeNode(XmlNode xmlNode, TreeNode treeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;

            if (xmlNode.HasChildNodes) //The current node has children
            {
                xNodeList = xmlNode.ChildNodes;

                for (int x = 0; x <= xNodeList.Count - 1; x++) //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    treeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = treeNode.Nodes[x];
                    addTreeNode(xNode, tNode);
                }
            }
            else //No children, so add the outer xml (trimming off whitespace)
                treeNode.Text = xmlNode.OuterXml.Trim();
        }
        #endregion

        #region XML Writer Methods

        private void serializeTreeview2()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = this.xmlTreeView.Nodes[0].Text + ".xml";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                exportToXml2(xmlTreeView, dlg.FileName);
            }
        }

        //We use this in the exportToXml2 and the saveNode functions, though it's only instantiated once.
        private XmlTextWriter xr;

        public void exportToXml2(TreeView tv, string filename)
        {
            xr = new XmlTextWriter(filename, System.Text.Encoding.UTF8);

            xr.WriteStartDocument();
            //Write our root node
            xr.WriteStartElement(xmlTreeView.Nodes[0].Text);
            foreach (TreeNode node in tv.Nodes)
            {
                saveNode(node.Nodes);
            }
            //Close the root node
            xr.WriteEndElement();
            xr.Close();
        }

        private void saveNode(TreeNodeCollection tnc)
        {
            foreach (TreeNode node in tnc)
            {
                //If we have child nodes, we'll write a parent node, then iterrate through
                //the children
                if (node.Nodes.Count > 0)
                {
                    xr.WriteStartElement(node.Text);
                    saveNode(node.Nodes);
                    xr.WriteEndElement();
                }
                else //No child nodes, so we just write the text
                {
                    xr.WriteString(node.Text);
                }
            }
        }

        #endregion

        #region GLControl
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            if (app == null) return;
            app.Load();
            //propertyGrid1.SelectedObject = app.cube;

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
            //float deltaRotation = (float) milliseconds / 20.0f;
            //rotation += deltaRotation;
            //cube.Transformation.RotateZ += deltaRotation;
            var fe = new FrameEventArgs();
            app.Update(fe);
            //glControl1.Invalidate();
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
            /*SelectedSceneElement = null;
            listBox1.Items.Clear();
            var itemsHit = scene.DoHitTest(e.X, e.Y);
            foreach (var item in itemsHit)
                listBox1.Items.Add(item);
            if (listBox1.Items.Count > 0)
            {
                listBox1.SetSelected(0, true);
                // listBox1_SelectedIndexChanged(this, null);
            }*/
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
                if (code != null)
                {
                    currentCode = null; // prevent codeBox_TextChanged from changing the previously selected code
                    codeBox.Text = code.Text;
                    currentCode = code;
                    ZComponent comp = selectedComponent as ZComponent;
                    if (comp != null) 
                        codeProperties = comp.Tag as ZNodeProperties;
                    codePropertyName = g.PropertyDescriptor.Name;
                }
            }
        }

        private void codeBox_TextChanged(object sender, EventArgs e)
        {
            if (currentCode != null && codeProperties != null && codePropertyName != null)
            {
                currentCode.Text = codeBox.Text;
                PropertyChangedEventArgs ev = new PropertyChangedEventArgs(codePropertyName, codeBox.Text);                
                ev.Action = PropertyChangeAction.CodeChanged;
                codeProperties.PropertyHolderChanged(codeBox, ev);
            }
        }

    }
}