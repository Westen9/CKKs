using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;
using System;

namespace CKK.Logic.Models
{
    [Serializable]
    public class ShoppingCartItem : InventoryItem
    {
        public ShoppingCartItem(Product product, int quantity)
        {
            Product= product;
            Quantity = quantity;

        }

        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }
}
