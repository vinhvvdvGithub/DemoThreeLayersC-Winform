using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
namespace QuanLyNhanVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

            UserBUS.Instance.Xem(dgvUser);
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (UserBUS.Instance.Them(dgvUser))
            {
                MessageBox.Show("Them thanh cong");
                btnXem_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Them khong thanh cong");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (UserBUS.Instance.Xoa(dgvUser))
            {
                MessageBox.Show("Xoa thanh cong");
                btnXem_Click( sender,  e);
            }
            else
            {
                MessageBox.Show("Xoa khong thanh cong");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (UserBUS.Instance.Sua(dgvUser))
            {
                MessageBox.Show("Sua thanh cong");
                btnXem_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Sua khong thanh cong");
            }
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvUser.SelectedCells[0].OwningRow;
            txtName.Text= row.Cells["Name"].Value.ToString();
            txtID.Text = row.Cells["ID"].Value.ToString();
            dateTimePicker1.Value = (DateTime)row.Cells["DateOfBirth"].Value;
        }
    }
}
