namespace SuperMap.SampleCode.Analyst.TrafficAnalyst
{
	partial class FormMain
	{
		/// <summary>
		/// 必需的设计器变量。
        /// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
        /// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonClear = new System.Windows.Forms.Button();
			this.textBoxLineID = new System.Windows.Forms.TextBox();
			this.textBoxStopID = new System.Windows.Forms.TextBox();
			this.buttonFindStops = new System.Windows.Forms.Button();
			this.buttonFindLines = new System.Windows.Forms.Button();
			this.buttonAnalyst = new System.Windows.Forms.Button();
			this.labelTactic = new System.Windows.Forms.Label();
			this.comboTactic = new System.Windows.Forms.ComboBox();
			this.radioEnd = new System.Windows.Forms.RadioButton();
			this.radioStart = new System.Windows.Forms.RadioButton();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.comboGuide = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(902, 618);
			this.splitContainer1.SplitterDistance = 36;
			this.splitContainer1.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.buttonLoad);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.buttonClear);
			this.panel1.Controls.Add(this.textBoxLineID);
			this.panel1.Controls.Add(this.textBoxStopID);
			this.panel1.Controls.Add(this.buttonFindStops);
			this.panel1.Controls.Add(this.buttonFindLines);
			this.panel1.Controls.Add(this.buttonAnalyst);
			this.panel1.Controls.Add(this.labelTactic);
			this.panel1.Controls.Add(this.comboTactic);
			this.panel1.Controls.Add(this.radioEnd);
			this.panel1.Controls.Add(this.radioStart);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(902, 36);
			this.panel1.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label5.Location = new System.Drawing.Point(103, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(2, 24);
			this.label5.TabIndex = 13;
			this.label5.Text = "label5";
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(9, 7);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(87, 23);
			this.buttonLoad.TabIndex = 12;
			this.buttonLoad.Text = "Load data";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// label4
			// 
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Location = new System.Drawing.Point(660, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(2, 24);
			this.label4.TabIndex = 11;
			this.label4.Text = "label4";
			// 
			// label3
			// 
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label3.Location = new System.Drawing.Point(837, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(2, 24);
			this.label3.TabIndex = 10;
			this.label3.Text = "label3";
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Location = new System.Drawing.Point(483, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(2, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "label2";
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(843, 7);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(43, 23);
			this.buttonClear.TabIndex = 9;
			this.buttonClear.Text = "Clear";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// textBoxLineID
			// 
			this.textBoxLineID.Location = new System.Drawing.Point(667, 10);
			this.textBoxLineID.Name = "textBoxLineID";
			this.textBoxLineID.Size = new System.Drawing.Size(86, 21);
			this.textBoxLineID.TabIndex = 8;
			// 
			// textBoxStopID
			// 
			this.textBoxStopID.Location = new System.Drawing.Point(490, 9);
			this.textBoxStopID.Name = "textBoxStopID";
			this.textBoxStopID.Size = new System.Drawing.Size(86, 21);
			this.textBoxStopID.TabIndex = 7;
			// 
			// buttonFindStops
			// 
			this.buttonFindStops.Location = new System.Drawing.Point(756, 7);
			this.buttonFindStops.Name = "buttonFindStops";
			this.buttonFindStops.Size = new System.Drawing.Size(75, 23);
			this.buttonFindStops.TabIndex = 6;
			this.buttonFindStops.Text = "Query Stop By Path";
			this.buttonFindStops.UseVisualStyleBackColor = true;
			this.buttonFindStops.Click += new System.EventHandler(this.buttonFindStops_Click);
			// 
			// buttonFindLines
			// 
			this.buttonFindLines.Location = new System.Drawing.Point(579, 7);
			this.buttonFindLines.Name = "buttonFindLines";
			this.buttonFindLines.Size = new System.Drawing.Size(75, 23);
			this.buttonFindLines.TabIndex = 5;
			this.buttonFindLines.Text = "Query Path By Stop";
			this.buttonFindLines.UseVisualStyleBackColor = true;
			this.buttonFindLines.Click += new System.EventHandler(this.buttonFindLines_Click);
			// 
			// buttonAnalyst
			// 
			this.buttonAnalyst.Location = new System.Drawing.Point(401, 7);
			this.buttonAnalyst.Name = "buttonAnalyst";
			this.buttonAnalyst.Size = new System.Drawing.Size(75, 23);
			this.buttonAnalyst.TabIndex = 4;
			this.buttonAnalyst.Text = "Analyze";
			this.buttonAnalyst.UseVisualStyleBackColor = true;
			this.buttonAnalyst.Click += new System.EventHandler(this.buttonAnalyst_Click);
			// 
			// labelTactic
			// 
			this.labelTactic.AutoSize = true;
			this.labelTactic.Location = new System.Drawing.Point(237, 12);
			this.labelTactic.Name = "labelTactic";
			this.labelTactic.Size = new System.Drawing.Size(59, 12);
			this.labelTactic.TabIndex = 3;
			this.labelTactic.Text = "Strategy:";
			// 
			// comboTactic
			// 
			this.comboTactic.FormattingEnabled = true;
			this.comboTactic.Location = new System.Drawing.Point(299, 9);
			this.comboTactic.Name = "comboTactic";
			this.comboTactic.Size = new System.Drawing.Size(99, 20);
			this.comboTactic.TabIndex = 2;
			// 
			// radioEnd
			// 
			this.radioEnd.AutoSize = true;
			this.radioEnd.Location = new System.Drawing.Point(177, 10);
			this.radioEnd.Name = "radioEnd";
			this.radioEnd.Size = new System.Drawing.Size(41, 16);
			this.radioEnd.TabIndex = 1;
			this.radioEnd.TabStop = true;
			this.radioEnd.Text = "End";
			this.radioEnd.UseVisualStyleBackColor = true;
			this.radioEnd.Click += new System.EventHandler(this.radioEnd_Click);
			// 
			// radioStart
			// 
			this.radioStart.AutoSize = true;
			this.radioStart.Location = new System.Drawing.Point(113, 10);
			this.radioStart.Name = "radioStart";
			this.radioStart.Size = new System.Drawing.Size(53, 16);
			this.radioStart.TabIndex = 0;
			this.radioStart.TabStop = true;
			this.radioStart.Text = "Start";
			this.radioStart.UseVisualStyleBackColor = true;
			this.radioStart.Click += new System.EventHandler(this.radioStart_Click);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Size = new System.Drawing.Size(902, 578);
			this.splitContainer2.SplitterDistance = 380;
			this.splitContainer2.TabIndex = 0;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.panel2);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.dataGridView);
			this.splitContainer3.Size = new System.Drawing.Size(902, 194);
			this.splitContainer3.SplitterDistance = 26;
			this.splitContainer3.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.comboGuide);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(902, 26);
			this.panel2.TabIndex = 0;
			// 
			// comboGuide
			// 
			this.comboGuide.FormattingEnabled = true;
			this.comboGuide.Location = new System.Drawing.Point(223, 4);
			this.comboGuide.Name = "comboGuide";
			this.comboGuide.Size = new System.Drawing.Size(486, 20);
			this.comboGuide.TabIndex = 1;
			this.comboGuide.SelectedIndexChanged += new System.EventHandler(this.comboGuide_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(209, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please select the transfer method:";
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowTemplate.Height = 23;
			this.dataGridView.Size = new System.Drawing.Size(902, 164);
			this.dataGridView.TabIndex = 0;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(902, 618);
			this.Controls.Add(this.splitContainer1);
			this.Name = "FormMain";
			this.Text = "Analyze";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.RadioButton radioEnd;
		private System.Windows.Forms.RadioButton radioStart;
		private System.Windows.Forms.Label labelTactic;
		private System.Windows.Forms.ComboBox comboTactic;
		private System.Windows.Forms.Button buttonAnalyst;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.TextBox textBoxLineID;
		private System.Windows.Forms.TextBox textBoxStopID;
		private System.Windows.Forms.Button buttonFindStops;
		private System.Windows.Forms.Button buttonFindLines;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox comboGuide;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button buttonLoad;

	}
}



