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
    public partial class Form_Avrage_Humidity_Monthes : Form
    {
        crptproduct crpt = new crptproduct();
        //System.Timers.Timer Timer;
        //DateTime CurrantTime;
        //DateTime dateTime;
        ReportDocument crypet = new ReportDocument();
        public string QueryLine = "";
        public Form_Avrage_Humidity_Monthes()
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
                cmd = con.CreateCommand(); //SELECT * FROM `average_humidity` WHERE `last_month` = "2020-08" 
                string StrSearch = "SELECT * FROM `average_humidity` WHERE `last_month` = '" + comb_year_serach.Text + "-" + comb_month_search.Text + "' ";
                QueryLine = StrSearch;
                cmd.CommandText = StrSearch;
                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet custDB = new DataSet();
                custDB.Clear();
                adap.Fill(custDB, "Average_Humidity");
                CrystalReport_avrage_humidity_monthes myReport = new CrystalReport_avrage_humidity_monthes();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport;
                crystalReportViewer1.Refresh();
                MessageBox.Show(comb_year_serach.Text + "-" + comb_month_search.Text);
                    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Insert_LastDataMonth()
        {
            try
            {
                string DateLastMonth = "";
                Double Week1 = 0;
                Double Week2 = 0;
                Double Week3 = 0;
                Double Week4 = 0;
                Double Month = 0;

                // Get Date of Last Month
                var query = "SELECT CURRENT_DATE() - INTERVAL 1 MONTH as 'Date_Last_Month' FROM `end_product`";
                using (var command = new MySqlCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {


                            DateLastMonth = reader.GetString("Date_Last_Month");


                        }

                    }

                }

                DateLastMonth = DateLastMonth.Substring(0, 7);

                //Get Avrage of Week 1 of Last Month
                query = "SELECT SUM(`Humidity_EP`)/COUNT(`Humidity_EP`) As 'Week 1' FROM `end_product` WHERE `Date_EP` BETWEEN '" + DateLastMonth + "-01'" + " AND '" + DateLastMonth + "-07' AND `Humidity_EP` != 0";
                {
                    using (var command = new MySqlCommand(query, con))
                    {
                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {


                                Week1 = Convert.ToDouble(reader.GetString("Week 1"));


                            }

                        }
                    }

                }

                //Get Avrage of Week 2 of Last Month
                query = "SELECT SUM(`Humidity_EP`)/COUNT(`Humidity_EP`) As 'Week 2' FROM `end_product` WHERE `Date_EP`BETWEEN '" + DateLastMonth + "-08'" + " AND '" + DateLastMonth + "-15' AND `Humidity_EP` != 0"; ;
                using (var command = new MySqlCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {


                            Week2 = Convert.ToDouble(reader.GetString("Week 2"));


                        }

                    }

                }

                //Get Avrage of Week 3 of Last Month
                query = "SELECT SUM(`Humidity_EP`)/COUNT(`Humidity_EP`) As 'Week 3' FROM `end_product` WHERE `Date_EP` BETWEEN '" + DateLastMonth + "-16'" + " AND '" + DateLastMonth + "-22' AND `Humidity_EP` != 0";
                using (var command = new MySqlCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {


                            Week3 = Convert.ToDouble(reader.GetString("Week 3"));


                        }

                    }

                }

                //Get Avrage of Week 4 of Last Month
                query = "SELECT SUM(`Humidity_EP`)/COUNT(`Humidity_EP`) As 'Week 4' FROM `end_product` WHERE `Date_EP`BETWEEN '" + DateLastMonth + "-23'AND LAST_DAY(CURRENT_DATE() - INTERVAL 1 MONTH) AND `Humidity_EP` != 0";
                using (var command = new MySqlCommand(query, con))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {


                            Week4 = Convert.ToDouble(reader.GetString("Week 4"));


                        }

                    }

                }


                Month = Week1 + Week2 + Week3 + Week4;
                Month = Month / 4;
                // MessageBox.Show("month = " + Month + " and week 1 = " + Week1 + "  and week 2 =" + Week2 + " and week 3 =" + Week3 + " and week 4 =" + Week4);


                //insert Data indatabase
                string StrInsert = "INSERT INTO `average_humidity` VALUES ('" + null + "','" + DateLastMonth + "','" + Week1 + "','" + Week2 + "','" + Week3 + "','" + Week4 + "','" + Month + "')";
                cmd.Parameters.Clear();
                SetCommand(StrInsert);
                cmd.ExecuteNonQuery();

            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer_Set_Tick(object sender, EventArgs e)
        {
            if (LbTimer.Text == "08:10:30")
            {
                try
                {
                    Insert_LastDataMonth();
                    MySqlDataAdapter adap;
                    cmd = con.CreateCommand();
                    ReportDocument cryRpt = new ReportDocument();
                    string StrSearch = "SELECT * FROM `average_humidity` WHERE `last_month`  =  CURRENT_DATE() - INTERVAL 1 MONTH ";
                    cmd.CommandText = StrSearch;
                    adap = new MySqlDataAdapter();
                    adap.SelectCommand = cmd;
                    DataSet custDB = new DataSet();
                    custDB.Clear();
                    adap.Fill(custDB, "Average_Humidity");
                    CrystalReport_avrage_humidity_monthes myReport = new CrystalReport_avrage_humidity_monthes();
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

                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Avrage_Humidity_Monthly_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");
                    Class1.Path_Report_Aveage_Month = @"C:\StorgePDF\Avrage_Humidity_Monthly_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
                    Form_SendMessage fs = new Form_SendMessage();
                    fs.Show();
                    this.Hide();
                    timer_Set.Stop();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timer_Now_Tick(object sender, EventArgs e)
        {
            LbTimer.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");

        }

        private void Form_Avrage_Humidity_Monthes_Load(object sender, EventArgs e)
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

        private void comb_year_serach_ValueMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void comb_month_search_ValueMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void comb_year_serach_SelectedValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void comb_month_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void Export_Send_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (comb_year_send.Text == "" && comb_month_send.Text == "")
                {
                    Insert_LastDataMonth();
                    MessageBox.Show("The Data of Last Month Inserted ...!", "Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Most insert data in database befor export and send query from database ...!
                    MySqlDataAdapter adap;
                    cmd = con.CreateCommand();
                    ReportDocument cryRpt = new ReportDocument();

                    var today = DateTime.Today;
                    var lastmonth = new DateTime(today.Year, today.Month - 1, 1);
                    string SUB_lastmonth = lastmonth.ToString().Substring(0, 10);

                    string StrSearch = @"SELECT * FROM `average_humidity` WHERE `last_month` = '" + comb_year_send.Text + "-" + comb_month_send.Text + "' ";
                    cmd.CommandText = StrSearch;
                    adap = new MySqlDataAdapter();
                    adap.SelectCommand = cmd;

                    DataSet custDB = new DataSet();
                    custDB.Clear();
                    adap.Fill(custDB, "Average_Humidity");
                    CrystalReport_avrage_humidity_monthes myReport = new CrystalReport_avrage_humidity_monthes();
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

                    cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\StorgePDF\Avrage_Humidity_Monthly_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf");
                    Class1.Path_Report_Aveage_Month = @"C:\StorgePDF\Avrage_Humidity_Monthly_" + year + "_" + month + "_" + day + "_" + huar + "_" + Mint + ".Pdf";
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

        private void button1_Click(object sender, EventArgs e)
        {
            Insert_LastDataMonth();
        }
    }
}
