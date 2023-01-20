using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Interfaces;
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private Customer Customer;
        private List<ShoppingCartItem> Products;

        public ShoppingCart(Customer cust)
        {
            Customer = cust;
            Products = new List<ShoppingCartItem>();
        }
        public int GetCustomerid()
        {
            return Customer.Id;
        }        

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            var GetProduct = Products.FirstOrDefault(p => p.Product.Id == prod.Id);
            //seeing if the quantity has a negetive 
            //seeing if product is in the list
            if (quantity > 0 && prod != null)
            {
                //
                if (GetProduct == null)
                {
                    var x = new ShoppingCartItem(prod, quantity);
                    Products.Add(x);
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
                if (quantity<=0)
                {
                    throw new InventoryItemStockTooLowException();
                }
                return null;
            }
        }
        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            var GetProduct = Products.FirstOrDefault(p => p.Product.Id == id);

            if (quantity > 0 && GetProduct != null)
            {
                if (GetProduct.Quantity > quantity)
                {
                    GetProduct.Quantity = GetProduct.Quantity - quantity;
                    return GetProduct;
                }
                else if(GetProduct.Quantity <= quantity)
                {
                    GetProduct.Quantity = 0;
                    Products.Remove(GetProduct);
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
        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }

            var GetProduct = Products.FirstOrDefault(p => p.Product.Id == id);

            if (GetProduct?.Product.Id == id)
            {
                return GetProduct;
            }
            else
            {
                return null;
            }
        }
        public decimal GetTotal()
        {
            decimal Total = 0;

            foreach (var Product in Products)
            {
                Total += (Product.Quantity * Product.Product.Price);
            }

            return Total;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return Products;
        }
    }
}

