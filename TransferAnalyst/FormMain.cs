///////////////////////////////////////////////////////////////////////////////////////////////////
//------------------------------版权声明----------------------------
//
// 此文件为 SuperMap iObjects .NET 的示范代码
// 版权所有：北京超图软件股份有限公司
//------------------------------------------------------------------
//------------------------------Copyright Statement----------------------------
//
// SuperMap iObjects .NET Sample Code
// Copyright: SuperMap Software Co., Ltd. All Rights Reserved.
//------------------------------------------------------------------
//-----------------------SuperMap iObjects .NET 示范程序说明--------------------------
//
// 1、范例简介：示范如何进行公交换乘分析、根据站点查找线路以及根据线路查找站点
// 2、示例数据：安装目录\SampleData\City\Changchun.swmu;
// 3、关键类型/成员: 
//      Workspace.Open 方法
//      MapControl.MouseMove 事件
//      MapControl.MouseDown 事件
//      TrackingLayer.Add 方法
//      TrackingLayer.Remove 方法
//      TrackingLayer.GetTag 方法
//      TrackingLayer.IndexOf 方法
//      LineSetting.Dataset 属性
//      LineSetting.LineIDField 属性
//      LineSetting.NameField 属性
//      LineSetting.LengthField 属性
//      LineSetting.FareFieldInfo 属性
//      FareFieldInfo.FareTypeField 属性
//      FareFieldInfo.StartFareField 属性
//      FareFieldInfo.StartFareRangeField 属性
//      FareFieldInfo.FareStepField 属性
//      FareFieldInfo.FareStepRangeField 属性
//      StopSetting.Dataset 属性
//      StopSetting.StopIDField 属性
//      StopSetting.NameField 属性
//      RelationSetting.Dataset 属性
//      RelationSetting.LineIDField 属性
//      RelationSetting.StopIDField 属性
//      RelationSetting.DatasetNetwork 属性
//      RelationSetting.EdgeIDField 属性
//      RelationSetting.NodeIDField 属性
//      RelationSetting.FNodeIDField 属性
//      RelationSetting.TNodeIDField 属性
//      TransferAnalystSetting.LineSetting 属性
//      TransferAnalystSetting.StopSetting 属性
//      TransferAnalystSetting.RelationSetting 属性
//      TransferAnalystSetting.SnapTolerance 属性
//      TransferAnalystSetting.MergeTolerance 属性
//      TransferAnalystSetting.WalkingTolerance 属性
//      TransferAnalystSetting.Unit 属性
//      TransferAnalystParameter.SearchMode 属性
//      TransferAnalystParameter.StartStopID 属性
//      TransferAnalystParameter.EndStopID 属性
//      TransferAnalystParameter.Tactic 属性
//      TransferAnalystParameter.WalkingRatio 属性
//      TransferAnalystParameter.SolutionCount 属性
//      TransferAnalyst.Check 方法
//      TransferAnalyst.Load 方法
//      TransferAnalyst.FindTransferSolutions 方法
//      TransferAnalyst.FindStopsByLine 方法
//      TransferAnalyst.FindLinesByStop 方法
//      TransferSolutions.Count 属性
//      TransferSolutions.Item 属性
//      TransferSolution.TransferTime 属性
//      TransferSolutions.Item 属性
//      TransferLines.Count 属性
//      TransferLines.Item 属性
//      TransferLine.LineName 属性
//      TransferGuide.Item 属性
//      TransferGuide.Count 属性
//      TransferGuide.TotalDistance 属性
//      TransferGuide.TotalFare 属性
//      TransferGuideItem.IsWalking 属性
//      TransferGuideItem.StartName 属性
//      TransferGuideItem.EndName 属性
//      TransferGuideItem.LineName 属性
//      TransferGuideItem.Distance 属性
//      TransferGuideItem.Fare 属性
//      TransferGuideItem.PassStopCount 属性
//      LineInfo.LineID 属性
//      LineInfo.Name 属性
//      LineInfo.TotalDistance 属性
//      LineInfo.TotalLine 属性
//      StopInfo.StopID 属性
//      StopInfo.Name 属性
// 4、使用步骤：
//  (1)点击“加载公交数据”按钮，使公交分析环境设置生效
//  (2)点击“起始点”单选按钮，在地图上选择一个点作为起始点；点击“终止点”单选按钮，在地图上选择一个点作为终止点；在换乘策略下拉框的列表可选择一项换乘策略
//..(3)点击“换乘分析”按钮进行公交换乘分析。在地图下方的换乘方案下拉框中选择项，可以查看各个换乘方案的详细信息
//  (4)在地图上选择一个起始站点，或在文本框内输入站点ID，然后点击“站点查线路”按钮，根据指定的站点ID查询经过该站点的公交线路
//  (5)在文本框内输入线路ID，点击“线路查站点”按钮，根据指定的线路ID查询该线路上的公交站点
//  (6)点击“清除”按钮，将清空分析结果和跟踪图层中的对象
//---------------------------------------------------------------------------------------
//-----------------------Description--------------------------
//
// 1. Functions: How to traffic transfer analyst, search line according to stops, and search stops according to lines.
// 2. Data: \SampleData\City\Changchun.swmu;
//3. Key classes and members 
//      Workspace.Open 
//      MapControl.MouseMove 
//      MapControl.MouseDown 
//      TrackingLayer.Add 
//      TrackingLayer.Remove 
//      TrackingLayer.GetTag 
//      TrackingLayer.IndexOf 
//      LineSetting.Dataset 
//      LineSetting.LineIDField 
//      LineSetting.NameField 
//      LineSetting.LengthField 
//      LineSetting.FareFieldInfo 
//      FareFieldInfo.FareTypeField 
//      FareFieldInfo.StartFareField 
//      FareFieldInfo.StartFareRangeField 
//      FareFieldInfo.FareStepField 
//      FareFieldInfo.FareStepRangeField 
//      StopSetting.Dataset 
//      StopSetting.StopIDField 
//      StopSetting.NameField 
//      RelationSetting.Dataset 
//      RelationSetting.LineIDField 
//      RelationSetting.StopIDField 
//      RelationSetting.DatasetNetwork 
//      RelationSetting.EdgeIDField 
//      RelationSetting.NodeIDField 
//      RelationSetting.FNodeIDField 
//      RelationSetting.TNodeIDField 
//      TransferAnalystSetting.LineSetting 
//      TransferAnalystSetting.StopSetting 
//      TransferAnalystSetting.RelationSetting 
//      TransferAnalystSetting.SnapTolerance 
//      TransferAnalystSetting.MergeTolerance 
//      TransferAnalystSetting.WalkingTolerance 
//      TransferAnalystSetting.Unit 
//      TransferAnalystParameter.SearchMode 
//      TransferAnalystParameter.StartStopID 
//      TransferAnalystParameter.EndStopID 
//      TransferAnalystParameter.Tactic 
//      TransferAnalystParameter.WalkingRatio 
//      TransferAnalystParameter.SolutionCount 
//      TransferAnalyst.Check 
//      TransferAnalyst.Load 
//      TransferAnalyst.FindTransferSolutions 
//      TransferAnalyst.FindStopsByLine 
//      TransferAnalyst.FindLinesByStop 
//      TransferSolutions.Count 
//      TransferSolutions.Item 
//      TransferSolution.TransferTime 
//      TransferSolutions.Item 
//      TransferLines.Count 
//      TransferLines.Item 
//      TransferLine.LineName 
//      TransferGuide.Item 
//      TransferGuide.Count 
//      TransferGuide.TotalDistance 
//      TransferGuide.TotalFare 
//      TransferGuideItem.IsWalking 
//      TransferGuideItem.StartName 
//      TransferGuideItem.EndName 
//      TransferGuideItem.LineName 
//      TransferGuideItem.Distance 
//      TransferGuideItem.Fare 
//      TransferGuideItem.PassStopCount 
//      LineInfo.LineID
//      LineInfo.Name 
//      LineInfo.TotalDistance 
//      LineInfo.TotalLine 
//      StopInfo.StopID 
//      StopInfo.Name 
// 4. Steps:
//  1. Click Load Transfer Data. In this case, the environment settings are valid.
//  2. Check Start Stop, and select a start stop on the map. Check End Stop, and select an end stop on the map. Select a transfer way under the ComboBox.
//  3. Click Analyze to make a bus transfer analysis. Select different item in the drop-down list to view different transfer solution.
//  4. Select a new stop on the map, or type a stop ID to the textbox. Click Query Path by Stop to view all the bus paths that goes through this stop.
//  5. Type a path ID and click Query Stop by Path. All the stops along this path can be displayed. 
//  6.Click Clear to clear the result
//---------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.UI;
using System.Diagnostics;

namespace SuperMap.SampleCode.Analyst.TrafficAnalyst
{
	public partial class FormMain : Form
	{
		private Workspace m_workspace;
		private MapControl m_mapControl;
		private SampleRun m_sampleRun;

		public FormMain()
		{
			InitializeComponent();
            InitializeCultureResources();
		}
        private void InitializeCultureResources()
        {
            if (SuperMap.Data.Environment.CurrentCulture == "zh-CN")
            {
                this.buttonLoad.Size = new System.Drawing.Size(87, 23);        
                this.buttonLoad.Text = "加载公交数据";
                this.buttonClear.Size = new System.Drawing.Size(43, 23);
                this.buttonClear.Text = "清除";
                this.buttonFindStops.Size = new System.Drawing.Size(75, 23);
                this.buttonFindStops.Text = "线路查站点";
                this.buttonFindLines.Size = new System.Drawing.Size(75, 23);
                this.buttonFindLines.Text = "站点查线路";
                this.buttonAnalyst.Size = new System.Drawing.Size(75, 23);
                this.buttonAnalyst.Text = "换乘分析";
                this.labelTactic.Size = new System.Drawing.Size(59, 12);
                this.labelTactic.Text = "换乘策略:";
                this.radioEnd.Size = new System.Drawing.Size(59, 16);
                this.radioEnd.Text = "终止点";
                this.radioStart.Size = new System.Drawing.Size(59, 16);
                this.radioStart.Text = "起始点";
                this.label1.Size = new System.Drawing.Size(95, 12);
                this.label1.Text = "请选择换乘方案:";
                this.Text = "公交分析";
            }
        }
		/// <summary>
		/// 加载窗体时，添加控件并加载数据
		/// Open the workspace and add data to the map
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_Load(object sender, EventArgs e)
		{
			// 将MapControl添加到窗体上，并与Workspace绑定
			// Add the MapControl to the window, and bound with Workspace
			m_workspace = new Workspace();
			m_mapControl = new MapControl();
			m_mapControl.Dock = DockStyle.Fill;
			this.splitContainer2.Panel1.Controls.Add(m_mapControl);
			m_mapControl.Map.Workspace = m_workspace;

			// 设置控件初始状态
			// Set the initial state of control
			ControlsInitialStatus();

			// 添加公交换乘策略
			// Add the bus transfer strategy
            if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
            {
                comboTactic.Items.Add("Less Transfer");
                comboTactic.Items.Add("Less Walk");
                comboTactic.Items.Add("More Convenient");
                comboTactic.Items.Add("Shortest Path");
            }
            else
            {
                comboTactic.Items.Add("少换乘");
                comboTactic.Items.Add("少步行");
                comboTactic.Items.Add("较快捷");
                comboTactic.Items.Add("距离最短");
            }
			comboTactic.SelectedIndex = 0;

			// 为dataGridView添加列
			// Add columon to dataGridView
			dataGridView.AutoResizeColumns();
			dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView.AllowUserToOrderColumns = false;
			dataGridView.AllowUserToAddRows = false;
			dataGridView.Columns.Clear();
            if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
            {
                dataGridView.Columns.Add("No.", "No.");
                dataGridView.Columns.Add("Guide", "Guide");
                dataGridView.Columns.Add("Distance", "Distance");
                dataGridView.Columns.Add("Cost", "Cost");
            }
            else
            {
                dataGridView.Columns.Add("序号", "序号");
                dataGridView.Columns.Add("导引", "导引");
                dataGridView.Columns.Add("距离", "距离");
                dataGridView.Columns.Add("费用", "费用");
            }
			dataGridView.Columns[0].Width = 30;
			dataGridView.Columns[2].Width = 100;
			dataGridView.Columns[3].Width = 100;

			// 实例化SampleRun
			// Instantiate SampleRun
			m_sampleRun = new SampleRun(m_workspace, m_mapControl, comboGuide, dataGridView);

			// 事件注册
			// Event registeration
			m_mapControl.MouseMove += new MouseEventHandler(m_mapControl_MouseMove);
			m_mapControl.MouseDown += new MouseEventHandler(m_mapControl_MouseDown);
		}

		/// <summary>
		/// MapControl鼠标移动事件。鼠标移动时，捕捉公交站点。
		/// MapControl mouse move event. When the mouse moves, it snaps the bus stops.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mapControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (m_mapControl.Action == SuperMap.UI.Action.Select)
			{
				Point point = new Point(e.X, e.Y);
				m_sampleRun.SetBound(point);
			}
		}

		/// <summary>
		/// MapControl鼠标按下事件。鼠标按下时捕捉公交站点。
		/// MapControl mouse press down event. Pressing down the mouse tp snap the bus stops.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mapControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				m_sampleRun.SnapPoint();
			}
		}

		/// <summary>
		/// “加载公交数据按钮”单击事件
		/// The load bus data event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonLoad_Click(object sender, EventArgs e)
		{
			if (m_sampleRun.Load())
			{
				radioStart.Enabled = true;
				radioStart.Checked = true;
				radioEnd.Enabled = true;
				comboTactic.Enabled = true;
				buttonAnalyst.Enabled = true;
				buttonFindLines.Enabled = true;
				buttonFindStops.Enabled = true;
				buttonClear.Enabled = true;

				m_mapControl.Action = SuperMap.UI.Action.Select;
			}
		}

		/// <summary>
		/// “换乘分析”按钮单击事件
		/// Bus Transfer Analysis
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAnalyst_Click(object sender, EventArgs e)
		{
			Int32 tacticIndex = comboTactic.SelectedIndex;
			m_sampleRun.Analyst(tacticIndex);
		}

		/// <summary>
		/// 选择换乘方案，查看详细信息
		/// Select a transfer method to view details
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboGuide_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_sampleRun.ShowReslut();
		}

		/// <summary>
		/// “站点查线路”按钮单击事件if
		///  Query the path by stops
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonFindLines_Click(object sender, EventArgs e)
		{
			// 如果输入站点ID的文本框为空，则使用在地图上选择的起始站点ID作为查询站点
			// If the ID textbox is null, the start stop ID is the query stop.
			Int64 stopID = -1;
			if (textBoxStopID.Text.Trim().Length == 0)
			{
				stopID = m_sampleRun.GetStopID();
				textBoxStopID.Text = stopID.ToString();
			}
			else
			{
				stopID = Convert.ToInt64(textBoxStopID.Text.Trim());
			}
			m_sampleRun.FindLinesByStop(stopID);
		}

		/// <summary>
		/// “线路查站点”按钮单击事件
		/// Query the stops by the line
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonFindStops_Click(object sender, EventArgs e)
		{
			Int64 lineID = -1;
			if (textBoxLineID.Text.Trim().Length == 0)
			{
                if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                {
                    MessageBox.Show("Please input the line ID to query!");
                }
                else
                {
                    MessageBox.Show("请输入要查询的线路ID！");
                }
			}
			else
			{
				lineID = Convert.ToInt64(textBoxLineID.Text.Trim());
				m_sampleRun.FindStopsByLine(lineID);
			}
		}

		/// <summary>
		/// “清除”按钮单击事件
		/// Clear event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonClear_Click(object sender, EventArgs e)
		{
			textBoxLineID.Text = "";
			textBoxStopID.Text = "";
			m_sampleRun.ClearResult();
		}

		/// <summary>
		/// 控件初始状态
		/// Initial state of the controls
		/// </summary>
		private void ControlsInitialStatus()
		{
			buttonLoad.Enabled = true;
			radioStart.Enabled = false;
			radioEnd.Enabled = false;
			comboTactic.Enabled = false;
			buttonAnalyst.Enabled = false;
			buttonFindLines.Enabled = false;
			buttonFindStops.Enabled = false;
			buttonClear.Enabled = false;
		}

		/// <summary>
		/// “起始点”单项按钮单击事件
		/// Start stop
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioStart_Click(object sender, EventArgs e)
		{
			m_sampleRun.SelectStartStop();
		}

		/// <summary>
		/// “终止点”单项按钮单击事件
		/// End stop
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioEnd_Click(object sender, EventArgs e)
		{
			m_sampleRun.SelectEndStop();
		}

		/// <summary>
		/// 窗体关闭时，释放相关资源
		/// Release resources
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				m_mapControl.Dispose();
				m_workspace.Close();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}
	}
}


