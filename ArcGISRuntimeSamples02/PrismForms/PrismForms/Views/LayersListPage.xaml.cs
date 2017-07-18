using Xamarin.Forms;
using System;

namespace PrismForms.Views
{
	public partial class LayersListPage : ContentPage
	{
		public LayersListPage()
		{
			InitializeComponent();
		}


		async void OnArcGISMapImageLayerClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ArcGISMapImageLayerUrlPage());
		}

	}
}

