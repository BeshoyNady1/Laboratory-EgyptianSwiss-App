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
    public partial class Form_EndProduct_AvgHumid : Form
    {
        crptproduct crpt = new crptproduct();
        ReportDocument crypet = new ReportDocument();
        CrystalReport__AvgHumid myReport = new CrystalReport__AvgHumid();
        public string QueryLine = "";
        public Form_EndProduct_AvgHumid()
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
                string CountUnits = "", AvgHumid = "";

                QueryLine = "SELECT COUNT(`Num_EP`) AS 'count_Units' , SUM(`Humidity_EP`)/COUNT(`Num_EP`) AS 'Average_Humidity' FROM `end_product` WHERE `Humidity_EP` != 0 AND `Date_EP` BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "'  ";

                using (var command = new MySqlCommand(QueryLine, con))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            CountUnits = reader.GetString("count_Units");
                            AvgHumid = reader.GetString("Average_Humidity");
                        }
                    }
                }
                TextObject Title_repo = (TextObject)myReport.ReportDefinition.Sections["Section1"].ReportObjects["Text_Title"];
                TextObject par_date = (TextObject)myReport.ReportDefinition.Sections["Section1"].ReportObjects["Text_date"];
                TextObject par_CountUnits = (TextObject)myReport.ReportDefinition.Sections["Section3"].ReportObjects["Text_CountUnits"];
                TextObject par_AvgHumid = (TextObject)myReport.ReportDefinition.Sections["Section3"].ReportObjects["Text_AvgHumid"];
                Title_repo.Text = "(المنتج النهائي)";
                par_date.Text = dateTimePicker1.Text.Substring(0, 7);
                par_CountUnits.Text = CountUnits;
                par_AvgHumid.Text = AvgHumid.Substring(0, 6);

                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_EndProduct_AvgHumid_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            con.Open();
            timer_Set.Start();
            Class1.Path_Report_Laboratory = "";
            Class1.Path_Report_End_Product = "";
            Class1.Path_Report_Incoming_Wheat = "";
            Class1.Path_Report_Samples_Product = "";
            Class1.Path_Report_Improvement = "";
            Class1.path_Report_Final_Product_Pasta = "";
            Class1.Path_Report_Aveage_Month = "";

        }
        private void WhatYouSearch()
        {
            try
            {
                if (QueryLine == "")
                { MessageBox.Show("Your Query is null", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    string year = DateTime.Now.Year.ToString();
                    string month = DateTime.Now.Month.ToString();
                    string day = DateTime.Now.Day.ToString();
                    string huar = DateTime.Now.Hour.ToString();
                    string Mint = DateTime.Now.Minute.ToString();
                    //___________________________________________________
                    crypet = myReport;
                    crypet.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\EndProduct_AvgHumid_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");

                    Class1.Path_Report_Incoming_Wheat = @"C:\StorgePDF\EndProduct_AvgHumid_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void timer_Now_Tick(object sender, EventArgs e)
        {

            LbTimer.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");

        }

        private void Export_Send_Btn_Click(object sender, EventArgs e)
        {
            WhatYouSearch();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
