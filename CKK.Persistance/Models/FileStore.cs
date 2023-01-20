using CKK.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using CKK.Logic.Exceptions;

namespace CKK.Persistance.Models
{
    internal class FileStore : IStore, ISavable, ILoadable
    {
        private List<StoreItem> items;
        public readonly String FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            + Path.DirectorySeparatorChar + "Persistance"
            + Path.DirectorySeparatorChar + "StoreItems.dat";
        private int IdCounter;

        public FileStore()
        {
            items = new List<StoreItem>();
            IdCounter = 0;
        }

        public StoreItem AddStoreItem(Product prod, int quantity) 
        {
            var GetProduct = items.FirstOrDefault(p => p.Product.Id == prod.Id);
            if (quantity > 0 && prod != null)
            {
                if (GetProduct == null)
                {
                    var x = new StoreItem(prod, quantity);
                    items.Add(x);
                    return x;
                }
                else
                {
                    GetProduct.Quantity = GetProduct.Quantity + quantity;
                    return GetProduct;
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
            var GetProduct = items.FirstOrDefault(p => p.Product.Id == id);

            if (quantity > 0 && GetProduct != null)
            {
                if (GetProduct.Quantity > quantity)
                {
                    GetProduct.Quantity = GetProduct.Quantity - quantity;
                    return GetProduct;
                }
                else if (GetProduct.Quantity <= quantity)
                {
                    GetProduct.Quantity = 0;
                    items.Remove(GetProduct);
                    return GetProduct;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (quantity <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (GetProduct == null)
                {
                    throw new ProductDoesNotExistException();
                }
                return null;
            }
        }
        
        public StoreItem FindStoreItemById(int id) 
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }

            var GetProduct = items.FirstOrDefault(p => p.Product.Id == id);

            if (GetProduct?.Product.Id == id)
            {
                return GetProduct;
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
            var GetProduct = items.FirstOrDefault(p => p.Product.Id == id);

            if (GetProduct != null)
            {
                GetProduct.Quantity = 0;
                items.Remove(GetProduct);
                return GetProduct;
            }
            else
            {
                if (GetProduct == null)
                {
                    throw new ProductDoesNotExistException();
                }
                return null;
            }
        }

        private void CreatePath()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }
        }

        public void Save() 
        {
            FileStream fs = new FileStream(FilePath,FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, items);
        }

        public void Load()
        {
            FileStream fileStream = new FileStream(FilePath,FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            items =(List<StoreItem>)binaryFormatter.Deserialize(fileStream);
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
            return items.OrderByDescending(p => ((double)p.Product.Price)).ToList();
        }

        public List<StoreItem> GetProductsByid()
        {
            return items.OrderByDescending(p => p.Product.Id).ToList();
        }

        public List<StoreItem> GetProductsByName()
        {
            return items.OrderByDescending(p => p.Product.Name).ToList();
        }
    }
}
