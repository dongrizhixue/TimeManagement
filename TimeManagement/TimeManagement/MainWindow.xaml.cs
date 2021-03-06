﻿using System;
using System.Windows;
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
                    MessageBox.Show("倒计时不能小于零。","提示");
                }
            }
            else
            {
                MessageBox.Show("时间转换错误，请填写数字。", "提示");
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
