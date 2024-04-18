using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCourseManagement.Common;
using WPFCourseManagement.Model;

namespace WPFCourseManagement.ViewModel
{
    public class CoursePageViewModel
    {
        public ObservableCollection<CategoryItemModel> CategoryCourse { get; set; }
        public ObservableCollection<CategoryItemModel> CategoryTechnology { get; set; }
        public ObservableCollection<CategoryItemModel> CategoryTeacher { get; set; }

        public ObservableCollection<CourseModel> CourseList { get; set; } = new ObservableCollection<CourseModel>();

        public CommandBase OpenCourseUrlCommand { get; set; }

        public CommandBase TeacherFilterComand { get; set; }

        public List<CourseModel> courseAll;

        public CoursePageViewModel()
        {
            this.OpenCourseUrlCommand = new CommandBase();
            this.OpenCourseUrlCommand.DoCanExecute = new Func<object, bool>((o)=>true);
            this.OpenCourseUrlCommand.DoExecute = new Action<object>((o) => { System.Diagnostics.Process.Start(o.ToString()); });

            this.TeacherFilterComand = new CommandBase();
            this.TeacherFilterComand.DoCanExecute = new Func<object, bool>((o) => true);
            this.TeacherFilterComand.DoExecute = new Action<object>(DoFilter);
            this.InitCategory();
            this.InitCourse();
        }
        private void DoFilter(object o)
        {
            string techer = o.ToString();
            List<CourseModel> temp = courseAll;
            if (techer!="全部")
            {
                temp = courseAll.Where(c => c.techers.Exists(e => e == techer)).ToList();
            }
            CourseList.Clear();
            foreach (var item in temp)
            {
                CourseList.Add(item);
            }
        }

        private void InitCategory()
        {
            this.CategoryCourse = new ObservableCollection<CategoryItemModel>();
            this.CategoryCourse.Add(new CategoryItemModel("全部", true));
            this.CategoryCourse.Add(new CategoryItemModel("公开课"));
            this.CategoryCourse.Add(new CategoryItemModel("VIP课"));

            this.CategoryTechnology = new ObservableCollection<CategoryItemModel>();
            this.CategoryTechnology.Add(new CategoryItemModel("全部", true));
            this.CategoryTechnology.Add(new CategoryItemModel("C#"));
            this.CategoryTechnology.Add(new CategoryItemModel("Java"));
            this.CategoryTechnology.Add(new CategoryItemModel("ASP.Net"));
            this.CategoryTechnology.Add(new CategoryItemModel("微服务"));

            this.CategoryTeacher = new ObservableCollection<CategoryItemModel>();
            this.CategoryTeacher.Add(new CategoryItemModel("全部", true));
            this.CategoryTeacher.Add(new CategoryItemModel("zhan"));
            this.CategoryTeacher.Add(new CategoryItemModel("lisi"));
            this.CategoryTeacher.Add(new CategoryItemModel("John"));
            this.CategoryTeacher.Add(new CategoryItemModel("wanwu"));
        }

        private void InitCourse()
        {
            for (int i = 0; i < 10; i++)
            {
                CourseList.Add(new CourseModel() { IsShowSkeleton = true });
            }
            Task.Run( new Action ( async ()=> 
            {
                await Task.Delay(4000);

                Application.Current.Dispatcher.Invoke(new Action(()=> {
                    CourseList.Clear();
                    CourseList.Add(new CourseModel() 
                    { 
                        CourseName = "C#",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "https://haifeizhang.com/",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers =  new List<string>() { "zhan","lisi","wanwu"}
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "C#/.Net架构师蜕变营",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "https://haifeizhang.com/",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" },
                        course = "VIP课"
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "Java",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "https://haifeizhang.com/",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" }
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "C#/.Net架构师蜕变营",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "https://haifeizhang.com/",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" }
                    });

                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "C#/.Net架构师蜕变营",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" }
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "C#/.Net架构师蜕变营",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" }
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "C#",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" }
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "C#/.Net架构师蜕变营",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" }
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "Java",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" },
                        course = "VIP课"
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "C#/.Net架构师蜕变营",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" }
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "C#/.Net架构师蜕变营",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" }
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "Java",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" },
                        course = "VIP课"
                    });
                    CourseList.Add(new CourseModel()
                    {
                        CourseName = "C#/.Net架构师蜕变营",
                        Cover = "./Assets/Images/SK_LOGO.jpg",
                        Url = "",
                        Description = "C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营C#/.Net架构师蜕变营",
                        techers = new List<string>() { "zhan", "lisi", "wanwu" },
                        course = "VIP课"
                    });

                    courseAll = CourseList.ToList();
                }));
            }));
        }
    }
}
