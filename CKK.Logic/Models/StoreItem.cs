using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System;

namespace CKK.Logic.Models
{
    [Serializable]
    public class StoreItem : InventoryItem
    {

        public StoreItem(Product product, int quantity)
        {
            Product= product;
            Quantity = quantity;
        }
        public Product GetProduct()
        {
            return Product;
        }
    }
}
