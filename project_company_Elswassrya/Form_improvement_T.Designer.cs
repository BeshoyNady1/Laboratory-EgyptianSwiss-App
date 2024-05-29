namespace project_company_Elswassrya
{
    partial class Form_improvement_T
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport_Track_Improvement1 = new project_company_Elswassrya.CrystalReport_Track_Improvement();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tex_Serch = new System.Windows.Forms.TextBox();
            this.lab_Type = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lab_From = new System.Windows.Forms.Label();
            this.lab_TO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_M_IM = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_IM = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(2, 75);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport_Track_Improvement1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1264, 920);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tex_Serch);
            this.panel1.Controls.Add(this.lab_Type);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lab_From);
            this.panel1.Controls.Add(this.lab_TO);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker_M_IM);
            this.panel1.Controls.Add(this.dateTimePicker_IM);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 70);
            this.panel1.TabIndex = 5;
            // 
            // tex_Serch
            // 
            this.tex_Serch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tex_Serch.Location = new System.Drawing.Point(407, 6);
            this.tex_Serch.Name = "tex_Serch";
            this.tex_Serch.Size = new System.Drawing.Size(200, 28);
            this.tex_Serch.TabIndex = 9;
            this.tex_Serch.Visible = false;
            this.tex_Serch.TextChanged += new System.EventHandler(this.tex_Serch_TextChanged);
            // 
            // lab_Type
            // 
            this.lab_Type.AutoSize = true;
            this.lab_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_Type.Location = new System.Drawing.Point(630, 5);
            this.lab_Type.Name = "lab_Type";
            this.lab_Type.Size = new System.Drawing.Size(115, 25);
            this.lab_Type.TabIndex = 8;
            this.lab_Type.Text = "/ Type Here";
            this.lab_Type.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(756, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 65);
            this.panel2.TabIndex = 7;
            // 
            // lab_From
            // 
            this.lab_From.AutoSize = true;
            this.lab_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_From.Location = new System.Drawing.Point(234, 41);
            this.lab_From.Name = "lab_From";
            this.lab_From.Size = new System.Drawing.Size(44, 18);
            this.lab_From.TabIndex = 6;
            this.lab_From.Text = "From";
            this.lab_From.Visible = false;
            // 
            // lab_TO
            // 
            this.lab_TO.AutoSize = true;
            this.lab_TO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_TO.Location = new System.Drawing.Point(486, 43);
            this.lab_TO.Name = "lab_TO";
            this.lab_TO.Size = new System.Drawing.Size(21, 18);
            this.lab_TO.TabIndex = 5;
            this.lab_TO.Text = "to";
            this.lab_TO.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1036, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "/ Select Type of Search";
            // 
            // dateTimePicker_M_IM
            // 
            this.dateTimePicker_M_IM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker_M_IM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_M_IM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_M_IM.Location = new System.Drawing.Point(407, 6);
            this.dateTimePicker_M_IM.Name = "dateTimePicker_M_IM";
            this.dateTimePicker_M_IM.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker_M_IM.TabIndex = 3;
            this.dateTimePicker_M_IM.Visible = false;
            this.dateTimePicker_M_IM.ValueChanged += new System.EventHandler(this.dateTimePicker_M_IM_ValueChanged);
            // 
            // dateTimePicker_IM
            // 
            this.dateTimePicker_IM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker_IM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_IM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_IM.Location = new System.Drawing.Point(158, 6);
            this.dateTimePicker_IM.Name = "dateTimePicker_IM";
            this.dateTimePicker_IM.Size = new System.Drawing.Size(200, 28);
            this.dateTimePicker_IM.TabIndex = 2;
            this.dateTimePicker_IM.Visible = false;
            this.dateTimePicker_IM.ValueChanged += new System.EventHandler(this.dateTimePicker_IM_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Type Name",
            "User Name",
            "Date",
            "From Date To Date"});
            this.comboBox1.Location = new System.Drawing.Point(786, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 33);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form_improvement_T
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 1007);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "Form_improvement_T";
            this.Text = "Form_improvement_T";
            this.Load += new System.EventHandler(this.Form_improvement_T_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport_Track_Improvement CrystalReport_Track_Improvement1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tex_Serch;
        private System.Windows.Forms.Label lab_Type;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lab_From;
        private System.Windows.Forms.Label lab_TO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_M_IM;
        private System.Windows.Forms.DateTimePicker dateTimePicker_IM;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}