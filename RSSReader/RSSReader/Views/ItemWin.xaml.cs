using RSSReader.Models;
using RSSReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSSReader.Views
{
    /// <summary>
    /// ItemWin.xaml 的交互逻辑
    /// </summary>
    public partial class ItemWin : Page
    {
        public ItemViewModel ViewModel { get; set; }
        public ItemWin()
        {
            ViewModel = new ItemViewModel();
            InitializeComponent();
            this.Loaded += ItemWin_Loaded;
        }
        /// <summary>
        /// 获取导航页传递过来的参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemWin_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.RItem = App.Current.Properties["frame"] as RssItem;
        }


    }
}
