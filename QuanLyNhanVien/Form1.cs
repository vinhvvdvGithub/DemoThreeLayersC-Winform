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
            if (txtID.Text != "" && txtName.Text != "" && txtThongtin.Text != "")
            {
                // Tạo DTo
                 UserDTO tv = new UserDTO(txtID.Text, txtName.Text, dateTimePicker1.Value, txtThongtin.Text, true); // Vì ID tự tăng nên để ID số gì cũng dc

                // Them
                if (UserBUS.Instance.Them(tv))
                {
                    MessageBox.Show("Thêm thành công");
                     UserBUS.Instance.Xem(dgvUser); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Thêm ko thành công");
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
