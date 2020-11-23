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
    public partial class ManageRoomsForm : Form
    {
        ROOM room = new ROOM();

        public ManageRoomsForm()
        {
            InitializeComponent();
        }

        private void ManageRoomsForm_Load(object sender, EventArgs e)
        {
            cmBoxRoomType.DataSource = room.roomTypeList();
            cmBoxRoomType.DisplayMember = "label";
            cmBoxRoomType.ValueMember = "category_id";

            dataGridView1.DataSource = room.getRooms();
        }

        private void btnAddNewRoom_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(cmBoxRoomType.SelectedValue.ToString());
            String phone = txtPhone.Text;
            String free = "";

            try
            {
                int number = Convert.ToInt32(txtRoomNO.Text);

                if (rbtnYES.Checked)
                {
                    free = "YES";
                }
                else if (rbtnNO.Checked)
                {
                    free = "NO";
                }

                if (room.addRooms(number, type, phone, free))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("New Room Added Succsess!!", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error-New Room Not Added", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Room number Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRoomNO.Text = "";
            txtPhone.Text = "";
            cmBoxRoomType.SelectedIndex = 0;
            rbtnYES.Checked = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomNO.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmBoxRoomType.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value;
            txtPhone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            String free = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            if (free.Equals("YES"))
            {
                rbtnYES.Checked = true;
            }
            else if (free.Equals("NO"))
            {
                rbtnNO.Checked = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(cmBoxRoomType.SelectedValue.ToString());
            String phone = txtPhone.Text;
            String free="";
            
            if (rbtnYES.Checked)
            {
                free = "YES";
            }
            else if (rbtnNO.Checked)
            {
                free = "NO";
            }

            try
            {
                int number = Convert.ToInt32(txtRoomNO.Text);

                if (room.editRooms(number, type, phone, free))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Room data Updated!!", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error-Room data not Updated", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Room number Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(txtRoomNO.Text);

                if (room.removeRoom(number))
                {
                    dataGridView1.DataSource = room.getRooms();
                    MessageBox.Show("Room data Removed!!", "Delete Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error-Room data not Removed", "Delete Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Room number Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
