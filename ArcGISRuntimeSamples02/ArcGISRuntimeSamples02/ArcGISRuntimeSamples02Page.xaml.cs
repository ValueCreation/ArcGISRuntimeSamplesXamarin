using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Portal;
using Esri.ArcGISRuntime.Xamarin.Forms;
using System;
using Xamarin.Forms;

namespace ArcGISRuntimeSamples02
{
	public partial class ArcGISRuntimeSamples02Page : ContentPage
	{

		private FeatureLayer _featureLayer;

		public ArcGISRuntimeSamples02Page()
		{

			MyMapView = new Esri.ArcGISRuntime.Xamarin.Forms.MapView();

			InitializeComponent();

			Title = "WebMap";

			Initialize();

		}

		public async void Initialize()
		{


			ArcGISPortal arcGISOnline = await ArcGISPortal.CreateAsync();

			var portalItem = await ArcGISPortalItem.CreateAsync(arcGISOnline, "e502689353eb44959ae6aee0abc43274");

			var myMap = new Map(portalItem);

			// Assign the map to the MapView
			MyMapView.Map = myMap;

			/*
			_featureLayer = MyMapView.Map.OperationalLayers[0] as FeatureLayer;

			_featureLayer.SelectionWidth = 3;

			await _featureLayer.LoadAsync();

			// Check for the load status. If the layer is loaded then add it to map
			if (_featureLayer.LoadStatus == LoadStatus.Loaded)
			{
				// Add the feature layer to the map
				//myMap.OperationalLayers.Add(_featureLayer);

				// Add tap event handler for mapview
				MyMapView.GeoViewTapped += OnMapViewTapped;
			}
            */

		}

		private async void OnMapViewTapped(object sender, GeoViewInputEventArgs e)
		{
			try
			{
				// Define the selection tolerance
				double tolerance = 5;

				// Convert the tolerance to map units
				double mapTolerance = tolerance * MyMapView.UnitsPerPixel;

				// Define the envelope around the tap location for selecting features
				var selectionEnvelope = new Envelope(e.Location.X - mapTolerance, e.Location.Y - mapTolerance, e.Location.X + mapTolerance,
					e.Location.Y + mapTolerance, MyMapView.Map.SpatialReference);

				// Define the query parameters for selecting features
				var queryParams = new Esri.ArcGISRuntime.Data.QueryParameters();

				// Set the geometry to selection envelope for selection by geometry
				queryParams.Geometry = selectionEnvelope;

				// Select the features based on query parameters defined above
				await _featureLayer.SelectFeaturesAsync(queryParams, SelectionMode.New);
			}
			catch (Exception ex)
			{
				await DisplayAlert("Sample error", ex.ToString(), "OK");
			}
		}

	}
}
