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
using SuperMap.Mapping;
using SuperMap.UI;

namespace zl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     
       
            private void FormDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            mapControl1.Dispose();
            workspace1.Close();
            workspace1.Dispose();
        }

        private void toolStripOpen_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "SuperMap 工作空间文件(*.smwu)|*.smwu";
            //判断打开的结果，如果打开就执行下列操作
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //避免连续打开工作空间导致程序异常     
                mapControl1.Map.Close();
                workspace1.Close();
                mapControl1.Map.Refresh();
                //定义打开工作空间文件名
                String fileName = openFileDialog1.FileName;
                //打开工作空间文件
                WorkspaceConnectionInfo connectionInfo = new WorkspaceConnectionInfo(fileName);
                //打开工作空间
                workspace1.Open(connectionInfo);
                //建立MapControl与Workspace的连接
                mapControl1.Map.Workspace = workspace1;
                //判断工作空间中是否有地图
                if (workspace1.Maps.Count == 0)
                {
                    MessageBox.Show("当前工作空间中不存在地图!");
                    return;
                }
                //通过名称打开工作空间中的地图
                mapControl1.Map.Open("世界地图");
                //刷新地图窗口
                mapControl1.Map.Refresh();
            }
        }

        private void toolStripPan_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.Pan;
        }

        private void toolStripZoomIn_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomIn;
        }

        private void toolStripZoomOut_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomOut;
        }

        private void toolStripZoomFree_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.ZoomFree;
        }

        private void toolStripViewEntire_Click(object sender, EventArgs e)
        {
            mapControl1.Map.ViewEntire();
        }

        private void toolStripSelect_Click(object sender, EventArgs e)
        {
            mapControl1.Action = SuperMap.UI.Action.Select2;
        }

        private void toolStripQueryProperty_Click(object sender, EventArgs e)
        {
            //获取选择集
            Selection[] selection = mapControl1.Map.FindSelection(true);

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

        private void toolStripSQLQuery_Click(object sender, EventArgs e)
        {
            //判断toolStripTextBox1的输入内容是否为空
            if (toolStripTextBox1.Text.Length == 0)
            {
                MessageBox.Show("查询信息不能为空");
                return;
            }

            //定义图层个数
            Int32 layerCount = mapControl1.Map.Layers.Count;
            //判断当前地图窗口中是否有打开的图层
            if (layerCount == 0)
            {
                MessageBox.Show("请先打开一个矢量数据集！");
                return;
            }

            //定义查询条件信息;
            QueryParameter queryParameter = new QueryParameter();
            queryParameter.AttributeFilter = toolStripTextBox1.Text;
            queryParameter.CursorType = CursorType.Static;

            Boolean hasGeometry = false;
            //遍历每一个图层，实现多图层查询
            foreach (Layer layer in mapControl1.Map.Layers)
            {
                //得到矢量数据集并强制转换为矢量数据集类型
                DatasetVector dataset = layer.Dataset as DatasetVector;

                if (dataset == null)
                {
                    continue;
                }
                //通过查询条件对矢量数据集进行查询,从数据集中查询出属性数据，
                Recordset recordset = dataset.Query(queryParameter);
                //判断是否有查询结果
                if (recordset.RecordCount > 0)
                {
                    hasGeometry = true;
                }

                //把查询得到的数据加入到选择集中(使其高亮显示)
                Selection selection = layer.Selection;
                selection.FromRecordset(recordset);
                recordset.Dispose();
            }
            //没有查询结果，弹出提示
            if (!hasGeometry)
            {
                MessageBox.Show("没有符合查询条件的结果或查询条件有误，请重新确认后查询！");
            }

            //当可创建对象使用完毕后，使用Dispose方法来释放所占用的内部资源。
            queryParameter.Dispose();

            //刷新地图窗口显示
            mapControl1.Refresh();
            hasGeometry = false;
        }
    }
    }
