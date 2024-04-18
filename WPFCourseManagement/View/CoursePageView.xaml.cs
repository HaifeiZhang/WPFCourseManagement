using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WPFCourseManagement.Model;
using WPFCourseManagement.ViewModel;

namespace WPFCourseManagement.View
{
    /// <summary>
    /// Interaction logic for CoursePageView.xaml
    /// </summary>
    public partial class CoursePageView : UserControl
    {
        public CoursePageView()
        {
            InitializeComponent();
            this.DataContext = new CoursePageViewModel();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;

            string tech = button.Content.ToString();

            ICollectionView view = CollectionViewSource.GetDefaultView(this.IsCourse.ItemsSource);

            if (tech =="全部")
            {
                view.Filter = null;

                view.SortDescriptions.Add(new SortDescription("CourseName", ListSortDirection.Ascending));
            }
            else
            {
                view.Filter = new Predicate<object>((o)=> 
                {

                    return (o as CourseModel).CourseName == tech;
                });
            }
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;

            string course = button.Content.ToString();

            ICollectionView view = CollectionViewSource.GetDefaultView(this.IsCourse.ItemsSource);

            if (course == "全部")
            {
                view.Filter = null;

                view.SortDescriptions.Add(new SortDescription("CourseName", ListSortDirection.Ascending));
            }
            else
            {
                view.Filter = new Predicate<object>((o) =>
                {

                    return (o as CourseModel).course == course;
                });
            }
        }
    }
}
