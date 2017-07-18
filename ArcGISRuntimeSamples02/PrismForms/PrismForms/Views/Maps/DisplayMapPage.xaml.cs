using Esri.ArcGISRuntime.Mapping;
using Xamarin.Forms;

namespace PrismForms.Views
{
	public partial class DisplayMapPage : ContentPage
	{
		public DisplayMapPage()
		{
			InitializeComponent();

			Initialize();
		}

		private void Initialize()
		{

			Map myMap = new Map(Basemap.CreateImagery());

			MyMapView.Map = myMap;

		}
	}
}

