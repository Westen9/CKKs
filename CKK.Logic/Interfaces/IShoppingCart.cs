using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Interfaces
{
    public interface IShoppingCart
    {
        public int GetCustomerid();

        public ShoppingCartItem AddProduct(Product prod, int quantity);

        public ShoppingCartItem RemoveProduct(int id, int quantity);

        public ShoppingCartItem GetProductById(int id);

        public decimal GetTotal();

        public List<ShoppingCartItem> GetProducts();
    }
}
