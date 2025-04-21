namespace Academy
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageStudents = new System.Windows.Forms.TabPage();
            this.cbStudentsDirection = new System.Windows.Forms.ComboBox();
            this.cbStudentsGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxStDirections = new System.Windows.Forms.ComboBox();
            this.comboBoxStGroups = new System.Windows.Forms.ComboBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.tabPageGroups = new System.Windows.Forms.TabPage();
            this.cbGroupsDirection = new System.Windows.Forms.ComboBox();
            this.comboBoxGroups = new System.Windows.Forms.ComboBox();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.tabPageDirections = new System.Windows.Forms.TabPage();
            this.checkBUnEmptyDirections = new System.Windows.Forms.CheckBox();
            this.checkBEmptyDirections = new System.Windows.Forms.CheckBox();
            this.dgvDirections = new System.Windows.Forms.DataGridView();
			this.tabPageDisciplines = new System.Windows.Forms.TabPage();
            this.dgvDisciplines = new System.Windows.Forms.DataGridView();
			this.tabPageTeachers = new System.Windows.Forms.TabPage();
            this.dgvTeachers = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPageStudents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.tabPageGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.tabPageDirections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
            this.tabPageDisciplines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplines)).BeginInit();
            this.tabPageTeachers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
            // statusStrip1
			// 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelCount.Text = "toolStripStatusLabel1";
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageStudents);
			this.tabControl.Controls.Add(this.tabPageGroups);
			this.tabControl.Controls.Add(this.tabPageDirections);
			this.tabControl.Controls.Add(this.tabPageDisciplines);
			this.tabControl.Controls.Add(this.tabPageTeachers);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(800, 428);
			this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageStudents
            // 
            this.tabPageStudents.Controls.Add(this.cbStudentsDirection);
            this.tabPageStudents.Controls.Add(this.cbStudentsGroup);
            this.tabPageStudents.Controls.Add(this.comboBoxStDirections);
            this.tabPageStudents.Controls.Add(this.comboBoxStGroups);
            this.tabPageStudents.Controls.Add(this.dgvStudents);
            this.tabPageStudents.Location = new System.Drawing.Point(4, 22);
            this.tabPageStudents.Name = "tabPageStudents";
            this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStudents.Size = new System.Drawing.Size(792, 402);
            this.tabPageStudents.TabIndex = 0;
            this.tabPageStudents.Text = "Students";
            this.tabPageStudents.UseVisualStyleBackColor = true;
            // 
            // cbStudentsDirection
            // 
            this.cbStudentsDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStudentsDirection.FormattingEnabled = true;
            this.cbStudentsDirection.Location = new System.Drawing.Point(376, 6);
            this.cbStudentsDirection.Name = "cbStudentsDirection";
            this.cbStudentsDirection.Size = new System.Drawing.Size(121, 21);
            this.cbStudentsDirection.TabIndex = 4;
            this.cbStudentsDirection.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // cbStudentsGroup
            // 
            this.cbStudentsGroup.FormattingEnabled = true;
            this.cbStudentsGroup.Location = new System.Drawing.Point(503, 6);
            this.cbStudentsGroup.Name = "cbStudentsGroup";
            this.cbStudentsGroup.Size = new System.Drawing.Size(121, 21);
            this.cbStudentsGroup.TabIndex = 3;
            this.cbStudentsGroup.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // comboBoxStDirections
            // 
            this.comboBoxStDirections.FormattingEnabled = true;
            this.comboBoxStDirections.Location = new System.Drawing.Point(3, 6);
            this.comboBoxStDirections.Name = "comboBoxStDirections";
            this.comboBoxStDirections.Size = new System.Drawing.Size(173, 21);
            this.comboBoxStDirections.TabIndex = 2;
            this.comboBoxStDirections.Text = "Отобразить по направлению";
            this.comboBoxStDirections.SelectedIndexChanged += new System.EventHandler(this.comboBoxStDirections_SelectedIndexChanged);
            // 
            // comboBoxStGroups
            // 
            this.comboBoxStGroups.FormattingEnabled = true;
            this.comboBoxStGroups.Location = new System.Drawing.Point(194, 6);
            this.comboBoxStGroups.Name = "comboBoxStGroups";
            this.comboBoxStGroups.Size = new System.Drawing.Size(142, 21);
            this.comboBoxStGroups.TabIndex = 1;
            this.comboBoxStGroups.Text = "Группа";
            this.comboBoxStGroups.SelectedIndexChanged += new System.EventHandler(this.comboBoxStGroups_SelectedIndexChanged);
            // 
            // dgvStudents
            // 
            this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(-4, 34);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(796, 372);
            this.dgvStudents.TabIndex = 0;
            // 
            // tabPageGroups
            // 
            this.tabPageGroups.Controls.Add(this.cbGroupsDirection);
            this.tabPageGroups.Controls.Add(this.comboBoxGroups);
            this.tabPageGroups.Controls.Add(this.dgvGroups);
            this.tabPageGroups.Location = new System.Drawing.Point(4, 22);
            this.tabPageGroups.Name = "tabPageGroups";
            this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroups.Size = new System.Drawing.Size(792, 402);
            this.tabPageGroups.TabIndex = 1;
            this.tabPageGroups.Text = "Groups";
            this.tabPageGroups.UseVisualStyleBackColor = true;
            // 
            // cbGroupsDirection
            // 
            this.cbGroupsDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGroupsDirection.FormattingEnabled = true;
            this.cbGroupsDirection.Location = new System.Drawing.Point(181, 3);
            this.cbGroupsDirection.Name = "cbGroupsDirection";
            this.cbGroupsDirection.Size = new System.Drawing.Size(121, 21);
            this.cbGroupsDirection.TabIndex = 2;
            this.cbGroupsDirection.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
            // 
            // comboBoxGroups
            // 
            this.comboBoxGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroups.FormattingEnabled = true;
            this.comboBoxGroups.Location = new System.Drawing.Point(3, 3);
            this.comboBoxGroups.Name = "comboBoxGroups";
            this.comboBoxGroups.Size = new System.Drawing.Size(171, 21);
            this.comboBoxGroups.TabIndex = 1;
            this.comboBoxGroups.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroups_SelectedIndexChanged);
            // 
            // dgvGroups
            // 
            this.dgvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Location = new System.Drawing.Point(-4, 30);
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.Size = new System.Drawing.Size(796, 372);
            this.dgvGroups.TabIndex = 0;
            // 
            // tabPageDirections
            // 
            this.tabPageDirections.Controls.Add(this.checkBUnEmptyDirections);
            this.tabPageDirections.Controls.Add(this.checkBEmptyDirections);
            this.tabPageDirections.Controls.Add(this.dgvDirections);
            this.tabPageDirections.Location = new System.Drawing.Point(4, 22);
            this.tabPageDirections.Name = "tabPageDirections";
            this.tabPageDirections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDirections.Size = new System.Drawing.Size(792, 402);
            this.tabPageDirections.TabIndex = 2;
            this.tabPageDirections.Text = "Directions";
            this.tabPageDirections.UseVisualStyleBackColor = true;
            // 
            // checkBUnEmptyDirections
            // 
            this.checkBUnEmptyDirections.AutoSize = true;
            this.checkBUnEmptyDirections.Location = new System.Drawing.Point(199, 7);
            this.checkBUnEmptyDirections.Name = "checkBUnEmptyDirections";
            this.checkBUnEmptyDirections.Size = new System.Drawing.Size(342, 17);
            this.checkBUnEmptyDirections.TabIndex = 2;
            this.checkBUnEmptyDirections.Text = "Показать частично или полностью заполненные направления";
            this.checkBUnEmptyDirections.UseVisualStyleBackColor = true;
            this.checkBUnEmptyDirections.CheckedChanged += new System.EventHandler(this.checkBUnEmptyDirections_CheckedChanged);
            // 
            // checkBEmptyDirections
            // 
            this.checkBEmptyDirections.AutoSize = true;
            this.checkBEmptyDirections.Location = new System.Drawing.Point(9, 7);
            this.checkBEmptyDirections.Name = "checkBEmptyDirections";
            this.checkBEmptyDirections.Size = new System.Drawing.Size(183, 17);
            this.checkBEmptyDirections.TabIndex = 1;
            this.checkBEmptyDirections.Text = "Показать пустые направления";
            this.checkBEmptyDirections.UseVisualStyleBackColor = true;
            this.checkBEmptyDirections.CheckedChanged += new System.EventHandler(this.checkBEmptyDirections_CheckedChanged);
            // 
            // dgvDirections
            // 
            this.dgvDirections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDirections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirections.Location = new System.Drawing.Point(-4, 30);
            this.dgvDirections.Name = "dgvDirections";
            this.dgvDirections.Size = new System.Drawing.Size(796, 372);
            this.dgvDirections.TabIndex = 0;
            // 
			// tabPageDisciplines
			// 
            this.tabPageDisciplines.Controls.Add(this.dgvDisciplines);
			this.tabPageDisciplines.Location = new System.Drawing.Point(4, 22);
			this.tabPageDisciplines.Name = "tabPageDisciplines";
			this.tabPageDisciplines.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDisciplines.Size = new System.Drawing.Size(792, 402);
			this.tabPageDisciplines.TabIndex = 3;
			this.tabPageDisciplines.Text = "Disciplines";
			this.tabPageDisciplines.UseVisualStyleBackColor = true;
			// 
            // dgvDisciplines
            // 
            this.dgvDisciplines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDisciplines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisciplines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisciplines.Location = new System.Drawing.Point(-4, 30);
            this.dgvDisciplines.Name = "dgvDisciplines";
            this.dgvDisciplines.Size = new System.Drawing.Size(796, 372);
            this.dgvDisciplines.TabIndex = 0;
            // 
			// tabPageTeachers
			// 
            this.tabPageTeachers.Controls.Add(this.dgvTeachers);
			this.tabPageTeachers.Location = new System.Drawing.Point(4, 22);
			this.tabPageTeachers.Name = "tabPageTeachers";
			this.tabPageTeachers.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTeachers.Size = new System.Drawing.Size(792, 402);
			this.tabPageTeachers.TabIndex = 4;
			this.tabPageTeachers.Text = "Teachers";
			this.tabPageTeachers.UseVisualStyleBackColor = true;
			// 
            // dgvTeachers
			// 
            this.dgvTeachers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTeachers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeachers.Location = new System.Drawing.Point(-4, 30);
            this.dgvTeachers.Name = "dgvTeachers";
            this.dgvTeachers.Size = new System.Drawing.Size(796, 372);
            this.dgvTeachers.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 402);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Students";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Academy_PV_319";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
			this.tabControl.ResumeLayout(false);
			this.tabPageStudents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.tabPageGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.tabPageDirections.ResumeLayout(false);
            this.tabPageDirections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).EndInit();
            this.tabPageDisciplines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisciplines)).EndInit();
            this.tabPageTeachers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeachers)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.TabPage tabPageGroups;
		private System.Windows.Forms.TabPage tabPageDirections;
		private System.Windows.Forms.TabPage tabPageDisciplines;
		private System.Windows.Forms.TabPage tabPageTeachers;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
       // private System.Windows.Forms.TabPage tabPageGroups;
       // private System.Windows.Forms.TabPage tabPageStudents;
		private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.DataGridView dgvDirections;
        private System.Windows.Forms.DataGridView dgvDisciplines;
        private System.Windows.Forms.DataGridView dgvTeachers;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.ComboBox comboBoxGroups;
        private System.Windows.Forms.ComboBox comboBoxStDirections;
        private System.Windows.Forms.ComboBox comboBoxStGroups;
        private System.Windows.Forms.ComboBox cbGroupsDirection;
        private System.Windows.Forms.CheckBox checkBEmptyDirections;
        private System.Windows.Forms.CheckBox checkBUnEmptyDirections;
        private System.Windows.Forms.ComboBox cbStudentsDirection;
        private System.Windows.Forms.ComboBox cbStudentsGroup;
    }
}

