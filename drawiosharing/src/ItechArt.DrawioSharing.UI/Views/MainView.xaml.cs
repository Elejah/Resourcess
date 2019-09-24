using System;
using System.ComponentModel;
using ItechArt.DrawioSharing.UI.ViewModels;

namespace ItechArt.DrawioSharing.UI.Views
{
    public partial class MainView
    {
        private bool _isExit;


        public MainView()
        {
            InitializeComponent();

            var viewModel = (MainViewModel)DataContext;
            viewModel.ClosedViewModel += MainViewModelOnCloseWindow;
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (_isExit)
            {
                return;
            }
            e.Cancel = true;
            Hide();
        }

        private void MainViewModelOnCloseWindow(object sender, EventArgs e)
        {
            _isExit = true;
            Close();
        }

    }
}