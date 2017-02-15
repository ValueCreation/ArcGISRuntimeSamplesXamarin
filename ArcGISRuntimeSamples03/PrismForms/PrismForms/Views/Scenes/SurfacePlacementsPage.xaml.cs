using Xamarin.Forms;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Geometry;
using System;

#if WINDOWS_UWP
using Colors = Windows.UI.Colors;
#else
using Colors = System.Drawing.Color;
#endif

namespace PrismForms.Views
{
	public partial class SurfacePlacementsPage : ContentPage
	{
		public SurfacePlacementsPage()
		{
			InitializeComponent();

			Initialize();
		}

		private GraphicsOverlay drapedGraphicsOverlay = new GraphicsOverlay();
		private GraphicsOverlay relativeGraphicsOverlay = new GraphicsOverlay();
		private GraphicsOverlay absoluteGraphicsOverlay = new GraphicsOverlay();

		private void Initialize()
		{
			var myScene = new Scene(Basemap.CreateTopographic());
			MySceneView.Scene = myScene;

			var camera = new Camera(53.04, -4.04, 1300, 0, 90, 0);
			MySceneView.SetViewpointCamera(camera);

			var surface = new Surface();
			var url = new System.Uri("https://elevation3d.arcgis.com/arcgis/rest/services/WorldElevation3D/Terrain3D/ImageServer");
			var elevationSource = new ArcGISTiledElevationSource(url);
			surface.ElevationSources.Add(elevationSource);
			myScene.BaseSurface = surface;

			drapedGraphicsOverlay.SceneProperties.SurfacePlacement = SurfacePlacement.Draped;
			relativeGraphicsOverlay.SceneProperties.SurfacePlacement = SurfacePlacement.Relative;
			absoluteGraphicsOverlay.SceneProperties.SurfacePlacement = SurfacePlacement.Absolute;

			MySceneView.GraphicsOverlays.Add(drapedGraphicsOverlay);
			MySceneView.GraphicsOverlays.Add(relativeGraphicsOverlay);
			MySceneView.GraphicsOverlays.Add(absoluteGraphicsOverlay);

			addGraphics();

		}

		private void addGraphics()
		{
			var point = new MapPoint(-4.04, 53.06, 1000, SpatialReferences.Wgs84);

			drapedGraphicsOverlay.Graphics.Add(new Graphic(point, pointSymbol()));
			drapedGraphicsOverlay.Graphics.Add(new Graphic(point, textSymbol("Draped")));

			relativeGraphicsOverlay.Graphics.Add(new Graphic(point, pointSymbol()));
			relativeGraphicsOverlay.Graphics.Add(new Graphic(point, textSymbol("Relative")));

			absoluteGraphicsOverlay.Graphics.Add(new Graphic(point, pointSymbol()));
			absoluteGraphicsOverlay.Graphics.Add(new Graphic(point, textSymbol("Absolute")));

		}

		private SimpleMarkerSceneSymbol pointSymbol()
		{
			return new SimpleMarkerSceneSymbol(SimpleMarkerSceneSymbolStyle.Sphere, Colors.Red, 50, 50, 50, SceneSymbolAnchorPosition.Center);
		}


		private TextSymbol textSymbol(String text)
		{
			return new TextSymbol(text, Colors.Blue, 20, HorizontalAlignment.Left, VerticalAlignment.Middle);
		}

	}

}