
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SuperMap.Data;
using SuperMap.UI;
using System.Diagnostics;
using SuperMap.Mapping;
using System.Drawing;
using SuperMap.Analyst.TrafficAnalyst;

namespace SuperMap.SampleCode.Analyst.TrafficAnalyst
{
	class SampleRun
	{
		private Workspace m_workspace;
		private MapControl m_mapControl;
		private ComboBox m_comboGuide;
		private DataGridView m_dataGridView;
		private Datasource m_datasource;

		// 公交线路数据集
		// Bus path dataset
		private DatasetVector m_datasetLine;

		// 公交站点数据集
		// Bus stop dataset
		private DatasetVector m_datasetStop;

		// 网络数据集
		// Network dataset
		private DatasetVector m_datasetNetwork;

		// 公交站点图层
		// Stop layer
		private Layer m_layerStop;

		// 跟踪图层
		// Tracking layer
		private TrackingLayer m_trackingLayer;

		// 公交数据是否加载成功
		// Whether the data is loaded successfully or not
		private Boolean m_isLoad = false;

		// 公交站点选择集对象
		// Stop selection object
		private Selection m_selection;

		// 公交分析对象
		// Transfer analysis object
		private TransferAnalyst m_transferAnalyst;

		// 选择起始点
		// Select a start stop
		private Boolean m_isStartPoint = true;

		// 起始站点ID
		// Start stop ID
		private Int64 m_startStopID = -1;

		// 终止站点ID
		// End stop ID
		private Int64 m_endStopID;

		// 公交换乘方案集合对象
		// Bus transfer set object
		private TransferSolutions m_solutions;

		/// <summary>
		/// 根据MapControl、MapControl等构造SampleRun对象
		/// Initialize the SampleRun object with the specified MapControl
		/// </summary>
		public SampleRun(Workspace workspace, MapControl mapControl, ComboBox comboGuide, DataGridView dataGridView)
		{
			m_workspace = workspace;
			m_mapControl = mapControl;
			m_comboGuide = comboGuide;
			m_dataGridView = dataGridView;
			m_mapControl.Map.Workspace = m_workspace;

			Initialize();
		}

		/// <summary>
		/// 打开需要的工作空间，加载数据到地图上
		/// Open the workspace and add data to the map
		/// </summary>
		private void Initialize()
		{
			try
			{
				// 打开工作空间
				// Open the workspace
				String filePath = @"..\..\..\..\DATA\City\Changchun.smwu";
				WorkspaceConnectionInfo info = new WorkspaceConnectionInfo(filePath);
				info.Type = WorkspaceType.SMWU;
				m_workspace.Open(info);

				// 加载底图
				// Load the base map
                if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                {
                    m_mapControl.Map.Open("ChangChunCityMap");
                }
                else
                {
                    m_mapControl.Map.Open("长春市区图");
                }
				// 获取公交线路（BusLine）、站点（BusStop）和网络数据集
				// Get BusLine, BusStop and network dataset
				m_datasource = m_workspace.Datasources["changchun"];
				m_datasetLine = m_datasource.Datasets["BusLine"] as DatasetVector;
				m_datasetStop = m_datasource.Datasets["BusPoint"] as DatasetVector;
				m_datasetNetwork = m_datasource.Datasets["RoadNet"] as DatasetVector;

				// 底图中有线路数据集的图层，因此不再添加
				// 为突出显示站点，将站点添加到地图上并设置风格
				// The base map has a path dataset
				// Add stops the map and set their style
				m_layerStop = m_mapControl.Map.Layers.Add(m_datasetStop, true);
				m_layerStop.IsSelectable = true;

				// 设置站点数据集的图层风格
				// Set the layer style for the stops
				LayerSettingVector stopSetting = new LayerSettingVector();
				GeoStyle stopStyle = new GeoStyle();
				stopStyle.LineColor = Color.FromArgb(170, 0, 192);
				stopStyle.MarkerSize = new Size2D(4, 4);
				stopSetting.Style = stopStyle;
				m_layerStop.AdditionalSetting = stopSetting;

				m_mapControl.Map.IsAntialias = true;
				m_mapControl.Map.Refresh();

				// 设置跟踪图层
				// Set the tracking layer
				m_trackingLayer = m_mapControl.Map.TrackingLayer;
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 加载公交数据
		/// Add the bus data
		/// </summary>
		/// <returns></returns>
		public Boolean Load()
		{
			try
			{
				if (!m_isLoad)
				{
					// 公交线路环境设置
					// Set the bus line environment
					LineSetting lineSetting = new LineSetting();
					lineSetting.Dataset = m_datasetLine;
					lineSetting.LineIDField = "LINEID";
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        lineSetting.NameField = "NAME_en";
                    }
                    else
                    {
                        lineSetting.NameField = "NAME";
                    }
					lineSetting.LengthField = "SMLENGTH";
					lineSetting.LineTypeField = "LINETYPE";
					// 设置票价信息
					// Set the price information
					FareFieldInfo fareFieldInfo = new FareFieldInfo();
					fareFieldInfo.FareTypeField = "FARETYPE";
					fareFieldInfo.StartFareField = "STARTFARE";
					fareFieldInfo.StartFareRangeField = "STARTFARERANGE";
					fareFieldInfo.FareStepField = "FARESTEP";
					fareFieldInfo.FareStepRangeField = "FARESTEPRANGE";
					lineSetting.FareFieldInfo = fareFieldInfo;

					// 公交站点环境设置
					// Set the stop environment
					StopSetting stopSetting = new StopSetting();
					stopSetting.Dataset = m_datasetStop;
					stopSetting.StopIDField = "STOPID";					
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        stopSetting.NameField = "NAME_en";
                    }
                    else
                    {
                        stopSetting.NameField = "NAME";
                    }

					// 公交关系设置
					// Set the bus line relations
					RelationSetting relationSetting = new RelationSetting();
					relationSetting.Dataset = m_datasource.Datasets["LineStopRelation"] as DatasetVector;
					relationSetting.LineIDField = "LINEID";
					relationSetting.StopIDField = "STOPID";
					// 设置网络数据集的信息
					// Set the network dataset information
					relationSetting.DatasetNetwork = m_datasetNetwork;
					relationSetting.EdgeIDField = "SMEDGEID";
					relationSetting.NodeIDField = "SMNODEID";
					relationSetting.FNodeIDField = "SMFNODE";
					relationSetting.TNodeIDField = "SMTNODE";

					// 公交分析环境设置
					// Bus analysis environment settings
					TransferAnalystSetting transferAnalystSetting = new TransferAnalystSetting();
					transferAnalystSetting.LineSetting = lineSetting;
					transferAnalystSetting.StopSetting = stopSetting;
					transferAnalystSetting.RelationSetting = relationSetting;

					// 设置站点捕捉容限
					// Set the stop snapping tolerance
					transferAnalystSetting.SnapTolerance = 50.0;

					// 设置站点归并容限
					// Set the stop merge tolerance
					transferAnalystSetting.MergeTolerance = 100.0;

					// 设置步行阈值
					// Set the walking tolerance
					transferAnalystSetting.WalkingTolerance = 500.0;

					// 设置站点捕捉容限、归并容限及步行阈值的单位
					// Set the units
					transferAnalystSetting.Unit = Unit.Meter;

					// 实例化一个TransferAnalyst对象
					// Initialize a TransferAnalyst object
					m_transferAnalyst = new TransferAnalyst();

					// 加载公交数据
					// Load the bus data
					m_isLoad = m_transferAnalyst.Load(transferAnalystSetting);
					if (m_isLoad)
					{						
                        if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                        {
                            MessageBox.Show("Load the bus data successfully!");
                        }
                        else
                        {
                            MessageBox.Show("成功加载公交数据！");
                        }
					}
					else
					{						
                        if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                        {
                            MessageBox.Show("Failed to load the bus data! Please check the environment settings or data.");
                        }
                        else
                        {
                            MessageBox.Show("公交数据加载失败！请检查公交分析环境设置或公交数据。");
                        }
					}
				}
				m_mapControl.Map.Refresh();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
			return m_isLoad;
		}

		/// <summary>
		/// 公交换乘分析
		/// Bus Transfer Analysis
		/// </summary>
		/// <param name="tactic"></param>
		public void Analyst(Int32 tacticIndex)
		{
			try
			{
				if (m_isLoad)
				{
					// 实例化一个公交分析参数设置对象，并设置相关参数
					// Initialize a TransferAnalystParameter, and set it
					TransferAnalystParameter parameter = new TransferAnalystParameter();
					parameter.SearchMode = TransferSearchMode.ID;
					parameter.StartStopID = m_startStopID;
					parameter.EndStopID = m_endStopID;
					parameter.Tactic = GetTactic(tacticIndex);
					parameter.WalkingRatio = 10;
					parameter.SolutionCount = 5;

					// 进行公交换乘分析
					// Traffic transfer analysis
					m_solutions = m_transferAnalyst.FindTransferSolutions(parameter);

					// 解析换乘分析结果
					// Result
					if (m_solutions != null)
					{
						// 将换乘方案的概要信息添加到m_comboGuide中
						// Store the result to m_comboGuide
						FillComboBox();
						// 在地图和DataGridView中显示换乘导引
						// Display the transfer guide on the map and the DataGridView
						ShowReslut();
					}
					else
					{						
                        if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                        {
                            MessageBox.Show("Sorry! There is no proper transfer line!");
                        }
                        else
                        {
                            MessageBox.Show("抱歉！没有寻找到合适的换乘方案！");
                        }
					}
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 根据站点查询线路
		/// Query the path by stops
		/// </summary>
		public void FindLinesByStop(Int64 stopID)
		{
			try
			{
				if (m_isLoad)
				{
					m_comboGuide.Items.Clear();
					m_comboGuide.Text = "";
					m_dataGridView.Rows.Clear();					
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        m_dataGridView.Columns[1].HeaderText = "Path ID";
                        m_dataGridView.Columns[2].HeaderText = "Name";
                        m_dataGridView.Columns[3].HeaderText = "Length";
                    }
                    else
                    {
                        m_dataGridView.Columns[1].HeaderText = "线路ID";
                        m_dataGridView.Columns[2].HeaderText = "名称";
                        m_dataGridView.Columns[3].HeaderText = "总长度";
                    }

					// 清除跟踪层上已有的线路
					// Clear items of tracking layer
					for (Int32 i = m_trackingLayer.Count - 1; i >= 0; i--)
					{
						if (m_trackingLayer.GetTag(i) != "StartStop" && m_trackingLayer.GetTag(i) != "StartStopName")
						{
							m_trackingLayer.Remove(i);
						}
					}
					m_mapControl.Map.RefreshTrackingLayer();

					// 查询经过指定站点的线路
					// Query the path by stops
					LineInfo[] lineInfos = m_transferAnalyst.FindLinesByStop(stopID);
					if (lineInfos.Length > 0)
					{
						for (Int32 i = 0; i < lineInfos.Length; i++)
						{
							// 将线路信息添加到DataGridView中
							// Add the line information to the DataGridView
							Object[] values = new Object[4];
							values[0] = i + 1;
							values[1] = lineInfos[i].LineID;
							values[2] = lineInfos[i].Name;
							values[3] = lineInfos[i].TotalDistance;
							m_dataGridView.Rows.Add(values);

							// 在跟踪图层中绘制查询出的线路
							// Draw the path on the tracking layer
							GeoLine line = lineInfos[i].TotalLine;
							GeoStyle Style = new GeoStyle();
							Style.LineColor = GetRandomColor();
							Style.LineWidth = 1.0;
							line.Style = Style;
							m_trackingLayer.Add(line, "lines");
						}
						m_mapControl.Map.RefreshTrackingLayer();
						m_mapControl.Map.IsCustomBoundsEnabled = true;
						m_mapControl.Map.CustomBounds = m_datasetLine.Bounds;
						m_mapControl.Map.ViewEntire();
					}
				}
				else
				{					
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        MessageBox.Show("Sorry! There is no path that goes through this stop!");
                    }
                    else
                    {
                        MessageBox.Show("抱歉！没有查找到经过该站点的线路！");
                    }
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 根据线路查询站点
		/// Query stop by the path
		/// </summary>
		/// <param name="lineID"></param>
		public void FindStopsByLine(Int64 lineID)
		{
			try
			{
				if (m_isLoad)
				{
					m_comboGuide.Items.Clear();
					m_dataGridView.Rows.Clear();
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        m_dataGridView.Columns[1].HeaderText = "Stop ID";
                        m_dataGridView.Columns[2].HeaderText = "Name";
                    }
                    else
                    {
                        m_dataGridView.Columns[1].HeaderText = "站点ID";
                        m_dataGridView.Columns[2].HeaderText = "名称";
                    }
					m_dataGridView.Columns[3].HeaderText = "----";

					// 清除跟踪层上的对象
					// Clear object on the tracking layer
					m_trackingLayer.Clear();
					m_mapControl.Map.RefreshTrackingLayer();

					// 查询经过指定站点的线路
					// Query the path by stops
					StopInfo[] stopInfos = m_transferAnalyst.FindStopsByLine(lineID);
					if (stopInfos.Length > 0)
					{
						// 将该线路添加到跟踪层上显示
						// Add the path to the tracking layer
						LineInfo[] lineInfos = m_transferAnalyst.FindLinesByStop(stopInfos[0].StopID);
						for (Int32 i = 0; i < lineInfos.Length; i++)
						{
							if (lineInfos[i].LineID == lineID)
							{
								GeoLine line = lineInfos[i].TotalLine;
								m_mapControl.Map.CustomBounds = line.Bounds;
								m_mapControl.Map.IsCustomBoundsEnabled = true;
								m_mapControl.Map.ViewEntire();

								GeoStyle style = new GeoStyle();
								style.LineColor = Color.DeepSkyBlue;
								style.LineWidth = 1.0;
								line.Style = style;
								m_trackingLayer.Add(line, "Line");
								break;
							}
						}
						// 添加站点信息
						// Add the stops
						for (Int32 j = 0; j < stopInfos.Length; j++)
						{
							// 将线路信息添加到DataGridView中
							// Add the line information to DataGridView
							Object[] values = new Object[4];
							values[0] = j + 1;
							values[1] = stopInfos[j].StopID;
							values[2] = stopInfos[j].Name;
							values[3] = "----";
							m_dataGridView.Rows.Add(values);

							// 在跟踪图层中绘制查询出的站点及其名称
							// Draw stops and names on the tracking layer
							Point2D point2D = stopInfos[j].Position;
							GeoPoint point = new GeoPoint(point2D);
							point.Style = GetStopStyle(new Size2D(5, 5), Color.Orange);
							m_trackingLayer.Add(point, "Stops");

							GeoText geoText = new GeoText();
							TextPart part = new TextPart(stopInfos[j].Name, point2D);
							geoText.AddPart(part);
							geoText.TextStyle = GetStopTextStyle(5.0, Color.FromArgb(153, 0, 255));
							m_trackingLayer.Add(geoText, "StopNames");

						}
						m_mapControl.Map.RefreshTrackingLayer();
					}
				}
				else
				{					
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        MessageBox.Show("Sorry! There is no stop on this path!");
                    }
                    else
                    {
                        MessageBox.Show("抱歉！没有查找到该线路上的站点！");
                    }
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 鼠标移动时绘制捕捉框
		/// Draw the snap box when the mouse moves
		/// </summary>
		/// <param name="point"></param>
		public void SetBound(Point point)
		{
			try
			{
				// 清除跟踪图层上的捕捉框
				// Clear snap box on the tracking layer
				Int32 indexSnapPane = m_trackingLayer.IndexOf("snapPane");
				if (indexSnapPane != -1)
				{
					m_trackingLayer.Remove(indexSnapPane);
					m_mapControl.Map.RefreshTrackingLayer();
				}

				// 将屏幕坐标转换为地图坐标
				// Transform the pixel coordinates to the map coordinates
				Point2D mapPoint = m_mapControl.Map.PixelToMap(point);

				Double scale = (3 * 10E-4) / m_mapControl.Map.Scale;
				m_selection = m_layerStop.HitTest(mapPoint, 4 / 3 * scale);
				if (m_selection != null && m_selection.Count > 0)
				{
					Recordset recordset = m_selection.ToRecordset();
					GeoPoint stopPoint = recordset.GetGeometry() as GeoPoint;

					// 构造捕捉框
					// Build the snap box
					Point2Ds points = new Point2Ds();
					points.Add(new Point2D(stopPoint.X - scale, stopPoint.Y - scale));
					points.Add(new Point2D(stopPoint.X + scale, stopPoint.Y - scale));
					points.Add(new Point2D(stopPoint.X + scale, stopPoint.Y + scale));
					points.Add(new Point2D(stopPoint.X - scale, stopPoint.Y + scale));
					points.Add(new Point2D(stopPoint.X - scale, stopPoint.Y - scale));
					GeoLine snapPane = new GeoLine(points);

					m_mapControl.SelectionTolerance = 2.0;
					m_trackingLayer.Add(snapPane, "snapPane");
					m_mapControl.Map.RefreshTrackingLayer();

					recordset.Dispose();
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 将换乘方案的概述添加到ComboBox中
		/// Add the transfer guide to ComboBox
		/// </summary>
		private void FillComboBox()
		{
			try
			{
				m_comboGuide.Items.Clear();
				TransferSolution solution = null;
				String summary = "";
				for (int i = 0; i < m_solutions.Count; i++)
				{
					solution = m_solutions[i];
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        summary = "Method " + (i + 1) + "：";
                    }
                    else
                    {
                        summary = "方案 " + (i + 1) + "：";
                    }
					TransferLines lines = null;
					for (int j = 0; j < solution.TransferTime + 1; j++)
					{
						lines = solution[j];
						for (int k = 0; k < lines.Count; k++)
						{
							if (k == 0)
							{
								summary += lines[0].LineName;
							}
							else
							{
								summary += "/" + lines[k].LineName;
							}
						}
						if (solution.TransferTime > 0)
						{
							if (j != solution.TransferTime)
							{
                                if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                                {
                                    summary += "Transfer";
                                }
                                else
                                {
                                    summary += "换乘";
                                }
							}
						}
					}
					m_comboGuide.Items.Add(summary);
				}
				m_comboGuide.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 标记当前为在地图上选择起始站点
		/// Mark the current point as the start point
		/// </summary>
		public void SelectStartStop()
		{
			m_isStartPoint = true;
		}

		/// <summary>
		/// 标记当前为在地图上选择终止站点
		/// Mark the current point as the end point
		/// </summary>
		public void SelectEndStop()
		{
			m_isStartPoint = false;
		}

		/// <summary>
		/// 捕捉公交站点
		/// Snap the bus stops 
		/// </summary>
		public void SnapPoint()
		{
			try
			{
				if (m_selection != null)
				{
					// 获取被选中的站点对象
					// Get the selected stop object
					Recordset recordset = m_selection.ToRecordset();
					GeoPoint snapPoint = recordset.GetGeometry() as GeoPoint;

					// 构造文本对象，用于在跟踪层上显示站点的名称
					// Construct the text object, which is used to display the stop name on the tracking name
					GeoText stopText = new GeoText();
					// 站点名称
					// Stop name
                    String stopName = "";
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        stopName = recordset.GetFieldValue("Name_en").ToString();
                    }
                    else
                    {
                        stopName = recordset.GetFieldValue("Name").ToString();
                    }
					TextPart textPart = new TextPart(stopName, new Point2D(snapPoint.X, snapPoint.Y));
					stopText.AddPart(textPart);

					if (m_isStartPoint)
					{
						// 绘制之前先清空跟踪层上的点和文字
						// Clear all points and words on the tracking layer before drawing
						Int32 indexStartStop = m_trackingLayer.IndexOf("StartStop");
						if (indexStartStop != -1)
						{
							m_trackingLayer.Remove(indexStartStop);
						}
						Int32 indexStartText = m_trackingLayer.IndexOf("StartStopName");
						if (indexStartText != -1)
						{
							m_trackingLayer.Remove(indexStartText);
						}
						// 分别设置站点及其名称文本的风格，并添加到跟踪层上
						// Set the stop and name style and add them to the tracking layer
						snapPoint.Style = GetStopStyle(new Size2D(8, 8), Color.FromArgb(236, 118, 0));
						m_trackingLayer.Add(snapPoint, "StartStop");
						stopText.TextStyle = GetStopTextStyle(6.0, Color.FromArgb(0, 0, 0));
						m_trackingLayer.Add(stopText, "StartStopName");

						// 设置为起始站点ID
						// Set the strat stop ID
						m_startStopID = recordset.GetInt64("STOPID");
					}
					else
					{
						// 绘制之前先清空跟踪层上的点和文字
						// Clear all points and words on the tracking layer before drawing
						Int32 indexEndStop = m_trackingLayer.IndexOf("EndStop");
						if (indexEndStop != -1)
						{
							m_trackingLayer.Remove(indexEndStop);
						}
						Int32 indexEndText = m_trackingLayer.IndexOf("EndStopName");
						if (indexEndText != -1)
						{
							m_trackingLayer.Remove(indexEndText);
						}
						// 分别设置站点及其名称文本的风格，并添加到跟踪层上
						// Set the stop and name style and add them to the tracking layer
						snapPoint.Style = GetStopStyle(new Size2D(8, 8), Color.FromArgb(22, 255, 0));
						m_trackingLayer.Add(snapPoint, "EndStop");
						stopText.TextStyle = GetStopTextStyle(6.0, Color.FromArgb(0, 0, 0));
						m_trackingLayer.Add(stopText, "EndStopName");

						// 设置为起始站点ID
						// Set the strat stop ID
						m_endStopID = recordset.GetInt64("STOPID");
					}
					recordset.Dispose();
				}
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 在地图上显示换乘的图形导引，在DataGridView中显示详细信息
		/// Display the graphical guide on the map. And display the details on DataGridView
		/// </summary>
		public void ShowReslut()
		{			
            if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
            {
                m_dataGridView.Columns[1].HeaderText = "Guilde";
                m_dataGridView.Columns[2].HeaderText = "Distance";
                m_dataGridView.Columns[3].HeaderText = "Cost";
            }
            else
            {
                m_dataGridView.Columns[1].HeaderText = "导引";
                m_dataGridView.Columns[2].HeaderText = "距离";
                m_dataGridView.Columns[3].HeaderText = "费用";
            }
			// 删除跟踪图层上除起始、终止站点及其名称外的几何对象
			// Delete objects on the tracking layer except the start and end stop
			for (Int32 i = m_trackingLayer.Count - 1; i >= 0; i--)
			{
				String tag = m_trackingLayer.GetTag(i);
				if (tag != "StartStop" && tag != "EndStop" && tag != "StartStopName" && tag != "EndStopName")
				{
					m_trackingLayer.Remove(i);
				}
			}
			m_mapControl.Map.RefreshTrackingLayer();

			TransferSolution solution = null;
			if (m_comboGuide.SelectedIndex == -1)
			{
				solution = m_solutions[0];
			}
			else
			{
				solution = m_solutions[m_comboGuide.SelectedIndex];
			}

			// 提取换乘方案中的第一条换乘路线，即每段乘车段集合中的第一段乘车路线的组合对应的完整路线
			// Extract the first transfer path
			TransferLine[] linesOnOne = new TransferLine[solution.TransferTime + 1];
			for (int j = 0; j < solution.TransferTime + 1; j++)
			{
				linesOnOne[j] = solution[j][0];
			}
			// 获取换乘导引
			// gat the transfer guide
			TransferGuide transferGuide = m_transferAnalyst.GetDetailInfo(m_startStopID, m_endStopID, linesOnOne);

			// 从换乘导引中提取详细的导引信息
			// Extract the details from transfer guide
			if (transferGuide != null)
			{
				for (Int32 i = 0; i < transferGuide.Count; i++)
				{
					TransferGuideItem item = transferGuide[i];
					// 获取换乘导引子项的路径对象
					// Get the path objects of the guide items
					GeoLine path = item.Route;
					GeoStyle style = new GeoStyle();
					if (item.IsWalking)
					{
						style.LineColor = Color.FromArgb(255, 87, 87);
						style.LineWidth = 0.6;
						style.LineSymbolID = 12;
					}
					else
					{
						style.LineColor = Color.Blue;
						style.LineWidth = 1.0;
					}

					path.Style = style;

					// 在跟踪层上绘制每个换乘导引子项的路径对象
					// Draw the path object of transfer guide item on the tracking layer
					m_trackingLayer.Add(path, "Path");

					// 绘制中间站点
					// Draw mid-stops
					GeoPoint transferStop = new GeoPoint(item.StartPosition.X, item.StartPosition.Y);
					transferStop.Style = GetStopStyle(new Size2D(5, 5), Color.FromArgb(87, 255, 255));

					GeoText transferStopName = new GeoText();
					TextPart part = new TextPart(item.StartName, new Point2D(transferStop.X, transferStop.Y));
					transferStopName.AddPart(part);
					transferStopName.TextStyle = GetStopTextStyle(5.0, Color.FromArgb(89, 89, 89));
					if (i != 0)
					{
						m_trackingLayer.Add(transferStop, "transferStop");
					}
					m_trackingLayer.Add(transferStopName, "transferStopName");

					transferStop = new GeoPoint(item.EndPosition.X, item.EndPosition.Y);
					transferStop.Style = GetStopStyle(new Size2D(5, 5), Color.FromArgb(87, 255, 255));

					transferStopName = new GeoText();
					part = new TextPart(item.EndName, new Point2D(transferStop.X, transferStop.Y));
					transferStopName.AddPart(part);
					transferStopName.TextStyle = GetStopTextStyle(5.0, Color.FromArgb(89, 89, 89));
					if (i != transferGuide.Count - 1)
					{
						m_trackingLayer.Add(transferStop, "transferStop");
					}
					m_trackingLayer.Add(transferStopName, "transferStopName");

					m_mapControl.Map.RefreshTrackingLayer();
				}
				m_mapControl.Map.RefreshTrackingLayer();

				// 添加信息到DataGridView
				// Add information to DataGridView
				FillGuidesInfo(transferGuide);
			}
			else
			{				
                if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                {
                    MessageBox.Show("Sorry! There is no proper transfer line!");
                }
                else
                {
                    MessageBox.Show("抱歉！公交方案详细信息提取出错！");
                }
			}
		}

		/// <summary>
		/// 将换乘方案信息添加到DataGridView上
		/// Add transfer information to DataGridView
		/// </summary>
		/// <param name="transferGuide"></param>
		private void FillGuidesInfo(TransferGuide transferGuide)
		{
			// 清除DataGridView中的数据
			// Clear data of DataGridView
			m_dataGridView.Rows.Clear();

			// 添加换乘方案详细信息到m_dataGridView
			// Add detailed transfer information to m_dataGridView
			Object[] values = new Object[4];
			// 步行的距离
			//Walking distance
			Double disWalk = 0.0;

			//乘车经过的距离
			//Bus path distance
			Double disRide = 0.0;
			for (Int32 i = 0; i < transferGuide.Count; i++)
			{
				TransferGuideItem item = transferGuide[i];

				values[0] = (i + 1).ToString();

				if (item.IsWalking)
				{
					if (i == transferGuide.Count - 1)
					{
                        if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                        {
                            values[1] = "Walk to the destination";
                        }
                        else
                        {
                            values[1] = "步行至终点";
                        }
					}
					else
					{
                        if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                        {
                            values[1] = "Walk to" + transferGuide[i + 1].StartName;
                        }
                        else
                        {
                            values[1] = "步行至" + transferGuide[i + 1].StartName;
                        }
					}
					disWalk += item.Distance;
				}
				else
				{
                    if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
                    {
                        values[1] = "From " + item.StartName + ", take " + item.LineName + " with " + (item.PassStopCount - 1) + " stops, and get off at " + item.EndName;
                    }
                    else
                    {
                        values[1] = "从" + item.StartName + "乘坐" + item.LineName + "经过" + (item.PassStopCount - 1) + "站，在" + item.EndName + "下车";
                    }					
					disRide += item.Distance;
				}
				values[2] = item.Distance;
				values[3] = item.Fare;
				m_dataGridView.Rows.Add(values);
			}

			values[0] = transferGuide.Count + 1;
			values[1] = "乘车总距离：" + disRide + "，步行总距离：" + disWalk;
			values[2] = "总距离：" + transferGuide.TotalDistance;
			values[3] = "总费用：" + transferGuide.TotalFare;
            if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
            {
                values[1] = "Bus distance: " + disRide + ", walking distance: " + disWalk;
                values[2] = "Total distance: " + transferGuide.TotalDistance;
                values[3] = "Total cost: " + transferGuide.TotalFare;
            }
            else
            {
                values[1] = "乘车总距离：" + disRide + "，步行总距离：" + disWalk;
                values[2] = "总距离：" + transferGuide.TotalDistance;
                values[3] = "总费用：" + transferGuide.TotalFare;
            }
			m_dataGridView.Rows.Add(values);
		}

		/// <summary>
		/// 站点查线路时，如果不输入站点ID，则按照已选择的起始站点进行查询
		/// If there is no stop ID, it will query by the selected start and end stops
		/// </summary>
		/// <returns></returns>
		public Int64 GetStopID()
		{
			return m_startStopID;
		}

		/// <summary>
		/// 清空跟踪图层及分析结果
		/// Clear
		/// </summary>
		public void ClearResult()
		{
			try
			{
				m_solutions = null;
				m_startStopID = -1;
				m_trackingLayer.Clear();
				m_mapControl.Map.RefreshTrackingLayer();
				m_comboGuide.Items.Clear();
				m_comboGuide.Text = "";
				m_dataGridView.Rows.Clear();
				m_layerStop.Selection.Clear();
				m_mapControl.Map.Refresh();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// 获得公交换乘策略
		/// Get the bus transfer methods
		/// </summary>
		/// <param name="tacticIndex"></param>
		/// <returns></returns>
		private TransferTactic GetTactic(Int32 tacticIndex)
		{
			TransferTactic tactic;
			switch (tacticIndex)
			{
				case 0:
					tactic = TransferTactic.LessTransfer;
					break;
				case 1:
					tactic = TransferTactic.LessWalk;
					break;
				case 2:
					tactic = TransferTactic.LessTime;
					break;
				case 3:
					tactic = TransferTactic.MinDistance;
					break;
				default:
					tactic = TransferTactic.LessTransfer;
					break;
			}
			return tactic;
		}

		/// <summary>
		/// 设置站点几何风格，用于在跟踪层上绘制
		/// Set the stop geometry style, which is used to draw in tracking layer
		/// </summary>
		/// <param name="size2D"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		private GeoStyle GetStopStyle(Size2D size2D, Color color)
		{
			GeoStyle style = new GeoStyle();
			style.MarkerSize = size2D;
			style.LineColor = color;
			return style;
		}

		/// <summary>
		/// 站点名称文本的风格，用于在跟踪层上绘制
		/// The text style of stop name, which is used to draw in tracking layer
		/// </summary>
		/// <param name="name"></param>
		/// <param name="anchorPoint"></param>
		/// <param name="color"></param>
		/// <returns></returns>
		private TextStyle GetStopTextStyle(Double fontHeight, Color color)
		{
			TextStyle style = new TextStyle();
			style.BackOpaque = true;
			style.Shadow = true;
			style.BackColor = Color.FromArgb(255, 255, 0);
			style.FontHeight = fontHeight;
            if (SuperMap.Data.Environment.CurrentCulture != "zh-CN")
            {
                style.FontName = "Times New Roman";
            }
            else
            {
                style.FontName = "微软雅黑";
            }
			style.Bold = true;
			style.ForeColor = color;
			return style;
		}

		/// <summary>
		/// 获取一个随机颜色
		/// Get a color
		/// </summary>
		/// <returns></returns>
		private Color GetRandomColor()
		{
			System.Threading.Thread.Sleep(10);
			Random randomR = new Random((Int32)DateTime.Now.Ticks);
			System.Threading.Thread.Sleep(randomR.Next(10));
			Random randomG = new Random((Int32)DateTime.Now.Ticks);
			System.Threading.Thread.Sleep(randomG.Next(10));
			Random randomB = new Random((Int32)DateTime.Now.Ticks);

			Int32 intRed = randomR.Next(254);
			Int32 intGreen = randomG.Next(254);
			Int32 intBlue = randomB.Next(254);

			return Color.FromArgb(intRed, intGreen, intBlue);
		}

	}
}


