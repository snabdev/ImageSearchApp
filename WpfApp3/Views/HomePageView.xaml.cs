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
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for HomePageView.xaml
    /// </summary>
    public partial class HomePageView : UserControl
    {
        public HomePageView()
        {
            InitializeComponent();
            IPhotoFeedTypeSelectorFactory photoFeedTypeSelectorFactory = new PhotoFeedTypeSelectorFactory();
            IPhotoFeedTypeSelector photoFeedSelector = photoFeedTypeSelectorFactory.GetPhotoFeedTypeSelectorInstance();
            ISearchEngineWrapper searchEngineWrapper = new SearchEngineWrapper(photoFeedSelector);

            photoFeedSelector.PublishPhotoFeedSelectionChange(PhotoFeedType.FLICKR);
            HomePageViewModel homePageViewModel = new HomePageViewModel(searchEngineWrapper.CreateSearchEngine());
            this.DataContext = homePageViewModel;
        }
    }
}
