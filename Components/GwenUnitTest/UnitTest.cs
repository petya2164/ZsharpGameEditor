using System;
using Gwen.Control;
using Gwen.Control.Layout;
using Gwen.Input;

namespace Gwen.UnitTest
{
    public class UnitTest : DockBase
    {
        private Control.GUIControl m_LastControl;
        private readonly Control.StatusBar m_StatusBar;
        private readonly Control.ListBox m_TextOutput;
        private Control.TabButton m_Button;
        private readonly Control.CollapsibleList m_List;
        //private readonly Center m_Center;
        private readonly Control.LabeledCheckBox m_DebugCheck;

        public double Fps; // set this in your rendering loop
        public String Note; // additional text to display in status bar

        public UnitTest(ZGE.Components.ZComponent parent) : base(parent)
        {
            Dock = Pos.Fill;
            SetSize(1024, 768);
            m_List = new Control.CollapsibleList(this);

            LeftDock.TabControl.AddPage("Unit tests", m_List);
            LeftDock.Width = 150;

            m_TextOutput = new Control.ListBox(BottomDock);
            m_Button = BottomDock.TabControl.AddPage("Output", m_TextOutput);
            BottomDock.Height = 200;

            m_DebugCheck = new Control.LabeledCheckBox(m_List);
            m_DebugCheck.Text = "Debug outlines";
            m_DebugCheck.CheckChanged += DebugCheckChanged;

            m_StatusBar = new Control.StatusBar(this);
            m_StatusBar.Dock = Pos.Bottom;
            m_StatusBar.AddControl(m_DebugCheck, true);

            //m_Center = new Center(this);
            //m_Center.Dock = Pos.Fill;
            GUnit test;

            {
                CollapsibleCategory cat = m_List.Add("Non-Interactive");
                {
                    test = new Label(this);
                    RegisterUnitTest("Label", cat, test);
                    test = new RichLabel(this);
                    RegisterUnitTest("RichLabel", cat, test);
                    test = new GroupBox(this);
                    RegisterUnitTest("GroupBox", cat, test);
                    test = new ProgressBar(this);
                    RegisterUnitTest("ProgressBar", cat, test);
                    test = new ImagePanel(this);
                    RegisterUnitTest("ImagePanel", cat, test);
                    test = new StatusBar(this);
                    RegisterUnitTest("StatusBar", cat, test);
                }
            }

            {
                CollapsibleCategory cat = m_List.Add("Standard");
                {
                    test = new Button(this);
                    RegisterUnitTest("Button", cat, test);
                    test = new TextBox(this);
                    RegisterUnitTest("TextBox", cat, test);
                    test = new CheckBox(this);
                    RegisterUnitTest("CheckBox", cat, test);
                    test = new RadioButton(this);
                    RegisterUnitTest("RadioButton", cat, test);
                    test = new ComboBox(this);
                    RegisterUnitTest("ComboBox", cat, test);
                    test = new ListBox(this);
                    RegisterUnitTest("ListBox", cat, test);
                    test = new NumericUpDown(this);
                    RegisterUnitTest("NumericUpDown", cat, test);
                    test = new Slider(this);
                    RegisterUnitTest("Slider", cat, test);
                    test = new MenuStrip(this);
                    RegisterUnitTest("MenuStrip", cat, test);
                    test = new CrossSplitter(this);
                    RegisterUnitTest("CrossSplitter", cat, test);
                }
            }
            
            {
                CollapsibleCategory cat = m_List.Add("Containers");
                {
                    test = new Window(this);
                    RegisterUnitTest("Window", cat, test);
                    test = new TreeControl(this);
                    RegisterUnitTest("TreeControl", cat, test);
                    test = new Properties(this);
                    RegisterUnitTest("Properties", cat, test);
                    test = new TabControl(this);
                    RegisterUnitTest("TabControl", cat, test);
                    test = new ScrollControl(this);
                    RegisterUnitTest("ScrollControl", cat, test);
                    test = new Docking(this);
                    RegisterUnitTest("Docking", cat, test);
                }
            }
            
            {
                CollapsibleCategory cat = m_List.Add("Non-standard");
                {
                    test = new CollapsibleList(this);
                    RegisterUnitTest("CollapsibleList", cat, test);
                    test = new ColorPickers(this);
                    RegisterUnitTest("Color pickers", cat, test);
                }
            }

            m_StatusBar.SendToBack();
            PrintText("Unit Test started!");
        }

        public void RegisterUnitTest(String name, CollapsibleCategory cat, GUnit test)
        {
            Control.Button btn = cat.Add(name);
            test.Dock = Pos.Fill;
            test.Hide();
            test.UnitTest = this;
            btn.UserData = test;
            btn.Clicked += OnCategorySelect;
        }

        private void DebugCheckChanged(GUIControl control)
        {
            /*if (m_DebugCheck.IsChecked)
                m_Center.DrawDebugOutlines = true;
            else
                m_Center.DrawDebugOutlines = false;*/
            Invalidate();
        }

        private void OnCategorySelect(GUIControl control)
        {
            if (m_LastControl != null)
            {
                m_LastControl.Hide();
            }
            GUIControl test = control.UserData as GUIControl;
            test.Show();
            m_LastControl = test;
        }

        public void PrintText(String str)
        {
            m_TextOutput.AddRow(str);
            m_TextOutput.ScrollToBottom();
        }

        protected override void Layout(Skin.Base skin)
        {
            base.Layout(skin);
        }

        protected override void Render(Skin.Base skin)
        {
            
            Note = (InputHandler.HoveredControl != null) ? InputHandler.HoveredControl.GetType().FullName : "NONE";
            m_StatusBar.Text = String.Format("GWEN.Net Unit Test - {0:F0} fps. {1}", Fps, Note);

            base.Render(skin);
        }
    }
}
