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
using System.Timers;

namespace project_company_Elswassrya
{
    public partial class form_project : Form
    {
        System.Timers.Timer Timer;
        DateTime CurrantTime;
        DateTime dateTime;
        public form_project()
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

        private void Clear_Fp()
        {
            tex_Num_Fp.Clear();
            tex_Type_Pro_Fp.Clear();
            tex_Hum_Fp.Clear();
            tex_Ash_Fp.Clear();
            tex_Wet_Fp.Clear();
            tex_Dry_Fp.Clear();
            tex_Fall_Fp.Clear();
            tex_Perc_Fp.Clear();
            tex_Nodes_Fp.Clear();
            tex_Search_Fp.Clear();

            dataGridView_Fp.Refresh();
            FillGrid_Fp();
            this.Refresh();
        }

        private void Clear()
        {
            teb_in_1.Clear();
            teb_in_2.Clear();
            teb_in_3.Clear();
            teb_in_4.Clear();
            teb_out_1.Clear();
            teb_out_2.Clear();
            teb_out_3.Clear();
            teb_out_4.Clear();
            teb_out_5.Clear();
            tex_add_1.Clear();
            tex_add_2.Clear();
            tex_add_3.Clear();
            tex_add_4.Clear();
            tex_add_5.Clear();
            //tex_add_6.Clear();
            tex_add_7.Clear();
            tex_add_8.Clear();
            tex_add_9.Clear();
            tex_Number.Clear();
            tex_Truck_Number_IW.Clear();
            dateTimePicker_mian.Refresh();
            dataGridView1.Refresh();
            FillGrid();
        }
        private void Clear_Wh()
        {
            
            tex_Search_Wh.Clear();
            tex_Truck_Number_IW.Clear();
            tex_Number_IW.Clear();
            tex_QT_IW.Clear();
            tex_Weight_type_IW.Clear();
            tex_QT_IW.Clear();
            tex_QK_IW.Clear();
            tex_Hum_IW.Clear();
            tex_Weight10000.Clear();
            tex_Wet_gluten_IW.Clear();
            tex_Dry_gluten_IW.Clear();
            tex_Index_Number_IW.Clear();
            tex_Falling_number_IW.Clear();
            tex_Cleanliness_IW.Clear();
            tex_TypeW_IW.Clear();
            texNotes_IW.Clear();
            comb_Search_Wh.ResetText();
            comb_Search_Wh.Refresh();
            tex_Search_Wh.Clear();
            tex_sup_name.Clear();

            dataGridView_Wh.Refresh();
            FillGrid_Wh();
            this.Refresh();
        }
        private void Clear_PA()
        {

            tex_Num_EP.Clear();
            tex_Typ_pro_EP.Clear();
            tex_Humidity_EP.Clear();
            tex_Ash_EP.Clear();
            tex_Wet_gluten_EP.Clear();
            tex_Dry_gluten_EP.ResetText();
            tex_Falling_number_EP.Clear();
            tex_Percentage_waste_EP.Clear();
            tex_Nodes_EP.Clear();
            dataGridView_PA.Refresh();
            FillGrid_PA();
            this.Refresh();
        }
       
        
        private void Clear_SP()
        {
            // com_Sample_SP.Text + "','" + tex_mois_SP.Text + "','" + tex_Wet_Glu_SP.Text + "','" + tex_DryGlu_SP.Text + "','" + tex_Index_SP.Text + "','" + tex_Fall_Num_SP.Text + "','" + tex_Ash_SP.Text + "','" + tex_Res_SP.Text + "','" + tex_Star_SP.Text + "','" + tex_Notes_SP.Text + "','" + datePicker_SP.Value + "','" + TimePicker_SP.Value +
            com_Sample_SP.ResetText();
            tex_mois_SP.Clear();
            tex_Wet_Glu_SP.Clear();
            tex_DryGlu_SP.Clear();
            tex_Index_SP.Clear();
            tex_Fall_Num_SP.Clear();
            tex_Ash_SP.Clear();
            tex_Res_SP.Clear();
            tex_Star_SP.Clear();
            tex_Notes_SP.Clear();
            com_Search_SP.ResetText();
            datePicker_SP.ResetText();
            TimePicker_SP.ResetText();
            FillGrid_SP();
            this.Refresh();
        }


        private void Clear_IM()
        {
            tex_Num_IM.ResetText();
            comb_TypeName_IM.Refresh();
            tex_Balance_IM.Clear();
            tex_Expenses_IM.Clear();
            tex_Residual_IM.Clear();
            tex_Incoming_IM.Clear();
            dateTimePicker_Date_IM.Refresh();
            tex_Input_permission_IM.Clear();
            tex_Bill_IM.Clear();
            tex_Notes_IM.Clear();
            comboBox_Serche_IM.ResetText();
            comboBox_Serche_IM.Refresh();
            tex_Search_IM.Clear();
            FillGrid_IM();
            this.Refresh();
        }

        private void FillGrid()
        {
            SetCommand("SELECT * FROM laboratory ORDER BY `Number` DESC LIMIT 30");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = tbl;


        }

        private void FillGrid_IM()
        {
            SetCommand("SELECT * FROM improvement ORDER BY `Number_ID` DESC LIMIT 30");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView_IM.DataSource = tbl;


        }

        private void FillGrid_SP()
        {
            SetCommand("SELECT * FROM `samples_production` ORDER BY `Num_SP` DESC LIMIT 30");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView_SP.DataSource = tbl;


        }
        private void FillGrid_Wh()
        {
            SetCommand("SELECT * FROM incoming_wheat ORDER BY `Number_IW` DESC LIMIT 30");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView_Wh.DataSource = tbl;
            

        }
       
        private void FillGrid_PA()
        {
            SetCommand("SELECT * FROM end_product ORDER BY `Num_EP` DESC LIMIT 30");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView_PA.DataSource = tbl;


        }

        private void FillGrid_Fp()
        {
            SetCommand("SELECT * FROM `final_product_pasta` ORDER BY `Num` DESC LIMIT 30");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView_Fp.DataSource = tbl;


        }


        private void Search()   //__________________________________________________________________________________________________________________________________________________________________________
        {
            try
            {
                string Query = dateTimePicker_mian.Value.ToString();
                Query = Query.Substring(0, 10);
                string StrSearch = "SELECT * FROM `laboratory` WHERE `Date`   Like '%" + Query + "%'";
                SetCommand(StrSearch);
                DataTable TblSearch = new DataTable();
                TblSearch.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = TblSearch;
                // MessageBox.Show(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void Search_Wh()
        {
            try
            {
                string StrSearch = "SELECT * FROM `incoming_wheat` ";
                string Query = "", Query2 = "", Query1 = "";
                if (comb_Search_Wh.SelectedItem.Equals("Type of Wheat") ||  comb_Search_Wh.SelectedItem.Equals("Truck Number"))
                {
                    StrSearch += " WHERE ";

                    if (comb_Search_Wh.SelectedItem.Equals("Type of Wheat")) StrSearch += "Type_Wheat";
                    else if (comb_Search_Wh.SelectedItem.Equals("Truck Number")) StrSearch += "truck_number";

                    StrSearch += " Like '%" + tex_Search_Wh.Text + "%'";
                }else if (comb_Search_Wh.SelectedItem.Equals("Date"))
                {
                     Query = date_2_Wh.Value.ToString();
                    Query = Query.Substring(0, 10);
                     StrSearch += " WHERE `Date_IW` Like '%" + Query + "%'";
                    
                } else if (comb_Search_Wh.SelectedItem.Equals("From Date To Date"))
                {
                     Query2 = date_2_Wh.Value.ToString();
                    Query2 = Query2.Substring(0, 10);

                     Query1 = date_1_Wh.Value.ToString();
                    Query1 = Query1.Substring(0, 10);

                     StrSearch += " WHERE `Date_IW`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                }


                SetCommand(StrSearch);
                DataTable TblSearch = new DataTable();
                TblSearch.Load(cmd.ExecuteReader());
                dataGridView_Wh.DataSource = TblSearch;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void load_data()
        {

        }
        private void Search_SP()
        {
            try
            {

                if (com_Search_SP.SelectedItem.Equals("Date"))
                {
                    string Query = dateTimePicker1_SP.Value.ToString();
                    Query = Query.Substring(0, 10);
                    string StrSearch = "SELECT * FROM `samples_production` WHERE `Date_SP` = '" + Query + "'";
                    SetCommand(StrSearch);
                    DataTable TblSearch = new DataTable();
                    TblSearch.Load(cmd.ExecuteReader());
                    dataGridView_SP.DataSource = TblSearch;


                }
                else if (com_Search_SP.SelectedItem.Equals("From Date To Date"))
                {
                    string Query2 = dateTimePicker1_SP.Value.ToString();
                    Query2 = Query2.Substring(0, 10);

                    string Query1 = dateTimePicker2_SP.Value.ToString();
                    Query1 = Query1.Substring(0, 10);

                    string StrSearch_WH2 = "SELECT * FROM `samples_production` WHERE `Date_SP`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                    SetCommand(StrSearch_WH2);
                    DataTable TblSearch2 = new DataTable();
                    TblSearch2.Load(cmd.ExecuteReader());
                    dataGridView_SP.DataSource = TblSearch2;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Search_IM()
        {
            try
            {

                if (comboBox_Serche_IM.SelectedItem.Equals("Date"))
                {
                    string Query = dateTimePicker_M_IM.Value.ToString();
                    Query = Query.Substring(0, 10);
                    string StrSearch = "SELECT * FROM `improvement` WHERE `IM_Date` = '" + Query + "'";
                    SetCommand(StrSearch);
                    DataTable TblSearch = new DataTable();
                    TblSearch.Load(cmd.ExecuteReader());
                    dataGridView_IM.DataSource = TblSearch;


                }
                else if (comboBox_Serche_IM.SelectedItem.Equals("From Date To Date"))
                {
                    string Query2 = dateTimePicker_IM.Value.ToString();
                    Query2 = Query2.Substring(0, 10);

                    string Query1 = dateTimePicker_M_IM.Value.ToString();
                    Query1 = Query1.Substring(0, 10);

                    string StrSearch_WH2 = "SELECT * FROM `improvement` WHERE `IM_Date`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                    SetCommand(StrSearch_WH2);
                    DataTable TblSearch2 = new DataTable();
                    TblSearch2.Load(cmd.ExecuteReader());
                    dataGridView_IM.DataSource = TblSearch2;

                }else if(comboBox_Serche_IM.SelectedItem.Equals("Type Name"))
                {
                    string StrSearch_WH2 = "SELECT * FROM `improvement` WHERE `IM_Type` Like '"+tex_Search_IM.Text+"%'";
                    SetCommand(StrSearch_WH2);
                    DataTable TblSearch2 = new DataTable();
                    TblSearch2.Load(cmd.ExecuteReader());
                    dataGridView_IM.DataSource = TblSearch2;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Fill_Compu()
        {
            var query = "SELECT DISTINCT `IM_Type` FROM `improvement` LIMIT 30 ";
            using (var command = new MySqlCommand(query, con))
            {
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {//using loop  to fill data
                        comb_TypeName_IM.Items.Add(reader.GetString("IM_Type"));

                    }
                }
            }
        }

        private void Form_project_Load(object sender, EventArgs e)
        {

            try
            {

                con.Open();
                timer_Set.Start();
                //Fill_Compu();
                this.WindowState = FormWindowState.Maximized;
                if (Class1.TypeUser == "Administrator")
                    {
                        //pic_Person1.BackgroundImage.Save(@"E:\work_station\project_company\3.0\Office-Customer-Male-Light-icon.png");
                        pic_Person1.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";
                        pic_person2.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";
                        pic_person3.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";
                        pic_Person6.ImageLocation = @"C:\StorgePDFOffice-Customer-Male-Light-icon.png";
                        pic_Person_7.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";
                        pic_Person_8.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";



                       pic_add_IM.Visible = true; label86.Visible = true;
                        pic_updata_IM.Visible = true; label84.Visible = true;
                        pic_Delete_IM.Visible = true; label83.Visible = true;
                        pic_Clear_IM.Visible = true; label82.Visible = true;
                        pic_report_IM.Visible = true; label72.Visible = true;
                        comboBox_Serche_IM.Visible = true; label79.Visible = true;
                        pic_Process_IM.Visible = true; lab_Process_IM.Visible = true;


                        lab_person1.Text = Class1.NamePass;
                        textBox_type.Text = "Administrator";
                        textBox_Name.Text = lab_person1.Text;
                        lab_person1.Text = string.Concat("Admin/ ", lab_person1.Text);
                        labe_person2.Text = lab_person1.Text;
                        labe_person3.Text = lab_person1.Text;
                        label140.Text= lab_person1.Text;
                        label76.Text= lab_person1.Text;
                        label99.Text = lab_person1.Text; 


                }
                else if(Class1.TypeUser == "top_administrators")
                    {
                        pic_Person1.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";
                        pic_person2.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";
                        pic_person3.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";
                        pic_Person6.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";
                        pic_Person_7.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";
                        pic_Person_8.ImageLocation = @"C:\StorgePDF\Office-Customer-Male-Light-icon.png";


                    //tracking on 
                         pictureBox3.Visible = true;
                        label112.Visible = true;
                        pictureBox4.Visible = true;
                        label114.Visible = true;
                        pictureBox5.Visible = true;
                        label115.Visible = true;
                        pic_track_6.Visible = true;
                        label139.Visible = true;
                        pic_track_7.Visible = true;
                        label75.Visible = true;
                        pic_track_8.Visible = true;
                        label98.Visible = true;

                        //improvment on 
                        pic_add_IM.Visible = true; label86.Visible = true;
                        pic_updata_IM.Visible = true; label84.Visible = true;
                        pic_Delete_IM.Visible = true; label83.Visible = true;
                        pic_Clear_IM.Visible = true; label82.Visible = true;
                        pic_report_IM.Visible = true; label72.Visible = true;
                        comboBox_Serche_IM.Visible = true; label79.Visible = true;
                        pic_Process_IM.Visible = true; lab_Process_IM.Visible = true;

                        lab_person1.Text = Class1.NamePass;
                        textBox_type.Text = "top_Administrators";
                        textBox_Name.Text = lab_person1.Text;
                        lab_person1.Text = string.Concat("Top_Admin/ ", lab_person1.Text);
                        labe_person2.Text = lab_person1.Text;
                        labe_person3.Text = lab_person1.Text;
                        label140.Text = lab_person1.Text;
                        label76.Text = lab_person1.Text;
                        label99.Text = lab_person1.Text;

                }
                else if (Class1.TypeUser == "User")
                {
                    //pic_Person1.BackgroundImage.Save(@"E:\work_station\project_company\3.0\Person-Male-Light-icon.png");
                    pic_Person1.ImageLocation = @"C:\StorgePDF\Person-Male-Light-icon.png";
                    pic_person2.ImageLocation = @"C:\StorgePDF\Person-Male-Light-icon.png";
                    pic_person3.ImageLocation = @"C:\StorgePDF\Person-Male-Light-icon.png";
                    pic_Person6.ImageLocation = @"C:\StorgePDF\Person-Male-Light-icon.png";
                    pic_Person_7.ImageLocation = @"C:\StorgePDF\Person-Male-Light-icon.png";
                    pic_Person_8.ImageLocation = @"C:\StorgePDF\Person-Male-Light-icon.png";

                    lab_person1.Text = Class1.NamePass;
                    textBox_type.Text = "User";
                    textBox_Name.Text = lab_person1.Text;
                    lab_person1.Text = string.Concat("User/ ", lab_person1.Text);
                    labe_person2.Text = lab_person1.Text;
                    labe_person3.Text = lab_person1.Text;
                    label140.Text = lab_person1.Text;
                    label76.Text = lab_person1.Text;
                    label99.Text = lab_person1.Text;
                }


                //}
                //TblSearch.Close();

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.DataPropertyName = col.Name;

                }


                FillGrid();
                Clear();
                //_____________________________________________________________________________________________________________________________________________

                foreach (DataGridViewColumn coll in dataGridView_Wh.Columns)
                {
                    coll.DataPropertyName = coll.Name;

                }


                FillGrid_Wh();
                Clear_Wh();

                //______________________________________________________________________________________________________________________________________________

                foreach (DataGridViewColumn colll in dataGridView_PA.Columns)
                {
                    colll.DataPropertyName = colll.Name;

                }

                FillGrid_PA();
                Clear_PA();

                //__________________________________________________________________________________________________________________________________

                foreach (DataGridViewColumn collll in dataGridView_SP.Columns)
                {
                    collll.DataPropertyName = collll.Name;

                }

                FillGrid_SP();
                Clear_SP();


                //__________________________________________________________________________________________________________________________________

                foreach (DataGridViewColumn collll in dataGridView_IM.Columns)
                {
                    collll.DataPropertyName = collll.Name;

                }

                FillGrid_IM();
                Clear_IM();

                //__________________________________________________________________________________________________________________________________

                foreach (DataGridViewColumn collll in dataGridView_Fp.Columns)
                {
                    collll.DataPropertyName = collll.Name;

                }

                FillGrid_Fp();
                Clear_Fp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Timer_ELapsed(object sender, ElapsedEventArgs e)
        {
            CurrantTime = DateTime.Now;
            dateTime = Convert.ToDateTime("08:00:00");
            if (CurrantTime.Hour == dateTime.Hour && CurrantTime.Minute == dateTime.Minute && CurrantTime.Second == dateTime.Second)
            {
                Timer.Stop();
                try
                {
                    //MessageBox.Show(DateTime.Now.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form_LA F1 = new Form_LA();
                    F1.Show();
                    Form_incoming_wheat f2 = new Form_incoming_wheat();
                    f2.Show();
                    Form_end_product f3 = new Form_end_product();
                    f3.Show();
                    Form_samples_production f4 = new Form_samples_production();
                    f4.Show();
                    Form_Improvement f5 = new Form_Improvement();
                    f5.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            CurrantTime = DateTime.Now;
            dateTime = Convert.ToDateTime("16:00:00");
            Timer.Start();
            if (CurrantTime.Hour == dateTime.Hour && CurrantTime.Minute == dateTime.Minute && CurrantTime.Second == dateTime.Second)
            {
                Timer.Stop();
                try
                {
                    //MessageBox.Show(DateTime.Now.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form_LA F1 = new Form_LA();
                    F1.Show();
                    Form_incoming_wheat f2 = new Form_incoming_wheat();
                    f2.Show();
                    Form_end_product f3 = new Form_end_product();
                    f3.Show();
                    Form_samples_production f4 = new Form_samples_production();
                    f4.Show();
                    Form_Improvement f5 = new Form_Improvement();
                    f5.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            CurrantTime = DateTime.Now;
            dateTime = Convert.ToDateTime("00:00:00");
            Timer.Start();
            if (CurrantTime.Hour == dateTime.Hour && CurrantTime.Minute == dateTime.Minute && CurrantTime.Second == dateTime.Second)
            {
                Timer.Stop();
                try
                {
                    Form_LA F1 = new Form_LA(); //T
                    F1.Show();
                    Form_incoming_wheat f2 = new Form_incoming_wheat();//T
                    f2.Show();
                    Form_end_product f3 = new Form_end_product();//T
                    f3.Show();
                    Form_samples_production f4 = new Form_samples_production();//T
                    f4.Show();
                    Form_Improvement f5 = new Form_Improvement();//T
                    f5.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Pic_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_add_3.Text != "" && tex_add_4.Text != "" && tex_add_5.Text != "")
                {
                    if (MessageBox.Show("Are you sure you want to delete this item?...", "Error Message...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string StrInsert2 = "INSERT INTO `track_laboratory` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "DELETE" + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_Number.Text + "','" + teb_out_1.Text + "','" + teb_out_2.Text + "','" + teb_out_3.Text + "','" + teb_out_4.Text + "','" + teb_out_5.Text + "','" + tex_add_1.Text + "','" + tex_add_2.Text + "','" + tex_add_3.Text + "','" + tex_add_4.Text + "','" + tex_add_5.Text + "','" + tex_add_7.Text + "','" + tex_add_8.Text + "','" + tex_add_9.Text + "')";
                        cmd.Parameters.Clear();
                        SetCommand(StrInsert2);
                        cmd.ExecuteNonQuery();
                        SetCommand("DELETE FROM `laboratory` WHERE Number = " + tex_Number.Text);
                        cmd.ExecuteNonQuery();
                        FillGrid();
                        Clear();

                        MessageBox.Show("Deleted successfully...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You have no data to Delete ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Pic_Process_Click(object sender, EventArgs e)
        {
            double result = Convert.ToDouble(teb_in_4.Text) - 100;
            teb_out_1.Text = Convert.ToString(result / 100);
            if (Convert.ToDouble(teb_out_1.Text) < 0) teb_out_1.Text = Convert.ToString(Convert.ToDouble(teb_out_1.Text) * -1);
            double result2 = Convert.ToDouble(teb_in_3.Text) * Convert.ToDouble(teb_out_1.Text);
            teb_out_2.Text = Convert.ToString(result2);
            if (Convert.ToDouble(teb_out_2.Text) < 0) teb_out_2.Text = Convert.ToString(Convert.ToDouble(teb_out_2.Text) * -1);
            teb_out_3.Text = Convert.ToString(Convert.ToDouble(teb_in_2.Text) - Convert.ToDouble(teb_in_1.Text));
            if (Convert.ToDouble(teb_out_3.Text) < 0)
            {
                teb_out_3.Text = Convert.ToString(Convert.ToDouble(teb_out_3.Text) * -1);
                teb_out_3.Text = teb_out_3.Text.Substring(0, 7);
            }
            else
            {
                //teb_out_3.Text = teb_out_3.Text.Substring(0, 7);
            }



            teb_out_4.Text = Convert.ToString(Convert.ToDouble(teb_out_3.Text) / Convert.ToDouble(teb_in_3.Text));
            teb_out_4.Text = Convert.ToString(Convert.ToDouble(teb_out_4.Text) * 100);
            if (Convert.ToDouble(teb_out_4.Text) < 0)
            {
                teb_out_4.Text = Convert.ToString(Convert.ToDouble(teb_out_4.Text) * -1);
                teb_out_4.Text = teb_out_4.Text.Substring(0, 7);
            }
            else
            {
                teb_out_4.Text = teb_out_4.Text.Substring(0, 7);
            }



            double result3 = Convert.ToDouble(teb_in_3.Text) * Convert.ToDouble(teb_out_1.Text);
            teb_out_5.Text = Convert.ToString(Convert.ToDouble(teb_out_3.Text) / result3);
            teb_out_5.Text = Convert.ToString(Convert.ToDouble(teb_out_5.Text) * 100);
            if (Convert.ToDouble(teb_out_5.Text) < 0)
            {
                teb_out_5.Text = Convert.ToString(Convert.ToDouble(teb_out_5.Text) * -1);
                teb_out_5.Text = teb_out_5.Text.Substring(0, 7);
            }
            else
            {
                teb_out_5.Text = teb_out_5.Text.Substring(0, 7);
                double t = Convert.ToDouble(teb_out_5.Text);

                t = Math.Round(Convert.ToDouble(teb_out_5.Text), 3, MidpointRounding.ToEven);
                teb_out_5.Text = t.ToString();

            }
        }

        private void Pic_New_Click(object sender, EventArgs e)
        {
            Clear();

        }
        private void Insert_Laboratory()
        {
            try
            {
                //MessageBox.Show(DateTime.Now.ToString("yyyy/mm/dd"));
                if (tex_add_3.Text != "" && tex_add_4.Text != "" && tex_add_5.Text != "")
                {
                    string time = TimePicker.Value.ToString();
                    time = time.Substring(10, 8);
                    string StrInsert = "INSERT INTO `laboratory` VALUES ('" + null + "','" + teb_out_1.Text + "','" + teb_out_2.Text + "','" + teb_out_3.Text + "','" + teb_out_4.Text + "','" + teb_out_5.Text + "','" + tex_add_1.Text + "','" + tex_add_2.Text + "','" + tex_add_3.Text + "','" + tex_add_4.Text + "','" + tex_add_5.Text + "','" + tex_add_7.Text + "','" + tex_add_8.Text + "','" + tex_add_9.Text + "','" + datePicker.Value + "','" + time + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert);
                    cmd.ExecuteNonQuery();
                    string StrInsert2 = "INSERT INTO `track_laboratory` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "INSERT" + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_Number.Text + "','" + teb_out_1.Text + "','" + teb_out_2.Text + "','" + teb_out_3.Text + "','" + teb_out_4.Text + "','" + teb_out_5.Text + "','" + tex_add_1.Text + "','" + tex_add_2.Text + "','" + tex_add_3.Text + "','" + tex_add_4.Text + "','" + tex_add_5.Text + "','" + tex_add_7.Text + "','" + tex_add_8.Text + "','" + tex_add_9.Text + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert2);
                    cmd.ExecuteNonQuery();
                    FillGrid();
                    Clear();

                    MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to Add ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Pic_Add_Click(object sender, EventArgs e)
        {
            Insert_Laboratory();


        }

        private void Pic_Updata_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_Number.Text != "" )
                {
                    string time = TimePicker.Value.ToString();
                    time = time.Substring(10, 8);
                    string StrUpDate = "UPDATE `laboratory` SET `The_moisture_of_the_dried_sample`= '" + teb_out_1.Text + "',`Dried_flour_sample`= '" + teb_out_2.Text + "',`Ash` = '" + teb_out_3.Text + "',`Wet_ash` = '" + teb_out_4.Text + "',`Dry_ash` = '" + teb_out_5.Text + "',`Moisture` = '" + tex_add_1.Text + "',`Gluten` = '" + tex_add_2.Text + "',`Index_Number` = '" + tex_add_3.Text + "',`Falling_Number` ='" + tex_add_4.Text + "',`Over_250_Micron` = '" + tex_add_5.Text + "',`Color_Degree` ='" + tex_add_7.Text + "',`Starch_Damage` = '" + tex_add_8.Text + "',`Water_test` = '" + tex_add_9.Text + "' ,  `Date` = '"+datePicker.Value+ "' , `Time` = '"+ time + "' WHERE `Number` = '" + tex_Number.Text + "'";
                    SetCommand(StrUpDate);
                    cmd.ExecuteNonQuery();
                    string StrInsert2 = "INSERT INTO `track_laboratory` VALUES ('" + null + "','" + textBox_Name.Text + "','"+ "UPDATE" + "','"+ DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_Number.Text + "','" + teb_out_1.Text + "','" + teb_out_2.Text + "','" + teb_out_3.Text + "','" + teb_out_4.Text + "','" + teb_out_5.Text + "','" + tex_add_1.Text + "','" + tex_add_2.Text + "','" + tex_add_3.Text + "','" + tex_add_4.Text + "','" + tex_add_5.Text + "','" + tex_add_7.Text + "','" + tex_add_8.Text + "','" + tex_add_9.Text + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert2);
                    cmd.ExecuteNonQuery();
                    FillGrid();
                    Clear();

                    MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to edit ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count > 0)
                {
                    tex_Number.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    teb_out_1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    teb_out_2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    teb_out_3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    teb_out_4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    teb_out_5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    tex_add_1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    tex_add_2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    tex_add_3.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    tex_add_4.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    tex_add_5.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    tex_add_7.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    tex_add_8.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                    tex_add_9.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                    datePicker.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                    TimePicker.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_Search_Click(object sender, EventArgs e)
        {

            Search();
            this.Refresh();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(77, 148, 255);
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Tex_Search_Wh_TextChanged(object sender, EventArgs e)
        {
            Search_Wh();
        }

        private void Panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Comb_Search_Wh_SelectedIndexChanged(object sender, EventArgs e)
        {
            tex_Search_Wh.Clear(); tex_Search_Wh.Focus();
            if (comb_Search_Wh.SelectedItem.Equals("Type of Wheat") ||  comb_Search_Wh.SelectedItem.Equals("Truck Number"))
            {
                label_From_Wh.Visible = false;
                label_To_Wh.Visible = false;
                date_1_Wh.Visible = false;
                date_2_Wh.Visible = false;
                tex_Search_Wh.Visible = true;
                label_type_Wh.Visible = true;
            }
            else if (comb_Search_Wh.SelectedItem.Equals("Date"))
            {
                tex_Search_Wh.Visible = false;
                date_1_Wh.Visible = false;
                date_2_Wh.Visible = true;
                label_From_Wh.Visible = false;
                label_To_Wh.Visible = false;
            }
            else
            {
                tex_Search_Wh.Visible = false;
                date_1_Wh.Visible = true;
                date_2_Wh.Visible = true;
                label_From_Wh.Visible = true;
                label_To_Wh.Visible = true;
            }
        }

        private void Pic_Delete_Wh_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_Number_IW.Text != ""  )
                {
                    if (MessageBox.Show("Are you sure you want to delete this item?...", "Error Message...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string StrInsert_W2 = "INSERT INTO `track_incoming_wheat` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "DELETE" + "','" + tex_Truck_Number_IW.Text + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_QT_IW.Text + "','" + tex_QK_IW.Text + "','" + tex_Weight_type_IW.Text + "','" + tex_Hum_IW.Text + "','" + tex_Weight10000.Text + "','" + tex_Wet_gluten_IW.Text + "','" + tex_Dry_gluten_IW.Text + "','" + tex_Index_Number_IW.Text + "','" + tex_Falling_number_IW.Text + "','" + tex_Cleanliness_IW.Text + "','" + tex_TypeW_IW.Text + "','" + texNotes_IW.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
                        cmd.Parameters.Clear();
                        SetCommand(StrInsert_W2);
                        cmd.ExecuteNonQuery();
                        SetCommand("DELETE FROM `incoming_wheat` WHERE `Number_IW`= "+ tex_Number_IW.Text);
                        cmd.Parameters.Clear();
                        cmd.ExecuteNonQuery();
                       
                        FillGrid_Wh();
                        Clear_Wh();

                        MessageBox.Show("Deleted successfully...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You have no data to delete...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Insert_IncomeWheat ()
        {
            try
            {
                if (tex_TypeW_IW.Text != "")
                {
                    string time = TimePicker_IW.Value.ToString();
                    time = time.Substring(10, 8);
                    if (string.IsNullOrEmpty(tex_QT_IW.Text)) tex_QT_IW.Text = "00";
                    if (string.IsNullOrEmpty(tex_QK_IW.Text)) tex_QK_IW.Text = "00";
                    string StrInsert_W = "INSERT INTO `incoming_wheat` VALUES ('" + null + "','" + tex_Truck_Number_IW.Text + "','" + time + "','" + tex_QT_IW.Text + "','" + tex_QK_IW.Text + "','" + tex_Weight_type_IW.Text + "','" + tex_Hum_IW.Text + "','" + tex_Weight10000.Text + "','" + tex_Wet_gluten_IW.Text + "','" + tex_Dry_gluten_IW.Text + "','" + tex_Index_Number_IW.Text + "','" + tex_Falling_number_IW.Text + "','" + tex_Cleanliness_IW.Text + "','" + tex_TypeW_IW.Text + "','" + texNotes_IW.Text + "','" + datePicker_IW.Value + "','" + tex_sup_name.Text + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert_W);
                    cmd.ExecuteNonQuery();
                    string StrInsert_W2 = "INSERT INTO `track_incoming_wheat` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "INSERT" + "','" + tex_Truck_Number_IW.Text + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_QT_IW.Text + "','" + tex_QK_IW.Text + "','" + tex_Weight_type_IW.Text + "','" + tex_Hum_IW.Text + "','" + tex_Weight10000.Text + "','" + tex_Wet_gluten_IW.Text + "','" + tex_Dry_gluten_IW.Text + "','" + tex_Index_Number_IW.Text + "','" + tex_Falling_number_IW.Text + "','" + tex_Cleanliness_IW.Text + "','" + tex_TypeW_IW.Text + "','" + texNotes_IW.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
                    SetCommand(StrInsert_W2);
                    cmd.ExecuteNonQuery();
                    FillGrid_Wh();
                    Clear_Wh();

                    MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //MessageBox.Show("You have no data to add ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void Pic_Add_Wh_Click(object sender, EventArgs e)
        {
            Insert_IncomeWheat();
        }

        private void Pic_Updata_Wh_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_Number_IW.Text != "")
                {
                    string time = TimePicker_IW.Value.ToString();
                    time = time.Substring(10, 8);
                    string StrUpDate_W = "UPDATE `incoming_wheat` SET `truck_number`='" + tex_Truck_Number_IW.Text + "',`Time_IW`='" + time + "',`Quantity_Tons`='" + tex_QT_IW.Text + "',`Quantity_KG`='" + tex_QK_IW.Text + "',`Weight_type`='" + tex_Weight_type_IW.Text + "',`Humidity`='" + tex_Hum_IW.Text + "',`Weight_10000`='" + tex_Weight10000.Text + "',`Wet_gluten`='" + tex_Wet_gluten_IW.Text + "',`Dry_gluten`='" + tex_Dry_gluten_IW.Text + "',`Index_Number_IW`='" + tex_Index_Number_IW.Text + "',`Falling_number_IW`='" + tex_Falling_number_IW.Text + "',`Cleanliness`='" + tex_Cleanliness_IW.Text + "',`Type_Wheat`='" + tex_TypeW_IW.Text + "',`Notes`='" + texNotes_IW.Text + "', `Date_IW` = '"+datePicker_IW.Value+ "',`supplayer`='"+tex_sup_name.Text+"' WHERE  `Number_IW` = '" + tex_Number_IW .Text+ "' ";
                    SetCommand(StrUpDate_W);
                    cmd.ExecuteNonQuery();
                    string StrInsert_W2 = "INSERT INTO `track_incoming_wheat` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "UPDATE" + "','" + tex_Truck_Number_IW.Text + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_QT_IW.Text + "','" + tex_QK_IW.Text + "','" + tex_Weight_type_IW.Text + "','" + tex_Hum_IW.Text + "','" + tex_Weight10000.Text + "','" + tex_Wet_gluten_IW.Text + "','" + tex_Dry_gluten_IW.Text + "','" + tex_Index_Number_IW.Text + "','" + tex_Falling_number_IW.Text + "','" + tex_Cleanliness_IW.Text + "','" + tex_TypeW_IW.Text + "','" + texNotes_IW.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
                    SetCommand(StrInsert_W2);
                    cmd.ExecuteNonQuery();
                    FillGrid_Wh();
                    Clear_Wh();

                    MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }else
                {
                    MessageBox.Show("You have no data to Updata your data ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_New_Wh_Click(object sender, EventArgs e)
        {
            //Clear_Wh();
            //New_Item_Wh();
            //tex_Time_IW.Text = "12:12:10";



        }
        private void Search_WH2()
        {
            try
            {

                if (comb_Search_Wh.SelectedItem.Equals("Date"))
                {
                    string Query = date_2_Wh.Value.ToString();
                    Query = Query.Substring(0, 10);
                    string StrSearch = "SELECT * FROM `wheat` WHERE `Date_W` = '" + Query + "'";
                    SetCommand(StrSearch);
                    DataTable TblSearch = new DataTable();
                    TblSearch.Load(cmd.ExecuteReader());
                    dataGridView_Wh.DataSource = TblSearch;


                }
                else if (comb_Search_Wh.SelectedItem.Equals("From Date To Date"))
                {
                    string Query2 = date_2_Wh.Value.ToString();
                    Query2 = Query2.Substring(0, 10);

                    string Query1 = date_1_Wh.Value.ToString();
                    Query1 = Query1.Substring(0, 10);

                    string StrSearch_WH2 = "SELECT* FROM `wheat` WHERE `Date_W`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                    SetCommand(StrSearch_WH2);
                    DataTable TblSearch2 = new DataTable();
                    TblSearch2.Load(cmd.ExecuteReader());
                    dataGridView_Wh.DataSource = TblSearch2;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Search_PA2()
        {
            try
            {

                if (com_Seach_PA.SelectedItem.Equals("Date"))
                {
                    string Query = dateTimePicker2_PA.Value.ToString();
                    Query = Query.Substring(0, 10);
                    string StrSearch = "SELECT * FROM `end_product` WHERE `Date_EP` = '" + Query + "'";
                    SetCommand(StrSearch);
                    DataTable TblSearch = new DataTable();
                    TblSearch.Load(cmd.ExecuteReader());
                    dataGridView_PA.DataSource = TblSearch;


                }
                else if (com_Seach_PA.SelectedItem.Equals("From Date To Date"))
                {
                    string Query2 = dateTimePicker2_PA.Value.ToString();
                    Query2 = Query2.Substring(0, 10);

                    string Query1 = dateTimePicker1_PA.Value.ToString();
                    Query1 = Query1.Substring(0, 10);

                    string StrSearch_WH2 = "SELECT * FROM `end_product` WHERE `Date_EP`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                    SetCommand(StrSearch_WH2);
                    DataTable TblSearch2 = new DataTable();
                    TblSearch2.Load(cmd.ExecuteReader());
                    dataGridView_PA.DataSource = TblSearch2;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search_Fp2()
        {
            try
            {

                if (comboBox_Serche_Fp.SelectedItem.Equals("Date"))
                {
                    string Query = dateTimePicker_FP2.Value.ToString();
                    Query = Query.Substring(0, 10);
                    string StrSearch = "SELECT * FROM `final_product_pasta` WHERE `Date_Fp` = '" + Query + "'";
                    SetCommand(StrSearch);
                    DataTable TblSearch = new DataTable();
                    TblSearch.Load(cmd.ExecuteReader());
                    dataGridView_Fp.DataSource = TblSearch;


                }
                else if (comboBox_Serche_Fp.SelectedItem.Equals("From Date To Date"))
                {
                    string Query2 = dateTimePicker_FP2.Value.ToString();
                    Query2 = Query2.Substring(0, 10);

                    string Query1 = dateTimePicker_Fp.Value.ToString();
                    Query1 = Query1.Substring(0, 10);

                    string StrSearch_WH2 = "SELECT * FROM `final_product_pasta` WHERE `Date_Fp`  BETWEEN '" + Query1 + "' AND '" + Query2 + "'";
                    SetCommand(StrSearch_WH2);
                    DataTable TblSearch2 = new DataTable();
                    TblSearch2.Load(cmd.ExecuteReader());
                    dataGridView_Fp.DataSource = TblSearch2;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Pic_Search_Wh_Click(object sender, EventArgs e)
        {

            try
            {
                Search_WH2();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_Wh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView_Wh.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 77, 77);
                dataGridView_Wh.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_Wh_SelectionChanged(object sender, EventArgs e)
        {
            try
            {            

                if (dataGridView_Wh.CurrentRow != null && dataGridView_Wh.SelectedRows.Count > 0)
                {
                    tex_Number_IW.Text = dataGridView_Wh.CurrentRow.Cells[0].Value.ToString();
                    tex_Truck_Number_IW.Text = dataGridView_Wh.CurrentRow.Cells[1].Value.ToString();
                    TimePicker_IW.Text= dataGridView_Wh.CurrentRow.Cells[2].Value.ToString();
                    tex_QT_IW.Text = dataGridView_Wh.CurrentRow.Cells[3].Value.ToString();
                    tex_QK_IW.Text = dataGridView_Wh.CurrentRow.Cells[4].Value.ToString();
                    tex_Weight_type_IW.Text = dataGridView_Wh.CurrentRow.Cells[5].Value.ToString();
                    tex_Hum_IW.Text = dataGridView_Wh.CurrentRow.Cells[6].Value.ToString();
                    tex_Weight10000.Text = dataGridView_Wh.CurrentRow.Cells[7].Value.ToString();
                    tex_Wet_gluten_IW.Text = dataGridView_Wh.CurrentRow.Cells[8].Value.ToString();
                    tex_Dry_gluten_IW.Text = dataGridView_Wh.CurrentRow.Cells[9].Value.ToString();
                    tex_Index_Number_IW.Text = dataGridView_Wh.CurrentRow.Cells[10].Value.ToString();
                    tex_Falling_number_IW.Text = dataGridView_Wh.CurrentRow.Cells[11].Value.ToString();
                    tex_Cleanliness_IW.Text = dataGridView_Wh.CurrentRow.Cells[12].Value.ToString();
                    tex_TypeW_IW.Text = dataGridView_Wh.CurrentRow.Cells[13].Value.ToString();
                    texNotes_IW.Text = dataGridView_Wh.CurrentRow.Cells[14].Value.ToString();
                    datePicker_IW.Text = dataGridView_Wh.CurrentRow.Cells[15].Value.ToString();
                    tex_sup_name.Text = dataGridView_Wh.CurrentRow.Cells[16].Value.ToString();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_Clear_Wh_Click(object sender, EventArgs e)
        {
            Clear_Wh();
            this.Refresh();
        }

        private void Pic_Exit_Wh_Click(object sender, EventArgs e)
        { 
            Application.Exit();
        }

        private void Panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pic_New_PA_Click(object sender, EventArgs e)
        {
           
        }
        private void Insert_EndProduct ()
        {
            try
            {
                if (tex_Typ_pro_EP.Text != "")
                {
                    string time = TimePicker_EP.Value.ToString();
                    time = time.Substring(10, 9);
                    string StrInsert_PA = "INSERT INTO `end_product` VALUES ('" + null + "','" + time + "','" + tex_Humidity_EP.Text + "','" + tex_Ash_EP.Text + "','" + tex_Wet_gluten_EP.Text + "','" + tex_Dry_gluten_EP.Text + "','" + tex_Falling_number_EP.Text + "','" + tex_Percentage_waste_EP.Text + "','" + tex_Typ_pro_EP.Text + "','" + tex_Nodes_EP.Text + "','" + datePicker_EP.Value + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert_PA);
                    cmd.ExecuteNonQuery();
                    FillGrid_PA();
                    Clear_PA();

                    MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to add ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_Add_PA_Click(object sender, EventArgs e)
        {
            Insert_EndProduct();


        }

        private void Pic_Updata_PA_Click(object sender, EventArgs e)
        {
            try
            { 
                if (tex_Num_EP.Text != "" )
                {
                    string time = TimePicker_EP.Value.ToString();
                    time = time.Substring(10, 9);

                    string StrUpDate = "UPDATE `end_product` SET `Time_EP`='" + time + "',`Humidity_EP`='" + tex_Humidity_EP.Text + "',`Ash_EP`='" + tex_Ash_EP.Text + "',`Wet_gluten_EP`='" + tex_Wet_gluten_EP.Text + "',`Dry_gluten_EP`='" + tex_Dry_gluten_EP.Text + "',`Falling_number_EP`='" + tex_Falling_number_EP.Text + "',`Percentage_waste_EP`='" + tex_Percentage_waste_EP.Text + "',`type_product_EP`='" + tex_Typ_pro_EP.Text + "',`notes_EP`='" + tex_Nodes_EP.Text + "', `Date_EP` = '"+datePicker_EP.Value+"' WHERE `Num_EP` = '" + tex_Num_EP.Text + "'";
                    SetCommand(StrUpDate);
                    cmd.ExecuteNonQuery();

                    FillGrid_PA();
                    Clear_PA();

                    MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to edit ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_Delete_PA_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_Num_EP.Text != "" && tex_Typ_pro_EP.Text != "")
                {
                    if (MessageBox.Show("Are you sure you want to delete this item?...", "Error Message...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string StrInsert_PA2 = " INSERT INTO `track_end_product` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "DELETE" + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_Humidity_EP.Text + "','" + tex_Ash_EP.Text + "','" + tex_Wet_gluten_EP.Text + "','" + tex_Dry_gluten_EP.Text + "','" + tex_Falling_number_EP.Text + "','" + tex_Percentage_waste_EP.Text + "','" + tex_Typ_pro_EP.Text + "','" + tex_Nodes_EP.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
                        cmd.Parameters.Clear();
                        SetCommand(StrInsert_PA2);
                        cmd.ExecuteNonQuery();
                        SetCommand("DELETE FROM `end_product` WHERE `Num_EP` = " + tex_Num_EP.Text );
                        cmd.Parameters.Clear();
                        cmd.ExecuteNonQuery();
                       
                        FillGrid_PA();
                        Clear_PA();

                        MessageBox.Show("Deleted successfully...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You have no data to delete...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Search_PA()
        {
            try
            {
                if (com_Seach_PA.SelectedItem.Equals("Type_product"))
                {
                    string StrSearch = "SELECT * FROM `end_product` WHERE `type_product_EP` Like  '" + tex_Search_PA.Text + "%'";

                    SetCommand(StrSearch);
                    DataTable TblSearch = new DataTable();
                    TblSearch.Load(cmd.ExecuteReader());
                    dataGridView_PA.DataSource = TblSearch;

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Search_Fp()
        {
            try
            {
                if (comboBox_Serche_Fp.SelectedItem.Equals("Type_product"))
                {
                    string StrSearch = "SELECT * FROM `final_product_pasta` WHERE `type_product_Fp` LIKE  '" + tex_Search_Fp.Text + "%'";

                    SetCommand(StrSearch);
                    DataTable TblSearch = new DataTable();
                    TblSearch.Load(cmd.ExecuteReader());
                    dataGridView_Fp.DataSource = TblSearch;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Tex_Search_PA_TextChanged(object sender, EventArgs e)
        {
            Search_PA();
        }

        private void DataGridView_PA_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView_PA.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 51, 255);
                dataGridView_PA.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView_PA_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_PA.CurrentRow != null && dataGridView_PA.SelectedRows.Count > 0)
                {
                    tex_Num_EP.Text = dataGridView_PA.CurrentRow.Cells[0].Value.ToString();
                   TimePicker_EP.Text = dataGridView_PA.CurrentRow.Cells[1].Value.ToString();
                    tex_Humidity_EP.Text = dataGridView_PA.CurrentRow.Cells[2].Value.ToString();
                    tex_Ash_EP.Text = dataGridView_PA.CurrentRow.Cells[3].Value.ToString();
                    tex_Wet_gluten_EP.Text = dataGridView_PA.CurrentRow.Cells[4].Value.ToString();
                    tex_Dry_gluten_EP.Text = dataGridView_PA.CurrentRow.Cells[5].Value.ToString();
                    tex_Falling_number_EP.Text = dataGridView_PA.CurrentRow.Cells[6].Value.ToString();
                    tex_Percentage_waste_EP.Text = dataGridView_PA.CurrentRow.Cells[7].Value.ToString();
                    tex_Typ_pro_EP.Text = dataGridView_PA.CurrentRow.Cells[8].Value.ToString();
                    tex_Nodes_EP.Text = dataGridView_PA.CurrentRow.Cells[9].Value.ToString();
                    datePicker_EP.Text = dataGridView_PA.CurrentRow.Cells[10].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_Exit_PA_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Pic_Clear_PA_Click(object sender, EventArgs e)
        {
            Clear_PA();
        }

        private void Com_Seach_PA_SelectedIndexChanged(object sender, EventArgs e)
        {
            tex_Search_PA.Clear(); tex_Percentage_waste_EP.Focus();
            if (com_Seach_PA.SelectedItem.Equals("Type_product") )
            {
                tex_Search_PA.Visible = true;
                lab_type_PA.Visible = true;
            }
            else if (com_Seach_PA.SelectedItem.Equals("Date"))
            {
                lab_type_PA.Visible = true;
                dateTimePicker2_PA.Visible = true;
                tex_Search_PA.Visible = false;
                dateTimePicker1_PA.Visible = false;
                lab_from_PA.Visible = false;
                lab_to_PA.Visible = false;
            }
            else if (com_Seach_PA.SelectedItem.Equals("From Date To Date"))
            {
                dateTimePicker1_PA.Visible = true;
                dateTimePicker2_PA.Visible = true;
                lab_from_PA.Visible = true;
                lab_to_PA.Visible = true;
            }
        }

        private void DateTimePicker1_PA_ValueChanged(object sender, EventArgs e)
        {
            Search_PA2();
        }

        private void Pic_Search_PA_Click(object sender, EventArgs e)
        {
            Search_PA2();
        }

        private void Pic_New_PR_Click(object sender, EventArgs e)
        {
           
        }

        private void Pic_Add_PR_Click(object sender, EventArgs e)
        {
           
        }

        private void Pic_Updta_PR_Click(object sender, EventArgs e)
        {
          
        }

        private void Pic_Delete_PR_Click(object sender, EventArgs e)
        {
        }

        private void Pic_Exit_PR_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Application.Exit();
        }

        private void DataGridView_PR_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        
        }

        private void DataGridView_PR_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void Com_Search_PR_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Pic_Search_PR_Click(object sender, EventArgs e)
        {
           
        }
        private void Search_PR()
        {
         
        }
        private void Search_EN2()
        {
        }
       

        private void Pic_Clear_PR_Click(object sender, EventArgs e)
        {
        }

        private void Tex_Search_PR_TextChanged(object sender, EventArgs e)
        {
            Search_PR();
        }



        private void PictureBox4_Click(object sender, EventArgs e)
        {
    
        }

        private void Pict_Add_EN_Click(object sender, EventArgs e)
        {
           
        }
        private void PictureBox6_Click(object sender, EventArgs e)
        {
          
        }

        private void Pic_Delete_EN_Click(object sender, EventArgs e)
        {
          
        }

        private void DataGridView_EN_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void Pic_Exit_EN_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Application.Exit();

        }

        private void DataGridView_EN_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void Pic_Search_EN_Click(object sender, EventArgs e)
        {
        }

        private void Com_Search_EN_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
     
        private void Tex_Search_EN_TextChanged(object sender, EventArgs e)
        {
        }

        private void Pic_Clear_EN_Click(object sender, EventArgs e)
        {
        }

        private void Com_Select_EN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Pic_Increase_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pic_Decrease_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void com_R_EN_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        

       
        private void tex_R_EN_TextChanged(object sender, EventArgs e)
        {
        }

        private void com_R_P_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void tex_R_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Application.Exit();
        }

        private void pic_Exit_RP_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Application.Exit();

        }

        private void com_R_PA_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
       
        private void tex_R_PA_TextChanged(object sender, EventArgs e)
        {
        }

        private void pic_Exit_LA_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Application.Exit();

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void com_R_LA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_LA_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_R_PA_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Application.Exit();
        }

        private void dateTimePicker_R_P_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker_R_EN_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void pic_Person1_Click(object sender, EventArgs e)
        {
            if(textBox_type.Text == "top_Administrators" || textBox_type.Text == "Administrator")
            {
                Class1.Parmation_Name = textBox_type.Text;
                My_setting_Account my = new My_setting_Account();
                my.Show();
            }else
            {

            }
        }

        private void lab_person1_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Login_Form lf = new Login_Form();
            lf.Show();
            this.Close();
        }

        private void pic_LogOut2_Click(object sender, EventArgs e)
        {
            Login_Form lf = new Login_Form();
            lf.Show();
            this.Close();
        }

        private void pic_LogOut3_Click(object sender, EventArgs e)
        {
            Login_Form lf = new Login_Form();
            lf.Show();
            this.Close();
        }

        private void pic_LogOut4_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Login_Form lf = new Login_Form();
            lf.Show();
            this.Close();
        }

        private void pic_LogOut5_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Login_Form lf = new Login_Form();
            lf.Show();
            this.Close();
        }

        private void pic_person5_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators")
            {
                My_setting_Account my = new My_setting_Account();
                my.Show();
            }
            else
            {

            }
        }

        private void pic_person2_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators" || textBox_type.Text == "Administrator")
            {
                Class1.Parmation_Name = textBox_type.Text;
                My_setting_Account my = new My_setting_Account();
                my.Show();
            }
            else
            {

            }
        }

        private void pic_person3_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators" || textBox_type.Text == "Administrator")
            {
                Class1.Parmation_Name = textBox_type.Text;
                My_setting_Account my = new My_setting_Account();
                my.Show();
            }
            else
            {

            }
        }

        private void pic_person4_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators")
            {
                My_setting_Account my = new My_setting_Account();
                my.Show();
            }
            else
            {

            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators")
            {

                Form_laboratory fl = new Form_laboratory();
                fl.Show();
            }
            else
            {

            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators")
            {
                Form_incoming_wheat_T fiwt = new Form_incoming_wheat_T();
                fiwt.Show();
            }
            else
            {

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators")
            {
               // Form_end_product_T fept = new Form_end_product_T();
                //fept.Show();
            }
            else
            {

            }
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        { 
        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {
            Report_Laboratory Rl = new Report_Laboratory();
            Rl.Show();
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void date_1_Wh_ValueChanged(object sender, EventArgs e)
        {
            Search_Wh();
        }

        private void date_2_Wh_ValueChanged(object sender, EventArgs e)
        {
            Search_Wh();
        }

        private void dateTimePicker_mian_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void label114_Click(object sender, EventArgs e)
        {

        }

        private void label121_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form_incoming_wheat fiw = new Form_incoming_wheat();
            fiw.Show();
        }

        private void dateTimePicker2_PA_ValueChanged(object sender, EventArgs e)
        {
            Search_PA2();
        }

        private void data_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form_end_product fep = new Form_end_product();
            fep.Show();
        }

        private void dataGridView_PR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_PR_ValueChanged(object sender, EventArgs e)
        {
            Search_EN2();
        }

        private void dateTimePicker2_PR_ValueChanged(object sender, EventArgs e)
        {
            Search_EN2();
        }

        private void pic_Report_EN_Click(object sender, EventArgs e)
        {
        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label102_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_EN_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker2_EN_ValueChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
        }

        private void pic_Person6_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators" || textBox_type.Text == "Administrator")
            {
                Class1.Parmation_Name = textBox_type.Text;
                My_setting_Account my = new My_setting_Account();
                my.Show();
            }
            else
            {

            }
        }

        private void pic_track_6_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators")
            {
                Form_track_samples_production FTSP = new Form_track_samples_production();
                FTSP.Show();
            }
            else
            {

            }
        }
        private void Insert_SamplesProduction ()
        {
            try
            {
                if (com_Sample_SP.Text != "")
                {
                    string time = TimePicker_SP.Value.ToString();
                    time = time.Substring(10, 8);
                    string StrInsert_PA = "INSERT INTO `samples_production` VALUES ('" + null + "','" + com_Sample_SP.Text + "','" + tex_mois_SP.Text + "','" + tex_Wet_Glu_SP.Text + "','" + tex_DryGlu_SP.Text + "','" + tex_Index_SP.Text + "','" + tex_Fall_Num_SP.Text + "','" + tex_Ash_SP.Text + "','" + tex_Res_SP.Text + "','" + tex_Star_SP.Text + "','" + tex_Notes_SP.Text + "','" + datePicker_SP.Value + "','" + time + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert_PA);
                    cmd.ExecuteNonQuery();
                    string StrInsert_PA2 = "INSERT INTO `track_samples_production` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "INSERT" + "','" + com_Sample_SP.Text + "','" + tex_mois_SP.Text + "','" + tex_Wet_Glu_SP.Text + "','" + tex_DryGlu_SP.Text + "','" + tex_Index_SP.Text + "','" + tex_Fall_Num_SP.Text + "','" + tex_Ash_SP.Text + "','" + tex_Res_SP.Text + "','" + tex_Star_SP.Text + "','" + tex_Notes_SP.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert_PA2);
                    cmd.ExecuteNonQuery();
                    FillGrid_SP();
                    Clear_SP();
                    MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to add ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_add_SP_Click(object sender, EventArgs e)
        {
            Insert_SamplesProduction();
        }

        private void pic_updata_SP_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_Number_SP.Text != "")
                {
                    string time = TimePicker_SP.Value.ToString();
                    time = time.Substring(10,8);
                    string StrUpDate = "UPDATE `samples_production` SET `Sample_SP`='" + com_Sample_SP.Text + "',`Moisture_SP`='" + tex_mois_SP.Text + "',`Wet_Gluten_SP`='" + tex_Wet_Glu_SP.Text + "',`Dry_Gluten_SP`='" + tex_DryGlu_SP.Text + "',`Index_SP`='" + tex_Index_SP.Text + "',`Fall_Number_SP`='" + tex_Fall_Num_SP.Text + "',`Ash_SP`='" + tex_Ash_SP.Text + "',`Residue_Ratio_SP`='" + tex_Res_SP.Text + "',`Starch_SP`='" + tex_Star_SP.Text + "',`Notes_SP`='" + tex_Notes_SP.Text + "',`Date_SP`='" + datePicker_SP.Value + "',`Time_SP`='" + time + "' WHERE `Num_SP` = '"+tex_Number_SP.Text+"'";
                    SetCommand(StrUpDate);
                    cmd.ExecuteNonQuery();
                    string StrInsert_PA2 = "INSERT INTO `track_samples_production` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "UPDATE" + "','" + com_Sample_SP.Text + "','" + tex_mois_SP.Text + "','" + tex_Wet_Glu_SP.Text + "','" + tex_DryGlu_SP.Text + "','" + tex_Index_SP.Text + "','" + tex_Fall_Num_SP.Text + "','" + tex_Ash_SP.Text + "','" + tex_Res_SP.Text + "','" + tex_Star_SP.Text + "','" + tex_Notes_SP.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert_PA2);
                    cmd.ExecuteNonQuery();
                    FillGrid_SP();
                    Clear_SP();
                    MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to edit ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_delete_SP_Click(object sender, EventArgs e)
        {
            if (tex_Number_SP.Text != "")
            {
                if (MessageBox.Show("Are you sure you want to delete this item?...", "Error Message...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string StrInsert_PA2 = "INSERT INTO `track_samples_production` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "DELETE" + "','" + com_Sample_SP.Text + "','" + tex_mois_SP.Text + "','" + tex_Wet_Glu_SP.Text + "','" + tex_DryGlu_SP.Text + "','" + tex_Index_SP.Text + "','" + tex_Fall_Num_SP.Text + "','" + tex_Ash_SP.Text + "','" + tex_Res_SP.Text + "','" + tex_Star_SP.Text + "','" + tex_Notes_SP.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert_PA2);
                    cmd.ExecuteNonQuery();
                    SetCommand("DELETE FROM `samples_production` WHERE `Num_SP` = " +tex_Number_SP.Text);
                    cmd.ExecuteNonQuery();
                    FillGrid_SP();
                    Clear_SP();
                    MessageBox.Show("Deleted successfully...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You have no data to delete...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pic_logout_SP_Click(object sender, EventArgs e)
        {
            Login_Form lf = new Login_Form();
            lf.Show();
            this.Close();
        }

        private void pic_clear_SP_Click(object sender, EventArgs e)
        {
            Clear_SP();
        }

        private void pic_exit_Sp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView_SP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView_SP.RowsDefaultCellStyle.BackColor = Color.FromArgb(200, 214, 56);
                dataGridView_SP.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_SP_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_SP.CurrentRow != null && dataGridView_SP.SelectedRows.Count > 0)
                {
                    tex_Number_SP.Text = dataGridView_SP.CurrentRow.Cells[0].Value.ToString();
                    com_Sample_SP.Text = dataGridView_SP.CurrentRow.Cells[1].Value.ToString();
                    tex_mois_SP.Text = dataGridView_SP.CurrentRow.Cells[2].Value.ToString();
                    tex_Wet_Glu_SP.Text = dataGridView_SP.CurrentRow.Cells[3].Value.ToString();
                    tex_DryGlu_SP.Text = dataGridView_SP.CurrentRow.Cells[4].Value.ToString();
                    tex_Index_SP.Text = dataGridView_SP.CurrentRow.Cells[5].Value.ToString();
                    tex_Fall_Num_SP.Text = dataGridView_SP.CurrentRow.Cells[6].Value.ToString();
                    tex_Ash_SP.Text = dataGridView_SP.CurrentRow.Cells[7].Value.ToString();
                    tex_Res_SP.Text = dataGridView_SP.CurrentRow.Cells[8].Value.ToString();
                    tex_Star_SP.Text = dataGridView_SP.CurrentRow.Cells[9].Value.ToString();
                    tex_Notes_SP.Text = dataGridView_SP.CurrentRow.Cells[10].Value.ToString();
                    datePicker_SP.Text = dataGridView_SP.CurrentRow.Cells[11].Value.ToString();
                    TimePicker_SP.Text = dataGridView_SP.CurrentRow.Cells[12].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TimePicker_SP_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void com_Search_SP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_Search_SP.SelectedItem.Equals("From Date To Date"))
            {
                dateTimePicker1_SP.Visible = true;
                dateTimePicker2_SP.Visible = true;
                lab_from_SP.Visible = true;
                lab_to_SP.Visible = true;
                lab_type_SP.Visible = true;
            }
            else if (com_Search_SP.SelectedItem.Equals("Date"))
            {
                dateTimePicker1_SP.Visible = true;
                dateTimePicker2_SP.Visible = false;
                lab_from_SP.Visible = false;
                lab_to_SP.Visible = false;
                lab_type_SP.Visible = true;
            }
        }

        private void dateTimePicker2_SP_ValueChanged(object sender, EventArgs e)
        {
            Search_SP();
        }

        private void dateTimePicker1_SP_ValueChanged(object sender, EventArgs e)
        {
            Search_SP();
        }

        private void pictureBox2_Click_3(object sender, EventArgs e)
        {
            Form_LA fl = new Form_LA();
            fl.Show();


        }

        private void pic_report_Sp_Click(object sender, EventArgs e)
        {
            Form_samples_production FSP = new Form_samples_production();
            FSP.Show();
        }

        private void label133_Click(object sender, EventArgs e)
        {

        }

        private void pic_track7_Click(object sender, EventArgs e)
        {
        }

        private void pic_Person7_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "Administrator")
            {
                My_setting_Account my = new My_setting_Account();
                my.Show();
            }
            else
            {

            }
        }

        private void pic_Add_FH_Click(object sender, EventArgs e)
        {
           
        }

        private void pic_Updata_FH_Click(object sender, EventArgs e)
        {
           
        }

        private void pic_Delete_FH_Click(object sender, EventArgs e)
        {
            
        }

        private void pic_LogOut_FH_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Login_Form lf = new Login_Form();
            lf.Show();
            this.Close();
        }

        private void pic_Clear_FH_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            SetCommand("DELETE FROM `data_test` ");
            cmd.ExecuteNonQuery();
            Application.Exit();
        }
        private void Search_FH()
        {
         
        }

        private void com_Search_FH_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

        private void dataGridView_FH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void dataGridView_FH_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker_1_FH_ValueChanged(object sender, EventArgs e)
        {
            Search_FH();
        }

        private void dateTimePicker2_FH_ValueChanged(object sender, EventArgs e)
        {
            Search_FH();
        }

        private void pic_Report_FH_Click(object sender, EventArgs e)
        {
           
        }

        private void TimePicker_SP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pic_add_IM_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (comb_TypeName_IM.Text != "")
                {


                    string StrInsert = "INSERT INTO `improvement` VALUES ('"+null+"','"+ comb_TypeName_IM.Text+"','"+tex_Balance_IM.Text+"','"+tex_Expenses_IM.Text+"','"+tex_Residual_IM.Text+"','"+tex_Incoming_IM.Text+"','"+dateTimePicker_Date_IM.Value+"','"+tex_Input_permission_IM.Text+"','"+tex_Bill_IM.Text+"','"+tex_Notes_IM.Text+"')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert);
                    cmd.ExecuteNonQuery();
                    string StrInsert2 = "INSERT INTO `track_improvement` VALUES ('" + null + "','"+textBox_Name.Text+"','"+ "INSERT" + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','"+ DateTime.Now.ToString("HH:mm:ss") + "','"+ comb_TypeName_IM.Text+"','"+tex_Balance_IM.Text+"','"+tex_Expenses_IM.Text+"','"+tex_Residual_IM.Text+"','"+tex_Incoming_IM.Text+"','"+dateTimePicker_Date_IM.Value+"','"+tex_Input_permission_IM.Text+"','"+tex_Bill_IM.Text+"','"+tex_Notes_IM.Text+"')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert2);
                    cmd.ExecuteNonQuery();
                    FillGrid_IM();
                    Clear_IM();

                    MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to Add ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_updata_IM_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_Num_IM.Text != "")
                {
                   
                    //MessageBox.Show(tex_Balance_IM.Text + tex_Expenses_IM.Text + tex_Residual_IM.Text + tex_Incoming_IM.Text);

                    string StrUpDate = "UPDATE `improvement` SET `IM_Type`='"+ comb_TypeName_IM.Text+"',`IM_Balance`='"+tex_Balance_IM.Text+"',`IM_Expenses`='"+tex_Expenses_IM.Text+"',`IM_Residual`='"+tex_Residual_IM.Text+"',`IM_Incoming`='"+tex_Incoming_IM.Text+"',`IM_Date`='"+dateTimePicker_Date_IM.Value+"',`Input_permission`='"+tex_Input_permission_IM.Text+"',`IM_Bill`='"+tex_Bill_IM.Text+"',`IM_Notes`='"+tex_Notes_IM.Text+"' WHERE `Number_ID` = '"+tex_Num_IM.Text+"'";
                    SetCommand(StrUpDate);
                    cmd.ExecuteNonQuery();
                    string StrInsert2 = "INSERT INTO `track_improvement` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "UPDATE" + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + comb_TypeName_IM.Text + "','" + tex_Balance_IM.Text + "','" + tex_Expenses_IM.Text + "','" + tex_Residual_IM.Text + "','" + tex_Incoming_IM.Text + "','" + dateTimePicker_Date_IM.Value + "','" + tex_Input_permission_IM.Text + "','" + tex_Bill_IM.Text + "','" + tex_Notes_IM.Text + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert2);
                    cmd.ExecuteNonQuery();
                    FillGrid_IM();
                    Clear_IM();
                    MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to edit ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_Delete_IM_Click(object sender, EventArgs e)
        {
            if (tex_Num_IM.Text != "")
            {
                if (MessageBox.Show("Are you sure you want to delete this item?...", "Error Message...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string StrInsert2 = "INSERT INTO `track_improvement` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "DELETE" + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + comb_TypeName_IM.Text + "','" + tex_Balance_IM.Text + "','" + tex_Expenses_IM.Text + "','" + tex_Residual_IM.Text + "','" + tex_Incoming_IM.Text + "','" + dateTimePicker_Date_IM.Value + "','" + tex_Input_permission_IM.Text + "','" + tex_Bill_IM.Text + "','" + tex_Notes_IM.Text + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert2);
                    cmd.ExecuteNonQuery();
                    SetCommand("DELETE FROM `improvement` WHERE `Number_ID` = '"+tex_Num_IM.Text+"'");
                    cmd.ExecuteNonQuery();
                    FillGrid_IM();
                    Clear_IM();
                    MessageBox.Show("Deleted successfully...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You have no data to delete...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pic_Clear_IM_Click(object sender, EventArgs e)
        {
            Clear_IM();
        }

        private void pic_Logout_IM_Click(object sender, EventArgs e)
        {
            Login_Form lf = new Login_Form();
            lf.Show();
            this.Close();
        }

        private void dataGridView_IM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView_IM.RowsDefaultCellStyle.BackColor = Color.FromArgb(102, 255, 51);
                dataGridView_IM.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_IM_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_IM.CurrentRow != null && dataGridView_IM.SelectedRows.Count > 0)
                {
                    
                    tex_Num_IM.Text = dataGridView_IM.CurrentRow.Cells[0].Value.ToString();
                    comb_TypeName_IM.Text = dataGridView_IM.CurrentRow.Cells[1].Value.ToString();
                    tex_Balance_IM.Text = dataGridView_IM.CurrentRow.Cells[2].Value.ToString();
                    tex_Expenses_IM.Text = dataGridView_IM.CurrentRow.Cells[3].Value.ToString();
                    tex_Residual_IM.Text = dataGridView_IM.CurrentRow.Cells[4].Value.ToString();
                    tex_Incoming_IM.Text = dataGridView_IM.CurrentRow.Cells[5].Value.ToString();
                    dateTimePicker_Date_IM.Text = dataGridView_IM.CurrentRow.Cells[6].Value.ToString();
                    tex_Input_permission_IM.Text = dataGridView_IM.CurrentRow.Cells[7].Value.ToString();
                    tex_Bill_IM.Text = dataGridView_IM.CurrentRow.Cells[8].Value.ToString();
                    tex_Notes_IM.Text = dataGridView_IM.CurrentRow.Cells[9].Value.ToString();
                    //tex_Expenses_IM.Text = "0"; tex_Residual_IM.Text = "0"; tex_Incoming_IM.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_Serche_IM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Serche_IM.SelectedItem.Equals("From Date To Date"))
            {
                tex_Search_IM.Visible = false;
                dateTimePicker_M_IM.Visible = true;
                dateTimePicker_IM.Visible = true;
                lab_to_IM.Visible = true;
                lab_From_IM.Visible = true;
                lab_type_IM.Visible = false;
            }
            else if (comboBox_Serche_IM.SelectedItem.Equals("Date"))
            {
                tex_Search_IM.Visible = false;
                dateTimePicker_M_IM.Visible = true;
                dateTimePicker_IM.Visible = false;
                lab_to_IM.Visible = false;
                lab_From_IM.Visible = false;
                lab_type_IM.Visible = true;
            }
            else
            {
                tex_Search_IM.Visible = true;
                dateTimePicker_M_IM.Visible = false;
                dateTimePicker_IM.Visible = false;
                lab_to_IM.Visible = false;
                lab_From_IM.Visible = false;
                lab_type_IM.Visible = true;
            }
        }

        private void pic_exit_IM_Click(object sender, EventArgs e)
        {
            try
            {
                
                Application.Exit();
            }
            catch(Exception ex)
            {

            }
        }

        private void tex_Search_IM_TextChanged(object sender, EventArgs e)
        {
            Search_IM();
        }

        private void dateTimePicker_IM_ValueChanged(object sender, EventArgs e)
        {
            Search_IM();
        }

        private void dateTimePicker_M_IM_ValueChanged(object sender, EventArgs e)
        {
            Search_IM();
        }

        private void pic_report_IM_Click(object sender, EventArgs e)
        {
            Form_Improvement FI = new Form_Improvement();
            FI.Show();
        }

        private void pic_track_7_Click(object sender, EventArgs e)
        {
            Form_improvement_T FIT = new Form_improvement_T();
            FIT.Show();
        }

        private void pic_Person_7_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators" || textBox_type.Text == "Administrator")
            {
                Class1.Parmation_Name = textBox_type.Text;
                My_setting_Account my = new My_setting_Account();
                my.Show();
            }
            else
            {

            }
        }

        private void pic_Process_IM_Click(object sender, EventArgs e)
        {

            decimal Balance = 0, Expenses = 0, Residual = 0, Incoming = 0;

            if(tex_Balance_IM.Text != "")
            Balance = Convert.ToDecimal (tex_Balance_IM.Text);
            else
              Balance = 0;

            if (tex_Expenses_IM.Text != "")
                Expenses = Convert.ToDecimal(tex_Expenses_IM.Text);
            else Expenses = 0;


            if (tex_Residual_IM.Text != "")
                Residual = Convert.ToDecimal(tex_Residual_IM.Text);
            else Residual = 0;

            if (tex_Incoming_IM.Text != "")
                Incoming = Convert.ToDecimal(tex_Incoming_IM.Text);
            else Incoming = 0;

            if (Expenses > 0)
            { Residual = Balance - Expenses; }
            else { decimal Result = Balance + Incoming; Residual = Result; }

            tex_Balance_IM.Text = Balance.ToString();
            tex_Expenses_IM.Text = Expenses.ToString();
            tex_Residual_IM.Text = Residual.ToString();
            tex_Incoming_IM.Text = Incoming.ToString();
        }

        private void comb_TypeName_IM_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void comb_TypeName()
        {
            try
            {
                string num = "";
                string StrSearch_P = "SELECT MAX(Number_ID) AS maxnum FROM `improvement` WHERE `IM_Type`= '" + comb_TypeName_IM.Text + "'";
                //cmd.Parameters.Clear();
                SetCommand(StrSearch_P);
                var TblSearch_R = cmd.ExecuteReader();
                while (TblSearch_R.Read())
                {
                    num = TblSearch_R.GetString("maxnum");
                }
                TblSearch_R.Close();
                //SELECT `IM_Balance` FROM `improvement` WHERE `Number_ID`=10
                string Blance = "";
                string StrSearch1 = "SELECT `IM_Residual` FROM `improvement` WHERE `Number_ID`='" + num + "'";
                SetCommand(StrSearch1);
                var TblSearch2 = cmd.ExecuteReader();
                while (TblSearch2.Read())
                {
                    Blance = TblSearch2.GetString("IM_Residual");
                }
                TblSearch2.Close();
                tex_Balance_IM.Text = Blance.ToString();
                comb_TypeName_IM.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comb_TypeName_IM_SelectedValueChanged(object sender, EventArgs e)
        {
            comb_TypeName();
           
        }

        private void comb_TypeName_IM_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comb_TypeName();
            
        }

        private void comb_TypeName_IM_TextUpdate(object sender, EventArgs e)
        {

        }

        private void timer_Now_Tick(object sender, EventArgs e)
        {
            LbTime.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            LBtime2.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            LBtime3.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            LBtime4.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            LBtime5.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            LBtime6.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
        }

        private void timer_Set_Tick(object sender, EventArgs e)
        {
            // Reports at one day  _____________________________________________________________________________________
            if (LbTime.Text == "08:00:00")
            {
                try
                {
                    Form_LA fl = new Form_LA();//the updated is successfuly *
                    fl.Show();
                    timer_Set.Stop();
                    timer_Set.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (LbTime.Text == "08:02:00")
            {
                try
                {

                    Form_incoming_wheat fi = new Form_incoming_wheat();//the updated is successfuly *
                    fi.Show();
                    timer_Set.Stop();
                    timer_Set.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (LbTime.Text == "08:04:00")
            {
                try
                {
                    Form_end_product fd = new Form_end_product();//the updated is successfuly *
                    fd.Show();
                    timer_Set.Stop();
                    timer_Set.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (LbTime.Text == "08:06:00")
            {
                try
                {
                    Form_samples_production fs = new Form_samples_production();//the updated is successfuly *
                    fs.Show();
                    timer_Set.Stop();
                    timer_Set.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (LbTime.Text == "08:08:00")
            {
                try
                {
                    Form_Final_Product_Pasta fs = new Form_Final_Product_Pasta();//the updated is successfuly *
                    fs.Show();
                    timer_Set.Stop();
                    timer_Set.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            string day = DateTime.Now.Day.ToString();

            if (LbTime.Text == "08:10:00")
            {
                if (day == "6" || day ==  "06")
                {
                    try
                    {
                        Form_Avrage_Humidity_Monthes fs = new Form_Avrage_Humidity_Monthes();//the updated is successfuly *
                        fs.Show();
                        timer_Set.Stop();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            

        }
        private void Insert_Pasta ()
        {
            try
            {
                if (tex_Type_Pro_Fp.Text != "")
                {
                    string time = dateTimePicker_Time_Fp.Value.ToString();
                    time = time.Substring(10, 9);
                    string StrInsert_Fp = "INSERT INTO `final_product_pasta` VALUES ('" + null + "','" + time + "','" + tex_Hum_Fp.Text + "','" + tex_Ash_Fp.Text + "','" + tex_Wet_Fp.Text + "','" + tex_Dry_Fp.Text + "','" + tex_Fall_Fp.Text + "','" + tex_Perc_Fp.Text + "','" + tex_Type_Pro_Fp.Text + "','" + tex_Nodes_Fp.Text + "','" + dateTimePicker_S_Fp.Value + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert_Fp);
                    cmd.ExecuteNonQuery();
                    string StrInsert_PA2 = " INSERT INTO `track_end_product` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "INSERT" + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_Hum_Fp.Text + "','" + tex_Ash_Fp.Text + "','" + tex_Wet_Fp.Text + "','" + tex_Dry_Fp.Text + "','" + tex_Fall_Fp.Text + "','" + tex_Perc_Fp.Text + "','" + tex_Type_Pro_Fp.Text + "','" + tex_Nodes_Fp.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert_PA2);
                    cmd.ExecuteNonQuery();
                    FillGrid_Fp();
                    Clear_Fp();

                    MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to add ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pic_add_Fp_Click(object sender, EventArgs e)
        {
            Insert_Pasta();
        }

        private void dataGridView_Fp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView_Fp.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 153, 0);
                dataGridView_Fp.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_track_8_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators")
            {
               /* Form_end_product_T fept = new Form_end_product_T();
                fept.Show();*/
            }
            else
            {

            }
        }

        private void pic_updata_Fp_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_Num_Fp.Text != "")
                {
                    string time = dateTimePicker_Time_Fp.Value.ToString();
                    time = time.Substring(10, 9);
                    string StrUpDate = "UPDATE `final_product_pasta` SET `Time_Fp`='"+time+"',`Humidity_Fp`='"+ tex_Hum_Fp.Text + "',`Ash_Fp`='"+ tex_Ash_Fp.Text + "',`Wet_gluten_Fp`='"+ tex_Wet_Fp.Text + "',`Dry_gluten_Fp`='"+ tex_Dry_Fp.Text + "',`Falling_number_Fp`='"+ tex_Fall_Fp.Text + "',`Percentage_waste_Fp`='" + tex_Perc_Fp.Text + "',`type_product_Fp`='" + tex_Type_Pro_Fp.Text + "',`notes_Fp`='" + tex_Nodes_Fp.Text + "',`Date_Fp`='" + dateTimePicker_S_Fp.Value + "' WHERE `Num`= '"+ tex_Num_Fp .Text+ "'";
                    SetCommand(StrUpDate);
                    cmd.ExecuteNonQuery();
                    string StrInsert_PA2 = " INSERT INTO `track_end_product` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "UPDATE" + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_Hum_Fp.Text + "','" + tex_Ash_Fp.Text + "','" + tex_Wet_Fp.Text + "','" + tex_Dry_Fp.Text + "','" + tex_Fall_Fp.Text + "','" + tex_Perc_Fp.Text + "','" + tex_Type_Pro_Fp.Text + "','" + tex_Nodes_Fp.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
                    cmd.Parameters.Clear();
                    SetCommand(StrInsert_PA2);
                    cmd.ExecuteNonQuery();
                    FillGrid_Fp();
                    Clear_Fp();

                    MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have no data to edit ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_Delete_Fp_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_Num_Fp.Text != "")
                {
                    if (MessageBox.Show("Are you sure you want to delete this item?...", "Error Message...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        SetCommand("DELETE FROM `final_product_pasta` WHERE `Num` = " + tex_Num_Fp.Text);
                        cmd.Parameters.Clear();
                        cmd.ExecuteNonQuery();
                        string StrInsert_PA2 = " INSERT INTO `track_end_product` VALUES ('" + null + "','" + textBox_Name.Text + "','" + "DELETE" + "','" + DateTime.Now.ToString("HH:mm:ss") + "','" + tex_Hum_Fp.Text + "','" + tex_Ash_Fp.Text + "','" + tex_Wet_Fp.Text + "','" + tex_Dry_Fp.Text + "','" + tex_Fall_Fp.Text + "','" + tex_Perc_Fp.Text + "','" + tex_Type_Pro_Fp.Text + "','" + tex_Nodes_Fp.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "')";
                        cmd.Parameters.Clear();
                        SetCommand(StrInsert_PA2);
                        cmd.ExecuteNonQuery();
                        FillGrid_Fp();
                        Clear_Fp();

                        MessageBox.Show("Deleted successfully...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You have no data to delete...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_Clear_Fp_Click(object sender, EventArgs e)
        {
            Clear_Fp();
        }

        private void pic_Logout_Fp_Click(object sender, EventArgs e)
        {
            Login_Form lf = new Login_Form();
            lf.Show();
            this.Close();
        }

        private void dataGridView_Fp_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Fp.CurrentRow != null && dataGridView_Fp.SelectedRows.Count > 0)
                {

                    tex_Num_Fp.Text = dataGridView_Fp.CurrentRow.Cells[0].Value.ToString();
                    dateTimePicker_Time_Fp.Text = dataGridView_Fp.CurrentRow.Cells[1].Value.ToString();
                    tex_Hum_Fp.Text = dataGridView_Fp.CurrentRow.Cells[2].Value.ToString();
                    tex_Ash_Fp.Text = dataGridView_Fp.CurrentRow.Cells[3].Value.ToString();
                    tex_Wet_Fp.Text = dataGridView_Fp.CurrentRow.Cells[4].Value.ToString();
                    tex_Dry_Fp.Text = dataGridView_Fp.CurrentRow.Cells[5].Value.ToString();
                    tex_Fall_Fp.Text = dataGridView_Fp.CurrentRow.Cells[6].Value.ToString();
                    tex_Perc_Fp.Text = dataGridView_Fp.CurrentRow.Cells[7].Value.ToString();
                    tex_Type_Pro_Fp.Text = dataGridView_Fp.CurrentRow.Cells[8].Value.ToString();
                    tex_Nodes_Fp.Text = dataGridView_Fp.CurrentRow.Cells[9].Value.ToString();
                    dateTimePicker_S_Fp.Text = dataGridView_Fp.CurrentRow.Cells[10].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_Serche_Fp_SelectedIndexChanged(object sender, EventArgs e)
        {
            tex_Search_PA.Clear(); tex_Search_PA.Focus();
            if (comboBox_Serche_Fp.SelectedItem.Equals("Type_product") )
            {
                tex_Search_Fp.Visible = true;
                lab_Type_Fp.Visible = true;
                lab_to_Fp.Visible = false;
                lab_from_Fp.Visible = false;
                dateTimePicker_Fp.Visible = false;
                dateTimePicker_FP2.Visible = false;
                tex_Search_PA.Focus();
            }
            else if (comboBox_Serche_Fp.SelectedItem.Equals("Date"))
            {
                lab_Type_Fp.Visible = true;
                dateTimePicker_FP2.Visible = true;
                tex_Search_Fp.Visible = false;
                dateTimePicker_Fp.Visible = false;
                lab_to_Fp.Visible = false;
                lab_from_Fp.Visible = false;
            }
            else if (comboBox_Serche_Fp.SelectedItem.Equals("From Date To Date"))
            {
                dateTimePicker_FP2.Visible = true;
                dateTimePicker_Fp.Visible = true;
                lab_to_Fp.Visible = true;
                lab_from_Fp.Visible = true;
            }
        }

        private void pic_Exit_FP_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tex_Search_Fp_TextChanged(object sender, EventArgs e)
        {
            Search_Fp();
        }

        private void dateTimePicker_FP2_ValueChanged(object sender, EventArgs e)
        {
            Search_Fp2();
        }

        private void dateTimePicker_Fp_ValueChanged(object sender, EventArgs e)
        {
            Search_Fp2();
        }

        private void pic_Report_Fp_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Final_Product_Pasta ffpp = new Form_Final_Product_Pasta();
                ffpp.Show();

            }catch(Exception ex)
            {
                
            }
        }

        private void pic_Person_8_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == "top_Administrators" || textBox_type.Text == "Administrator")
            {
                Class1.Parmation_Name = textBox_type.Text;
                My_setting_Account my = new My_setting_Account();
                my.Show();
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox6_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox24_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox6_Click_3(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {


        }

        private void texNotes_IW_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tex_Nodes_EP_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void data_KeyDown(object sender, KeyEventArgs e)
        {
 
        }

        private void tex_Nodes_Fp_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void texNotes_IW_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void pictureBox16_Click_1(object sender, EventArgs e)
        {
            Form_FinalProductPasta_AvgHumid FFA = new Form_FinalProductPasta_AvgHumid();
            FFA.Show();
        }

        private void pictureBox7_Click_3(object sender, EventArgs e)
        {
            Form_IncomeWheat_AvgHumid FIA = new Form_IncomeWheat_AvgHumid();
            FIA.Show();
        }

        private void pictureBox10_Click_2(object sender, EventArgs e)
        {
            Form_EndProduct_AvgHumid FEA = new Form_EndProduct_AvgHumid();
            FEA.Show();
        }

        private void pictureBox13_Click_1(object sender, EventArgs e)
        {
            Form_SamplesProduction_AvgHumid FSA = new Form_SamplesProduction_AvgHumid();
            FSA.Show();
        }
    }
}