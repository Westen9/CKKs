using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public interface IStore
    {
        public StoreItem AddStoreItem(Product prod, int quantity);

        public StoreItem RemoveStoreItem(int id, int quantity);

        public StoreItem FindStoreItemById(int id);

        public List<StoreItem> GetStoreItems();

        public StoreItem DeleteStoreItem(int id);

        public List<StoreItem> GetAllProducsByName(string name);

        public List<StoreItem> GetAllProducsByItem(int id);

        public List<StoreItem> GetProductsByQuantity();

        public List<StoreItem> GetProductsByPrice();

        public List<StoreItem> GetProductsByid();

        public List<StoreItem> GetProductsByName();
    }
}
