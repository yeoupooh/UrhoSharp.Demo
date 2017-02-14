using System;
using Urho;
using Xamarin.Forms;

namespace UrhoSharp.Demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await HelloWorldUrhoSurface.Show<HelloWorld>(new Urho.ApplicationOptions(assetsFolder: null) { Orientation = ApplicationOptions.OrientationType.LandscapeAndPortrait });
        }

        public void OnRelRotateButtonClicked(object sender, EventArgs args)
        {
            HelloWorldUrhoSurface.RelRotateTo(10f);
        }
        public void OnZoomInButtonClicked(object sender, EventArgs args)
        {
            HelloWorldUrhoSurface.RelScaleTo(0.1f);
        }

        public void OnZoomOutButtonClicked(object sender, EventArgs args)
        {
            HelloWorldUrhoSurface.RelScaleTo(-0.1f);
        }
    }
}