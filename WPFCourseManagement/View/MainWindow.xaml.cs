using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WPFCourseManagement.Common;
using WPFCourseManagement.ViewModel;

namespace WPFCourseManagement.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            MainViewModel model = new MainViewModel();
            this.DataContext = model;
            model.UserInfo.Avatar = GlobalValues.UserInfo.Avatar;
            model.UserInfo.UserName = GlobalValues.UserInfo.UserName;
            model.UserInfo.Gender = GlobalValues.UserInfo.Gender;
            this.MaxHeight = SystemParameters.PrimaryScreenWidth;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnMax_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
