using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Interfaces;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    class SearchEngineFactory : ISearchEngineFactory
    {
        private static ISearchEngine _searchEngine;
        private IPhotoFeedFactory _photoFeedFactory;

        public SearchEngineFactory(IPhotoFeedFactory photoFeedFactory)
        {
            _photoFeedFactory = photoFeedFactory;
        }

        public ISearchEngine GetSearchEngineInstance(PhotoFeedType photoFeed)
        {
            if (_searchEngine == null)
            {
                _searchEngine = new SearchEngine(_photoFeedFactory.GetPhotoFeed(photoFeed));
            }
            return _searchEngine;
        }
    }
}
