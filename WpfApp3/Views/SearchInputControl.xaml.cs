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
        ImageSearchViewModel imageSearchViewModel;
        public SearchInputControl()
        {
            InitializeComponent();

            IPhotoFeedTypeSelectorFactory photoFeedSelectorFactory = new PhotoFeedTypeSelectorFactory();
            IPhotoFeedTypeSelector photoFeedSelector = photoFeedSelectorFactory.GetPhotoFeedTypeSelectorInstance();
            ISearchEngineWrapper searchEngineWrapper = new SearchEngineWrapper(photoFeedSelector);

            imageSearchViewModel = new ImageSearchViewModel(searchEngineWrapper.CreateSearchEngine());
            this.DataContext = imageSearchViewModel;
        }


        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            imageSearchViewModel.OnClick();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            imageSearchViewModel.OnKeyDown();
        }
    }
}
