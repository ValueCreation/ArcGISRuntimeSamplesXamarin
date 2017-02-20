using Xamarin.Forms;
using System;

namespace PrismForms.Views
{
	public partial class FeaturesListPage : ContentPage
	{
		public FeaturesListPage()
		{
			InitializeComponent();

			var featureLayerQueryButton = new Button
			{
				Text = "Feature layer query",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			featureLayerQueryButton.Clicked += OnFeatureLayerQueryClicked;

			Content = new StackLayout
			{
				Margin = new Thickness(0, 20, 0, 0),
				Children = {
					featureLayerQueryButton
				}
			};
		}

		async void OnFeatureLayerQueryClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new FeatureLayerQueryPage());
		}

	}
}

