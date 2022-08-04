using System.Collections.Generic;
using WpfApp3.Interfaces;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    class PhotoFeedFactory : IPhotoFeedFactory
    {

        private static IPhotoFeed photoFeed;
        private Dictionary<PhotoFeedType, IPhotoFeed> feedInstances = new Dictionary<PhotoFeedType, IPhotoFeed>();
        public const string FLICKR_API_KEY = "9852f09bbeaaf18e29f08f91639d3455";
        public PhotoFeedFactory()
        {
            feedInstances = new Dictionary<PhotoFeedType, IPhotoFeed>()
            {
                { PhotoFeedType.FLICKR, new PhotoFeed() { Feed= new FlickrFeed(FLICKR_API_KEY)} },
                { PhotoFeedType.TWITTER, new PhotoFeed() { Feed= new TwitterFeed("ABCD")} }
            };


        }
        public IPhotoFeed GetPhotoFeed(PhotoFeedType feedtype)
        {
            if (feedInstances.ContainsKey(feedtype))
            {
                photoFeed = feedInstances[feedtype];
            }

            return photoFeed;
        }
    }
}
