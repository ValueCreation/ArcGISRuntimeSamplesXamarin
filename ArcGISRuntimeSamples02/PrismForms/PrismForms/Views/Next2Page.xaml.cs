using Esri.ArcGISRuntime.Mapping;
using System;
using Xamarin.Forms;

namespace PrismForms.Views
{
	public partial class Next2Page : ContentPage
	{

		// String array to store titles for the viewpoints specified above.
		private string[] titles = new string[]
		{
			"Topo",
			"Streets",
			"Imagery",
			"Ocean"
		};

		// String array to store titles for the viewpoints specified above.
		public Next2Page()
		{
			InitializeComponent();

			initBasemap();
		}

		private async void OnChangeBasemapButtonClicked(object sender, EventArgs e)
		{
			// Show sheet and get title from the selection
			var selectedBasemap =
				await DisplayActionSheet("Select basemap", "Cancel", null, titles);

			// If selected cancel do nothing
			if (selectedBasemap == "Cancel") return;

			switch (selectedBasemap)
			{
				case "Topo":

					// Set the basemap to Topographic
					MyMapView.Map.Basemap = Basemap.CreateTopographic();
					break;

				case "Streets":

					// Set the basemap to Streets
					MyMapView.Map.Basemap = Basemap.CreateStreets();
					break;

				case "Imagery":

					// Set the basemap to Imagery
					MyMapView.Map.Basemap = Basemap.CreateImagery();
					break;

				case "Ocean":

					// Set the basemap to Imagery
					MyMapView.Map.Basemap = Basemap.CreateOceans();
					break;

				default:
					break;
			}
		}

		private void initBasemap()
		{
			// Create new Map with basemap
			Map myMap = new Map(Basemap.CreateTopographic());

			// Assign the map to the MapView
			MyMapView.Map = myMap;
		}

	}

}


