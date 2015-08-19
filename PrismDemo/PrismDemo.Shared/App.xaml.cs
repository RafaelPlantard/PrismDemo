using System;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Windows.ApplicationModel.Activation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;
using PrismDemo.Models;

namespace PrismDemo
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : MvvmAppBase
    {
        IUnityContainer _container = new UnityContainer();

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);

            return Task.FromResult<object>(null);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            _container.RegisterInstance<ISessionStateService>(SessionStateService);
            _container.RegisterInstance<INavigationService>(NavigationService);

            // Registrar todas types utilizados pelo container.
            _container.RegisterInstance<IEventAggregator>(new EventAggregator());

            ViewModelLocationProvider.SetDefaultViewModelFactory((viewModelType) => _container.Resolve(viewModelType));

            return Task.FromResult<object>(null);
        }

        protected override void OnRegisterKnownTypesForSerialization()
        {
            base.OnRegisterKnownTypesForSerialization();

            SessionStateService.RegisterKnownType(typeof(MainModel));
        }

    }
}