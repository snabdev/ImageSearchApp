using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using FlickrNet;
using Prism.Mvvm;
using WpfApp3.Interfaces;
using WpfApp3.Services;

namespace WpfApp3
{
    class HomePageViewModel : BindableBase
    {
        ISearchEngineWrapper _searchEngineWrapper;
        public bool CanShowError
        {
            get => _canShowError;
            set
            {
                _canShowError = value;
                RaisePropertyChanged(nameof(CanShowError));
            }
        }
        private bool _canShowError;
        public HomePageViewModel(ISearchEngine searchEngine)
        {
            searchEngine.SubscribeToStartSearch(StartSearchEventHandler);
            searchEngine.SubscribeToEndSearch(EndSearchResultsHandler);

            IsWaiting = false;
        }

        private void StartSearchEventHandler()
        {
            IsWaiting = true;
            //Thread.Sleep(5000);
        }

        private bool _isWaiting;

        public bool IsWaiting
        {
            get
            {
                return _isWaiting;
            }
            set
            {
                _isWaiting = value;
                RaisePropertyChanged(nameof(IsWaiting));
            }
        }


        private void EndSearchResultsHandler(EndSearchEventArgs eventArgs)
        {
            CanShowError = eventArgs!=null && !eventArgs.SearchResults.Any() && !string.IsNullOrEmpty(eventArgs.SearchInput);
            IsWaiting = false;
        }
    }
}
