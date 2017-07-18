using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismForms.ViewModels
{
	public class FeaturesListPageViewModel : BindableBase
	{
		private readonly INavigationService _navigationService;
		public ICommand GoBack4Command { get; }

		public FeaturesListPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			GoBack4Command = new DelegateCommand(() =>
			{
				_navigationService.GoBackAsync();
			});

		}
	}
}
