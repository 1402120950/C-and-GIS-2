namespace zl
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
            this.components = new System.ComponentModel.Container();
            this.workspace1 = new SuperMap.Data.Workspace(this.components);
            this.mapControl1 = new SuperMap.UI.MapControl();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripOpen = new System.Windows.Forms.Button();
            this.toolStripPan = new System.Windows.Forms.Button();
            this.toolStripZoomIn = new System.Windows.Forms.Button();
            this.toolStripZoomOut = new System.Windows.Forms.Button();
            this.toolStripZoomFree = new System.Windows.Forms.Button();
            this.toolStripViewEntire = new System.Windows.Forms.Button();
            this.toolStripSelect = new System.Windows.Forms.Button();
            this.toolStripQueryProperty = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripLabel1 = new System.Windows.Forms.Label();
            this.toolStripTextBox1 = new System.Windows.Forms.TextBox();
            this.toolStripSQLQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // workspace1
            // 
            this.workspace1.Caption = "UntitledWorkspace";
            this.workspace1.Description = "";
            this.workspace1.DesktopInfo = "";
            // 
            // mapControl1
            // 
            this.mapControl1.Action = SuperMap.UI.Action.Select2;
            this.mapControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mapControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapControl1.Location = new System.Drawing.Point(33, 13);
            this.mapControl1.Margin = new System.Windows.Forms.Padding(72, 33, 72, 33);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(709, 289);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.TrackMode = SuperMap.UI.TrackMode.Edit;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.Location = new System.Drawing.Point(745, 215);
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.Size = new System.Drawing.Size(64, 87);
            this.toolStripOpen.TabIndex = 1;
            this.toolStripOpen.Text = "打开工作空间文件";
            this.toolStripOpen.UseVisualStyleBackColor = true;
            this.toolStripOpen.Click += new System.EventHandler(this.toolStripOpen_Click_1);
            // 
            // toolStripPan
            // 
            this.toolStripPan.Location = new System.Drawing.Point(33, 307);
            this.toolStripPan.Name = "toolStripPan";
            this.toolStripPan.Size = new System.Drawing.Size(64, 42);
            this.toolStripPan.TabIndex = 2;
            this.toolStripPan.Text = "漫游";
            this.toolStripPan.UseVisualStyleBackColor = true;
            this.toolStripPan.Click += new System.EventHandler(this.toolStripPan_Click);
            // 
            // toolStripZoomIn
            // 
            this.toolStripZoomIn.Location = new System.Drawing.Point(103, 307);
            this.toolStripZoomIn.Name = "toolStripZoomIn";
            this.toolStripZoomIn.Size = new System.Drawing.Size(64, 42);
            this.toolStripZoomIn.TabIndex = 3;
            this.toolStripZoomIn.Text = "放大";
            this.toolStripZoomIn.UseVisualStyleBackColor = true;
            this.toolStripZoomIn.Click += new System.EventHandler(this.toolStripZoomIn_Click);
            // 
            // toolStripZoomOut
            // 
            this.toolStripZoomOut.Location = new System.Drawing.Point(173, 307);
            this.toolStripZoomOut.Name = "toolStripZoomOut";
            this.toolStripZoomOut.Size = new System.Drawing.Size(64, 42);
            this.toolStripZoomOut.TabIndex = 4;
            this.toolStripZoomOut.Text = "缩小";
            this.toolStripZoomOut.UseVisualStyleBackColor = true;
            this.toolStripZoomOut.Click += new System.EventHandler(this.toolStripZoomOut_Click);
            // 
            // toolStripZoomFree
            // 
            this.toolStripZoomFree.Location = new System.Drawing.Point(243, 307);
            this.toolStripZoomFree.Name = "toolStripZoomFree";
            this.toolStripZoomFree.Size = new System.Drawing.Size(102, 42);
            this.toolStripZoomFree.TabIndex = 5;
            this.toolStripZoomFree.Text = "自由缩放";
            this.toolStripZoomFree.UseVisualStyleBackColor = true;
            this.toolStripZoomFree.Click += new System.EventHandler(this.toolStripZoomFree_Click);
            // 
            // toolStripViewEntire
            // 
            this.toolStripViewEntire.Location = new System.Drawing.Point(351, 307);
            this.toolStripViewEntire.Name = "toolStripViewEntire";
            this.toolStripViewEntire.Size = new System.Drawing.Size(90, 42);
            this.toolStripViewEntire.TabIndex = 6;
            this.toolStripViewEntire.Text = "全幅显示";
            this.toolStripViewEntire.UseVisualStyleBackColor = true;
            this.toolStripViewEntire.Click += new System.EventHandler(this.toolStripViewEntire_Click);
            // 
            // toolStripSelect
            // 
            this.toolStripSelect.Location = new System.Drawing.Point(447, 307);
            this.toolStripSelect.Name = "toolStripSelect";
            this.toolStripSelect.Size = new System.Drawing.Size(64, 42);
            this.toolStripSelect.TabIndex = 7;
            this.toolStripSelect.Text = "选择";
            this.toolStripSelect.UseVisualStyleBackColor = true;
            this.toolStripSelect.Click += new System.EventHandler(this.toolStripSelect_Click);
            // 
            // toolStripQueryProperty
            // 
            this.toolStripQueryProperty.Location = new System.Drawing.Point(517, 307);
            this.toolStripQueryProperty.Name = "toolStripQueryProperty";
            this.toolStripQueryProperty.Size = new System.Drawing.Size(93, 42);
            this.toolStripQueryProperty.TabIndex = 8;
            this.toolStripQueryProperty.Text = "图查属性";
            this.toolStripQueryProperty.UseVisualStyleBackColor = true;
            this.toolStripQueryProperty.Click += new System.EventHandler(this.toolStripQueryProperty_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(817, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(363, 289);
            this.dataGridView1.TabIndex = 9;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = true;
            this.toolStripLabel1.Location = new System.Drawing.Point(30, 378);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(134, 18);
            this.toolStripLabel1.TabIndex = 10;
            this.toolStripLabel1.Text = "输入查询条件：";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Location = new System.Drawing.Point(170, 368);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 28);
            this.toolStripTextBox1.TabIndex = 11;
            // 
            // toolStripSQLQuery
            // 
            this.toolStripSQLQuery.Location = new System.Drawing.Point(292, 363);
            this.toolStripSQLQuery.Name = "toolStripSQLQuery";
            this.toolStripSQLQuery.Size = new System.Drawing.Size(95, 33);
            this.toolStripSQLQuery.TabIndex = 12;
            this.toolStripSQLQuery.Text = "属性查图";
            this.toolStripSQLQuery.UseVisualStyleBackColor = true;
            this.toolStripSQLQuery.Click += new System.EventHandler(this.toolStripSQLQuery_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 505);
            this.Controls.Add(this.toolStripSQLQuery);
            this.Controls.Add(this.toolStripTextBox1);
            this.Controls.Add(this.toolStripLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStripQueryProperty);
            this.Controls.Add(this.toolStripSelect);
            this.Controls.Add(this.toolStripViewEntire);
            this.Controls.Add(this.toolStripZoomFree);
            this.Controls.Add(this.toolStripZoomOut);
            this.Controls.Add(this.toolStripZoomIn);
            this.Controls.Add(this.toolStripPan);
            this.Controls.Add(this.toolStripOpen);
            this.Controls.Add(this.mapControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SuperMap.Data.Workspace workspace1;
        private SuperMap.UI.MapControl mapControl1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button toolStripOpen;
        private System.Windows.Forms.Button toolStripPan;
        private System.Windows.Forms.Button toolStripZoomIn;
        private System.Windows.Forms.Button toolStripZoomOut;
        private System.Windows.Forms.Button toolStripZoomFree;
        private System.Windows.Forms.Button toolStripViewEntire;
        private System.Windows.Forms.Button toolStripSelect;
        private System.Windows.Forms.Button toolStripQueryProperty;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label toolStripLabel1;
        private System.Windows.Forms.TextBox toolStripTextBox1;
        private System.Windows.Forms.Button toolStripSQLQuery;
    }
}

