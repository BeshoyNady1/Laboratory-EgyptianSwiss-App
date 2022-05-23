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
    public partial class Form_improvement_T : Form
    {
        //crptproduct crpt = new crptproduct();
        //System.Timers.Timer Timer;
        //DateTime CurrantTime;
        //DateTime dateTime;
        
        ReportDocument crypet = new ReportDocument();
        public Form_improvement_T()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;server=localhost;database=project_company;uid=root;password=;sslmode=none;charset=utf8;");
        MySqlCommand cmd = new MySqlCommand();
        //private object ExportOption;

        private void SetCommand(string SQL)
        {
            cmd.Connection = con;
            cmd.CommandText = SQL;
        }
        private void Search()
        {

            MySqlDataAdapter adap;
            cmd = con.CreateCommand();
            if (comboBox1.SelectedItem.Equals("Type Name"))
            {
                string StrSearch = "SELECT * FROM `track_improvement`";
                string Query = "", Query2 = "", Query1 = "";
                StrSearch += " WHERE  `TIM_Type` Like '" + tex_Serch.Text + "%'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Track_Improvement");
                CrystalReport_Track_Improvement myReport = new CrystalReport_Track_Improvement();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                tex_Serch.Focus();

            }else if (comboBox1.SelectedItem.Equals("User Name"))
            {
                string StrSearch = "SELECT * FROM `track_improvement`";
                string Query = "", Query2 = "", Query1 = "";
                StrSearch += " WHERE  `TIM_Name` Like '" + tex_Serch.Text + "%'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Track_Improvement");
                CrystalReport_Track_Improvement myReport = new CrystalReport_Track_Improvement();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                tex_Serch.Focus();

            }
            else if (comboBox1.SelectedItem.Equals("From Date To Date"))
            {

                string Query = "", Query2 = "", Query1 = "";
                Query2 = dateTimePicker_M_IM.Value.ToString();
                Query2 = Query2.Substring(0, 10);

                Query1 = dateTimePicker_IM.Value.ToString();
                Query1 = Query1.Substring(0, 10);

                string StrSearch = "SELECT * FROM `track_improvement` WHERE `TIM_Date`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Track_Improvement");
                //CrystalReport_improvement myReport = new CrystalReport_improvement();
                CrystalReport_Track_Improvement myReport = new CrystalReport_Track_Improvement();
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


                string StrSearch = "SELECT * FROM `track_improvement` WHERE `TIM_Date`  = '" + Query2 + "'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Track_Improvement");
                CrystalReport_Track_Improvement myReport = new CrystalReport_Track_Improvement();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();

            }
        }
        private void Form_improvement_T_Load(object sender, EventArgs e)
        {
            this.Refresh();
        }
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Type Name") || comboBox1.SelectedItem.Equals("User Name"))
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
            Search();
        }

        private void dateTimePicker_IM_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimePicker_M_IM_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
