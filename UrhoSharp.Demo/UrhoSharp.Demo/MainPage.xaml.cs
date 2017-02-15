using System;
using Urho;
using Xamarin.Forms;

namespace UrhoSharp.Demo
{
	public partial class MainPage : ContentPage
	{
		HelloWorld app;
		//MainPageViewModel ViewModel;

		public MainPage()
		{
			InitializeComponent();
			//BindingContext = ViewModel = new MainPageViewModel();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			app = await HelloWorldUrhoSurface.Show<HelloWorld>(new Urho.ApplicationOptions(assetsFolder: null) { Orientation = ApplicationOptions.OrientationType.LandscapeAndPortrait });
			//ViewModel.App = app;
		}

		//public void OnRelRotateButtonClicked(object sender, EventArgs args)
		//{
		//	HelloWorldUrhoSurface.RelRotateTo(10f);
		//}
		//public void OnZoomInButtonClicked(object sender, EventArgs args)
		//{
		//	HelloWorldUrhoSurface.RelScaleTo(0.1f);
		//}

		//public void OnZoomOutButtonClicked(object sender, EventArgs args)
		//{
		//	HelloWorldUrhoSurface.RelScaleTo(-0.1f);
		//}
	}
}