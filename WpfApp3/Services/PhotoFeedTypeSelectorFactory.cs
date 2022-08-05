using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Interfaces;

namespace WpfApp3.Services
{
    class PhotoFeedTypeSelectorFactory : IPhotoFeedTypeSelectorFactory
    {
        private static IPhotoFeedTypeSelector _photoFeedSelector;

        public IPhotoFeedTypeSelector GetPhotoFeedTypeSelectorInstance()
        {
            if (_photoFeedSelector == null)
            {
                _photoFeedSelector = new PhotoFeedTypeSelector();
            }
            return _photoFeedSelector;
        }
    }
}
