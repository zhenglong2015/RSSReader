// ==========================================
// Author                  :  ZTB 
// Create Time           :    2016/7/26 8:14:18
// ==========================================
using RSSReader.Common;
using RSSReader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.ViewModels
{
    public class ItemViewModel : ModelBase
    {
        private RssItem rItem;

        public RssItem RItem
        {
            get { return rItem; }
            set { SetProperty(ref rItem, value); }
        }
    }
}
