using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Mapping;
using Xamarin.Forms;

namespace PrismForms.Views
{
	public partial class MapLoadedPage : ContentPage
	{
		public MapLoadedPage()
		{
			InitializeComponent();

			Initialize();
		}

		private void Initialize()
		{

			Map myMap = new Map(Basemap.CreateImageryWithLabels());

			myMap.LoadStatusChanged += OnMapsLoadStatusChanged;

			MyMapView.Map = myMap;

		}

		private void OnMapsLoadStatusChanged(object sender, LoadStatusEventArgs e)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
			loadStatusLabel.Text = string.Format(
				"Maps' load status : {0}",
				e.Status.ToString());
			});
		}
			
	}
}

