using FlickrNet;
using WpfApp3.Interfaces;

namespace WpfApp3.Services
{
    class TwitterFeed : IFeed
    {
        public TwitterFeed() { }
        public TwitterFeed(string apiKey) { }

        public PhotoCollection PhotosSearch(PhotoSearchOptions options)
        {
            return new PhotoCollection();
        }
    }
}
