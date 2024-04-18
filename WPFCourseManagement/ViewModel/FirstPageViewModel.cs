using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCourseManagement.Common;
using WPFCourseManagement.Model;

namespace WPFCourseManagement.ViewModel
{
    public class FirstPageViewModel:NotifyBase
    {
        private double _instrumentValue;

        public double InstrumentValue
        {
            get { return _instrumentValue; }
            set { _instrumentValue = value; this.DoNotify(); }
        }

        public ObservableCollection<CourseSeriesModel> CourseSeriesList { get; set; } = new ObservableCollection<CourseSeriesModel>();

        Random random = new Random();
        bool taskSwitch = true;
        List<Task> taskList = new List<Task>();

        public FirstPageViewModel()
        {
            //给个初始值
            this.InstrumentValue = 50;
            this.RefreshInstrumentValue();
            this.InitCourseSeries();
        }
        private void InitCourseSeries()
        {
            CourseSeriesList.Add(new CourseSeriesModel
            {
                CourseName = "C#/.Net架构师",
                SeriesCollection = new LiveCharts.SeriesCollection { 
                    new PieSeries
                {
                    Title = "SK",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(12)},
                    DataLabels = false
                },
                new PieSeries
                {
                    Title = "SK2",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(13)},
                    DataLabels = false
                },
                new PieSeries
                {
                    Title = "SK3",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(23)},
                    DataLabels = false
                },new PieSeries
                {
                    Title = "SK4",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(123)},
                    DataLabels = false
                }},
                SeriesList = new ObservableCollection<SeriesModel>
                {
                    new SeriesModel{SeriesName="云课堂", CurrentValue=161, IsGrowing=false,ChangeRate=-75},
                    new SeriesModel{SeriesName="抖音", CurrentValue=161, IsGrowing=true,ChangeRate=75},
                    new SeriesModel{SeriesName="腾讯", CurrentValue=161, IsGrowing=false,ChangeRate=-75},
                    new SeriesModel{SeriesName="爱奇艺", CurrentValue=161, IsGrowing=true,ChangeRate=75},
                    new SeriesModel{SeriesName="B站", CurrentValue=161, IsGrowing=false,ChangeRate=-75}
                }
            });
            CourseSeriesList.Add(new CourseSeriesModel
            {
                CourseName = "C#/.Net架构师",
                SeriesCollection = new LiveCharts.SeriesCollection {
                    new PieSeries
                {
                    Title = "SK",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(12)},
                    DataLabels = false
                },
                new PieSeries
                {
                    Title = "SK2",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(13)},
                    DataLabels = false
                },
                new PieSeries
                {
                    Title = "SK3",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(23)},
                    DataLabels = false
                },new PieSeries
                {
                    Title = "SK4",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(123)},
                    DataLabels = false
                }},
                SeriesList = new ObservableCollection<SeriesModel>
                {
                    new SeriesModel{SeriesName="云课堂", CurrentValue=161, IsGrowing=false,ChangeRate=-75},
                    new SeriesModel{SeriesName="抖音", CurrentValue=161, IsGrowing=true,ChangeRate=75},
                    new SeriesModel{SeriesName="腾讯", CurrentValue=161, IsGrowing=false,ChangeRate=-75},
                    new SeriesModel{SeriesName="爱奇艺", CurrentValue=161, IsGrowing=true,ChangeRate=75},
                    new SeriesModel{SeriesName="B站", CurrentValue=161, IsGrowing=false,ChangeRate=-75}
                }
            });
            CourseSeriesList.Add(new CourseSeriesModel
            {
                CourseName = "C#/.Net架构师",
                SeriesCollection = new LiveCharts.SeriesCollection {
                    new PieSeries
                {
                    Title = "SK",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(12)},
                    DataLabels = false
                },
                new PieSeries
                {
                    Title = "SK2",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(13)},
                    DataLabels = false
                },
                new PieSeries
                {
                    Title = "SK3",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(23)},
                    DataLabels = false
                },new PieSeries
                {
                    Title = "SK4",
                    Values = new ChartValues<ObservableValue>{ new ObservableValue(123)},
                    DataLabels = false
                }},
                SeriesList = new ObservableCollection<SeriesModel>
                {
                    new SeriesModel{SeriesName="云课堂", CurrentValue=161, IsGrowing=false,ChangeRate=-75},
                    new SeriesModel{SeriesName="抖音", CurrentValue=161, IsGrowing=true,ChangeRate=75},
                    new SeriesModel{SeriesName="腾讯", CurrentValue=161, IsGrowing=false,ChangeRate=-75},
                    new SeriesModel{SeriesName="爱奇艺", CurrentValue=161, IsGrowing=true,ChangeRate=75},
                    new SeriesModel{SeriesName="B站", CurrentValue=161, IsGrowing=false,ChangeRate=-75}
                }
            });
        }

        private void RefreshInstrumentValue()
        {
            var task = Task.Factory.StartNew(new Action(async()=> 
            {
                while (taskSwitch)
                {
                    var val = InstrumentValue + random.Next(-10, 10);
                    if (val > 100)
                    {
                        InstrumentValue=100;
                    }
                    else if( val < 10)
                    {
                        InstrumentValue = 10;
                    }
                    else
                    {
                        InstrumentValue = val;
                    }
                    
                    await Task.Delay(1000);
                }
                
            }));
            taskList.Add(task);
        }

        public void Dispose()
        {
            try
            {
                taskSwitch = false;
                Task.WaitAll(this.taskList.ToArray());
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
