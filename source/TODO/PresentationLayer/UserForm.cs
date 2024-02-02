using Shared.Models;
using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class UserForm : Form
    {
        private User user;

        public UserForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
        }

        private void lbl_Logout_Click(object sender, EventArgs e)
        {
            
        }
    }
}
