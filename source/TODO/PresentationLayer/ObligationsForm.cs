using BusinessLayer;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ObligationsForm : Form
    {

        private User user;
        private ObligationBusiness obligationBusiness;

        public ObligationsForm(User user)
        {
            InitializeComponent();
            this.obligationBusiness = new ObligationBusiness();
            this.user = user;
        }

        public void ClearFields()
        {
            lbl_Id.Text = string.Empty;
            txt_Title.Text = "";
            txt_Note.Text = string.Empty;
            dateTimePicker.Value = DateTime.Now;
        }

        public void SetFields(DataGridViewCellEventArgs e)
        {
            //dataGridView_Obligations.Rows.Clear();
            var selectedValue = dataGridView_Obligations.Rows[e.RowIndex];
            lbl_Id.Text = selectedValue.Cells[0].Value.ToString();
            txt_Title.Text = selectedValue.Cells[1].Value.ToString();
            txt_Note.Text = selectedValue.Cells[3].Value.ToString();
            dateTimePicker.Text = DateTime.Parse(selectedValue.Cells[2].Value.ToString()).ToString();
        }

        public void SetDataGridViewItems()
        {
            dataGridView_Obligations.Rows.Clear();
            foreach (var obligation in obligationBusiness.GetObligationsByUserId(user.GetSetUserId))
            {
                dataGridView_Obligations.Rows.Add(obligation.GetSetId, obligation.GetSetTitle, obligation.GetSetDate, obligation.GetSetNote);
            }

        }

        private void ObligationsForm_Load(object sender, System.EventArgs e)
        {
            /*
            dataGridView_Obligations.DataSource = obligationBusiness.GetObligationsByUserId(user.GetSetUserId);
            dataGridView_Obligations.Columns["GetSetUserId"].Visible = false;
            dataGridView_Obligations.Columns["GetSetId"].DataPropertyName = "OBLIGATION ID";
            */

            SetDataGridViewItems();

        }

        private void dataGridView_Obligations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SetFields(e);
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            if(txt_Title.Text == "")
            {
                MessageBox.Show("Empty Title Field Is Not Allowed!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string title = txt_Title.Text;
            DateTime date = dateTimePicker.Value;
            string note = txt_Note.Text;
            if (note == "")
                note = "/";

            Obligation newObligation = new Obligation(user.GetSetUserId, title, date, note);
            obligationBusiness.InsertObligation(newObligation);
            
            ClearFields();
            SetDataGridViewItems();

            MessageBox.Show("Added New Obligation!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Title.Text == "" || lbl_Id.Text == "")
            {
                MessageBox.Show("Empty Title Field Is Not Allowed!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string title = txt_Title.Text;
            DateTime date = dateTimePicker.Value;
            string note = txt_Note.Text;
            if (note == "")
                note = "/";
            int obligation_id = Convert.ToInt32(lbl_Id.Text);
            Obligation newObligation = new Obligation(user.GetSetUserId, title, date, note);
            newObligation.GetSetId = obligation_id;
            obligationBusiness.UpdateObligation(newObligation);

            ClearFields();
            SetDataGridViewItems();

            MessageBox.Show("Updated "+newObligation.GetSetTitle+" obligation!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Title.Text == "" || lbl_Id.Text == "")
            {
                MessageBox.Show("Empty Title Field Is Not Allowed!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Obligation delete = new Obligation();

            foreach (var obligation in obligationBusiness.GetObligationsByUserId(user.GetSetUserId))
            {
                if (obligation.GetSetId == Convert.ToInt32(lbl_Id.Text))
                {
                    delete = obligation;
                }
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete obligation with id: " + delete.GetSetId + "?", "Delete Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                obligationBusiness.DeleteObligation(delete.GetSetId);

                ClearFields();
                SetDataGridViewItems();

                MessageBox.Show("Deleted Obligation With ID " + delete.GetSetId + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearFields();
        }

        private void checkBox_Search_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Search.Checked == true)
            {
                List<Obligation> obligations = new List<Obligation>();
                foreach (Obligation obligation in obligationBusiness.GetObligationsByUserId(user.GetSetUserId))
                {
                    obligations.Add(obligation);
                }

                dataGridView_Obligations.Rows.Clear();

                for (int i = 0; i < obligations.Count; i++)
                {
                    if (obligations[i].GetSetTitle.Contains(txt_Search.Text))
                    {
                        dataGridView_Obligations.Rows.Add(obligations[i].GetSetId, obligations[i].GetSetTitle, obligations[i].GetSetDate, obligations[i].GetSetNote);
                    }
                }
            }
            else
            {
                SetDataGridViewItems();
            }
        }
    }
}
