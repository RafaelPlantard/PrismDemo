using System;
using System.Collections.Generic;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using PrismDemo.Models;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.PubSubEvents;
using PrismDemo.Events;

namespace PrismDemo.ViewModels
{
    class MainPageViewModel : ViewModel
    {
        private MainModel _model;
        private readonly INavigationService _navigateService;
        private readonly IEventAggregator _eventAggregator;

        [RestorableState]
        public MainModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainPageViewModel(INavigationService navigateService, IEventAggregator eventAggregator)
        {
            _navigateService = navigateService;
            _eventAggregator = eventAggregator;
            
            NavigateCommand = new DelegateCommand<string>(Navigate);

            Model = new MainModel
            {
                Title = "Página Principal"
            };
        }

        private void Navigate(string message)
        {
            _navigateService.Navigate("Detailed", null);

            _eventAggregator.GetEvent<NavigateToSharedEvent>().Publish(message);
        }

        public override void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatedFrom(viewModelState, suspending);
        }

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
        }
    }
}
