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



namespace project_company_Elswassrya
{
    public partial class Login_Form : Form
    {
        
        public Login_Form()
        {
            InitializeComponent();
            //this.TransparencyKey = (BackColor);

        }
        MySqlConnection con = new MySqlConnection("datasource=172.16.2.104;port=3306;server=localhost;database=project_company;uid=root;password=;sslmode=none;charset=utf8;");
        MySqlCommand cmd = new MySqlCommand();
        

        private void SetCommand(string SQL)
        {
            cmd.Connection = con;
            cmd.CommandText = SQL;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Login_Click_1(object sender, EventArgs e)
        {
           
            int count = 0;
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT COUNT(*) FROM users WHERE users_Name = '" + tex_UserName.Text + "' && users_Password = '" + tex_Password.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[0][0]) == i)
                {


                    //string StrInsert_PA = "INSERT INTO `data_test` VALUES ('" + null + "','" + tex_UserName.Text + "','" + tex_Password.Text + "','" + "User" + "')";
                    //cmd.Parameters.Clear();
                    //SetCommand(StrInsert_PA);
                    //cmd.ExecuteNonQuery();
                    Class1.NamePass = tex_UserName.Text;
                    Class1.TypeUser = "User";
                    this.Hide();
                    form_project fp = new form_project();
                    fp.Show();
                }
                else
                {
                    count++;
                }
            }



            sda = new MySqlDataAdapter("SELECT COUNT(*) FROM administrator WHERE admin_Name = '" + tex_UserName.Text + "' && admin_Password = '" + tex_Password.Text + "'", con);
            dt = new DataTable();
            sda.Fill(dt);
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[0][0]) == i)
                {

                    //string StrInsert_PA = "INSERT INTO `data_test` VALUES ('" + null + "','" + tex_UserName.Text + "','" + tex_Password.Text + "','" + "Administrator" + "')";
                    //cmd.Parameters.Clear();
                    //SetCommand(StrInsert_PA);
                    //cmd.ExecuteNonQuery();
                    Class1.NamePass = tex_UserName.Text;
                    Class1.TypeUser = "Administrator";
                    this.Hide();
                    form_project fp = new form_project();
                    fp.Show();
                }
                else
                {
                    count++;
                }
            }




            sda = new MySqlDataAdapter("SELECT COUNT(*) FROM `top_administrators` WHERE `TOP_Name` = '" + tex_UserName.Text + "' && `TOP_Password` = '" + tex_Password.Text + "'", con);
            dt = new DataTable();
            sda.Fill(dt);
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[0][0]) == i)
                {

                    //string StrInsert_PA = "INSERT INTO `data_test` VALUES ('" + null + "','" + tex_UserName.Text + "','" + tex_Password.Text + "','" + "top_administrators" + "')";
                    //cmd.Parameters.Clear();
                    //SetCommand(StrInsert_PA);
                    //cmd.ExecuteNonQuery();
                    Class1.NamePass = tex_UserName.Text;
                    Class1.TypeUser = "top_administrators";
                    this.Hide();
                    form_project fp = new form_project();
                    fp.Show();
                }
                else
                {
                    count++;
                }
            }



            if (count >= 3)
            {
                MessageBox.Show("the User Name or Password are Wroing ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                count = 0;
            }
            count = 0;
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Login_App()
        {
            try
            {
                int count = 0;
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT COUNT(*) FROM users WHERE users_Name = '" + tex_UserName.Text + "' && users_Password = '" + tex_Password.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[0][0]) == i)
                    {


                        //string StrInsert_PA = "INSERT INTO `data_test` VALUES ('" + null + "','" + tex_UserName.Text + "','" + tex_Password.Text + "','" + "User" + "')";
                        //cmd.Parameters.Clear();
                        //SetCommand(StrInsert_PA);
                        //cmd.ExecuteNonQuery();
                        Class1.NamePass = tex_UserName.Text;
                        Class1.TypeUser = "User";
                        this.Hide();
                        form_project fp = new form_project();
                        fp.Show();
                    }
                    else
                    {
                        count++;
                    }
                }



                sda = new MySqlDataAdapter("SELECT COUNT(*) FROM administrator WHERE admin_Name = '" + tex_UserName.Text + "' && admin_Password = '" + tex_Password.Text + "'", con);
                dt = new DataTable();
                sda.Fill(dt);
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[0][0]) == i)
                    {

                        //string StrInsert_PA = "INSERT INTO `data_test` VALUES ('" + null + "','" + tex_UserName.Text + "','" + tex_Password.Text + "','" + "Administrator" + "')";
                        //cmd.Parameters.Clear();
                        //SetCommand(StrInsert_PA);
                        //cmd.ExecuteNonQuery();
                        Class1.NamePass = tex_UserName.Text;
                        Class1.TypeUser = "Administrator";
                        this.Hide();
                        form_project fp = new form_project();
                        fp.Show();
                    }
                    else
                    {
                        count++;
                    }
                }




                sda = new MySqlDataAdapter("SELECT COUNT(*) FROM `top_administrators` WHERE `TOP_Name` = '" + tex_UserName.Text + "' && `TOP_Password` = '" + tex_Password.Text + "'", con);
                dt = new DataTable();
                sda.Fill(dt);
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dt.Rows[0][0]) == i)
                    {

                        //string StrInsert_PA = "INSERT INTO `data_test` VALUES ('" + null + "','" + tex_UserName.Text + "','" + tex_Password.Text + "','" + "top_administrators" + "')";
                        //cmd.Parameters.Clear();
                        //SetCommand(StrInsert_PA);
                        //cmd.ExecuteNonQuery();
                        Class1.NamePass = tex_UserName.Text;
                        Class1.TypeUser = "top_administrators";
                        this.Hide();
                        form_project fp = new form_project();
                        fp.Show();
                    }
                    else
                    {
                        count++;
                    }
                }



                if (count >= 3)
                {
                    MessageBox.Show("the User Name or Password are Wroing ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    count = 0;
                }
                count = 0;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login_App();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tex_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login_App();
            }
        }

        private void tex_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_App();
            }
        }
    }
}
