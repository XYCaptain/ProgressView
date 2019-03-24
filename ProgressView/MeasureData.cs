using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProgressView
{
    class MeasureData : INotifyPropertyChanged
    {
        private double _percent;
        private string _channelName;
        private string _dataName;
        private bool _toDelet;

        public event PropertyChangedEventHandler PropertyChanged;
        private void prochanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public double Percent
        {
            get => _percent; set { _percent = value; prochanged("Percent"); prochanged("Color"); }
        }
        public string ChannelName
        {
            get => _channelName; set { _channelName = value; prochanged("ChannelName"); }
        }
        public string DataName
        {
            get => _dataName; set { _dataName = value; prochanged("DataName"); }
        }

        public bool ToDelet
        {
            get => _toDelet; set { _toDelet = value; prochanged("ToDelet"); }
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
