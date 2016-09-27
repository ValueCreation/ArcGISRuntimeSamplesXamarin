using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using System;
using System.Linq;
using Xamarin.Forms;

#if WINDOWS_UWP
using Colors = Windows.UI.Colors;
#else
using Colors = System.Drawing.Color;
#endif

namespace ArcGISRuntimeSamples01
{
	public partial class ArcGISRuntimeSamples01Page : ContentPage
	{
		private string[] titles = new string[]
		{
			"地形図",
			"道路地図",
			"衛星画像",
			"海洋図"
		};

		private GraphicsOverlay _polygonOverlay;

		public ArcGISRuntimeSamples01Page()
		{

			MyMapView = new Esri.ArcGISRuntime.Xamarin.Forms.MapView();

			InitializeComponent();

			Title = "サンプル地図";

			Initialize();

		}

		private async void OnChangeBasemapButtonClicked(object sender, EventArgs e)
		{

			var selectedBasemap =
				await DisplayActionSheet("背景地図の選択", "キャンセル", null, titles);

			if (selectedBasemap == "Cancel") return;

			switch (selectedBasemap)
			{
				case "地形図":
					MyMapView.Map.Basemap = Basemap.CreateTopographic();
					break;
				case "道路地図":
					MyMapView.Map.Basemap = Basemap.CreateStreets();
					break;
				case "衛星画像":
					MyMapView.Map.Basemap = Basemap.CreateImageryWithLabels();
					break;
				case "海洋図":
					MyMapView.Map.Basemap = Basemap.CreateOceans();
					break;
				default:
					break;

			}
		}

		private void Initialize()
		{
			// 背景地図の作成
			Map myMap = new Map(Basemap.CreateTopographic());

			MyMapView.Map = myMap;

			// 地図の初期表示設定
			Envelope initialLocation = new Envelope(
				139.73796129226685, 35.676132273129205, 139.76033164024353, 35.67623685688028,
				SpatialReferences.Wgs84);

			myMap.InitialViewpoint = new Viewpoint(initialLocation);

			// ポリゴンの表示
			CreateOverlay();

			// ジオコーディング
			var address = "東京都千代田区永田町２‐２‐２";
			geocoding(address);

		}

		private void CreateOverlay()
		{
			// Create polygon builder and add polygon corners into it
			PolygonBuilder builder = new PolygonBuilder(SpatialReferences.Wgs84);

			builder.AddPoint(new MapPoint(139.7439694404602, 35.67343919433673));
			builder.AddPoint(new MapPoint(139.74006414413452, 35.673264881898525));
			builder.AddPoint(new MapPoint(139.7426176071167, 35.67146944163043));
			builder.AddPoint(new MapPoint(139.7437334060669, 35.671992389566405));
			builder.AddPoint(new MapPoint(139.74454879760742, 35.67209697874246));

			// Get geometry from the builder
			Polygon polygonGeometry = builder.ToGeometry();

			// Create symbol for the polygon
			SimpleFillSymbol polygonSymbol = new SimpleFillSymbol(
				SimpleFillSymbolStyle.Solid,
			   Colors.Yellow,
				null);

			// Create new graphic
			Graphic polygonGraphic = new Graphic(polygonGeometry, polygonSymbol);

			// Create overlay to where graphics are shown
			_polygonOverlay = new GraphicsOverlay();
			_polygonOverlay.Graphics.Add(polygonGraphic);

			// Add created overlay to the MapView
			MyMapView.GraphicsOverlays.Add(_polygonOverlay);
		}

		public async void geocoding(string address)
		{

			var geocodeServiceUrl = @"http://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer";
			LocatorTask geocodeTask = await LocatorTask.CreateAsync(new Uri(geocodeServiceUrl));

			// set geocode parameters to search within Japan
			var geocodeParams = new GeocodeParameters
			{
				CountryCode = "Japan"
			};

			// geocode the Japanese Prime Minister's office address
			var matches = await geocodeTask.GeocodeAsync(address, geocodeParams);
			// get the top match (first one), return if none are found
			// (add a using statement for System.Linq to enable syntax like the following)
			var bestMatch = matches.FirstOrDefault();

			if (bestMatch == null)
			{
				return;
			}
			else
			{
				GraphicsOverlay overlay = new GraphicsOverlay();

				// Create symbol for points
				SimpleMarkerSymbol pointSymbol = new SimpleMarkerSymbol()
				{
					Color = Colors.Blue,
					Size = 20,
					Style = SimpleMarkerSymbolStyle.Circle,
				};

				// Create simple renderer with symbol
				SimpleRenderer renderer = new SimpleRenderer(pointSymbol);

				var point = new MapPoint(bestMatch.InputLocation.X, bestMatch.InputLocation.Y, SpatialReferences.Wgs84);

				overlay.Graphics.Add(new Graphic(point));

				// Set renderer to graphics overlay
				overlay.Renderer = renderer;

				// Add created overlay to the MapView
				MyMapView.GraphicsOverlays.Add(overlay);

			}

		}

	}
}
