using Prism.Unity;
using PrismForms.Views;
using Xamarin.Forms;

namespace PrismForms
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("NavigationPage/MainPage?title=Xamarin%20Advent%20Calendar");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<NavigationPage>();
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterTypeForNavigation<Next1Page>();
			Container.RegisterTypeForNavigation<Next2Page>();
			Container.RegisterTypeForNavigation<Next3Page>();

		}
	}
}

