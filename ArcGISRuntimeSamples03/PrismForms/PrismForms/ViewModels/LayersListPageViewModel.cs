using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismForms.ViewModels
{
	public class LayersListPageViewModel : BindableBase
	{
		private readonly INavigationService _navigationService;
		public ICommand GoBack3Command { get; }
		public LayersListPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			GoBack3Command = new DelegateCommand(() =>
			{
				_navigationService.GoBackAsync();
			});

		}
	}
}

