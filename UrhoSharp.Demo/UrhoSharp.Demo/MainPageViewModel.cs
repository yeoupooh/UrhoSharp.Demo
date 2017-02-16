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
        public ICommand RotateSurfaceCommand { get; set; }
        public ICommand RotateWorldCommand { get; set; }
        public ICommand ZoomInCommand { get; set; }
        public ICommand ZoomOutCommand { get; set; }

        int surfaceAngle = 0;
        float worldAngle = 0f;
        double scale = 1f;
        HelloWorld app;

        public int SurfaceAngle
        {
            get { return surfaceAngle; }
            set
            {
                surfaceAngle = value;
                NotifyPropertyChanged("SurfaceAngle");
            }
        }
        public float WorldAngle
        {
            get { return surfaceAngle; }
            set
            {
                worldAngle = value;
                NotifyPropertyChanged("WorldAngle");
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
            RotateSurfaceCommand = new Command((obj) =>
            {
                Debug.WriteLine(string.Format("rotate surface command: {0}", obj));
                SurfaceAngle += 10;
            });
            RotateWorldCommand = new Command((obj) =>
            {
                Debug.WriteLine(string.Format("rotate world command: {0}", obj));
                WorldAngle += 10f;
                app?.RotateWorld(worldAngle);
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
