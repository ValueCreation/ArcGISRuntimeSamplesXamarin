using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PrismForms.ViewModels
{
	public class Next1PageViewModel : BindableBase
	{
		private readonly INavigationService _navigationService;
		public ICommand GoBackCommand { get; }
		public Next1PageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			GoBackCommand = new DelegateCommand(() =>
			{
				_navigationService.GoBackAsync();
			});                                 

		}
	}
}
