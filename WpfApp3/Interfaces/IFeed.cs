using FlickrNet;

namespace WpfApp3.Interfaces
{
    public interface IFeed
    {
        PhotoCollection PhotosSearch(PhotoSearchOptions options);
    }
}