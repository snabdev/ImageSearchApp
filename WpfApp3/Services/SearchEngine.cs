using System;
using FlickrNet;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WpfApp3.Interfaces;
using System.IO;

namespace WpfApp3
{
    public class EndSearchEventArgs
    {
        public string SearchInput { get; set; }
        public PhotoCollection SearchResults { get; set; }
    }
    public class SearchEngine : ISearchEngine
    {


        public IPhotoFeed _photoFeed;

        //private static SearchEngine _instance = null;

        private delegate void EndSearchResults(EndSearchEventArgs eventArgs);
        private event EndSearchResults EndSearchEvent;

        private delegate void StartSearchResults();
        private event StartSearchResults StartSearchEvent;

        public SearchEngine(IPhotoFeed photoFeed)
        {
            _photoFeed = photoFeed;
        }

        //public static SearchEngine Instance
        //{
        //    get
        //    {

        //        //_instance = _instance ?? new SearchEngine();
        //        if (_instance == null)
        //        {
        //            _instance = new SearchEngine();
        //        }
        //        return _instance;
        //    }
        //}


        public void SubscribeToEndSearch(Action<EndSearchEventArgs> handler)
        {
            this.EndSearchEvent += new EndSearchResults(handler);
        }

        public void UnSubscribeFromEndSearch(Action<EndSearchEventArgs> handler)
        {
            this.EndSearchEvent -= new EndSearchResults(handler);
        }
        public void SubscribeToStartSearch(Action handler)
        {
            this.StartSearchEvent += new StartSearchResults(handler);
        }

        public void UnSubscribeFromSearch(Action handler)
        {
            this.StartSearchEvent -= new StartSearchResults(handler);
        }

        public async Task StartSearch(string searchInput)
        {
            try
            {

                PhotoCollection photos = new PhotoCollection();
                this.StartSearchEvent(); // IsLoading = True

                if (!string.IsNullOrEmpty(searchInput))
                {
                    photos = await Task.Run(() =>
                    {
                    //  Flickr flickr = new Flickr(FLICKR_API_KEY);
                    var options = new PhotoSearchOptions
                        { Tags = searchInput, SafeSearch = SafetyLevel.Restricted, Page = 1 };
                        options.SortOrder = PhotoSearchSortOrder.Relevance;
                        PhotoCollection returnValue = _photoFeed.Feed.PhotosSearch(options);
                        return returnValue;

                    });
                }

                this.EndSearchEvent(new EndSearchEventArgs() { SearchInput = searchInput, SearchResults = photos }); // IsLoading = False
            }
            catch(Exception ex)
            {
                string sDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyApplicationDir");

                if (!Directory.Exists(sDirectory))
                {
                    Directory.CreateDirectory(sDirectory);
                }

                using (FileStream stream = File.Create(Path.Combine(sDirectory, "Log.txt")))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(ex.Message);
                    }
                }

                this.EndSearchEvent(new EndSearchEventArgs() { SearchInput = searchInput, SearchResults = new PhotoCollection()}); // IsLoading = False

            }
        }
    }

}
