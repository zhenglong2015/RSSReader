using RSSReader.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.ViewModels
{
    public class MainViewModel
    {

        public MainViewModel()
        {
            HomeList = new ObservableCollection<RssItem>();
            PickedList = new ObservableCollection<RssItem>();
            CandidateList = new ObservableCollection<RssItem>();
            NewsList = new ObservableCollection<RssItem>();
            GetData();
        }

        private async void GetData()
        {
            var a = await RssItem.RssGetItems("http://feed.cnblogs.com/blog/sitehome/rss");
            foreach (var item in a)
            {
                HomeList.Add(item);
            }
            var b = await RssItem.RssGetItems("http://feed.cnblogs.com/blog/picked/rss");
            foreach (var item in b)
            {
                PickedList.Add(item);
            }
            var c = await RssItem.RssGetItems("http://feed.cnblogs.com/blog/candidate/rss");
            foreach (var item in c)
            {
                CandidateList.Add(item);
            }
            var d = await RssItem.RssGetItems("http://feed.cnblogs.com/news/rss");
            foreach (var item in d)
            {
                NewsList.Add(item);
            }
        }

        public ObservableCollection<RssItem> HomeList { get; set; }
        public ObservableCollection<RssItem> PickedList { get; set; }
        public ObservableCollection<RssItem> CandidateList { get; set; }
        public ObservableCollection<RssItem> NewsList { get; set; }
        public bool IsLoading { get; set; }
    }
}
