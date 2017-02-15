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

		//ServiceLocator.SetLocatorProvider(i => SimpleIoc.Default);

		//        if (ViewModelBase.IsInDesignModeStatic)
		//        {
		//            SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
		//        }
		//        else
		//        {
		//            SimpleIoc.Default.Register<IDataService, DataService>();    
		//        }

		//SimpleIoc.Default.Register<MainViewModel>();		

		HelloWorld app;

		INotifyPropertyChanged PropertyChanged { get; set; }

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
			AddSampleNodesCommand = new Command((obj) => app?.AddSampleNodes());
			RelRotateCommand = new Command((obj) => Debug.WriteLine("rel rotate command"));
			ZoomInCommand = new Command((obj) => Debug.WriteLine("zoom in command"));
			ZoomOutCommand = new Command((obj) => Debug.WriteLine("zoom out command"));
		}
	}
}
