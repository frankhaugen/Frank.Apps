using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using YouTubeSearch;
using Button = System.Windows.Controls.Button;

namespace Frank.Apps.YouTube
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<(Label, Button)> collection = new ObservableCollection<(Label, Button)>();

        public MainWindow()
        {
            InitializeComponent();

            ResultsList.ItemsSource = collection;
            ResultsList.DataContext = collection;
        }

        private async void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            var search = new VideoSearch();

            var list = await search.GetVideos("John Skeet programmer, long", 1);

            foreach (var videoSearchComponent in list)
            {
                var title = new Label();
                title.Content = videoSearchComponent.getTitle();

                var button = new System.Windows.Controls.Button();
                button.Content = videoSearchComponent.getUrl();
                button.Click += (o, args) => Process.Start(videoSearchComponent.getUrl());

                collection.Add((title, button));
                //collection.Add((videoSearchComponent.getTitle(), new Uri(videoSearchComponent.getUrl())));
            }
        }
    }
}
