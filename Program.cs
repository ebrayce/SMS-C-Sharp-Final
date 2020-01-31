using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Windows.Forms;

namespace SMS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LogInForm logInForm = new LogInForm();
            Application.Run(logInForm);

            //MainForm mainForm = new MainForm();
            //Application.Run(mainForm);

        }
    }
}
