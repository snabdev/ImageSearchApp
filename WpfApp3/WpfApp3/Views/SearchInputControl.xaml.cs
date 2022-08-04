using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp3.Interfaces;
using WpfApp3.Services;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for SearchInputControl.xaml
    /// </summary>
    public partial class SearchInputControl : UserControl
    {
        public SearchInputControl()
        {
            InitializeComponent();

            IPhotoFeedSelectorFactory photoFeedSelectorFactory = new PhotoFeedSelectorFactory();
            IPhotoFeedSelector photoFeedSelector = photoFeedSelectorFactory.GetPhotoFeedSelectorInstance();
            ISearchEngineWrapper searchEngineWrapper = new SearchEngineWrapper(photoFeedSelector);

            ImageSearchViewModel ImageSearchViewModel = new ImageSearchViewModel(searchEngineWrapper.CreateSearchEngine());
            this.DataContext = ImageSearchViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
