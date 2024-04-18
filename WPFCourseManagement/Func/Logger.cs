using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFCourseManagement.Func
{
    public class Logger
    {
        private static Logger instance = null;
        private static readonly object padlock = new object();

        private TextBox logTextBox;

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
            }
        }

        public void SetTextBox(TextBox textBox)
        {
            logTextBox = textBox;
        }

        public void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logMessage = $"{timestamp}  {message}{Environment.NewLine}";
            logTextBox.Dispatcher.Invoke(() => logTextBox.AppendText(logMessage));
        }
    }

}
