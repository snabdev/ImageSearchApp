using FlickrNet;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WpfApp3.Interfaces;
using WpfApp3.Services;

namespace WpfApp3
{
    class ImageSearchViewModel : ObservableObject
    {
        private ISearchEngine _searchEngine;
        private string _inputText;
        public ImageSearchViewModel(ISearchEngine searchEngine)
        {
            _searchEngine = searchEngine;
            SearchCommand = new DelegateCommand(ExecuteSearch, () => !string.IsNullOrEmpty(InputText));
        }
        public void OnClick()
        {
            InputText = string.Empty;
        }
        public void OnKeyDown()
        {
            ExecuteSearch();
        }
        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {
                //IsBtnEnabled = true;
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
                SearchCommand.RaiseCanExecuteChanged();
                if (string.IsNullOrEmpty(_inputText))
                {
                    //IsBtnEnabled = false;
                    ExecuteSearch();
                }
            }
        }
        private bool _isBtnEnabled;

        public bool IsBtnEnabled
        {
            get
            {
                return _isBtnEnabled;
            }
            set
            {
                _isBtnEnabled = value;
                OnPropertyChanged(nameof(IsBtnEnabled));
            }
        }


        private async void ExecuteSearch()
        {
            await _searchEngine.StartSearch(_inputText);
        }

        public DelegateCommand SearchCommand { get; set; }
    }
}
