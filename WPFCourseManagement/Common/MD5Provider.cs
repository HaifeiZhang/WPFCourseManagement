using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WPFCourseManagement.Common
{
    public class MD5Provider
    {
        public static string GetMD5Code(string str)
        {
            MD5 mD5 = MD5.Create();
            string pwd = "";
            byte[] pws = mD5.ComputeHash(Encoding.UTF8.GetBytes(str));
            foreach (var item in pws)
            {
                pwd += item.ToString("x2");
            }
            return pwd;
        }
    }
}
