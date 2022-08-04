using WpfApp3.Interfaces;

namespace WpfApp3.Services
{
    class PhotoFeed : IPhotoFeed
    {
        public IFeed Feed { get; set; }

    }
}
