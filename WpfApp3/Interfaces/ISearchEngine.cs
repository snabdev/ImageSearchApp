using FlickrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Interfaces
{
    public interface ISearchEngine
    {
        void SubscribeToEndSearch(Action<EndSearchEventArgs> handler);

        void UnSubscribeFromEndSearch(Action<EndSearchEventArgs> handler);

        void SubscribeToStartSearch(Action handler);

        void UnSubscribeFromSearch(Action handler);

        Task StartSearch(string searchInput);

    }
}
