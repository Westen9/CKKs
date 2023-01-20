using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System.Xml.Linq;

namespace CKK.Logic.Models
{
    public class Store : Entity, IStore
    {
        private List<StoreItem> items;

        public Store()
        {
            items = new List<StoreItem>();
        }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (quantity > 0)
            {
                if (prod.Id == 0)
                { prod.Id = 1; }

                var GetStoreItems = items.FirstOrDefault(p => p.Product.Id == prod.Id);

                if (GetStoreItems == null)
                {
                    var x = new StoreItem(prod, quantity);
                    items.Add(x);
                    return x;
                }
                else
                {
                    GetStoreItems.Quantity = GetStoreItems.Quantity + quantity;
                    return GetStoreItems;
                }
            }
            else
            {
                if (quantity <= 0)
                {
                    throw new InventoryItemStockTooLowException();
                }
                return null;
            }
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            var GetStoreItems = items.FirstOrDefault(p => p.Product.Id == id);

            if (GetStoreItems != null)
            {
                if (quantity > 0 && GetStoreItems.Quantity != 0)
                {
                    if (GetStoreItems.Quantity <= quantity)
                    {
                        GetStoreItems.Quantity = 0;
                        return GetStoreItems;
                    }
                    else
                    {
                        GetStoreItems.Quantity = GetStoreItems.Quantity - quantity;
                        return GetStoreItems;
                    }
                }
                else
                {
                    if (quantity < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    return null;
                }
            }
            else
            {
                throw new ProductDoesNotExistException();
            }
        }   
        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }

            var GetStoreItems = items.FirstOrDefault(p => p.Product.Id == id);

            if (GetStoreItems?.Product.Id == id)
            {
                return GetStoreItems;
            }
            else
            {
                return null;
            }
        }
        public List<StoreItem> GetStoreItems()
        {
            return items;
        }

        public StoreItem DeleteStoreItem(int id)
        {
            var GetStoreItems = items.FirstOrDefault(p => p.Product.Id == id);
            items.Remove(GetStoreItems);
            return GetStoreItems;
        }

        public List<StoreItem> GetAllProducsByName(string name)
        {
            return items.Where(p => p.Product.Name.Contains(name)).ToList();
        }

        public List<StoreItem> GetAllProducsByItem(int id)
        {
            return items.Where(p => p.Product.Id == id).ToList();
        }

        public List<StoreItem> GetProductsByQuantity()
        {
            return items.OrderByDescending(p => p.Quantity).ToList();
        }

        public List<StoreItem> GetProductsByPrice()
        {
            return items.OrderByDescending(p => (double)p.Product.Price).ToList();
        }

        public List<StoreItem> GetProductsByid()
        {
            return items.OrderByDescending(p => p.Product.Id).ToList();
        }

        public List<StoreItem> GetProductsByName()
        {
            return items.OrderByDescending(p=>p.Product.Name).ToList();
        }
    }
}