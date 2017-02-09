using Xamarin.Forms;
using System;

namespace PrismForms.Views
{
	public partial class ScenesListPage : ContentPage
	{
		public ScenesListPage()
		{
			InitializeComponent();

			var extrudeGraphicsButton = new Button
			{
				Text = "グラフィックスの表示",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			extrudeGraphicsButton.Clicked += OnExtrudeGraphicsClicked;

			Content = new StackLayout
			{
				Margin = new Thickness(0, 20, 0, 0),
				Children = {
					extrudeGraphicsButton
				}
			};

		}

		async void OnExtrudeGraphicsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ExtrudeGraphicsPage());
		}

	}
}

