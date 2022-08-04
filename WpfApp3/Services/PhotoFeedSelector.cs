using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Interfaces;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class PhotoFeedSelector : IPhotoFeedSelector
    {
        public delegate void PhotoFeedSelectionChange(PhotoFeedType feedType);
        public event PhotoFeedSelectionChange PhotoFeedSelectionChangedEvent;

        public void PublishPhotoFeedSelectionChange(PhotoFeedType feedType)
        {
            PhotoFeedSelectionChangedEvent(feedType);
        }

        public void SubscribeToPhotoFeedSelectionChange(Action<PhotoFeedType> handler)
        {
            PhotoFeedSelectionChangedEvent += new PhotoFeedSelectionChange(handler);
        }

        public void UnsubscribeFromPhotoFeedSelectionChange(Action<PhotoFeedType> handler)
        {
            PhotoFeedSelectionChangedEvent -= new PhotoFeedSelectionChange(handler);

        }
    }
}
