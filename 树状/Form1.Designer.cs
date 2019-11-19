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
            this.mapControl.Location = new System.Drawing.Point(354, -2);
            this.mapControl.Margin = new System.Windows.Forms.Padding(60, 28, 60, 28);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(437, 452);
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
            this.layersTree.Location = new System.Drawing.Point(-2, 215);
            this.layersTree.Map = null;
            this.layersTree.Name = "layersTree";
            this.layersTree.SelectedNodes = new System.Windows.Forms.TreeNode[0];
            this.layersTree.SimpleMode = false;
            this.layersTree.Size = new System.Drawing.Size(357, 235);
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
            this.workspaceControl.Location = new System.Drawing.Point(-2, -3);
            this.workspaceControl.Name = "workspaceControl";
            this.workspaceControl.Size = new System.Drawing.Size(357, 218);
            this.workspaceControl.TabIndex = 2;
            // 
            // 
            // 
            this.workspaceControl.WorkspaceToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.workspaceControl.WorkspaceToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.workspaceControl.WorkspaceToolBar.Location = new System.Drawing.Point(0, 0);
            this.workspaceControl.WorkspaceToolBar.Name = "WorkspaceToolBar";
            this.workspaceControl.WorkspaceToolBar.Size = new System.Drawing.Size(357, 27);
            this.workspaceControl.WorkspaceToolBar.TabIndex = 0;
            // 
            // 
            // 
            this.workspaceControl.WorkspaceTree.AllowDrop = true;
            this.workspaceControl.WorkspaceTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.workspaceControl.WorkspaceTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.workspaceControl.WorkspaceTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspaceControl.WorkspaceTree.ItemHeight = 21;
            this.workspaceControl.WorkspaceTree.Location = new System.Drawing.Point(0, 54);
            this.workspaceControl.WorkspaceTree.Name = "WorkspaceTree";
            this.workspaceControl.WorkspaceTree.SelectedNodes = new System.Windows.Forms.TreeNode[0];
            this.workspaceControl.WorkspaceTree.Size = new System.Drawing.Size(357, 164);
            this.workspaceControl.WorkspaceTree.TabIndex = 1;
            this.workspaceControl.WorkspaceTree.Workspace = null;
            this.workspaceControl.Load += new System.EventHandler(this.workspaceControl_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.workspaceControl);
            this.Controls.Add(this.layersTree);
            this.Controls.Add(this.mapControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SuperMap.UI.MapControl mapControl;
        private SuperMap.UI.LayersTree layersTree;
        private SuperMap.UI.WorkspaceControl workspaceControl;
    }
}

