using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseManagement.Common;
using WPFCourseManagement.DataAccess.DataEntity;

namespace WPFCourseManagement.DataAccess
{
    public class LocalDataAccess
    {
        private static LocalDataAccess instance;
        private LocalDataAccess()
        {

        }
        public static LocalDataAccess GetInstance()
        {
            return instance ?? (instance = new LocalDataAccess());
        }

        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapter;

        private void Dispose()
        {
            if (adapter!=null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if (comm!=null)
            {
                comm.Dispose();
                comm = null;
            }
            if (conn!=null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        private bool DBConnection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            if (conn==null)
            {
                conn = new SqlConnection(conStr);
            }
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }

        public UserEntity CheckUserInfo(string userName, string pwd)
        {
            return new UserEntity() { UserName = "zhangsan", UserPassword = "123456", RoleID = 1 ,Gender=2, Avatar= "/Assets/Images/SK_LOGO.jpg" };
            try
            {
                if (DBConnection())
                {
                    string userSql = "SELECT * FROM nd_ppe_db.userinfo where UserNme = @userName and UserPassword=@pwd;";
                    adapter = new SqlDataAdapter(userSql, conn);
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@userName", System.Data.SqlDbType.VarChar)
                    { Value = userName });
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@pwd", System.Data.SqlDbType.VarChar)
                    { Value = pwd });
                    //encrype the password
                    //adapter.SelectCommand.Parameters.Add(new SqlParameter("@pwd", System.Data.SqlDbType.VarChar)
                    //{ Value = MD5Provider.GetMD5Code(pwd) });

                    DataTable table = new DataTable();
                    int count = adapter.Fill(table);
                    if (count <= 0)
                    {
                        throw new Exception("用户名或者密码不正确！");
                    }
                    DataRow dr = table.Rows[0];
                    if (dr.Field<int>("is can login")==0)
                    {
                        throw new Exception("当前用户没有权限！");
                    }
                    UserEntity userInfo = new UserEntity();
                    userInfo.UserName = dr.Field<string>("UserName");
                    userInfo.UserPassword = dr.Field<string>("UserPassword");
                    userInfo.RoleID = dr.Field<int>("RoleID");

                    return userInfo;

                }
            }
            catch (Exception ex)
            {

                throw ex;
                
            }
            finally
            {
                this.Dispose();
            }
            return null;


        }

    }
}
