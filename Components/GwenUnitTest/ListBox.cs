﻿using System;
using Gwen.Control;
using Gwen.Control.Layout;

namespace Gwen.UnitTest
{
    public class ListBox : GUnit
    {
        public ListBox(ControlBase parent)
            : base(parent)
        {
            {
                Control.ListBox ctrl = new Control.ListBox(this);
                ctrl.SetPosition(10, 10);

                ctrl.AddRow("First");
                ctrl.AddRow("Blue");
                ctrl.AddRow("Yellow");
                ctrl.AddRow("Orange");
                ctrl.AddRow("Brown");
                ctrl.AddRow("Black");
                ctrl.AddRow("Green");
                ctrl.AddRow("Dog");
                ctrl.AddRow("Cat Blue");
                ctrl.AddRow("Shoes");
                ctrl.AddRow("Shirts");
                ctrl.AddRow("Chair");
                ctrl.AddRow("I'm autosized");
                ctrl.AddRow("Last");
                
                ctrl.AllowMultiSelect = true;
                ctrl.SelectRowsByRegex("Bl.e|Dog");

                ctrl.RowSelected += RowSelected;
                ctrl.RowUnselected += RowUnSelected;
                
                ctrl.SizeToContents();
            }

            {
                Table ctrl = new Table(this);
                ctrl.SetPosition(120, 10);

                ctrl.AddRow("First");
                ctrl.AddRow("Blue");
                ctrl.AddRow("Yellow");
                ctrl.AddRow("Orange");
                ctrl.AddRow("Brown");
                ctrl.AddRow("Black");
                ctrl.AddRow("Green");
                ctrl.AddRow("Dog");
                ctrl.AddRow("Cat Blue");
                ctrl.AddRow("Shoes");
                ctrl.AddRow("Shirts");
                ctrl.AddRow("Chair");
                ctrl.AddRow("I'm autosized");
                ctrl.AddRow("Last");

                ctrl.SizeToContents(0);
            }

            {
                Control.ListBox ctrl = new Control.ListBox(this);
                ctrl.SetBounds(220, 10, 200, 200);
                ctrl.ColumnCount = 3;
                //ctrl.AllowMultiSelect = true;
                ctrl.RowSelected += RowSelected;
                ctrl.RowUnselected += RowUnSelected;

                {
                    TableRow row = ctrl.AddRow("Baked Beans");
                    row.SetCellText(1, "Heinz");
                    row.SetCellText(2, "£3.50");
                }

                {
                    TableRow row = ctrl.AddRow("Bananas");
                    row.SetCellText(1, "Trees");
                    row.SetCellText(2, "£1.27");
                }

                {
                    TableRow row = ctrl.AddRow("Chicken");
                    row.SetCellText(1, "\u5355\u5143\u6D4B\u8BD5");
                    row.SetCellText(2, "£8.95");
                }
            }

            {
                // fixed-size table
                Control.Layout.Table table = new Table(this);
                table.SetColumnCount(3);
                table.SetBounds(450, 10, 320, 100);
                table.SetColumnWidth(0, 100);
                table.SetColumnWidth(1, 100);
                table.SetColumnWidth(2, 100);
                var row1 = table.AddRow();
                row1.SetCellText(0, "Row 1");
                row1.SetCellText(1, "R1 cell 1");
                row1.SetCellText(2, "Row 1 cell 2");

                table.AddRow().Text = "Row 2, slightly bigger";
                table[1].SetCellText(1, "Center cell");

                table.AddRow().Text = "Row 3, medium";
                table[2].SetCellText(2, "Last cell");
            }

            {
                //Control.Label outer = new Control.Label(this);
                //outer.SetBounds(340, 140, 300, 200);

                // autosized table
                Control.Layout.Table table = new Table(this);
                table.SetColumnCount(3);
                table.SetPosition(450, 150);

                var row1 = table.AddRow();
                row1.SetCellText(0, "Row 1");
                row1.SetCellText(1, "R1 cell 1");
                row1.SetCellText(2, "Row 1 cell 2");

                table.AddRow().Text = "Row 2, slightly bigger";
                table[1].SetCellText(1, "Center cell");

                table.AddRow().Text = "Row 3, medium";
                table[2].SetCellText(2, "Last cell");

                table.SizeToContents(0);
            }
        }

        void RowSelected(ControlBase control)
        {
            Control.ListBox list = control as Control.ListBox;
            UnitPrint(String.Format("ListBox: RowSelected: {0}", list[list.SelectedRowIndex].Text));
        }

        void RowUnSelected(ControlBase control)
        {
            // todo: how to determine which one was unselected (store somewhere)
            // or pass row as the event param?
            Control.ListBox list = control as Control.ListBox;
            UnitPrint(String.Format("ListBox: OnRowUnselected"));
        }
    }
}
