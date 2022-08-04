using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Interfaces;

namespace WpfApp3.Services
{
    class PhotoFeedSelectorFactory : IPhotoFeedSelectorFactory
    {
        private static IPhotoFeedSelector _photoFeedSelector;

        public IPhotoFeedSelector GetPhotoFeedSelectorInstance()
        {
            if (_photoFeedSelector == null)
            {
                _photoFeedSelector = new PhotoFeedSelector();
            }
            return _photoFeedSelector;
        }
    }
}
