using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;

namespace CKK.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStore _Store;
        public ObservableCollection<StoreItem> _Item { get; private set; }

        public MainWindow(Store store)
        {
            _Store = store;
            InitializeComponent();
            _Item = new ObservableCollection<StoreItem>();
            lbInventoryList.ItemsSource = _Item;
            ReFreshList();
        }

        private void ReFreshList()
        {
            _Item.Clear();
            foreach (StoreItem si in new ObservableCollection<StoreItem>(_Store.GetStoreItems())) _Item.Add(si);
        }

        private void sName_Click(object sender, RoutedEventArgs e)
        {
            _Item = new ObservableCollection<StoreItem>(_Store.GetAllProducsByName(TBName.Text));
        }

        private void sItem_Click(object sender, RoutedEventArgs e)
        {
            _Item = new ObservableCollection<StoreItem>(_Store.GetAllProducsByItem(Convert.ToInt32(TBItem.Text)));
        }

        private void Quantity_Click(object sender, RoutedEventArgs e)
        {
            _Item = new ObservableCollection<StoreItem>(_Store.GetProductsByQuantity());
        }

        private void Price_Click(object sender, RoutedEventArgs e)
        {
            _Item = new ObservableCollection<StoreItem>(_Store.GetProductsByPrice());
        }

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            _Item = new ObservableCollection<StoreItem>(_Store.GetProductsByid());
        }

        private void Name_Click(object sender, RoutedEventArgs e)
        {
            _Item = new ObservableCollection<StoreItem>(_Store.GetProductsByName());
        }
    }
}
