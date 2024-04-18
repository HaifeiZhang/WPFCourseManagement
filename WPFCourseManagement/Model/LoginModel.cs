using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseManagement.Common;

namespace WPFCourseManagement.Model
{
    public class LoginModel:NotifyBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                this.DoNotify();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                this.DoNotify();
            }
        }

        private string _ValidationCode;

        public string ValidationCode
        {
            get { return _ValidationCode; }
            set
            {
                _ValidationCode = value;
                this.DoNotify();
            }
        }
        


    }
}
