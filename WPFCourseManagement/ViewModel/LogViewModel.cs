using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using WPFCourseManagement.Common;

namespace WPFCourseManagement.ViewModel
{
    public class LogViewModel:NotifyBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private ObservableCollection<string> logMessages = new ObservableCollection<string>();
        public static LogViewModel logViewModel;
        private ListBox listBox;
        
        public ObservableCollection<string> LogMessages
        {
            get { return logMessages; }
            set
            {
                logMessages = value;
                this.DoNotify("LogMessages");
            }
        }

        public LogViewModel( ListBox list)
        {
            listBox = list;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Test();
        }

        public void AddLog(string message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                LogMessages.Add($"{DateTime.Now}: {message}");
                //listBox.TabIndex = listBox.Items.Count - 1;
                //把信息滚到最新消息处
                listBox.ScrollIntoView(listBox.Items[logMessages.Count-1]);
            });
            //把日志写入TXT文件
            Logger.Info($"{DateTime.Now}: {message}");

            //listBox.Dispatcher.Invoke(() => listBox.SelectedIndex = listBox.Items.Count - 1);
            //listBox.SelectedIndex = logMessages.Count - 1;
        }

        private void Test()
        {

            int count = 0;
            
            AddLog("这是第 " + count.ToString() + " 行日志！");
            //Thread.Sleep(100);
            count++;
            
            
            
        }
    }
}
