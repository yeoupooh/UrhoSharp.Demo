using System;
namespace UrhoSharp.Demo
{
	public class ViewModelLocator
	{
		public MainPageViewModel MainPageVM
		{
			get { return new MainPageViewModel(); }
		}
	}
}
