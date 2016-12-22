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
		public ICommand NavigateNext1Command { get; }
		public ICommand NavigateNext2Command { get; }
		public ICommand NavigateNext3Command { get; }

		public MainPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;

			NavigateNext1Command = new DelegateCommand(() =>
			{
				_navigationService.NavigateAsync("Next1Page");
			});

			NavigateNext2Command = new DelegateCommand(() =>
			{
				_navigationService.NavigateAsync("Next2Page");
			});

			NavigateNext3Command = new DelegateCommand(() =>
			{
				_navigationService.NavigateAsync("Next3Page");
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

