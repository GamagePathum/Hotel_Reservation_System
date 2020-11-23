using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class ManageClientsForm : Form
    {
        CLIENT client = new CLIENT();
        public ManageClientsForm()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtCountry.Text = "";
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            String fname = txtFirstName.Text;
            String lname = txtLastName.Text;
            String phone = txtPhone.Text;
            String country = txtCountry.Text;

            if(fname.Trim().Equals("") || lname.Trim().Equals("") || phone.Trim().Equals(""))
            {
                MessageBox.Show("Fill the First Name,Last Name and Phone Number", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean insertClient = client.insertClient(fname, lname, phone, country);

                if (insertClient)
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("New Client Inserted Succsessfully!!", "Add Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERORR-Client Not Inserted!!", "Add Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ManageClientsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClients();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id;
            String fname = txtFirstName.Text;
            String lname = txtLastName.Text;
            String phone = txtPhone.Text;
            String country = txtCountry.Text;

            try
            {
                id = Convert.ToInt32(txtID.Text);

                if (fname.Trim().Equals("") || lname.Trim().Equals("") || phone.Trim().Equals(""))
                {
                    MessageBox.Show("Fill the First Name,Last Name and Phone Number", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean insertClient = client.editClients(id, fname, lname, phone, country);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = client.getClients();
                        MessageBox.Show("New Client Updated Succsessfully!!", "Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERORR-Client Updated!!", "Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtCountry.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtID.Text);

                
                if (client.removeClient(id))
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Client Deleted Succsessfully!!", "Delete Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                }
                else
                {
                    MessageBox.Show("ERORR-Client Deleted!!", "Delete Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
