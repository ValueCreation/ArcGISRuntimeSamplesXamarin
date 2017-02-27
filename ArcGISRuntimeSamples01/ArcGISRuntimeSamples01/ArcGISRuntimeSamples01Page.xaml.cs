using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using Esri.ArcGISRuntime.Symbology;
using System;
using Xamarin.Forms;

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

		public ArcGISRuntimeSamples01Page()
		{

			InitializeComponent();

			Title = "背景地図";

			Initialize();

		}

		private async void OnChangeBasemapButtonClicked(object sender, EventArgs e)
		{

			var selectedBasemap =
				await DisplayActionSheet("背景地図の選択", "キャンセル", null, titles);

			if (selectedBasemap == "Cancel") return;
			// 背景地図の選択
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
			// 背景地図（地形図）の設定と初期表示の位置を設定
			Map myMap = new Map(BasemapType.Topographic, 35.6761, 139.7379, 10);

			MyMapView.Map = myMap;
		}

	}
}
