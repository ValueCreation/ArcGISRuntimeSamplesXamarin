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

			var diplaySceneButton = new Button
			{
				Text = "3D地図表示",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			diplaySceneButton.Clicked += OnDiplaySceneClicked;

			var sceneSymbolsButton = new Button
			{
				Text = "3Dシンボル",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECECEC")
			};
			sceneSymbolsButton.Clicked += OnSceneSymbolsClicked;



			Content = new StackLayout
			{
				Margin = new Thickness(0, 20, 0, 0),
				Children = {
					diplaySceneButton,
					extrudeGraphicsButton,
					sceneSymbolsButton
				}
			};

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

