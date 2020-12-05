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
        public bool Them(UserDTO newUSer)
        {
           return UserDAO.Instance.Them( newUSer);
        }
        public bool Xoa(DataGridView data)
        {
            string id = data.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
            return UserDAO.Instance.Xoa(id);
        }
    }
}
