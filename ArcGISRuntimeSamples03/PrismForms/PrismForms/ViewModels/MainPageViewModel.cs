using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismForms.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		private string _title;
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		private readonly INavigationService _navigationService;
		public ICommand NavigateMapsListPageCommand { get; }
		public ICommand NavigateScenesListPageCommand { get; }

		public MainPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;

			NavigateMapsListPageCommand = new DelegateCommand(() =>
			{
				_navigationService.NavigateAsync("MapsListPage");
			});

			NavigateScenesListPageCommand = new DelegateCommand(() =>
			{
				_navigationService.NavigateAsync("ScenesListPage");
			});
		
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("title"))
				Title = (string)parameters["title"] + " 2016";
		}
	}
}

