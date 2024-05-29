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
/*using System.Net;
using System.Net.Mail;*/
//using System.IO;
using MailKit.Net.Smtp;
//using MailKit;
using MimeKit;
//using Aspose.Cells;

namespace project_company_Elswassrya
{
    public partial class Form_SendMessage : Form
    {
        string Laboratory_Num = "";
        string Incoming_Wheat_Num = "";
        string End_Product_Num = "";
        string Samples_Product = "";
        string final_product_pasta = "";
        string Email = "";
        string Mail_Send = "";
        string Password_Send = "";
        string MailName = "";
        int Port = 587;
        string TargetAttachmint = "";

        public Form_SendMessage()
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
        private void Laboratory_Fan(string num, string Email,int chackSend)
        {//Send Report to Mail
            int CKACKSEND = chackSend++;
            if (num == "True" && CKACKSEND <= comboBox.Items.Count)
            {//Class1.Path_Report_Laboratory
                MimeMessage message = new MimeMessage();
                BodyBuilder Attachmint = new BodyBuilder();
                message.From.Add(new MailboxAddress(MailName, Mail_Send));
                message.To.Add(MailboxAddress.Parse(Email));
                message.Subject = "Laboratory";
                message.Body = new TextPart("plain")
                {
                    Text = @""
                };
                Attachmint.Attachments.Add(Class1.Path_Report_Laboratory);
                message.Body = Attachmint.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", Port, true);
                client.Authenticate(Mail_Send, Password_Send);
                client.Send(message);
                Status_Panel.Visible = true;

            }
            else
            {
               
            }
        }

        private void Incoming_Wheat_fan(string num, string Email, int chackSend)
        {//Send Report to Mail
            
            try
             {
                int CKACKSEND = chackSend++;
                if (Class1.Path_Report_Incoming_Wheat.Substring(0, 50) == @"C:\StorgePDF\Incoming_Wheat_Avrage_Humidity_Month_")
                {
                    TargetAttachmint = Class1.Path_Report_Incoming_Wheat;
                }
                else
                {
                    string[] ExclConvert = Class1.Path_Report_Incoming_Wheat.Split('$'); // split the path of file ([0] is Excel file , [1] is pdf file )

                    string[] names = Email.Split('.');
                    if (Email == "beshoy.bekheet@egyptianswiss.com")// ‫beshoy.bekheet@egyptianswiss.com
                    {
                        TargetAttachmint = ExclConvert[0]; //As Excel file
                    }
                    else
                    {
                        TargetAttachmint = ExclConvert[1]; //As PDF file
                    }

                    if (rad_excel.Checked)
                        TargetAttachmint = ExclConvert[0];
                    else if(rad_pdf.Checked)
                        TargetAttachmint = ExclConvert[1];
                }


                if (num == "True")
                {
                    MimeMessage message = new MimeMessage();
                    BodyBuilder Attachmint = new BodyBuilder();
                    message.From.Add(new MailboxAddress(MailName, Mail_Send));
                    message.To.Add(MailboxAddress.Parse(Email));
                    message.Subject = "Incoming Wheat";
                    message.Body = null;
                    message.Body = new TextPart("plain")
                    {
                        Text = @""
                    };
                    Attachmint.Attachments.Add(TargetAttachmint);
                    message.Body = Attachmint.ToMessageBody();

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", Port, true);
                    client.Authenticate(Mail_Send, Password_Send);
                    client.Send(message);
                    Status_Panel.Visible = true;


                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void End_Product_fan(string num, string Email, int chackSend)
        {//Send Report to Mail
            int CKACKSEND = chackSend++;
            if (num == "True" && CKACKSEND <= comboBox.Items.Count)
            {
                try
                {
                    MimeMessage message = new MimeMessage();
                    BodyBuilder Attachmint = new BodyBuilder();
                    message.From.Add(new MailboxAddress(MailName, Mail_Send));
                    message.To.Add(MailboxAddress.Parse(Email));
                    message.Subject = "End Product";
                    message.Body = new TextPart("plain")
                    {
                        Text = @""
                    };
                    Attachmint.Attachments.Add(Class1.Path_Report_End_Product);
                    message.Body = Attachmint.ToMessageBody();

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", Port,true);
                    client.Authenticate(Mail_Send, Password_Send);
                    client.Send(message);
                    Status_Panel.Visible = true;
                }catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
               
            }
        }
        private void Avrage_Humidity_Month_fan(string num, string Email, int chackSend)
        {//Send Report to Mail
            int CKACKSEND = chackSend++;
            if (num == "True" && CKACKSEND <= comboBox.Items.Count)
            {
                MimeMessage message = new MimeMessage();
                BodyBuilder Attachmint = new BodyBuilder();
                message.From.Add(new MailboxAddress(MailName, Mail_Send));
                message.To.Add(MailboxAddress.Parse(Email));
                message.Subject = "Avrage Humidity Month";
                message.Body = new TextPart("plain")
                {
                    Text = @""
                };
                Attachmint.Attachments.Add(Class1.Path_Report_Aveage_Month);
                message.Body = Attachmint.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", Port, true);
                client.Authenticate(Mail_Send, Password_Send);
                client.Send(message);
                Status_Panel.Visible = true;

            }
            else
            {

            }
        }
        private void Samples_Product_fan(string num, string Email, int chackSend)
        {//Send Report to Mail
            //MessageBox.Show("Mail_Send =" + Mail_Send + " Password_Send = " + Password_Send + " MailName=" + MailName + " Port=" + Port);
            int CKACKSEND = chackSend++;
            if (num == "True" && CKACKSEND <= comboBox.Items.Count)
            {
                MimeMessage message = new MimeMessage();
                BodyBuilder Attachmint = new BodyBuilder();
                message.From.Add(new MailboxAddress(MailName, Mail_Send));
                message.To.Add(MailboxAddress.Parse(Email));
                message.Subject = "Samples Product";
                message.Body = new TextPart("plain")
                {
                    Text = @""
                };
                Attachmint.Attachments.Add(Class1.Path_Report_Samples_Product);
                message.Body = Attachmint.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", Port, true);
                client.Authenticate(Mail_Send, Password_Send);
                client.Send(message);
                Status_Panel.Visible = true;

            }
            else
            {
               
            }

        }

        private void final_product_pasta_Fan(string num, string Email, int chackSend)
        {//Send Report to Mail
            int CKACKSEND = chackSend++;
            if (num == "True" && CKACKSEND <= comboBox.Items.Count)
            {
                MimeMessage message = new MimeMessage();
                BodyBuilder Attachmint = new BodyBuilder();
                message.From.Add(new MailboxAddress(MailName, Mail_Send));
                message.To.Add(MailboxAddress.Parse(Email));
                message.Subject = "final product pasta";
                message.Body = new TextPart("plain")
                {
                    Text = @""
                };
                Attachmint.Attachments.Add(Class1.path_Report_Final_Product_Pasta);
                message.Body = Attachmint.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", Port, true);
                client.Authenticate(Mail_Send, Password_Send);
                client.Send(message);
                Status_Panel.Visible = true;

            }
            else
            {

            }

        }
        private void Iprovement(string num, string Email, int chackSend)
        {//Send Report to Mail
            int CKACKSEND = chackSend++;
            if (num == "True" && CKACKSEND <= comboBox.Items.Count)
            {
                MimeMessage message = new MimeMessage();
                BodyBuilder Attachmint = new BodyBuilder();
                message.From.Add(new MailboxAddress(MailName, Mail_Send));
                message.To.Add(MailboxAddress.Parse(Email));
                message.Subject = "Iprovement";
                message.Body = new TextPart("plain")
                {
                    Text = @""
                };
                Attachmint.Attachments.Add(Class1.Path_Report_Improvement);
                message.Body = Attachmint.ToMessageBody();

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", Port, true);
                client.Authenticate(Mail_Send, Password_Send);
                client.Send(message);
                Status_Panel.Visible = true;
               
            }
            else
            {

            }

        }
        private void Form_SendMessage_Load(object sender, EventArgs e)
        {
            //fill combobox to data Emails
            con.Open();
            if (Class1.Path_Report_Incoming_Wheat != "")
            {
                if (Class1.Path_Report_Incoming_Wheat.Substring(0, 50) != @"C:\StorgePDF\Incoming_Wheat_Avrage_Humidity_Month_")
                {
                    rad_excel.Visible = true;
                    rad_pdf.Visible = true;
                }
            }
            Status_Panel.Visible = false;
            var query = "SELECT `Acc_Name` FROM `accounts` ";
            using (var command = new MySqlCommand(query, con))
            {
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {//using loop  to fill data acunts
                        comboBox.Items.Add(reader.GetString("Acc_Name"));
                    }
                }
            }
            query = "SELECT * FROM `sender_mail` ORDER by id ASC LIMIT 1";
            using (var command = new MySqlCommand(query, con))
            {
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {//using loop  to fill data acunts
                        Mail_Send = reader.GetString("email");
                        Password_Send = reader.GetString("password");
                        MailName = reader.GetString("as_name");
                        Port = int.Parse(reader.GetString("port"));
                    }
                }
            }

            //MessageBox.Show("Mail_Send =" + Mail_Send + " Password_Send = " + Password_Send + " MailName=" + MailName + " Port=" + Port);
            Timer_Set2.Start();

        }

        private void Timer_ELapsed(object sender, ElapsedEventArgs e)
        {
        
            
        }



        private void btn_Send_Click(object sender, EventArgs e)
        {
            MimeMessage message = new MimeMessage();
            BodyBuilder Attachmint = new BodyBuilder();
            message.From.Add(new MailboxAddress(MailName, Mail_Send));
            message.To.Add(MailboxAddress.Parse(Email));
            message.Subject = "Report";
            message.Body = new TextPart("plain")
            {
                Text = @""
            };
            Attachmint.Attachments.Add(Class1.Path_Report_Improvement);
            message.Body = Attachmint.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", Port, true);
            client.Authenticate(Mail_Send, Password_Send);
            client.Send(message);
            Status_Panel.Visible = true;
        }
        private void link_Attachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //openFileDialog1.ShowDialog();
            //foreach (string filename in openFileDialog1.FileNames)
            //{
            //    MessageBox.Show(filename);
            //    label_Path.Text = filename.ToString();
            //}
        }

        private void timer_Now_Tick(object sender, EventArgs e)
        {
            LbTimer.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");

        }

        private void Timer_Set2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (LbTimer.Text == "08:01:00"  || LbTimer.Text == "08:03:00" || LbTimer.Text == "08:05:00" || LbTimer.Text == "08:07:00" || LbTimer.Text == "08:09:00" || LbTimer.Text == "08:11:00")
                {
                    if (Class1.Path_Report_Incoming_Wheat != "")
                    {
                        for (int i = 0; i < comboBox.Items.Count; i++)
                        {
                            var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                            using (var command = new MySqlCommand(query, con))
                            {
                                using (var reader = command.ExecuteReader())
                                {

                                    while (reader.Read())
                                    {


                                        Incoming_Wheat_Num = reader.GetString("Incoming_Wheat");


                                    }

                                    Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 

                                    Incoming_Wheat_fan(Incoming_Wheat_Num, Email,i);

                                }

                            }
                        }
                        Class1.Path_Report_Incoming_Wheat = "";
                        this.Hide();
                    }
                    else if (Class1.Path_Report_End_Product != "")
                    {
                        for (int i = 0; i < comboBox.Items.Count; i++)
                        {
                            var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                            using (var command = new MySqlCommand(query, con))
                            {
                                using (var reader = command.ExecuteReader())
                                {

                                    while (reader.Read())
                                    {
                                        End_Product_Num = reader.GetString("End_Product");
                                    }

                                    Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                    End_Product_fan(End_Product_Num, Email,i);

                                }

                            }
                        }
                        Class1.Path_Report_End_Product = "";
                        this.Hide();
                    }
                    else if (Class1.Path_Report_Samples_Product != "")
                    {
                        for (int i = 0; i < comboBox.Items.Count; i++)
                        {
                            var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                            using (var command = new MySqlCommand(query, con))
                            {
                                using (var reader = command.ExecuteReader())
                                {

                                    while (reader.Read())
                                    {
                                        Samples_Product = reader.GetString("Samples_Product");
                                    }

                                    Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                    Samples_Product_fan(Samples_Product, Email,i);
                                }

                            }
                        }
                        Class1.Path_Report_Samples_Product = "";
                        this.Hide();
                    }
                    else if (Class1.Path_Report_Laboratory != "")
                    {
                        for (int i = 0; i < comboBox.Items.Count; i++)
                        {
                            var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                            using (var command = new MySqlCommand(query, con))
                            {
                                using (var reader = command.ExecuteReader())
                                {

                                    while (reader.Read())
                                    {

                                        Laboratory_Num = reader.GetString("Laboratory");
                                    }

                                    Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                    Laboratory_Fan(Laboratory_Num, Email,i);
                                }

                            }
                        }
                        Class1.Path_Report_Laboratory = "";
                        this.Hide();
                    }
                    else if (Class1.path_Report_Final_Product_Pasta != "")
                    {
                        for (int i = 0; i < comboBox.Items.Count; i++)
                        {
                            var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                            using (var command = new MySqlCommand(query, con))
                            {
                                using (var reader = command.ExecuteReader())
                                {

                                    while (reader.Read())
                                    {

                                        final_product_pasta = reader.GetString("final_product_pasta");
                                    }

                                    Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                    final_product_pasta_Fan(final_product_pasta, Email, i);
                                }

                            }
                        }
                        Class1.path_Report_Final_Product_Pasta = "";
                        this.Hide();
                    }
                    else if (Class1.Path_Report_Aveage_Month != "")
                    {
                        for (int i = 0; i < comboBox.Items.Count; i++)
                        {
                            var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                            using (var command = new MySqlCommand(query, con))
                            {
                                using (var reader = command.ExecuteReader())
                                {

                                    while (reader.Read())
                                    {

                                        End_Product_Num = reader.GetString("End_Product");
                                    }

                                    Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                    Avrage_Humidity_Month_fan(End_Product_Num, Email, i);
                                }

                            }
                        }
                        Class1.Path_Report_Aveage_Month = "";
                        this.Hide();
                    }
                    Timer_Set2.Stop();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Send_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btn_SendAll_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class1.Path_Report_Incoming_Wheat != "")
                {
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                        using (var command = new MySqlCommand(query, con))
                        {
                            using (var reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {


                                    Incoming_Wheat_Num = reader.GetString("Incoming_Wheat");


                                }

                                Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                //MessageBox.Show(Incoming_Wheat_Num+" , "+ Email+" , "+ i);

                                Incoming_Wheat_fan(Incoming_Wheat_Num, Email, i);

                            }

                        }
                    }
                    Class1.Path_Report_Incoming_Wheat = "";
                    this.Hide();
                }
                else if (Class1.Path_Report_End_Product != "")
                {
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                        using (var command = new MySqlCommand(query, con))
                        {
                            using (var reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    End_Product_Num = reader.GetString("End_Product");
                                }

                                Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                End_Product_fan(End_Product_Num, Email, i);

                            }

                        }
                    }
                    Class1.Path_Report_End_Product = "";
                    this.Hide();
                }
                else if (Class1.Path_Report_Samples_Product != "")
                {
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                        using (var command = new MySqlCommand(query, con))
                        {
                            using (var reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    Samples_Product = reader.GetString("Samples_Product");
                                }

                                Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                Samples_Product_fan(Samples_Product, Email, i);
                            }

                        }
                    }
                    Class1.Path_Report_Samples_Product = "";
                    this.Hide();
                }
                else if (Class1.Path_Report_Laboratory != "")
                {
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                        using (var command = new MySqlCommand(query, con))
                        {
                            using (var reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {

                                    Laboratory_Num = reader.GetString("Laboratory");
                                }

                                Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 


                                Laboratory_Fan(Laboratory_Num, Email, i);
                            }

                        }
                    }
                    Class1.Path_Report_Laboratory = "";
                    this.Hide();
                }
                else if (Class1.path_Report_Final_Product_Pasta != "")
                {
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                        using (var command = new MySqlCommand(query, con))
                        {
                            using (var reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {

                                    final_product_pasta = reader.GetString("final_product_pasta");
                                }

                                Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                final_product_pasta_Fan(final_product_pasta, Email, i);
                            }

                        }
                    }
                    Class1.path_Report_Final_Product_Pasta = "";
                    this.Hide();
                }
                else if (Class1.Path_Report_Aveage_Month != "")
                {
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        var query = "SELECT * FROM `accounts` WHERE `Acc_Name` = '" + comboBox.Items[i] + "'";

                        using (var command = new MySqlCommand(query, con))
                        {
                            using (var reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {

                                    End_Product_Num = reader.GetString("End_Product");
                                }

                                Email = comboBox.Items[i].ToString(); //convert the funiction to value to send it 
                                Avrage_Humidity_Month_fan(End_Product_Num, Email, i);
                            }

                        }
                    }
                    Class1.Path_Report_Aveage_Month = "";
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Class1.Path_Report_Incoming_Wheat != "")
                {
                    Incoming_Wheat_fan("True", comboBox.SelectedItem.ToString(), 1);
                }
                else if (Class1.Path_Report_End_Product != "")
                {
                    End_Product_fan("True", comboBox.SelectedItem.ToString(), 1);
                }
                else if (Class1.Path_Report_Samples_Product != "")
                {
                    Samples_Product_fan("True", comboBox.SelectedItem.ToString(), 1);
                }
                else if (Class1.Path_Report_Laboratory != "")
                {
                    Laboratory_Fan("True", comboBox.SelectedItem.ToString(), 1);
                }
                else if (Class1.path_Report_Final_Product_Pasta != "")
                {
                    final_product_pasta_Fan("True", comboBox.SelectedItem.ToString(), 1);
                }
                else if (Class1.Path_Report_Improvement != "")
                {
                    Iprovement("True", comboBox.SelectedItem.ToString(), 1);
                }
                else if (Class1.Path_Report_Aveage_Month != "")
                {
                    Avrage_Humidity_Month_fan("True", comboBox.SelectedItem.ToString(), 1);
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
