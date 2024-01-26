using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
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
    }
}
