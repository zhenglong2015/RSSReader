﻿using RSSReader.Common;
using RSSReader.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml;

namespace RSSReader.Models
{
    public class RssItem
    {
        /// <summary>
        /// 将参数加入到App中，在目标页面的load中获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            App.Current.Properties["frame"] = e.ExtraData;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
        public Author author { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// 按钮抽象的单机命令
        /// </summary>
        public DelegateCommand ItemClick
        {
            get
            {
                return itemClick ?? (itemClick = new DelegateCommand(p=> {
                    NavigationWindow window = new NavigationWindow();
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.ShowsNavigationUI = false;
                    window.NavigationService.Navigate(new Uri("Views/ItemWin.xaml", UriKind.RelativeOrAbsolute), p);
                    window.NavigationService.Navigated += NavigationService_Navigated;
                    window.ShowDialog();
                    window.Close();
                }));
            }
        }

        private DelegateCommand itemClick;

        /// <summary>
        /// 获取内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<RssItem>> RssGetItems(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("aa");
            var rssXml = await client.GetStringAsync(url);
            XmlReader reader = XmlReader.Create(new StringReader(rssXml));
            SyndicationFeed downloadFeed = SyndicationFeed.Load(reader);

            return downloadFeed.Items.Select(i => new RssItem
            {
                Id = i.Id,
                Title = i.Title.Text,
                Summary = i.Summary.Text,
                Published = i.PublishDate.DateTime,
                Content = i.Content == null ? i.Summary.Text : i.Content.ToString()
            });
        }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
