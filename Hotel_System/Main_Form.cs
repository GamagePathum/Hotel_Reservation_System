﻿using System;
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
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void manageClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClientsForm manageCF = new ManageClientsForm();
            manageCF.ShowDialog();
        }

        private void manageRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRoomsForm manageROF = new ManageRoomsForm();
            manageROF.ShowDialog();
        }

        private void manageReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageReservationsForm manageREF = new ManageReservationsForm();
            manageREF.ShowDialog();
        }
    }
}
