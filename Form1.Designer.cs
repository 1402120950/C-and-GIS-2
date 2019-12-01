namespace WindowsFormsApp12
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mapControl = new SuperMap.UI.MapControl();
            this.layersTree = new SuperMap.UI.LayersTree();
            this.workspaceControl = new SuperMap.UI.WorkspaceControl();
            this.toolStripQueryProperty = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStripPan = new System.Windows.Forms.Button();
            this.toolStripSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapControl
            // 
            this.mapControl.Action = SuperMap.UI.Action.Select2;
            this.mapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mapControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapControl.Location = new System.Drawing.Point(374, 43);
            this.mapControl.Margin = new System.Windows.Forms.Padding(68, 34, 68, 34);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(953, 508);
            this.mapControl.TabIndex = 0;
            this.mapControl.TrackMode = SuperMap.UI.TrackMode.Edit;
            this.mapControl.Load += new System.EventHandler(this.mapControl_Load);
            // 
            // layersTree
            // 
            this.layersTree.AllowDrop = true;
            this.layersTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layersTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.layersTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.layersTree.DragNodeEnabled = true;
            this.layersTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.layersTree.DropLineColor = System.Drawing.SystemColors.HotTrack;
            this.layersTree.HideSelection = false;
            this.layersTree.Icons = ((SuperMap.UI.TreeIconTypes)(((((SuperMap.UI.TreeIconTypes.Visible | SuperMap.UI.TreeIconTypes.Selectable) 
            | SuperMap.UI.TreeIconTypes.Editable) 
            | SuperMap.UI.TreeIconTypes.Snapable) 
            | SuperMap.UI.TreeIconTypes.TypeIcon)));
            this.layersTree.IconType = SuperMap.UI.LayersTree.IconTypes.None;
            this.layersTree.ItemHeight = 20;
            this.layersTree.Location = new System.Drawing.Point(-3, 332);
            this.layersTree.Map = null;
            this.layersTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layersTree.Name = "layersTree";
            this.layersTree.SelectedNodes = new System.Windows.Forms.TreeNode[0];
            this.layersTree.SimpleMode = false;
            this.layersTree.Size = new System.Drawing.Size(378, 219);
            this.layersTree.TabIndex = 1;
            this.layersTree.VisibleScaleNodesList = ((System.Collections.Generic.List<SuperMap.UI.LayersTreeNodeBase>)(resources.GetObject("layersTree.VisibleScaleNodesList")));
            this.layersTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.layersTree1_AfterSelect);
            // 
            // workspaceControl
            // 
            this.workspaceControl.AllowDefaultAction = true;
            this.workspaceControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.workspaceControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.workspaceControl.Location = new System.Drawing.Point(-3, -2);
            this.workspaceControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.workspaceControl.Name = "workspaceControl";
            this.workspaceControl.Size = new System.Drawing.Size(378, 335);
            this.workspaceControl.TabIndex = 2;
            // 
            // 
            // 
            this.workspaceControl.WorkspaceToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.workspaceControl.WorkspaceToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.workspaceControl.WorkspaceToolBar.Location = new System.Drawing.Point(0, 0);
            this.workspaceControl.WorkspaceToolBar.Name = "WorkspaceToolBar";
            this.workspaceControl.WorkspaceToolBar.Size = new System.Drawing.Size(378, 27);
            this.workspaceControl.WorkspaceToolBar.TabIndex = 0;
            // 
            // 
            // 
            this.workspaceControl.WorkspaceTree.AllowDrop = true;
            this.workspaceControl.WorkspaceTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.workspaceControl.WorkspaceTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workspaceControl.WorkspaceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspaceControl.WorkspaceTree.ItemHeight = 21;
            this.workspaceControl.WorkspaceTree.Location = new System.Drawing.Point(0, 58);
            this.workspaceControl.WorkspaceTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.workspaceControl.WorkspaceTree.Name = "WorkspaceTree";
            this.workspaceControl.WorkspaceTree.SelectedNodes = new System.Windows.Forms.TreeNode[0];
            this.workspaceControl.WorkspaceTree.Size = new System.Drawing.Size(378, 277);
            this.workspaceControl.WorkspaceTree.TabIndex = 1;
            this.workspaceControl.WorkspaceTree.Workspace = null;
            this.workspaceControl.Load += new System.EventHandler(this.workspaceControl_Load);
            // 
            // toolStripQueryProperty
            // 
            this.toolStripQueryProperty.Location = new System.Drawing.Point(592, 12);
            this.toolStripQueryProperty.Name = "toolStripQueryProperty";
            this.toolStripQueryProperty.Size = new System.Drawing.Size(102, 29);
            this.toolStripQueryProperty.TabIndex = 3;
            this.toolStripQueryProperty.Text = "属性查询";
            this.toolStripQueryProperty.UseVisualStyleBackColor = true;
            this.toolStripQueryProperty.Click += new System.EventHandler(this.toolStripQueryProperty_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-3, 545);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1330, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(700, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "公交分析";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStripPan
            // 
            this.toolStripPan.Location = new System.Drawing.Point(396, 12);
            this.toolStripPan.Name = "toolStripPan";
            this.toolStripPan.Size = new System.Drawing.Size(99, 29);
            this.toolStripPan.TabIndex = 6;
            this.toolStripPan.Text = "漫游";
            this.toolStripPan.UseVisualStyleBackColor = true;
            this.toolStripPan.Click += new System.EventHandler(this.toolStripPan_Click);
            // 
            // toolStripSelect
            // 
            this.toolStripSelect.Location = new System.Drawing.Point(501, 12);
            this.toolStripSelect.Name = "toolStripSelect";
            this.toolStripSelect.Size = new System.Drawing.Size(85, 29);
            this.toolStripSelect.TabIndex = 8;
            this.toolStripSelect.Text = "选择";
            this.toolStripSelect.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 695);
            this.Controls.Add(this.toolStripSelect);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStripPan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStripQueryProperty);
            this.Controls.Add(this.workspaceControl);
            this.Controls.Add(this.layersTree);
            this.Controls.Add(this.mapControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "小图";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SuperMap.UI.MapControl mapControl;
        private SuperMap.UI.LayersTree layersTree;
        private SuperMap.UI.WorkspaceControl workspaceControl;
        private System.Windows.Forms.Button toolStripQueryProperty;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button toolStripPan;
        private System.Windows.Forms.Button toolStripSelect;
    }
}

