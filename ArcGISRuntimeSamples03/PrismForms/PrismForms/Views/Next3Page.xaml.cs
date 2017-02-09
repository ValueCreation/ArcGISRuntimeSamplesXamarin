using Esri.ArcGISRuntime.Mapping;
using System;
using Xamarin.Forms;

namespace PrismForms.Views
{
	public partial class Next3Page : ContentPage
	{
		public Next3Page()
		{
			InitializeComponent();

			InitTakeScreenshot();
		}

		private void InitTakeScreenshot()
		{
			// Create a new Map instance with the basemap  
			Basemap myBasemap = Basemap.CreateStreets();
			Map myMap = new Map(myBasemap);

			// Assign the map to the MapView
			MyMapView.Map = myMap;
		}

		private async void OnTakeScreenshotClicked(object sender, EventArgs e)
		{
			// Export the image from mapview and assign it to the imageview
			var exportedImage = await MyMapView.ExportImageAsync();

			// Create layout for sublayers page
			// Create root layout
			var layout = new StackLayout();

			var closeButton = new Button
			{
				Text = "Close"
			};
			closeButton.Clicked += CloseButton_Clicked;

			// Create image bitmap by getting stream from the exported image
			var buffer = await exportedImage.GetEncodedBufferAsync();
			byte[] data = new byte[buffer.Length];
			buffer.Read(data, 0, data.Length);
			var bitmap = ImageSource.FromStream(() => new System.IO.MemoryStream(data));
			var image = new Image()
			{
				Source = bitmap,
				Margin = new Thickness(10)
			};

			// Add elements into the layout
			layout.Children.Add(closeButton);
			layout.Children.Add(image);

			// Create internal page for the navigation page
			var screenshotPage = new ContentPage()
			{
				Content = layout,
				Title = "Screenshot"
			};

			// Navigate to the sublayers page
			await Navigation.PushAsync(screenshotPage);
		}

		private async void CloseButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

	}
}

