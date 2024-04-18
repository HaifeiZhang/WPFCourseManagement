using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCourseManagement.DataAccess.DataEntity
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string UserPassword { get; set; }
        public int RoleID { get; set; }
        public int Gender { get; set; }
    }
}
