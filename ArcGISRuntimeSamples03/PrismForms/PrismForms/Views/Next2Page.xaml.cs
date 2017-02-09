using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System;
using Xamarin.Forms;

namespace PrismForms.Views
{
	public partial class Next2Page : ContentPage
	{

		private string _navigationUrl = "https://www.arcgis.com/home/item.html?id=dcbbba0edf094eaa81af19298b9c6247";
		private string _streetUrl = "https://www.arcgis.com/home/item.html?id=4e1133c28ac04cca97693cf336cd49ad";
		private string _nightUrl = "https://www.arcgis.com/home/item.html?id=bf79e422e9454565ae0cbe9553cf6471";
		private string _darkGrayUrl = "https://www.arcgis.com/home/item.html?id=850db44b9eb845d3bd42b19e8aa7a024";

		private string _vectorTiledLayerUrl;
		private ArcGISVectorTiledLayer _vectorTiledLayer;

		// String array to store some vector layer choices
		private string[] _vectorLayerNames = new string[]
		{
			"Dark gray",
			"Streets",
			"Night",
			"Navigation"
		};

		// String array to store titles for the viewpoints specified above.
		public Next2Page()
		{
			InitializeComponent();

			initVectorTiledLayer();
		}

		private async void OnChangeLayerButtonClicked(object sender, EventArgs e)
		{
			// Show sheet and get title from the selection
			var selectedLayer =
				await DisplayActionSheet("Select basemap", "Cancel", null, _vectorLayerNames);

			// If selected cancel do nothing
			if (selectedLayer == "Cancel") return;

			switch (selectedLayer)
			{
				case "Dark gray":
					_vectorTiledLayerUrl = _darkGrayUrl;
					break;

				case "Streets":
					_vectorTiledLayerUrl = _streetUrl;
					break;

				case "Night":
					_vectorTiledLayerUrl = _nightUrl;
					break;

				case "Navigation":
					_vectorTiledLayerUrl = _navigationUrl;
					break;

				default:
					break;
			}

			// Create a new ArcGISVectorTiledLayer with the Url Selected by the user
			_vectorTiledLayer = new ArcGISVectorTiledLayer(new Uri(_vectorTiledLayerUrl));

			// // Create new Map with basemap and assigning to the Mapviews Map
			MyMapView.Map = new Map(new Basemap(_vectorTiledLayer));

			addFeatureLayer();

		}

		private void initVectorTiledLayer()
		{
			// Create a new ArcGISVectorTiledLayer with the navigation serice Url
			_vectorTiledLayer = new ArcGISVectorTiledLayer(new Uri(_nightUrl));

			// Create new Map with basemap
			MyMapView.Map = new Map(new Basemap(_vectorTiledLayer));

			addFeatureLayer();

		}

		private void addFeatureLayer()
		{

			// Create and set initial map area
			Envelope initialLocation = new Envelope(
				139.6297352, 35.6006059000001, 139.7937877, 35.7308676000001,
				SpatialReferences.Wgs84);
			MyMapView.Map.InitialViewpoint = new Viewpoint(initialLocation);

			// Create uri to the used feature service
			var serviceUri = new Uri("https://services5.arcgis.com/HzGpeRqGvs5TMkVr/arcgis/rest/services/osmdata/FeatureServer/0");

			// Create feature table for the pools feature service
			ServiceFeatureTable poolsFeatureTable = new ServiceFeatureTable(serviceUri);

			// Define the request mode
			poolsFeatureTable.FeatureRequestMode = FeatureRequestMode.OnInteractionCache;

			// Create FeatureLayer that uses the created table
			FeatureLayer osmLayer = new FeatureLayer(poolsFeatureTable);

			// Add created layer to the map
			MyMapView.Map.OperationalLayers.Add(osmLayer);

		}
	}

}


