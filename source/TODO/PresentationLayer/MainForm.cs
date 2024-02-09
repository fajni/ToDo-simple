using Shared.Models;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        private User user;
        public MainForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Account_Click(object sender, EventArgs e)
        {
            new UserForm(user).Show();
            //this.Hide();
        }

        private void btn_Obligations_Click(object sender, EventArgs e)
        {
            new ObligationsForm(user).Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
