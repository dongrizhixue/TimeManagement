using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;

namespace TimeManagement
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        TimeSpan timeRemaining = new TimeSpan();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeRemaining = timeRemaining - TimeSpan.FromSeconds(1);
            prbTimer.Value = prbTimer.Value - 1;
            ShowTime();
            if (timeRemaining.TotalSeconds == 0)
            {
                MessageBox.Show("计时结束", "提示");
                timer.Stop();
                SwitchToThisWindow(this.Handle, true);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            double min = 0;
            if (double.TryParse(txtCountdown.Text, out min))
            {
                if (min > 0)
                {
                    timeRemaining = TimeSpan.FromMinutes(min);
                    Initprb();
                    ShowTime();
                    if (timer.IsEnabled)
                    {
                        btnStart.Content = "开始";
                        timer.Stop();
                    }
                    else
                    {
                        btnStart.Content = "停止";
                        timer.Start();
                    }
                }
                else
                {
                    lblTimeRemaining.Content = "倒计时不能小于零。";
                }
            }
            else
            {
                lblTimeRemaining.Content = "时间转换错误，请填写数字。";
            }

        }

        /// <summary>
        /// 初始化进度条
        /// </summary>
        private void Initprb()
        {
            prbTimer.Maximum = timeRemaining.TotalSeconds;
            prbTimer.Value = prbTimer.Maximum;
        }

        private void ShowTime()
        {

            lblTimeRemaining.Content = timeRemaining.Hours.ToString() + ":" + timeRemaining.Minutes.ToString() + ":" + timeRemaining.Seconds.ToString();
        }
    }
}
