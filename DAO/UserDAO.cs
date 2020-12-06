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
        public UserDAO() { }
      
        public DataTable Xem()
        {
            string query = "select * from Users";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public bool Them(UserDTO newUser)
        {
            bool flag = false;
            string query = "SP_InsertUser @ID , @Name , @DateofBirth , @info , @Sex";
            object[] para = new object[]
            {
                 newUser
            };
            if (DataProvider.Instance.ExecuteNonQuery(query, para) != 0)
            {
                flag= true;
            }
            return flag ;
        }
        public bool Xoa(string id)
        {
            string query = "SP_DeleteUser @ID";

            if (DataProvider.Instance.ExecuteNonQuery(query, new object[] {id}) != 0)
            {
                return true;
            }
            return false;
        }
        public bool Sua(string id,UserDTO user) {
            string query = "SP_UpdateUser @ID , @Name , @DateofBirth , @info , @Sex";
            object[] para = new object[] {user.Id,user.Name,user.DateOfBirth,user.Info,user.Sex };

            if (DataProvider.Instance.ExecuteNonQuery(query, para) != 0)
            {
                return true;
            }

            return false;
        }
        //public List<User> Xem()
        //{
        //    List<User> users = new List<User>();
        //    string query = "select * from Users";
        //    DataTable data =DataProvider.Instance.ExecuteQuery(query);
           
        //    foreach (DataRow item in data.Rows)
        //    {
        //        string id =item.Cells["ID"].Value.ToString();
        //        string name=item.Cells["Name"].Value.ToString();
        //        DateTime dob= (DateTime) item.Cells["DateOfBirth"].Value;
        //        string info= item.Cells["Info"].Value.ToString();
        //        bool sex= (bool)item.Cells["Sex"].Value;
        //        User newU = new User(id,name,dob,info,sex);
        //        users.Add(newU);
        //    }
        //    return users;
        //}
    }
}
