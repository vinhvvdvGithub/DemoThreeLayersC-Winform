using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
namespace DAO
{
    public class UserDAO
    {
        private static UserDAO instance;

        public  static UserDAO Instance {
            get
            {
                if(instance == null)
                {
                    instance = new UserDAO();
                    
                }
                return instance;
            }

        }
        private UserDAO() { }
      
        public List<User> Xem()
        {
            List<User> users = new List<User>();
            string query = "select * from Users";
            DataTable data =DataProvider.Instance.ExecuteQuery(query);
           
            foreach (DataRow item in data.Rows)
            {
                string id =item.Cells["ID"].Value.ToString();
                string name=item.Cells["Name"].Value.ToString();
                DateTime dob= (DateTime) item.Cells["DateOfBirth"].Value;
                string info= item.Cells["Info"].Value.ToString();
                bool sex= (bool)item.Cells["Sex"].Value;
                User newU = new User(id,name,dob,info,sex);
                users.Add(newU);
            }
            return users;
        }
    }
}
