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
        void SubscribeToEndSearch(Action<PhotoCollection> handler);

        void UnSubscribeFromEndSearch(Action<PhotoCollection> handler);

        void SubscribeToStartSearch(Action handler);

        void UnSubscribeFromSearch(Action handler);

        Task StartSearch(string searchInput);

    }
}
