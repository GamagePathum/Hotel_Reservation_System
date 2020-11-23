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
    public partial class ManageReservationsForm : Form
    {
        public ManageReservationsForm()
        {
            InitializeComponent();
        }

        ROOM room = new ROOM();
        RESERVTION reserv = new RESERVTION();

        private void ManageReservationsForm_Load(object sender, EventArgs e)
        {
            cmbRoomType.DataSource = room.roomTypeList();
            cmbRoomType.DisplayMember = "label";
            cmbRoomType.ValueMember = "category_id";

            cmbRoomType_SelectedIndexChanged(null, null);

            dataGridViewReserve.DataSource = reserv.getAllReserve();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtClientID.Text = "";
            cmbRoomType.SelectedIndex = 0;
            dtpDateIn.Value = DateTime.Now;
            dtpDateOut.Value = DateTime.Now;
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int type = Convert.ToInt32(cmbRoomType.SelectedValue);
                cmbRoomNo.DataSource = room.roomByType(type);
                cmbRoomNo.DisplayMember = "roomNumber";
                cmbRoomNo.ValueMember = "roomNumber";
            }
            catch (Exception)
            {

            }
        }

        private void btnAddReserve_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(cmbRoomNo.SelectedValue);
            int cid = Convert.ToInt32(txtClientID.Text);
            DateTime din = dtpDateIn.Value;
            DateTime dout = dtpDateOut.Value;

            if (reserv.addReservation(number, cid, din, dout))
            {
                dataGridViewReserve.DataSource = reserv.getAllReserve();
                MessageBox.Show("Reservation Added Succsess!!", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error-Reservation Not Added", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
