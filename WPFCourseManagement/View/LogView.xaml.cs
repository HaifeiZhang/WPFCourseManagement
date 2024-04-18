using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCourseManagement.Func;
using WPFCourseManagement.ViewModel;

namespace WPFCourseManagement.View
{
    /// <summary>
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
            LogViewModel.logViewModel = new LogViewModel(logListBox);
            this.DataContext =  LogViewModel.logViewModel;
            //logListBox.ScrollIntoView("");
            //Logger.Instance.SetTextBox(logTextBox);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TestFunc testFunc = new TestFunc();
            Thread thread = new Thread(new ThreadStart(testFunc.Test));
            thread.IsBackground = true;
            thread.Start();
            
        }
    }
}
