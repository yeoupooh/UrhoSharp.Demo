using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace UrhoSharp.Demo
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ICommand AddSampleNodesCommand { get; set; }
        public ICommand RelRotateCommand { get; set; }
        public ICommand ZoomInCommand { get; set; }
        public ICommand ZoomOutCommand { get; set; }

        int angle = 0;
        double scale = 1f;
        HelloWorld app;

        public int Angle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
                NotifyPropertyChanged("Angle");
            }
        }

        public double Scale
        {
            get
            {
                return scale;

            }
            set
            {
                scale = value;
                NotifyPropertyChanged("Scale");
            }
        }

        public virtual new event PropertyChangedEventHandler PropertyChanged;

        public HelloWorld App
        {
            get { return app; }
            internal set
            {
                app = value;
            }
        }

        public MainPageViewModel()
        {
            AddSampleNodesCommand = new Command((obj) =>
            {
                Debug.WriteLine("add sample nodes");
                app?.AddSampleNodes();
            });
            RelRotateCommand = new Command((obj) =>
            {
                Debug.WriteLine(string.Format("rel rotate command: {0}", obj));
                Angle += 10;
            });
            ZoomInCommand = new Command((obj) =>
            {
                Scale += 0.1f;
                Debug.WriteLine("zoom in command");
            });
            ZoomOutCommand = new Command((obj) =>
            {
                Scale -= 0.1f;
                Debug.WriteLine("zoom out command");
            });
        }

        void NotifyPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
