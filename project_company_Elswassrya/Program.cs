using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace project_company_Elswassrya
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string strprocess = Process.GetCurrentProcess().ProcessName;
            //Array
            Process[] processes = Process.GetProcessesByName(strprocess);
            if(processes.Length > 1)
            {
                MessageBox.Show("Already Openning ...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Form());
        }
    }
}
