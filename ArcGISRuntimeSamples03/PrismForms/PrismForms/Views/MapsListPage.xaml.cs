using Xamarin.Forms;
using System;

namespace PrismForms.Views
{
	public partial class MapsListPage : ContentPage
	{
		public MapsListPage()
		{
			InitializeComponent();

			var displayMapButton = new Button
			{
				Text = "地図表示",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			displayMapButton.Clicked += OnDisplayMapClicked;

			var mapLoadButton = new Button
			{
				Text = "地図のロード",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			mapLoadButton.Clicked += OnMapLoadClicked;

			Content = new StackLayout
			{
				Margin = new Thickness(0, 20, 0, 0),
				Children = {
					displayMapButton,
					mapLoadButton
				}
			};

		}
		async void OnDisplayMapClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new DisplayMapPage());
		}

		async void OnMapLoadClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MapLoadedPage());
		}

	}
}

