
using System;
using Xunit;
using Xunit.Sdk;

namespace CKK.TestsForStudents
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
                store.AddProduct(expected);
                //Act
                var actual = store.AddProduct(expected);
                //Assert
                Assert.Equal(expected.GetId().ToString(), actual.GetProduct().GetId().ToString());
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
                var product2 = new Product();
                var product3 = new Product();
                store.AddProduct(product1, 1);
                store.AddProduct(product2, 20);
                store.AddProduct(product3, 100);
                store.RemoveProduct(product1, 1);
                store.RemoveProduct(product2, 3);
                store.RemoveProduct(product3, 4);

                //Act
                store.RemoveProduct(product1, 1);

                //Assert
                Assert.Null(store.RemoveProduct(product1, 0));
            }
            catch (Exception exe)
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
                testProduct.SetPrice(price);

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
