using BusinessLayer;
using Shared.Models;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class UserForm : Form
    {
        private User user;
        private UserBusiness userBusiness;

        public UserForm(User user)
        {
            InitializeComponent();
            this.user = user;
            this.userBusiness = new UserBusiness();
        }

        private void SetFields()
        {
            lbl_NameLastname.Text = user.GetSetName + " " + user.GetSetLastname;
            lbl_Id.Text = user.GetSetUserId.ToString();
            txt_Name.Text = user.GetSetName;
            txt_Lastname.Text = user.GetSetLastname;
            txt_Password.Text = user.GetSetPassword;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            SetFields();
        }

        private void lbl_Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].Name != "LoginForm")
                    {
                        Application.OpenForms[i].Hide();
                    }
                }
            }
            new LoginForm().Show();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if(txt_Name.Text == "" || txt_Lastname.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Empty Fields Are Not Allowed!", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user.GetSetName = txt_Name.Text;
            user.GetSetLastname = txt_Lastname.Text;
            user.GetSetPassword = txt_Password.Text;

            userBusiness.UpdateUser(user);

            SetFields();
            MessageBox.Show("Updated " + user.GetSetUserId + " user!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete account: " + user.GetSetUserId + "?", "Delete Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                userBusiness.DeleteUser(user.GetSetUserId);

                // TODO: Also delete User's Obligations

                MessageBox.Show("Deleted User With ID " + user.GetSetUserId + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i].Name != "LoginForm")
                    {
                        Application.OpenForms[i].Hide();
                    }
                }
            }
            new LoginForm().Show();
        }

        private void checkBox_Password_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Password.Checked)
            {
                txt_Password.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';
            }
        }
    }
}