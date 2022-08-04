using WpfApp3.Services;

namespace WpfApp3.Interfaces
{
    public interface IPhotoFeedTypeSelectorFactory
    {
        IPhotoFeedTypeSelector GetPhotoFeedTypeSelectorInstance();
    }
}