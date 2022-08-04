using FlickrNet;
using WpfApp3.Interfaces;

namespace WpfApp3.Services
{
    class FlickrFeed : Flickr, IFeed
    {
        public FlickrFeed() : base() { }
        public FlickrFeed(string apiKey) : base(apiKey) { }
        public FlickrFeed(string apiKey, string sharedSecret) : base(apiKey, sharedSecret) { }
        public FlickrFeed(string apiKey, string sharedSecret, string token) : base(apiKey, sharedSecret, token) { }
    }
}
