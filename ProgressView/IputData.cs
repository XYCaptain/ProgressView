using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressView
{
    class InputData
    {
        static InputData _InputData;
        bool isrun = true;

        private InputData()
        {
            //DealData();
        }

        ~InputData()
        {
            isrun = false;
        }

        internal static InputData Self
        {
            get
            {
                if (_InputData == null)
                {
                    _InputData = new InputData();
                }
                return _InputData;
            }
        }
        //线程字典
        Collection<MeasureData> _MeasureDataobs = new Collection<MeasureData>();
        ObservableCollection<MeasureData> MeasureDataobs = new ObservableCollection<MeasureData>();
        public ObservableCollection<MeasureData> MeasureData1
        {
            get
            {
                return MeasureDataobs;
            }
        }
        string _datastring;
        string[] _splitLine = { "\r\n" };
        MeasureData ot;
        public void DealData()
        {
            Run(() =>
            {
                do
                {
                    ReadData();
                    foreach (var item in MeasureDataobs)
                    {
                        item.ToDelet = true;
                    }
                    foreach (var line in _datastring.Split(_splitLine, StringSplitOptions.RemoveEmptyEntries).ToArray())
                    {
                        var item = line.Split(',');
                        var dataitems = MeasureDataobs.Where(x => x.ChannelName == item[0]);
                        
                        if (dataitems.Count() != 0)
                        {
                            var dataitem = dataitems.FirstOrDefault();
                            dataitem.DataName = item[1];
                            dataitem.Percent = double.Parse(item[2]);
                            dataitem.ToDelet = false;
                        }
                        else
                        {
                            MeasureDataobs.Add(
                                new MeasureData()
                                 {
                                     ChannelName = item[0],
                                     DataName = item[1],
                                     Percent = double.Parse(item[2]),
                                     ToDelet = false
                                 });
                        }
                    }
                    foreach (var item in MeasureDataobs.Where(x => x.ToDelet).ToList())
                    {
                        try
                        {
                            MeasureDataobs.Remove(item);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.ToString());
                        }
                    }
                    Thread.Sleep(200);
                } while (isrun);
            });
        }
        private void ReadData(string path = @".\Data.csv")
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    _datastring = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static Task Run(Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            new Thread(() => {
                //try
                //{
                    action();
                    tcs.SetResult(null);
                //}
                //catch (Exception ex)
                //{
                //    tcs.SetException(ex);
                //}
            })
            { IsBackground = true }.Start();
            return tcs.Task;
        }

        public void SimData()
        {
            Run(() =>
            {
                var ran = new Random();
                do
                {
                    ReadData();
                    foreach (var line in _datastring.Split(_splitLine, StringSplitOptions.RemoveEmptyEntries).ToArray())
                    {
                        var item = line.Split(',');
                        item[2] = (ran.NextDouble() * 100).ToString();
                    }
                    foreach (var item in MeasureDataobs.Where(x => x.ToDelet).ToList())
                    {
                        try
                        {
                            MeasureDataobs.Remove(item);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.ToString());
                        }
                    }
                    Thread.Sleep(200);
                } while (isrun);
            });
        }
    }
}
