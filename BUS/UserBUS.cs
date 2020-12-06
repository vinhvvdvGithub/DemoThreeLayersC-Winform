using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAO;
using DTO;

namespace BUS
{
    public class UserBUS
    {
        private static UserBUS instance;
        

        public static UserBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserBUS();

                }
                return instance;
            }

        }
        private UserBUS() { }
        public void Xem(DataGridView data)
        {
            data.DataSource = UserDAO.Instance.Xem();
        }
        public bool Them(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
            // string oldid = row.Cells["ID"].Value.ToString();

            string id = row.Cells["ID"].Value.ToString();
            string name = row.Cells["Name"].Value.ToString();
            DateTime dateofbirth;

            dateofbirth = (DateTime)row.Cells["DateOfBirth"].Value;
            string info = row.Cells["Info"].Value.ToString();
            bool sex = (bool)row.Cells["Sex"].Value;


            string ID = data.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
            UserDTO user = new UserDTO() { Id = id, Name = name, DateOfBirth = dateofbirth, Info = info, Sex = sex };

           // return UserDAO.Instance.Sua(ID, user);
            return UserDAO.Instance.Them(user);
        }
        public bool Xoa(DataGridView data)
        {
            string id = data.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
            return UserDAO.Instance.Xoa(id);
        }
        public bool Sua(DataGridView data)
        {
            DataGridViewRow row = data.SelectedCells[0].OwningRow;
           // string oldid = row.Cells["ID"].Value.ToString();

            string id = row.Cells["ID"].Value.ToString();
            string name = row.Cells["Name"].Value.ToString();
            DateTime dateofbirth;
         
             dateofbirth =(DateTime) row.Cells["DateOfBirth"].Value;
            string info = row.Cells["Info"].Value.ToString();
            bool sex= (bool)row.Cells["Sex"].Value;


            string ID = data.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
            UserDTO user = new UserDTO() { Id = id, Name = name, DateOfBirth = dateofbirth, Info = info, Sex = sex };

            return UserDAO.Instance.Sua(ID,user);
        }
    }
}
