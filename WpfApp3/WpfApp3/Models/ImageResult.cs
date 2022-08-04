using Prism.Mvvm;

namespace WpfApp3
{
    class ImageResult : BindableBase
    {
        private string _convertedData;
        public string ConvertedData
        {
            get
            {
                return _convertedData;
            }
            set
            {
                _convertedData = value;
                RaisePropertyChanged(nameof(ConvertedData));
            }
        }
    }
}
