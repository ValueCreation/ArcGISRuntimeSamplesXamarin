using Xamarin.Forms;
using Esri.ArcGISRuntime.Mapping;

namespace PrismForms.Views
{
	public partial class DisplayScenePage : ContentPage
	{
		public DisplayScenePage()
		{
			InitializeComponent();

			Initialize();

		}

		private void Initialize()
		{

			var myScene = new Scene(Basemap.CreateImagery());

			MySceneView.Scene = myScene;

			var camera = new Camera(45.7, 6.88, 4500, 10, 70, 0);
			MySceneView.SetViewpointCamera(camera);

			var surface = new Surface();

			var url = new System.Uri("https://elevation3d.arcgis.com/arcgis/rest/services/WorldElevation3D/Terrain3D/ImageServer");

			var elevationSource = new ArcGISTiledElevationSource(url);
			surface.ElevationSources.Add(elevationSource);
			myScene.BaseSurface = surface;

		}
	}
}

