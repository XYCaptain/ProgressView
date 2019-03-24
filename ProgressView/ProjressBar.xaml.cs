using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressView
{
    /// <summary>
    /// ProjressBar.xaml 的交互逻辑
    /// </summary>
    public partial class ProjressBar : UserControl
    {
        public ProjressBar()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty PercentProperty = DependencyProperty.Register("Percent", typeof(double), typeof(ProjressBar));
        public double Percent
        {
            get { return (double)GetValue(PercentProperty); }
            set { SetValue(PercentProperty, value); }
        }

        public static readonly DependencyProperty ChannelNameProperty = DependencyProperty.Register("ChannelName", typeof(string), typeof(ProjressBar));
        public string ChannelName
        {
            get { return (string)GetValue(ChannelNameProperty); }
            set { SetValue(ChannelNameProperty, value); }
        }

        public static readonly DependencyProperty DataNameProperty = DependencyProperty.Register("DataName", typeof(string), typeof(ProjressBar));
        public string DataName
        {
            get { return (string)GetValue(DataNameProperty); }
            set { SetValue(DataNameProperty, value); }
        }
        public object Color
        {
            get
            {
                if (Percent < 10)
                {
                    return "Red";
                }
                else if (Percent >= 10 && Percent < 30)
                {
                    return "Yellow";
                }
                else
                {
                    return "Green";
                }
            }
        }

    }

}
