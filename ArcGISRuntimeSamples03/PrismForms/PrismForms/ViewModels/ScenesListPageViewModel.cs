using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismForms.ViewModels
{
	public class ScenesListPageViewModel : BindableBase
	{
		private readonly INavigationService _navigationService;
		public ICommand GoBack1Command { get; }
		public ScenesListPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			GoBack1Command = new DelegateCommand(() =>
			{
				_navigationService.GoBackAsync();
			});

		}
	}
}
