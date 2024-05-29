
namespace project_company_Elswassrya
{
    partial class Form_Avrage_Humidity_Monthes
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comb_year_send = new System.Windows.Forms.ComboBox();
            this.comb_month_send = new System.Windows.Forms.ComboBox();
            this.comb_year_serach = new System.Windows.Forms.ComboBox();
            this.comb_month_search = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Export_Send_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LbTimer = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport_avrage_humidity_monthes1 = new project_company_Elswassrya.CrystalReport_avrage_humidity_monthes();
            this.timer_Now = new System.Windows.Forms.Timer(this.components);
            this.timer_Set = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comb_year_send);
            this.panel1.Controls.Add(this.comb_month_send);
            this.panel1.Controls.Add(this.comb_year_serach);
            this.panel1.Controls.Add(this.comb_month_search);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Export_Send_Btn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 99);
            this.panel1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(725, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "-: Send Report :-";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(803, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 24);
            this.label3.TabIndex = 41;
            this.label3.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 24);
            this.label2.TabIndex = 40;
            this.label2.Text = ":";
            // 
            // comb_year_send
            // 
            this.comb_year_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comb_year_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comb_year_send.FormattingEnabled = true;
            this.comb_year_send.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.comb_year_send.Location = new System.Drawing.Point(686, 28);
            this.comb_year_send.Name = "comb_year_send";
            this.comb_year_send.Size = new System.Drawing.Size(113, 24);
            this.comb_year_send.TabIndex = 39;
            // 
            // comb_month_send
            // 
            this.comb_month_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comb_month_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comb_month_send.FormattingEnabled = true;
            this.comb_month_send.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.comb_month_send.Location = new System.Drawing.Point(819, 28);
            this.comb_month_send.Name = "comb_month_send";
            this.comb_month_send.Size = new System.Drawing.Size(76, 24);
            this.comb_month_send.TabIndex = 38;
            // 
            // comb_year_serach
            // 
            this.comb_year_serach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comb_year_serach.FormattingEnabled = true;
            this.comb_year_serach.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.comb_year_serach.Location = new System.Drawing.Point(31, 37);
            this.comb_year_serach.Name = "comb_year_serach";
            this.comb_year_serach.Size = new System.Drawing.Size(113, 24);
            this.comb_year_serach.TabIndex = 37;
            this.comb_year_serach.ValueMemberChanged += new System.EventHandler(this.comb_year_serach_ValueMemberChanged);
            this.comb_year_serach.SelectedValueChanged += new System.EventHandler(this.comb_year_serach_SelectedValueChanged);
            // 
            // comb_month_search
            // 
            this.comb_month_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comb_month_search.FormattingEnabled = true;
            this.comb_month_search.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.comb_month_search.Location = new System.Drawing.Point(166, 37);
            this.comb_month_search.Name = "comb_month_search";
            this.comb_month_search.Size = new System.Drawing.Size(76, 24);
            this.comb_month_search.TabIndex = 36;
            this.comb_month_search.SelectedIndexChanged += new System.EventHandler(this.comb_month_search_SelectedIndexChanged);
            this.comb_month_search.ValueMemberChanged += new System.EventHandler(this.comb_month_search_ValueMemberChanged);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.pictureBox11);
            this.panel5.Controls.Add(this.pictureBox10);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel5.Location = new System.Drawing.Point(965, 1);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(122, 40);
            this.panel5.TabIndex = 35;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox11.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox11.Image = global::project_company_Elswassrya.Properties.Resources.minimize_icon_14;
            this.pictureBox11.Location = new System.Drawing.Point(-5, 0);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(41, 36);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 113;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox10.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox10.Image = global::project_company_Elswassrya.Properties.Resources._116925_matte_blue_and_white_square_icon_business_document10_sc1;
            this.pictureBox10.Location = new System.Drawing.Point(36, 0);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(41, 36);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 112;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = global::project_company_Elswassrya.Properties.Resources.Saki_NuoveXT_2_Actions_session_exit;
            this.pictureBox2.Location = new System.Drawing.Point(77, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 111;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(431, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 80);
            this.panel2.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(247, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "/ Select Month and Year";
            // 
            // Export_Send_Btn
            // 
            this.Export_Send_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Export_Send_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export_Send_Btn.Location = new System.Drawing.Point(670, 56);
            this.Export_Send_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.Export_Send_Btn.Name = "Export_Send_Btn";
            this.Export_Send_Btn.Size = new System.Drawing.Size(260, 32);
            this.Export_Send_Btn.TabIndex = 30;
            this.Export_Send_Btn.Text = "Export and Send";
            this.Export_Send_Btn.UseVisualStyleBackColor = true;
            this.Export_Send_Btn.Click += new System.EventHandler(this.Export_Send_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "-: Search For Report :-";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(658, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(8, 80);
            this.panel4.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.LbTimer);
            this.panel3.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Location = new System.Drawing.Point(446, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(206, 53);
            this.panel3.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::project_company_Elswassrya.Properties.Resources.Vcferreira_Firefox_Os_Clock;
            this.pictureBox1.Location = new System.Drawing.Point(134, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // LbTimer
            // 
            this.LbTimer.AutoSize = true;
            this.LbTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTimer.ForeColor = System.Drawing.Color.Black;
            this.LbTimer.Location = new System.Drawing.Point(12, 11);
            this.LbTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LbTimer.Name = "LbTimer";
            this.LbTimer.Size = new System.Drawing.Size(104, 26);
            this.LbTimer.TabIndex = 10;
            this.LbTimer.Text = "00:00:00";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 99);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.CrystalReport_avrage_humidity_monthes1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1089, 472);
            this.crystalReportViewer1.TabIndex = 4;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // timer_Now
            // 
            this.timer_Now.Enabled = true;
            this.timer_Now.Interval = 1000;
            this.timer_Now.Tick += new System.EventHandler(this.timer_Now_Tick);
            // 
            // timer_Set
            // 
            this.timer_Set.Interval = 1000;
            this.timer_Set.Tick += new System.EventHandler(this.timer_Set_Tick);
            // 
            // Form_Avrage_Humidity_Monthes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 571);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Avrage_Humidity_Monthes";
            this.Text = "Form_Avrage_Humidity_Monthes";
            this.Load += new System.EventHandler(this.Form_Avrage_Humidity_Monthes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Export_Send_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbTimer;
        private System.Windows.Forms.ComboBox comb_year_send;
        private System.Windows.Forms.ComboBox comb_month_send;
        private System.Windows.Forms.ComboBox comb_year_serach;
        private System.Windows.Forms.ComboBox comb_month_search;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport_avrage_humidity_monthes CrystalReport_avrage_humidity_monthes1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_Now;
        private System.Windows.Forms.Timer timer_Set;
    }
}