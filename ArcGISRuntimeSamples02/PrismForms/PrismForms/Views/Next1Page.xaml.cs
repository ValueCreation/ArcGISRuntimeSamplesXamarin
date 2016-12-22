using Esri.ArcGISRuntime.Mapping;
using Xamarin.Forms;


namespace PrismForms.Views
{
	public partial class Next1Page : ContentPage
	{
		public Next1Page()
		{
			InitializeComponent();

			Init3Map();
		}

		private void Init3Map() { 

			// create a new scene with a topographic basemap
			var myScene = new Scene(Basemap.CreateTopographic());

			MySceneView.Scene = myScene;

			// create an elevation source
			var elevationSource = new ArcGISTiledElevationSource(new System.Uri("http://elevation3d.arcgis.com/arcgis/rest/services/WorldElevation3D/Terrain3D/ImageServer"));
			// create a surface and add the elevation surface
			var sceneSurface = new Surface();
			sceneSurface.ElevationSources.Add(elevationSource);

			// apply the surface to the scene
			MySceneView.Scene.BaseSurface = sceneSurface;

			var snowdonCamera = new Camera(53.06, -4.04, 1289, 295, 71, 0);

			MySceneView.SetViewpointCamera(snowdonCamera);

		}
	}
}

