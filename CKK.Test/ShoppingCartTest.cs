using System;
using Xunit;
using Xunit.Sdk;
using CKK.Logic.Models;

namespace CKK.Test
{
    public class ShoppingCartTest
    {
        [Fact]
        public void AddProduct_ShouldAddProductCorrectly()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                ShoppingCart store = new ShoppingCart(cust);
                var expected = new Product();
                store.AddProduct(expected,2);
                //Act
                var actual = store.AddProduct(expected,2);
                //Assert
                Assert.Equal(expected.Id, actual.Product.Id);
            }
            catch
            {
                throw new XunitException("The product was not populated correctly.");
            }
        }

        [Fact]
        public void RemovingProduct_ShouldRemoveProductCorrectly()
        {
            try
            {
                //Assemble
                Customer cust = new Customer();
                ShoppingCart store = new ShoppingCart(cust);
                var product1 = new Product();
                product1.Id=1;
                var product2 = new Product();
                product2.Id=2;
                var product3 = new Product();
                product3.Id=3;
                store.AddProduct(product1, 1);
                store.AddProduct(product2, 20);
                store.AddProduct(product3, 100);

                //Act
                store.RemoveProduct(1, 1);
                store.RemoveProduct(2, 3);
                store.RemoveProduct(3, 4);

                //Assert
                var item = store.GetProducts().Find(x => x.Product.Id == 1);
                Assert.Null(item);
            }
            catch
            {
                throw new XunitException("The product was not populated correctly.");
            }
        }

        [Fact]
        public void GetTotal_ShouldReturnTheCorrectTotal()
        {
            try
            {
                //Assemble
                var price = 4.0m;
                var quantity = 2;
                var expected = 8m;
                var testProduct = new Product();
                testProduct.Price=price;

                var cartItem = new ShoppingCartItem(testProduct, quantity);
                //Act
                var actual = cartItem.GetTotal();
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Price that was given was incorrect.");
            }
        }
    }
}
