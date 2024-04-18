using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCourseManagement.Common;
using WPFCourseManagement.DataAccess;
using WPFCourseManagement.Model;

namespace WPFCourseManagement.ViewModel
{
    public class LoginViewModel : NotifyBase
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();
        public CommandBase CloseWindowCommand { get; set; }
        public CommandBase LoginCommand { get; set; }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; this.DoNotify(); }
        }

        public LoginViewModel()
        {
            //LoginModel.UserName = "111";
            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) => { (o as Window).Close(); });
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });

            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
        }

        private void DoLogin(object o)
        {
            this._errorMessage = "";
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMessage = "请输入用户名！";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Password))
            {
                this.ErrorMessage = "请输入密码！";
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.ValidationCode))
            {
                this.ErrorMessage = "请输入验证码";
                return;
            }
            if (LoginModel.ValidationCode =="")
            {
                this.ErrorMessage = "验证码不正确！";
                return;
            }
            Task.Run(new Action(() =>
            {
                var user = LocalDataAccess.GetInstance().CheckUserInfo(LoginModel.UserName, LoginModel.Password);
                try
                {
                    if (user == null)
                    {
                        throw new Exception("登录失败！用户名或者密码错误！");
                    }

                    GlobalValues.UserInfo = user;

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        (o as Window).DialogResult = true;
                    });
                    
                }
                catch (Exception ex)
                {

                    this.ErrorMessage = ex.Message;
                }
            }));
            
        }
    }
}
