using RSSReader.Common;
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
        public RssItem()
        {
            ItemClick = new Command(p =>
            {
                //跳转
                //   new ItemWin().ShowDialog();窗体之间

                //NavigationService.GetNavigationService(typeof(MainWin)).Navigate(new Uri("",UriKind.Relative));
                //NavigationService.GetNavigationService(this).GoForward();//向后转
                //NavigationService.GetNavigationService(this).GoBack();　 //向前转

                NavigationWindow window = new NavigationWindow();
                window.Source = new Uri("Views/ItemWin.xaml", UriKind.RelativeOrAbsolute);
                window.ShowsNavigationUI = false;
                window.ShowDialog();
            });
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
        public Author author { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }

        public Command ItemClick { get; set; }
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
                Content = i.Content.ToString() ?? i.Summary.Text
            });
        }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
