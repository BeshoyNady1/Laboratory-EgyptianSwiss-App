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

namespace project_company_Elswassrya
{
    public partial class Form_track_samples_production : Form
    {
        public Form_track_samples_production()
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
        private void Form_track_samples_production_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox1.Focus();
            if (comboBox1.SelectedItem.Equals("User Name"))
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
        private void Search()
        {
            try
            {
                MySqlDataAdapter adap;
                cmd = con.CreateCommand();



                if (comboBox1.SelectedItem.Equals("User Name"))
                {
                    string StrSearch = "SELECT * FROM `track_samples_production` WHERE `User_Name_TSP` Like '" + textBox1.Text + "%'";
                    cmd.CommandText = StrSearch;
                    adap = new MySqlDataAdapter();
                    adap.SelectCommand = cmd;
                    DataSet custDB = new DataSet();
                    custDB.Clear();
                    adap.Fill(custDB, "Track_Samples_Production");
                    CrystalReport_track_samples_production myReport = new CrystalReport_track_samples_production();
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
            string StrSearch = "SELECT * FROM `track_samples_production`";
            string Query = "", Query2 = "", Query1 = "";
            MySqlDataAdapter adap;
            cmd = con.CreateCommand();
            if (comboBox1.SelectedItem.Equals("Date"))
            {
                Query = dateTimePicker2.Value.ToString();
                Query = Query.Substring(0, 10);
                StrSearch += " WHERE `Date_TSP` Like '%" + Query + "%'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Track_Samples_Production");
                CrystalReport_track_samples_production myReport = new CrystalReport_track_samples_production();
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

                StrSearch += " WHERE `Date_TSP`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Track_Samples_Production");
                CrystalReport_track_samples_production myReport = new CrystalReport_track_samples_production();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                textBox1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Search2();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Search2();
        }
    }
}
