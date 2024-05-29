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
    public partial class Form_Improvement : Form
    {
        public string loication = "", QuieryLine = "";
        crptproduct crpt = new crptproduct();
        //System.Timers.Timer Timer;
        //DateTime CurrantTime;
        //DateTime dateTime;

        ReportDocument crypet = new ReportDocument();
       
        public Form_Improvement()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;server=localhost;database=project_company;uid=root;password=;sslmode=none;charset=utf8;");
        MySqlCommand cmd = new MySqlCommand();
        private object ExportOption;

        private void SetCommand(string SQL)
        {
            cmd.Connection = con;
            cmd.CommandText = SQL;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void Search()
        {
           
            MySqlDataAdapter adap;
            cmd = con.CreateCommand();
            if (comboBox1.SelectedItem.Equals("Type Name"))
            {
                string StrSearch = "SELECT * FROM `improvement`";

                StrSearch += " WHERE  `IM_Type` Like '" + tex_Serch.Text + "%'";
                QuieryLine = StrSearch;
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Improvement");
                CrystalReport_improvement myReport = new CrystalReport_improvement();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                tex_Serch.Focus();

            }
            else if (comboBox1.SelectedItem.Equals("From Date To Date"))
            {
               
                string  Query2 = "", Query1 = "";
                Query2 = dateTimePicker_M_IM.Value.ToString();
                Query2 = Query2.Substring(0, 10);

                Query1 = dateTimePicker_IM.Value.ToString();
                Query1 = Query1.Substring(0, 10);

                string StrSearch = "SELECT * FROM `improvement` WHERE `IM_Date`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                QuieryLine = StrSearch;
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Improvement");
                CrystalReport_improvement myReport = new CrystalReport_improvement();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();

            }
            else if (comboBox1.SelectedItem.Equals("Date"))
            {
                string Query = "", Query2 = "", Query1 = "";

                Query2 = dateTimePicker_M_IM.Value.ToString();
                Query2 = Query2.Substring(0, 10);

                Query1 = dateTimePicker_IM.Value.ToString();
                Query1 = Query1.Substring(0, 10);


                string StrSearch = "SELECT * FROM `improvement` WHERE `IM_Date`  = '" + Query2+"'";
                QuieryLine = StrSearch;
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Improvement");
                CrystalReport_improvement myReport = new CrystalReport_improvement();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();

            }
        }
        private void Form_Improvement_Load(object sender, EventArgs e)
        {
            this.Refresh();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (comboBox1.SelectedItem.Equals("Type Name"))
            {
                tex_Serch.Visible = true;
                lab_Type.Visible = true;
                dateTimePicker_IM.Visible = false;
                dateTimePicker_M_IM.Visible = false;
                lab_From.Visible = false;
                lab_TO.Visible = false;

            }
            else if (comboBox1.SelectedItem.Equals("Date"))
            {
                tex_Serch.Visible = false;
                lab_Type.Visible = true;
                dateTimePicker_IM.Visible = false;
                dateTimePicker_M_IM.Visible = true;
                lab_From.Visible = false;
                lab_TO.Visible = false;
            }
            else if (comboBox1.SelectedItem.Equals("From Date To Date"))
            {
                tex_Serch.Visible = false;
                lab_Type.Visible = true;
                dateTimePicker_IM.Visible = true;
                dateTimePicker_M_IM.Visible = true;
                lab_From.Visible = true;
                lab_TO.Visible = true;
            }
        }

        private void tex_Serch_TextChanged(object sender, EventArgs e)
        {
            Search(); tex_Serch.Focus();
        }

        private void dateTimePicker_IM_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimePicker_M_IM_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataAdapter adap;
                cmd = con.CreateCommand();
                ReportDocument cryRpt = new ReportDocument();
                if (QuieryLine == "")
                    QuieryLine = "SELECT * FROM `improvement` ";//for give the QuieryLine Value if it not have

                cmd.CommandText = QuieryLine; // this case if it orllredy have a value
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Improvement");
                CrystalReport_improvement myReport = new CrystalReport_improvement();
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

                //this is location 
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Improvement_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");

                // this is loaction we are will be send endbending on 
                loication = @"C:\StorgePDF\Improvement_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
                Class1.Path_Report_Improvement = loication;

                //open the form Send Message for send this report
                Form_SendMessage FSM = new Form_SendMessage();
                FSM.Show();
               
            }
            catch(Exception ex)
            {

            }

        }
    }
}
