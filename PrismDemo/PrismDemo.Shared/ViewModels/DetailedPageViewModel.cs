using System;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;
using PrismDemo.Events;

namespace PrismDemo.ViewModels
{
    class DetailedPageViewModel: ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }

        public DetailedPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<NavigateToSharedEvent>().Subscribe(NavigatingFromMainPage);

            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void NavigatingFromMainPage(string obj)
        {
            Message = obj;
        }

        private void Navigate()
        {
            _navigationService.GoBack();
        }
    }
}
