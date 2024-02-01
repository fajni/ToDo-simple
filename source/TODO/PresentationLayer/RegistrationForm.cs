using BusinessLayer;
using Shared.Models;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class RegistrationForm : Form
    {

        public UserBusiness userBusiness;

        public RegistrationForm()
        {
            userBusiness = new UserBusiness();
            InitializeComponent();
        }

        public void ClearFields()
        {
            if(txt_Name.Text == "" && txt_Lastname.Text == "" && txt_Password.Text == "" && txt_ConfirmPassword.Text == "")
            {
                MessageBox.Show("All fields are already empty!", "Notification", MessageBoxButtons.OK);
            }

            txt_Name.Text = "";
            txt_Lastname.Text = "";
            txt_Password.Text = "";
            txt_ConfirmPassword.Text = "";
        }

        private void lbl_BackToLogin_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ShowPassword.Checked)
            {
                txt_Password.PasswordChar = '\0';
                txt_ConfirmPassword.PasswordChar= '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';
                txt_ConfirmPassword.PasswordChar = '*';
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            if(txt_Name.Text == "" || txt_Lastname.Text == "" || txt_Password.Text == "" || txt_ConfirmPassword.Text == "")
            {
                MessageBox.Show("Empty Fields Are Not Allowed!", "Registration Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txt_Password.Text != txt_ConfirmPassword.Text)
            {
                MessageBox.Show("Passwords Does Not Match! Please Re-enter!", "Registration Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = txt_Name.Text;
            string lastname = txt_Lastname.Text;
            string password = txt_Password.Text;

            foreach(var user in userBusiness.GetAllUsers())
            {
                if(user.GetSetName == name && user.GetSetLastname == lastname)
                {
                    MessageBox.Show("User "+name+" "+lastname+" already exist!", "Registration Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            User newUser = new User(name, lastname, password);
            userBusiness.InsertUser(newUser);
            MessageBox.Show("Added new \""+name+" "+lastname+"\" user");
            new LoginForm().Show();
            this.Hide();
        }
    }
}
