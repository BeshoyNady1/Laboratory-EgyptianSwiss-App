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
    public partial class My_setting_Account : Form
    {
        public My_setting_Account()
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
        private void Clear_Data()
        {
            tex_Number_Add.Clear();
            tex_User_add.Clear();
            tex_Passwoed_add.Clear();
            dataGridView1.Refresh();
            FillGrid();
            this.Refresh();
        }
        private void Clear_Data_Acc()
        {
            tex_Name_Acc.Clear();
            check_End_Product.Checked = false;
            check_Incoming_Wheat.Checked = false;
            check_Laboratory.Checked = false;
            check_Samples_Product.Checked = false;
            FillGrid_Acc();
            this.Refresh();
        }
        private void Clear_Data_Sender_Account()
        {
            SenderEmail.Clear();
            Password.Clear();
            AsName.Clear();
            Port.Clear();
            FillGrid_Sender_Account();
            this.Refresh();
        }
        private void Clear_DataTopAdmin()
        {
            tex_num_TA.Clear();
            tex_Name_TA.Clear();
            tex_Pass_TA.Clear();
            FillGridTopAdmin();
            this.Refresh();
        }
        private void FillGrid()
        {
            SetCommand("SELECT * FROM users ORDER BY `users_Name` DESC ");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = tbl;


        }
        private void FillGrid_Acc()
        {
            SetCommand("SELECT * FROM accounts ORDER BY `Acc_ID` DESC ");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView_Acc.DataSource = tbl;


        }

        private void FillGrid_Sender_Account()
        {
            SetCommand("SELECT * FROM sender_mail ORDER BY `id` DESC ");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView3.DataSource = tbl;


        }
        private void FillGridTopAdmin()
        {
            SetCommand("SELECT * FROM Top_administrators ORDER BY `TOP_Name` DESC ");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView_topAdmin.DataSource = tbl;


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void data_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void My_setting_Account_Load(object sender, EventArgs e)
        {
            con.Open();
           
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DataPropertyName = col.Name;

            }
            FillGrid();


            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.DataPropertyName = col.Name;

            }
            FillGrid_A();




            foreach (DataGridViewColumn col in dataGridView3.Columns)
            {
                col.DataPropertyName = col.Name;

            }
            FillGrid_Sender_Account();


            foreach (DataGridViewColumn col in dataGridView_topAdmin.Columns)
            {
                col.DataPropertyName = col.Name;

            }
            FillGridTopAdmin();


            foreach (DataGridViewColumn col in dataGridView_Acc.Columns)
            {
                col.DataPropertyName = col.Name;

            }
            FillGrid_Acc();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
          
        }

        private void pic_Add_Click(object sender, EventArgs e)
        {
            if(tex_User_add.Text != "" && tex_Passwoed_add.Text != "")
            {
                string StrInsert_PA = "INSERT INTO `users` VALUES ('" + null + "','" + tex_User_add.Text + "','" + tex_Passwoed_add.Text + "')";
                cmd.Parameters.Clear();
                SetCommand(StrInsert_PA);
                cmd.ExecuteNonQuery();
                FillGrid();
                Clear_Data();
                MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 214, 100);
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.SelectedRows.Count > 0)
            {
                tex_Number_Add.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                tex_User_add.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                tex_Passwoed_add.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void pic_Delete_Click(object sender, EventArgs e)
        {
            if (tex_Number_Add.Text != "")
            {
                SetCommand("DELETE FROM `users` WHERE `users_Number` = '" + tex_Number_Add.Text+"'");
                cmd.ExecuteNonQuery();
                FillGrid();
                Clear_Data();
                MessageBox.Show("Delete successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
        
        private void Fill_com_SNU()
        {
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
        }

        private void pic_Clear_Click(object sender, EventArgs e)
        {
            Clear_Data();
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView2.RowsDefaultCellStyle.BackColor = Color.FromArgb(255, 214, 100);
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null && dataGridView2.SelectedRows.Count > 0)
            {
                tex_Num_Ad.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                tex_Na_ad.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                tex_pas_ad.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            }
        }
        private void FillGrid_A()
        {
            SetCommand("SELECT * FROM administrator ORDER BY `admin_Number` DESC ");
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = tbl;
        }

        private void Clear_Data_A()
        {
            tex_Num_Ad.Clear();
            tex_Na_ad.Clear();
            tex_pas_ad.Clear();
            FillGrid_A();
            this.Refresh();
        }
        private void pic_Add_Admin_Click(object sender, EventArgs e)
        {
            if (tex_Na_ad.Text != "" && tex_pas_ad.Text != "")
            {
                string StrInsert_PA = "INSERT INTO `administrator` VALUES ('" + null + "','" + tex_Na_ad.Text + "','" + tex_pas_ad.Text + "')";
                cmd.Parameters.Clear();
                SetCommand(StrInsert_PA);
                cmd.ExecuteNonQuery();
                FillGrid_A();
                Clear_Data_A();
                MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pic_updata_admin_Click(object sender, EventArgs e)
        {
            if (tex_Num_Ad.Text != "" )
            {
                string StrInsert_PA = "UPDATE `administrator` SET `admin_Name`= '"+ tex_Na_ad.Text + "', `admin_Password` = '"+ tex_pas_ad .Text+ "' WHERE `admin_Number` = '" + tex_Num_Ad.Text+ "'";
                cmd.Parameters.Clear();
                SetCommand(StrInsert_PA);
                cmd.ExecuteNonQuery();
                FillGrid_A();
                Clear_Data_A();
                //cmd.Parameters.Clear();
                MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pic_Update_Admin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_Num_Ad.Text != "")
                {
                    SetCommand("DELETE FROM `administrator` WHERE `admin_Number` = '" + tex_Num_Ad.Text+"'");
                    cmd.ExecuteNonQuery();
                    FillGrid_A();
                    Clear_Data_A();
                    MessageBox.Show("Delete successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void pic_Clear_Admin_Click(object sender, EventArgs e)
        {
            Clear_Data_A();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void com_SNU_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void label19_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tex_Number_Add.Text != "")
            {
                string StrInsert_PA = "UPDATE `users` SET `users_Name`= '" + tex_User_add.Text + "', `users_Password` = '" + tex_Passwoed_add.Text + "' WHERE `users_Number` = '" + tex_Number_Add.Text + "'";
                cmd.Parameters.Clear();
                SetCommand(StrInsert_PA);
                cmd.ExecuteNonQuery();
                FillGrid();
                Clear_Data();
                //cmd.Parameters.Clear();
                MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pic_add_ta_Click(object sender, EventArgs e)
        {
            if (tex_Name_TA.Text != "" && tex_Pass_TA.Text != "")
            {
                string StrInsert_PA = "INSERT INTO `Top_administrators` VALUES ('"+null+"','"+ tex_Name_TA .Text+ "','"+ tex_Pass_TA .Text+ "')";
                SetCommand(StrInsert_PA);
                cmd.ExecuteNonQuery();
                FillGridTopAdmin();
                Clear_DataTopAdmin();
                MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pic_updata_ta_Click(object sender, EventArgs e)
        {
            if (tex_num_TA.Text != "")
            {
                string StrInsert_PA = "UPDATE `Top_administrators` SET `TOP_Name`='"+ tex_Name_TA.Text + "',`TOP_Password`='"+ tex_Pass_TA.Text + "' WHERE `TOP_ID`='"+ tex_num_TA.Text + "'";
                cmd.Parameters.Clear();
                SetCommand(StrInsert_PA);
                cmd.ExecuteNonQuery();
                FillGridTopAdmin();
                Clear_DataTopAdmin();
                MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pic_cleare_ta_Click(object sender, EventArgs e)
        {
            Clear_DataTopAdmin();
        }

        private void dataGridView_topAdmin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView_topAdmin.RowsDefaultCellStyle.BackColor = Color.FromArgb(102, 255, 255);
                dataGridView_topAdmin.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_topAdmin_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_topAdmin.CurrentRow != null && dataGridView_topAdmin.SelectedRows.Count > 0)
            {
                tex_num_TA.Text = dataGridView_topAdmin.CurrentRow.Cells[0].Value.ToString();
                tex_Name_TA.Text = dataGridView_topAdmin.CurrentRow.Cells[1].Value.ToString();
                tex_Pass_TA.Text = dataGridView_topAdmin.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void dataGridView_Acc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                dataGridView_Acc.RowsDefaultCellStyle.BackColor = Color.FromArgb(191, 0, 255);
                dataGridView_Acc.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_Acc_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void pic_add_Acc_Click(object sender, EventArgs e)
        {

        }

        private void pic_updata_Acc_Click(object sender, EventArgs e)
        {

        }

        private void pic_Delete_Acc_Click(object sender, EventArgs e)
        {

        }

        private void pic_Clear_Acc_Click(object sender, EventArgs e)
        {
            Clear_Data_Acc();
        }

        private void pic_delete_ta_Click(object sender, EventArgs e)
        {
            try
            {
                if (tex_num_TA.Text != "")
                {
                    SetCommand("DELETE FROM `Top_administrators` WHERE `TOP_ID` = '" + tex_num_TA.Text + "'");
                    cmd.ExecuteNonQuery();
                    FillGridTopAdmin();
                    Clear_DataTopAdmin();
                    MessageBox.Show("Delete successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void AddMasterAcc_Click(object sender, EventArgs e)
        {
            if (SenderEmail.Text != "")
            {
                string StrInsert_PA = "INSERT INTO `sender_mail` VALUES ('" + null + "','" + SenderEmail.Text + "','" + Password.Text + "','" + AsName.Text + "','" + Port.Text + "')";
                cmd.Parameters.Clear();
                SetCommand(StrInsert_PA);
                cmd.ExecuteNonQuery();
                FillGrid_Sender_Account();
                Clear_Data_Sender_Account();
                MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteMasterAcc_Click(object sender, EventArgs e)
        {
            try
            {
                if (SenderEmail.Text != "")
                {
                    SetCommand("DELETE FROM `sender_mail` WHERE `id` = '" + Id_Sender_Account.Text + "'");
                    cmd.ExecuteNonQuery();
                    FillGrid_Sender_Account();
                    Clear_Data_Sender_Account();
                    MessageBox.Show("Delete successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.CurrentRow != null && dataGridView3.SelectedRows.Count > 0)
                {
                    Id_Sender_Account.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                    SenderEmail.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                    Password.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                    AsName.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                    Port.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ClearMasterAcc_Click(object sender, EventArgs e)
        {
            Clear_Data_Sender_Account();
        }

        private void dataGridView_Acc_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_Acc.CurrentRow != null && dataGridView_Acc.SelectedRows.Count > 0)
                {
                    tex_num_Acc.Text = dataGridView_Acc.CurrentRow.Cells[0].Value.ToString();
                    tex_Name_Acc.Text = dataGridView_Acc.CurrentRow.Cells[1].Value.ToString();
                    check_Laboratory.Checked = Convert.ToBoolean(dataGridView_Acc.CurrentRow.Cells[2].Value);
                    check_Incoming_Wheat.Checked = Convert.ToBoolean(dataGridView_Acc.CurrentRow.Cells[3].Value);
                    check_End_Product.Checked = Convert.ToBoolean(dataGridView_Acc.CurrentRow.Cells[4].Value);
                    check_Samples_Product.Checked = Convert.ToBoolean(dataGridView_Acc.CurrentRow.Cells[5].Value);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void pic_add_Acc_Click_1(object sender, EventArgs e)
        {
            if (tex_Name_Acc.Text != "")
            {
                string StrInsert_PA = "INSERT INTO `accounts` VALUES ('" + null + "','" + tex_Name_Acc.Text + "','" + ((check_Laboratory.Checked) ? '1' : '0') + "','" + ((check_Incoming_Wheat.Checked) ? '1' : '0') + "','" + ((check_End_Product.Checked) ? '1' : '0') + "','" + ((check_Samples_Product.Checked) ? '1' : '0') + "','" + ((check_final_product_pasta.Checked) ? '1' : '0') + "')";
                cmd.Parameters.Clear();
                SetCommand(StrInsert_PA);
                cmd.ExecuteNonQuery();
                FillGrid_Acc();
                Clear_Data_Acc();
                MessageBox.Show("Added successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pic_updata_Acc_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tex_Name_Acc.Text != "")
                {
                    string StrInsert_PA = "UPDATE `accounts` SET `Acc_Name`='" + tex_Name_Acc.Text + "',`Laboratory`='" + ((check_Laboratory.Checked) ? '1' : '0') + "',`Incoming_Wheat`='" + ((check_Incoming_Wheat.Checked) ? '1' : '0') + "',`End_Product`='" + ((check_End_Product.Checked) ? '1' : '0') + "',`Samples_Product`='" + ((check_Samples_Product.Checked) ? '1' : '0') + "', `final_product_pasta` = '" + ((check_final_product_pasta.Checked) ? '1' : '0') + "' WHERE `Acc_ID` ='" + tex_num_Acc.Text + "'";
                    //cmd.Parameters.Clear();
                    SetCommand(StrInsert_PA);
                    cmd.ExecuteNonQuery();
                    FillGrid_Acc();
                    Clear_Data_Acc();
                    MessageBox.Show("Edited successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void pic_Delete_Acc_Click_1(object sender, EventArgs e)
        {
                        try
            {
                if (tex_num_Acc.Text != "")
                {
                    SetCommand("DELETE FROM `accounts` WHERE `Acc_ID` = '"+ tex_num_Acc .Text+ "'");
                    cmd.ExecuteNonQuery();
                    FillGrid_Acc();
                    Clear_Data_Acc();
                    MessageBox.Show("Delete successfully ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("You have empty fields ...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pic_Clear_Acc_Click_1(object sender, EventArgs e)
        {
            Clear_Data_Acc();
        }
    }
}
