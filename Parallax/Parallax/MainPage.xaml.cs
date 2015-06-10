using System;
using System.Diagnostics;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;
using Parallax.MVVM;

namespace Parallax
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            //TODO: Make navigation cache persistant
            NavigationCacheMode = NavigationCacheMode.Required;
            Loaded += MainPage_Loaded;
        }

        async void MainPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            EventViewModel eventViewModel = await EventViewModel.CreateTaskAsync();
            stopwatch.Stop();
            await new MessageDialog(stopwatch.ElapsedMilliseconds.ToString()).ShowAsync();
        }
    }
}
