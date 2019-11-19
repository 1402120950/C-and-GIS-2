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
                          @"D:\supermap-iobjectsdotnet-10.0.0-17523-73237-all\SampleData\World\World.smwu");
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
    }
}
