using RSSReader.Common;
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
                Published = i.PublishDate.DateTime
            });
        }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
