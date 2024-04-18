using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using WPFCourseManagement.Common;
using WPFCourseManagement.Func;
using WPFCourseManagement.Model;

namespace WPFCourseManagement.ViewModel
{
    public class MainViewModel:NotifyBase
    {
        public UserModel UserInfo { get; set; }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; this.DoNotify(); }
        }

        private FrameworkElement _mainConten;

        public FrameworkElement MainContent
        {
            get { return _mainConten; }
            set { _mainConten = value; this.DoNotify(); }
        }

        public CommandBase NavChangedCommand { get; set; }

        public MainViewModel()
        {
            UserInfo = new UserModel();
            this.NavChangedCommand = new CommandBase();
            this.NavChangedCommand.DoExecute = new Action<object>(DoNavChanged);
            this.NavChangedCommand.DoCanExecute = new Func<object, bool>((o)=>true);
            DoNavChanged("FirstPageView");
            //Timer timer = new Timer(LogTest,null,0,3000);
            //Timer timer = new Timer();
            //timer.Elapsed += Timer_Elapsed;
            //timer.Interval = 1000;
            //timer.Start();
            
            
            
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            LogTest();
        }

        private void DoNavChanged(object obj)
        {
            Type type = Type.GetType("WPFCourseManagement.View."+obj.ToString());
            ConstructorInfo cti = type.GetConstructor(Type.EmptyTypes);
            this.MainContent = (FrameworkElement)cti.Invoke(null);
        }

        private void LogTest()
        {

            //LogViewModel.logViewModel.AddLog("这是从MainView过来的日志！");
                //Thread.Sleep(1000);
            
            
        }


    }
}
