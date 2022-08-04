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
    /// Interaction logic for ImageSearchResultUserControl.xaml
    /// </summary>
    public partial class ImageSearchResultUserControl : UserControl
    {
        public ImageSearchResultUserControl()
        {
            InitializeComponent();

            IPhotoFeedTypeSelectorFactory photoFeedSelectorFactory = new PhotoFeedTypeSelectorFactory();
            IPhotoFeedTypeSelector photoFeedSelector = photoFeedSelectorFactory.GetPhotoFeedTypeSelectorInstance();
            ISearchEngineWrapper searchEngineWrapper = new SearchEngineWrapper(photoFeedSelector);

            ImageSearchResultsViewModel imageSearchResultsViewModel = new ImageSearchResultsViewModel(searchEngineWrapper.CreateSearchEngine());
            this.DataContext = imageSearchResultsViewModel;
        }
    }
}
