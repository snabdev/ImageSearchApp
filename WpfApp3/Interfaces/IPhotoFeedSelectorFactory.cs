using WpfApp3.Services;

namespace WpfApp3.Interfaces
{
    public interface IPhotoFeedSelectorFactory
    {
        IPhotoFeedSelector GetPhotoFeedSelectorInstance();
    }
}