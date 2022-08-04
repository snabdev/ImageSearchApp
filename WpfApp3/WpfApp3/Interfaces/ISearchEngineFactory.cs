

using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3.Interfaces
{
    internal interface ISearchEngineFactory
    {
        ISearchEngine GetSearchEngineInstance(PhotoFeedType photoFeed);
    }
}