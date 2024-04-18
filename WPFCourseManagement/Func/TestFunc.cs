using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using WPFCourseManagement.ViewModel;

namespace WPFCourseManagement.Func
{
    public class TestFunc
    {
        private System.Threading.Timer timer1;
        public TestFunc()
        {
           
        }

        public void Test()
        {
            //System.Timers.Timer timer = new System.Timers.Timer();
            //timer.Interval = 1000;
            //timer.Elapsed += Timer_Elapsed;
            //timer.Start();

            timer1 = new System.Threading.Timer(callback,null,0,1000);
                

            
        }

        private void callback(object state)
        {
            TestLog2();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            //TestLog1();
            TestLog2();

        }

        private void TestLog1()
        {
            Logger.Instance.Log("The System is running!");


            Logger.Instance.Log("Configure the Interface Paramters!");

            Logger.Instance.Log("Call the MES Inteface!");


            Logger.Instance.Log("Get the MES return message CustomerBarcode:1234567899874563210");
            Logger.Instance.Log("The Printer is ready....");


            Logger.Instance.Log("Get the Label template is DMC Code");
            Logger.Instance.Log("Print DMC lable is beginning");


            Logger.Instance.Log("The Print is finished. Successfully!");
        }


        private void TestLog2()
        {
            LogViewModel.logViewModel.AddLog("开始打印！");
            print();
            LogViewModel.logViewModel.AddLog("打印结束！");
        }

        private void print()
        {
            LogViewModel.logViewModel.AddLog("获取二配置参数开始！");
            GetConfigParas();
            LogViewModel.logViewModel.AddLog("获取二配置参数结束！");

            LogViewModel.logViewModel.AddLog("开始调用MES接口！");

            LogViewModel.logViewModel.AddLog("获取MES打印内容！！");
        }

        private void GetConfigParas()
        {
            //throw new NotImplementedException();
        }
    }
}
