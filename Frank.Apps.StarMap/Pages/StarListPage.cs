using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Controls;
using Frank.Apps.StarMap.Models;
using Frank.Apps.StarMap.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Frank.Apps.StarMap.Pages
{
    public class StarListPage : Page
    {
        private ObservableCollection<Star> _stars;

        public StarListPage(DataContext dataContext)
        {
            Title = "Star list";
            _stars = new ObservableCollection<Star>(dataContext.Stars.AsNoTracking());

            var view = new DataGrid()
            {
                ItemsSource = _stars,
                DataContext = _stars,
                MaxHeight = 1024
            };

            Content = view;
        }
    }
}
