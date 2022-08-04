using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Interfaces;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    class SearchEngineWrapper :ISearchEngineWrapper
    {
        private IPhotoFeedTypeSelector _photoFeedSelector;
        private PhotoFeedType _feedType;
        public SearchEngineWrapper(IPhotoFeedTypeSelector photoFeedSelector)
        {
            _photoFeedSelector = photoFeedSelector;

            _photoFeedSelector.SubscribeToPhotoFeedSelectionChange(this.PhotoFeedSelectionChangedHandler);
        }

        public void PhotoFeedSelectionChangedHandler(PhotoFeedType feedType)
        {
            _feedType = feedType;
        }

        public ISearchEngine CreateSearchEngine()
        {
            IPhotoFeedFactory photoFeedFactory = new PhotoFeedFactory();
            ISearchEngineFactory searchEngineFactory = new SearchEngineFactory(photoFeedFactory);

            return searchEngineFactory.GetSearchEngineInstance(_feedType);
        }
    }
}
