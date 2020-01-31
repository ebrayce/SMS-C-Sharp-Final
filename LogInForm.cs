using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SMS.Controller;
using SMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class LogInForm : Form
    {
        private bool isAdmin()
        {
            //Username: Administrator
            //Password: AdminPas$w0rd

            return  getPassword() == "AdminPas$w0rd" && getUserName() == "Administrator";
            
        }

        public User user;
        private void clearInput()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        public void showErrorMessage()
        {
            if(getUserName() == "")
            {
                lbWrongUsername.Show();
            }
            else
            {
                lbWrongUsername.Hide();
            }
            if (getPassword() == "")
            {
                lbWrongPassword.Show();
            }
            else
            {
                lbWrongPassword.Hide();
            }
        }

        public bool validateInput()
        {
            if(getPassword() != "" && getUserName() != "")
            {
                return true;
            }
            
            return false;
        }

        public String getUserName()
        {
            return txtUsername.Text;
        }

        public String getPassword()
        {
            return txtPassword.Text;
        }

        public void logInUser()
        {


        }

        public LogInForm()
        {
            InitializeComponent();
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            btnLogIn.Enabled = false;
            showErrorMessage();

            if (validateInput())
            {
                user = HomeController.logIn(getUserName(), getPassword());

                
                if(user == null && isAdmin())
                {
                    User user = new User
                    {
                        //Username: Administrator
                        //Password: AdminPas$w0rd

                        Username = "Administrator",
                        Password = "AdminPas$w0rd",
                        Name = "Main Administrator"
                    };
                    UsersController.createUser(user);
                }

                //if (user != null || true)
                if (user != null ||  isAdmin())
                {
                    
                    MainForm mainForm = new MainForm();
                    Hide();
                    mainForm.Show();
                }
                else
                {
                   
                    lbLogInError.Show();
                    btnLogIn.Enabled = true;

                }
            }

            btnLogIn.Enabled = true;

        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            

        }
    }
}
