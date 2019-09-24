using ItechArt.Common.Logger;
using ItechArt.DrawioSharing.Foundation.HiServise;
using ItechArt.DrawioSharing.Foundation.Interfaces;
using Prism.Ioc;
using System.Windows;
using ItechArt.DrawioSharing.UI.Views;
using Prism.Mvvm;
using System;
using ItechArt.DrawioSharing.UI;
using System.Threading;
using System.Globalization;

namespace ItechArt.DrawioSharing
{
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILogger, Logger>();
            containerRegistry.RegisterSingleton<IHelloWorld, HelloWorld>();

            containerRegistry.RegisterForNavigation<AboutView>(DrawioSharingViews.AboutView);
            containerRegistry.RegisterForNavigation<SettingsView>(DrawioSharingViews.SettingsView);
            containerRegistry.RegisterForNavigation<DiagramsView>(DrawioSharingViews.DiagramsView);
        }

        protected override void OnInitialized()
        {
            //added for hide window on start up
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Cultures.English);
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                if (viewType.FullName == null)
                {
                    throw new ArgumentException("ViewType Name is null", nameof(viewType.FullName));
                }

                var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
                var viewModelType = viewType.Assembly.GetType($"{viewName}Model");

                return viewModelType;
            });
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
    }
}