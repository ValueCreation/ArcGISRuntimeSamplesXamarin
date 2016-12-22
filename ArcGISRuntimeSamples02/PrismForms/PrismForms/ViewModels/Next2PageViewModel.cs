using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismForms.ViewModels
{
	public class Next2PageViewModel : BindableBase
	{
		private readonly INavigationService _navigationService;
		public ICommand GoBack2Command { get; }
		public Next2PageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			GoBack2Command = new DelegateCommand(() =>
			{
				_navigationService.GoBackAsync();
			});

		}
	}
}
