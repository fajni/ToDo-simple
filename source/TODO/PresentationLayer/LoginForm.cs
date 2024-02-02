using BusinessLayer;
using Shared.Models;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        public UserBusiness userBusiness;

        public LoginForm()
        {
            userBusiness = new UserBusiness();
            InitializeComponent();
        }

        public void ClearFields()
        {
            if (txt_Name.Text == "" && txt_Lastname.Text == "" && txt_Password.Text == "")
                MessageBox.Show("All fields are already empty!", "Notification", MessageBoxButtons.OK);
            txt_Name.Text = string.Empty;
            txt_Lastname.Text = string.Empty;
            txt_Password.Text = string.Empty;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void lbl_Login_Click(object sender, EventArgs e)
        {
            new RegistrationForm().Show();
            this.Hide();
        }

        
        private void checkBox_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_ShowPassword.Checked)
            {
                txt_Password.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';
            }
        }
        

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if(txt_Name.Text == "" || txt_Lastname.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Empty Fields Are Not Allowed!", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach(User user in userBusiness.GetAllUsers())
            {
                if (user.GetSetName == txt_Name.Text && user.GetSetLastname == txt_Lastname.Text && user.GetSetPassword == txt_Password.Text)
                {
                    ClearFields();
                    //new ObligationsForm().Show();
                    //new UserForm(user).Show();
                    new MainForm(user).Show();
                    MessageBox.Show("Login Successfull!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    return;
                }
            }

            MessageBox.Show("Invalid Username or Password!", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
