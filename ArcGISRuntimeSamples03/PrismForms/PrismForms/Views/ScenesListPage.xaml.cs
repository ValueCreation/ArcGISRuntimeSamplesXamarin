using Xamarin.Forms;
using System;

namespace PrismForms.Views
{
	public partial class ScenesListPage : ContentPage
	{
		public ScenesListPage()
		{
			InitializeComponent();

			var diplaySceneButton = new Button
			{
				Text = "3D地図表示",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			diplaySceneButton.Clicked += OnDiplaySceneClicked;

			var extrudeGraphicsButton = new Button
			{
				Text = "3Dグラフィック表示",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			extrudeGraphicsButton.Clicked += OnExtrudeGraphicsClicked;

			var sceneSymbolsButton = new Button
			{
				Text = "3Dシンボル表示",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			sceneSymbolsButton.Clicked += OnSceneSymbolsClicked;

			var surfacePlacementsButton = new Button
			{
				Text = "Surface placements",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			surfacePlacementsButton.Clicked += OnSurfacePlacementsClicked;

			Content = new StackLayout
			{
				Margin = new Thickness(0, 20, 0, 0),
				Children = {
					diplaySceneButton,
					extrudeGraphicsButton,
					sceneSymbolsButton,
					surfacePlacementsButton
				}
			};

		}

		async void OnSurfacePlacementsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SurfacePlacementsPage());
		}

		async void OnSceneSymbolsClicked(object sender, EventArgs e)
		{ 
			await Navigation.PushAsync(new SceneSymbolsPage());
		}

		async void OnDiplaySceneClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new DisplayScenePage());
		}

		async void OnExtrudeGraphicsClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ExtrudeGraphicsPage());
		}

	}
}

