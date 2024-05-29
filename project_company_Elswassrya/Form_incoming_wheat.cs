using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
using System.Resources;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Timers;


namespace project_company_Elswassrya
{
    public partial class Form_incoming_wheat : Form
    {
        crptproduct crpt = new crptproduct();
        //System.Timers.Timer Timer;
        //DateTime CurrantTime;
        //DateTime dateTime;
        ReportDocument crypet = new ReportDocument();
        public string QueryLine = "";
        public Form_incoming_wheat()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;server=localhost;database=project_company;uid=root;password=;sslmode=none;charset=utf8;");
        MySqlCommand cmd = new MySqlCommand();

        private void SetCommand(string SQL)
        {
            cmd.Connection = con;
            cmd.CommandText = SQL;
        }
        private void Search()
        {
            try
            {
                MySqlDataAdapter adap;
                cmd = con.CreateCommand();
                

                
                if (comboBox1.SelectedItem.Equals("Type of Wheat") || comboBox1.SelectedItem.Equals("Truck Number"))
                {
                    string StrSearch = "";
                    if (comboBox1.SelectedItem.Equals("Type of Wheat")) StrSearch = "SELECT * FROM `incoming_wheat` WHERE  `Type_Wheat`  Like '%"+textBox1.Text+"%'";
                    else if (comboBox1.SelectedItem.Equals("Truck Number")) StrSearch = "SELECT * FROM `incoming_wheat` WHERE  `truck_number`  Like '%"+textBox1.Text+"%'";
                    QueryLine = StrSearch;
                    cmd.CommandText = StrSearch;
                    adap = new MySqlDataAdapter();
                    adap.SelectCommand = cmd;
                    DataSet custDB = new DataSet();
                    custDB.Clear();
                    adap.Fill(custDB,"Incoming_Wheat");
                    CrystalReport_incoming_wheat myReport = new CrystalReport_incoming_wheat();
                    myReport.SetDataSource(custDB);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.Refresh();
                    textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Search2()
        {
            string StrSearch = "SELECT * FROM `incoming_wheat` ";
            string Query = "", Query2 = "", Query1 = "";
            MySqlDataAdapter adap;
            cmd = con.CreateCommand();
            if (comboBox1.SelectedItem.Equals("Date"))
            {
                Query = dateTimePicker2.Value.ToString();
                Query = Query.Substring(0, 10);
                StrSearch += " WHERE `Date_IW` Like '%" + Query + "%'";
                QueryLine = StrSearch;
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Incoming_Wheat");
                CrystalReport_incoming_wheat myReport = new CrystalReport_incoming_wheat();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                textBox1.Focus();

            }
            else if (comboBox1.SelectedItem.Equals("From Date To Date"))
            {
                Query2 = dateTimePicker2.Value.ToString();
                Query2 = Query2.Substring(0, 10);

                Query1 = dateTimePicker1.Value.ToString();
                Query1 = Query1.Substring(0, 10);

                StrSearch += " WHERE `Date_IW`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                QueryLine = StrSearch;
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Incoming_Wheat");
                CrystalReport_incoming_wheat myReport = new CrystalReport_incoming_wheat();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                textBox1.Focus();
            }
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox1.Focus();
            if (comboBox1.SelectedItem.Equals("Type of Wheat") || comboBox1.SelectedItem.Equals("Truck Number"))
            {
                textBox1.Visible = true;
                label4.Visible = true;
                label2.Visible = false;
                label3.Visible = false;


            }
            else if (comboBox1.SelectedItem.Equals("Date"))
            {
                textBox1.Visible = false;
                label4.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
            else
            {
                dateTimePicker2.Visible = true;
                dateTimePicker1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = false;
                label4.Visible = true;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Search2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Search2();
        }

        private void Form_incoming_wheat_Load(object sender, EventArgs e)
        {
            timer_Set.Start();
            Class1.Path_Report_Laboratory = "";
            Class1.Path_Report_End_Product = "";
            Class1.Path_Report_Incoming_Wheat = "";
            Class1.Path_Report_Samples_Product = "";
            Class1.Path_Report_Improvement = "";
            Class1.path_Report_Final_Product_Pasta = "";
            Class1.Path_Report_Aveage_Month = "";
        }

        private void Timer_ELapsed(object sender, ElapsedEventArgs e)
        {
           
        }

        private void timer_Now_Tick(object sender, EventArgs e)
        {
            LbTimer.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");

        }

        private void timer_Set_Tick(object sender, EventArgs e)
        {
            //load Report Shift 3
            if (LbTimer.Text == "08:02:30")
            {
                try
                {
                    Last_Day();
                    timer_Set.Stop();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        private void Shift_1()
        {
            try
            {
                MySqlDataAdapter adap;
                cmd = con.CreateCommand();
                ReportDocument cryRpt = new ReportDocument();
                string StrSearch = "SELECT * FROM `incoming_wheat` WHERE `Date_IW`=  CURRENT_DATE()  AND `Time_IW` BETWEEN '08:00:00' AND '16:00:00'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Incoming_Wheat");
                CrystalReport_incoming_wheat myReport = new CrystalReport_incoming_wheat();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                cryRpt = myReport;
                //___________________________________________________
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string huar = DateTime.Now.Hour.ToString();
                string Mint = DateTime.Now.Minute.ToString();

                //Export AS Excel
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                ExcelFormatOptions CrFormatTypeOptions = new ExcelFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls";
                Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls$";
                CrExportOptions = cryRpt.ExportOptions;
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
                cryRpt.Export();

                //Export AS PDF
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf");
                Class1.Path_Report_Incoming_Wheat += @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf";

                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Shift_2()
        {
            try
            {
                MySqlDataAdapter adap;
                cmd = con.CreateCommand();
                ReportDocument cryRpt = new ReportDocument();
                string StrSearch = "SELECT * FROM `incoming_wheat` WHERE `Date_IW`=  CURRENT_DATE()  - INTERVAL 1 DAY  AND `Time_IW` BETWEEN '16:00:00' AND '23:59:59'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Incoming_Wheat");
                CrystalReport_incoming_wheat myReport = new CrystalReport_incoming_wheat();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                cryRpt = myReport;
                //___________________________________________________
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string huar = DateTime.Now.Hour.ToString();
                string Mint = DateTime.Now.Minute.ToString();

                //Export AS Excel
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                ExcelFormatOptions CrFormatTypeOptions = new ExcelFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls";
                Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls$";
                CrExportOptions = cryRpt.ExportOptions;
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
                cryRpt.Export();

                //Export AS PDF
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf");
                Class1.Path_Report_Incoming_Wheat += @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf";

                //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx");
                //Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx";
                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Shift_3()
        {
            try
            {
                MySqlDataAdapter adap;
                cmd = con.CreateCommand();
                ReportDocument cryRpt = new ReportDocument();
                //SELECT * FROM `laboratory` WHERE `Date` = CURRENT_DATE() AND `Time` BETWEEN '16:00:00' and '23:59:59'
                string StrSearch = "SELECT * FROM `incoming_wheat` WHERE `Date_IW`=  CURRENT_DATE() - INTERVAL 1 DAY  AND `Time_IW` BETWEEN '00:00:00' AND '08:00:00'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Incoming_Wheat");
                CrystalReport_incoming_wheat myReport = new CrystalReport_incoming_wheat();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                cryRpt = myReport;
                //___________________________________________________
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string huar = DateTime.Now.Hour.ToString();
                string Mint = DateTime.Now.Minute.ToString();

                //Export AS Excel
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                ExcelFormatOptions CrFormatTypeOptions = new ExcelFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls";
                Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls$";
                CrExportOptions = cryRpt.ExportOptions;
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
                cryRpt.Export();

                //Export AS PDF
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf");
                Class1.Path_Report_Incoming_Wheat += @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf";

                //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx");
                //Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx";
                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Last_Day()
        {
            try
            {
                MySqlDataAdapter adap;
                cmd = con.CreateCommand();
                ReportDocument cryRpt = new ReportDocument();
                string StrSearch = "SELECT * FROM `incoming_wheat` WHERE `Date_IW`=  CURRENT_DATE() - INTERVAL 1 DAY ";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;

                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Incoming_Wheat");
                CrystalReport_incoming_wheat myReport = new CrystalReport_incoming_wheat();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                cryRpt = myReport;
                //___________________________________________________
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string huar = DateTime.Now.Hour.ToString();
                string Mint = DateTime.Now.Minute.ToString();

                //Export AS Excel
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                ExcelFormatOptions CrFormatTypeOptions = new ExcelFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls";
                Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls$";
                CrExportOptions = cryRpt.ExportOptions;
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
                cryRpt.Export();

                //Export AS PDF
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf");
                Class1.Path_Report_Incoming_Wheat += @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf";

                //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx");
                //Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx";
                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Last_Month()
        {
            try
            {
                MySqlDataAdapter adap;
                cmd = con.CreateCommand();
                ReportDocument cryRpt = new ReportDocument();

                var today = DateTime.Today;
                var lastmonth = new DateTime(today.Year, today.Month - 1, 1);
                string SUB_lastmonth = lastmonth.ToString().Substring(0, 10);

                string StrSearch = @"SELECT * FROM `incoming_wheat` WHERE `Date_IW` BETWEEN '" + SUB_lastmonth + "' AND LAST_DAY(NOW()- INTERVAL 1 MONTH)";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;

                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Incoming_Wheat");
                CrystalReport_incoming_wheat myReport = new CrystalReport_incoming_wheat();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                cryRpt = myReport;
                //___________________________________________________
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string huar = DateTime.Now.Hour.ToString();
                string Mint = DateTime.Now.Minute.ToString();

                //Export AS Excel
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                ExcelFormatOptions CrFormatTypeOptions = new ExcelFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls";
                Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls$";
                CrExportOptions = cryRpt.ExportOptions;
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
                cryRpt.Export();

                //Export AS PDF
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf");
                Class1.Path_Report_Incoming_Wheat += @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf";

                //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx");
                //Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx";
                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WhatYouSearch()
        {
            try
            {
                if (QueryLine == "")
                { MessageBox.Show("Your Query is null", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    MySqlDataAdapter adap;
                    cmd = con.CreateCommand();
                    ReportDocument cryRpt = new ReportDocument();


                    cmd.CommandText = QueryLine;
                    adap = new MySqlDataAdapter();
                    adap.SelectCommand = cmd;

                    DataSet custDB = new DataSet();
                    custDB.Clear();
                    adap.Fill(custDB, "Incoming_Wheat");
                    CrystalReport_incoming_wheat myReport = new CrystalReport_incoming_wheat();
                    myReport.SetDataSource(custDB);
                    crystalReportViewer1.ReportSource = myReport;
                    crystalReportViewer1.Refresh();
                    cryRpt = myReport;
                    //___________________________________________________
                    string year = DateTime.Now.Year.ToString();
                    string month = DateTime.Now.Month.ToString();
                    string day = DateTime.Now.Day.ToString();
                    string huar = DateTime.Now.Hour.ToString();
                    string Mint = DateTime.Now.Minute.ToString();

                    //Export AS Excel
                    ExportOptions CrExportOptions;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    ExcelFormatOptions CrFormatTypeOptions = new ExcelFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls";
                    Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xls$";
                    CrExportOptions = cryRpt.ExportOptions;
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.ExcelRecord;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    cryRpt.Export();

                    //Export AS PDF
                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf");
                    Class1.Path_Report_Incoming_Wheat += @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".pdf";

                    //cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx");
                    //Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\Incoming_Wheat_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".xlsx";
                    Form_SendMessage fs = new Form_SendMessage();
                    fs.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Export_Send_Btn_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.Equals("Shift 1"))
            {
                Shift_1();
            }
            else if (comboBox2.SelectedItem.Equals("Shift 2"))
            {
                Shift_2();
            }
            else if (comboBox2.SelectedItem.Equals("Shift 3"))
            {
                Shift_3();
            }
            else if (comboBox2.SelectedItem.Equals("Last Day"))
            {
                Last_Day();
            }
            else if (comboBox2.SelectedItem.Equals("Last Month"))
            {
                Last_Month();
            }
            else if (comboBox2.SelectedItem.Equals("What you Search...!"))
            {
                WhatYouSearch();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
