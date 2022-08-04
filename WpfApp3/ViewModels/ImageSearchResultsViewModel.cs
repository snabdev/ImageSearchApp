using FlickrNet;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Interfaces;
using WpfApp3.Services;

namespace WpfApp3
{
    class ImageSearchResultsViewModel : BindableBase
    {
        ISearchEngineFactory _searchEngineFactory;
        public ImageSearchResultsViewModel(ISearchEngine searchEngine)
        {
            searchEngine.SubscribeToEndSearch(EndSearchResultsHandler);
        }

        //public string MyPic { get; set; }
        private ObservableCollection<ImageResult> _pictures;
        public ObservableCollection<ImageResult> Pictures
        {
            get
            {
                return _pictures;
            }
            set
            {
                _pictures = value;
                RaisePropertyChanged(nameof(Pictures));
            }
        }

        public void EndSearchResultsHandler(EndSearchEventArgs eventArgs)
        {
            this.Pictures = new ObservableCollection<ImageResult>();
            if (eventArgs.SearchResults.Any())
            {
                this.Pictures = new ObservableCollection<ImageResult>(eventArgs.SearchResults.Select(o => new ImageResult() { ConvertedData = o.LargeUrl }));
            }
        }

        //public async Task EndSearchResultsHandler(PhotoCollection photos)
        //{
        //    await new Task(() =>
        //    {
        //        this.Pictures = new ObservableCollection<ImageResult>();
        //        if (photos.Any())
        //        {
        //            this.Pictures = new ObservableCollection<ImageResult>(photos.Select(o => new ImageResult() { ConvertedData = o.LargeUrl }));
        //        }
        //    });
        //}
    }
}
