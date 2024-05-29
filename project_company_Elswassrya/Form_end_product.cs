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
    public partial class Form_end_product : Form
    {
        crptproduct crpt = new crptproduct();
        //System.Timers.Timer Timer;
        //DateTime CurrantTime;
        //DateTime dateTime;
        ReportDocument crypet = new ReportDocument();
        public string QueryLine = "";

        public Form_end_product()
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear(); textBox1.Focus();
            if (comboBox1.SelectedItem.Equals("Type of product") )
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



                if (comboBox1.SelectedItem.Equals("Type of product"))
                {
                    string StrSearch = "SELECT * FROM `end_product` WHERE `type_product_EP`  Like '%" + textBox1.Text + "%'";
                    QueryLine = StrSearch;
                    cmd.CommandText = StrSearch;
                    adap = new MySqlDataAdapter();
                    adap.SelectCommand = cmd;
                    DataSet custDB = new DataSet();
                    custDB.Clear();
                    adap.Fill(custDB, "End_Product");
                    CrystalReport_End_Product_New myReport = new CrystalReport_End_Product_New();
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
            string StrSearch = "SELECT * FROM `end_product`";
            string Query = "", Query2 = "", Query1 = "";
            MySqlDataAdapter adap;
            cmd = con.CreateCommand();
            if (comboBox1.SelectedItem.Equals("Date"))
            {
                Query = dateTimePicker2.Value.ToString();
                Query = Query.Substring(0, 10);
                StrSearch += " WHERE `Date_EP` Like '%" + Query + "%'";
                QueryLine = StrSearch;
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "End_Product");
                CrystalReport_End_Product_New myReport = new CrystalReport_End_Product_New();
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

                StrSearch += " WHERE `Date_EP`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                QueryLine = StrSearch;
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "End_Product");
                CrystalReport_End_Product_New myReport = new CrystalReport_End_Product_New();
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

        private void Form_end_product_Load(object sender, EventArgs e)
        {
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

        private void Timer_ELapsed(object sender, ElapsedEventArgs e)
        {
          
        }

        private void timer_Now_Tick(object sender, EventArgs e)
        {
            LbTimer.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");

        }

        private void timer_Set_Tick(object sender, EventArgs e)
        {
            //Load Report Shift 3
            if (LbTimer.Text == "08:04:30")
            {
                try
                {
                    Last_Day();
                    timer_Set.Stop();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button4_Click_1(object sender, EventArgs e)
        {
           
        }
        private void Shift_1()
        {
            try
            {
                MySqlDataAdapter adap;
                cmd = con.CreateCommand();
                ReportDocument cryRpt = new ReportDocument();
                //SELECT * FROM `laboratory` WHERE `Date` = CURRENT_DATE() AND `Time` BETWEEN '16:00:00' and '23:59:59'
                string StrSearch = "SELECT * FROM `end_product` WHERE `Date_EP` =  CURRENT_DATE() AND `Time_EP` BETWEEN '08:00:00' AND '16:00:00'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "End_Product");
                CrystalReport_End_Product_New myReport = new CrystalReport_End_Product_New();
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

                //Console.WriteLine("Laporety_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");

                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");
                Class1.Path_Report_End_Product = @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
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
                //SELECT * FROM `laboratory` WHERE `Date` = CURRENT_DATE() AND `Time` BETWEEN '16:00:00' and '23:59:59'
                string StrSearch = "SELECT * FROM `end_product` WHERE `Date_EP` =  CURRENT_DATE() - INTERVAL 1 DAY  AND `Time_EP` BETWEEN '16:00:00' AND '23:59:59'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "End_Product");
                CrystalReport_End_Product_New myReport = new CrystalReport_End_Product_New();
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

                //Console.WriteLine("Laporety_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");

                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");
                Class1.Path_Report_End_Product = @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
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
                string StrSearch = "SELECT * FROM `end_product` WHERE `Date_EP` =  CURRENT_DATE() - INTERVAL 1 DAY  AND `Time_EP` BETWEEN '00:00:00' AND '08:00:00'";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "End_Product");
                CrystalReport_End_Product_New myReport = new CrystalReport_End_Product_New();
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

                //Console.WriteLine("Laporety_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");

                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");
                Class1.Path_Report_End_Product = @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string Get_AvrageHumidity_YasterDay()
        {
            string DateYasterDay = "";
            string AvrageHumidity = "";
            // Step 1 Get Data
            var query = "SELECT CURRENT_DATE()- INTERVAL 1 DAY as 'YasterDay' , SUM(`Humidity_EP`)/COUNT(`Humidity_EP`) as 'AvrageHumidity' FROM `end_product` WHERE `Date_EP` = CURRENT_DATE()- INTERVAL 1 DAY AND `Humidity_EP` != 0 ";
            using (var command = new MySqlCommand(query, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateYasterDay = reader.GetString("YasterDay");
                        AvrageHumidity = reader.GetString("AvrageHumidity");
                    }
                }
            }
            return AvrageHumidity;
        }
        private void Last_Day()
        {
            try
            {//fill data in SubReport  (tex_avg)
                
                // Fill Data in Primary Report
                MySqlDataAdapter adap2;
                cmd = con.CreateCommand();
                ReportDocument cryRpt2 = new ReportDocument();
                string StrSearch = "SELECT * FROM `end_product` WHERE `Date_EP` =  CURRENT_DATE() - INTERVAL 1 DAY ";
                cmd.CommandText = StrSearch;
                adap2 = new MySqlDataAdapter();
                adap2.SelectCommand = cmd;
                DataSet custDB2 = new DataSet();
                custDB2.Clear();
                adap2.Fill(custDB2, "End_Product");
                CrystalReport_End_Product_New myReport = new CrystalReport_End_Product_New();
                myReport.SetDataSource(custDB2);
                TextObject SUM_Avg = (TextObject)myReport.ReportDefinition.Sections["Section4"].ReportObjects["tex_avg"];
                string avg_data = Get_AvrageHumidity_YasterDay();
                if (avg_data.Length > 6)
                    SUM_Avg.Text = Get_AvrageHumidity_YasterDay().Substring(0, 5);
                else
                    SUM_Avg.Text = Get_AvrageHumidity_YasterDay();

                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                cryRpt2 = myReport;
                //___________________________________________________
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString();
                string day = DateTime.Now.Day.ToString();
                string huar = DateTime.Now.Hour.ToString();
                string Mint = DateTime.Now.Minute.ToString();

                //Console.WriteLine("Laporety_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");
                cryRpt2.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");
                Class1.Path_Report_End_Product = @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string StrSearch = @"SELECT * FROM `end_product` WHERE `Date_EP` BETWEEN '" + SUB_lastmonth + "' AND LAST_DAY(NOW()- INTERVAL 1 MONTH)";
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;

                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "End_Product");
                CrystalReport_End_Product_New myReport = new CrystalReport_End_Product_New();
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

                //Console.WriteLine("Laporety_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");

                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\End_Product_Monthly_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");
                Class1.Path_Report_End_Product = @"C:\StorgePDF\End_Product_Monthly_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
                Form_SendMessage fs = new Form_SendMessage();
                fs.Show();
                this.Hide();
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
                    adap.Fill(custDB, "End_Product");
                    CrystalReport_End_Product_New myReport = new CrystalReport_End_Product_New();
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

                    //Console.WriteLine("Laporety_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");

                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");
                    Class1.Path_Report_End_Product = @"C:\StorgePDF\End_Product_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
                    Form_SendMessage fs = new Form_SendMessage();
                    fs.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Export_Send_Btn_Click(object sender, EventArgs e)
        {
            
            try
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
                else { MessageBox.Show("Your not Selected any Query >>>!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch(Exception)
            { }

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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form_SendMessage fs = new Form_SendMessage();
            fs.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form_Avrage_Humidity_Monthes fahm = new Form_Avrage_Humidity_Monthes();
            fahm.Show();
        }
    }
}
