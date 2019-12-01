using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.UI;
using SuperMap.Mapping;
using Analyst;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
           
        }

        private void layersTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //打开 World.smwu 工作空间
            Workspace workspace = new Workspace();
            WorkspaceConnectionInfo workspaceConnectionInfo = new WorkspaceConnectionInfo(
                          @"..\..\..\..\DATA\World\World.smwu");
           workspace.Open(workspaceConnectionInfo);

            //将打开的工作空间指定给工作空间管理器
            workspaceControl.WorkspaceTree.Workspace = workspace;



           
            workspace.Open(workspaceConnectionInfo);
            mapControl.Map.Workspace = workspace;
            mapControl.Map.Open(workspace.Maps[0]);
            mapControl.Map.Refresh();

            // 将地图控件中所显示的地图关联到二维图层树，使其管理其中的地图图层
            layersTree.Map = mapControl.Map;


        }

        private void mapControl_Load(object sender, EventArgs e)
        {

        }

        private void workspaceControl_Load(object sender, EventArgs e)
        {

        }

        private void toolStripQueryProperty_Click(object sender, EventArgs e)
        {
            //获取选择集
            Selection[] selection = mapControl.Map.FindSelection(true);

            //判断选择集是否为空
            if (selection == null || selection.Length == 0)
            {
                MessageBox.Show("请选择要查询属性的空间对象");
                return;
            }

            //将选择集转换为记录
            Recordset recordset = selection[0].ToRecordset();

            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            for (int i = 0; i < recordset.FieldCount; i++)
            {
                //定义并获得字段名称
                String fieldName = recordset.GetFieldInfos()[i].Name;

                //将得到的字段名称添加到dataGridView列中
                this.dataGridView1.Columns.Add(fieldName, fieldName);
            }

            //初始化row
            DataGridViewRow row = null;

            //根据选中记录的个数，将选中对象的信息添加到dataGridView中显示
            while (!recordset.IsEOF)
            {
                row = new DataGridViewRow();
                for (int i = 0; i < recordset.FieldCount; i++)
                {
                    //定义并获得字段值
                    Object fieldValue = recordset.GetFieldValue(i);

                    //将字段值添加到dataGridView中对应的位置
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    if (fieldValue != null)
                    {
                        cell.ValueType = fieldValue.GetType();
                        cell.Value = fieldValue;
                    }

                    row.Cells.Add(cell);
                }

                this.dataGridView1.Rows.Add(row);

                recordset.MoveNext();
            }
            this.dataGridView1.Update();

            recordset.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            fm.Show();
        }

        private void toolStripPan_Click(object sender, EventArgs e)
        {
            mapControl.Action = SuperMap.UI.Action.Pan;
        }

        private void toolStripSelect_Click(object sender, EventArgs e)
        {
            mapControl.Action = SuperMap.UI.Action.Select2;
        }
    }
    }
