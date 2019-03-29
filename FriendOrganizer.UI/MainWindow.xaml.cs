using FriendOrganizer.UI.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FriendOrganizer.UI
{
    
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            //viewModel.Load(); ERRADO!!!
            Loaded += MainWindow_Loaded;//Chama no load event handler
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
