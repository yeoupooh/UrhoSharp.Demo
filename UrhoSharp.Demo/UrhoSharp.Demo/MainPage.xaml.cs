using System;
using System.Diagnostics;
using Urho;
using Xamarin.Forms;

namespace UrhoSharp.Demo
{
    public partial class MainPage : ContentPage
    {
        HelloWorld app;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            app = await HelloWorldUrhoSurface.Show<HelloWorld>(new Urho.ApplicationOptions(assetsFolder: null) { Orientation = ApplicationOptions.OrientationType.LandscapeAndPortrait });

            if (BindingContext != null)
            {
                if (BindingContext.GetType() == typeof(MainPageViewModel))
                {
                    ((MainPageViewModel)BindingContext).App = app;
                    Debug.WriteLine("app is set");
                }
            }
        }

    }
}