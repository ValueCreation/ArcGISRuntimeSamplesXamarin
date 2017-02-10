using Xamarin.Forms;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI.Controls;
using Esri.ArcGISRuntime.UI;
using System;

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


		}
	}
}

