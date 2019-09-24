using System;
using System.Reflection;
using System.Resources;
using System.Windows.Input;
using ItechArt.DrawioSharing.Resources.Resources;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ItechArt.DrawioSharing.UI.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private bool _isVisible;

        private bool _isFrench;

        private string _message;

        public string Message
        {
            get => _message;
            protected set => SetProperty(ref _message, value);
        }

        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        public ICommand OpenDiagramsCommand { get; }

        public ICommand OpenSettingsCommand { get; }

        public ICommand OpenAboutCommand { get; }

        public ICommand ShowWindowCommand { get; }

        public ICommand ExitCommand { get; }

        public ICommand LangCommand { get; }

        public event EventHandler ClosedViewModel;


        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            OpenDiagramsCommand = new DelegateCommand(OpenDiagrams);
            OpenSettingsCommand = new DelegateCommand(OpenSettings);
            OpenAboutCommand = new DelegateCommand(OpenAbout);
            ShowWindowCommand = new DelegateCommand(ShowWindow);
            ExitCommand = new DelegateCommand(Exit);
            LangCommand = new DelegateCommand(Changelanguage);
        }


        public MainViewModel()
        {
            IsVisible = true;
        }


        private void OpenDiagrams()
        {
            ShowView(DrawioSharingViews.DiagramsView);
        }

        private void OpenSettings()
        {
            ShowView(DrawioSharingViews.SettingsView);
        }

        private void OpenAbout()
        {
            ShowView(DrawioSharingViews.AboutView);
        }

        private void ShowView(string viewName)
        {
            _regionManager.RequestNavigate(DrawioSharingRegions.ContentRegion, viewName);

            ShowWindow();
        }

        private void ShowWindow()
        {
            IsVisible = true;
        }

        private void Exit()
        {
            ClosedViewModel?.Invoke(this, new EventArgs());
        }
        private void Changelanguage()
        {
            string s = Resource.ResourceManager.GetString("DrawandSharing");
            Message = s;
        }
    }
}