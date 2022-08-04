using System;
using WpfApp3.Models;
using WpfApp3.Services;

namespace WpfApp3.Interfaces
{
    public interface IPhotoFeedTypeSelector
    {
        void PublishPhotoFeedSelectionChange(PhotoFeedType feedType);

        void SubscribeToPhotoFeedSelectionChange(Action<PhotoFeedType> feedType);

        void UnsubscribeFromPhotoFeedSelectionChange(Action<PhotoFeedType> feedType);

    }
}
