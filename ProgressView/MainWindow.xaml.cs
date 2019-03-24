using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace ProgressView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InputData.Self.DealData();
            this.DataContext = InputData.Self;
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(() =>
            //{
            //    for (int i = 0; i <= 100; i++)
            //    {
            //        //bar.Dispatcher.BeginInvoke((ThreadStart)delegate { this.percent.Text = string.Format("{0}%",i); this.bar.Value = i; this.bar1.Value = i; });
            //        //Thread.Sleep(100);
            //    }
            //}));
            //thread.Start();
        }
    }
}
