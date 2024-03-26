using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Billing;
using System.IO;
using Billing.Model;
using Billing.Services;
using Billing.Services.Interface;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Billing.Repositories;

namespace Billing.UnitTests
{
    [TestClass]
    public class CalculationTest
    {
        [TestMethod]
        public void CalculateTotalPrice_Returns_Correct_TotalPrice()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(repo => repo.GetAllDiscounts())
                .Returns(new List<Discount>
                {
                    new Discount { NumberOfBooks = 2, Percentage = 0.05m },
                    new Discount { NumberOfBooks = 3, Percentage = 0.10m },
                    new Discount { NumberOfBooks = 4, Percentage = 0.20m },
                    new Discount { NumberOfBooks = 5, Percentage = 0.25m }
                });

            var shoppingCartService = new ShoppingCartService(mockBookRepository.Object);

            var cart = new ShoppingCart
            {
                Items = new List<ShoppingCartItem>
                {
                    new ShoppingCartItem { BookId = 1, Quantity = 2 },
                    new ShoppingCartItem { BookId = 2, Quantity = 2 },
                    new ShoppingCartItem { BookId = 3, Quantity = 2 },
                    new ShoppingCartItem { BookId = 4, Quantity = 1 },
                    new ShoppingCartItem { BookId = 5, Quantity = 1 }
                }
            };

            // Act
            var totalPrice = shoppingCartService.CalculateTotalPrice(cart);

            // Assert            
            Assert.AreEqual(51.6m, totalPrice);
        }

        [TestMethod]
        public void CalculateTotalPrice_By5Book()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(repo => repo.GetAllDiscounts())
                .Returns(new List<Discount>
                {
                    new Discount { NumberOfBooks = 2, Percentage = 0.05m },
                    new Discount { NumberOfBooks = 3, Percentage = 0.10m },
                    new Discount { NumberOfBooks = 4, Percentage = 0.20m },
                    new Discount { NumberOfBooks = 5, Percentage = 0.25m }
                });

            var shoppingCartService = new ShoppingCartService(mockBookRepository.Object);

            var cart = new ShoppingCart
            {
                Items = new List<ShoppingCartItem>
                {
                    new ShoppingCartItem { BookId = 1, Quantity = 1 },
                    new ShoppingCartItem { BookId = 2, Quantity = 1 },
                    new ShoppingCartItem { BookId = 3, Quantity = 1 },
                    new ShoppingCartItem { BookId = 4, Quantity = 1 },
                    new ShoppingCartItem { BookId = 5, Quantity = 1 }
                }
            };

            // Act
            var totalPrice = shoppingCartService.CalculateTotalPrice(cart);

            // Assert            
            Assert.AreEqual(30m, totalPrice);
        }

        [TestMethod]
        public void CalculateTotalPrice_By7Book()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(repo => repo.GetAllDiscounts())
                .Returns(new List<Discount>
                {
                    new Discount { NumberOfBooks = 2, Percentage = 0.05m },
                    new Discount { NumberOfBooks = 3, Percentage = 0.10m },
                    new Discount { NumberOfBooks = 4, Percentage = 0.20m },
                    new Discount { NumberOfBooks = 5, Percentage = 0.25m }
                });

            var shoppingCartService = new ShoppingCartService(mockBookRepository.Object);

            var cart = new ShoppingCart
            {

                Items = new List<ShoppingCartItem>
                {
                    new ShoppingCartItem { BookId = 1, Quantity = 2 },
                    new ShoppingCartItem { BookId = 2, Quantity = 3 },
                    new ShoppingCartItem { BookId = 3, Quantity = 2 },
                    new ShoppingCartItem { BookId = 4, Quantity = 1 },
                    new ShoppingCartItem { BookId = 5, Quantity = 2 }
                }
            };

            // Act
            var totalPrice = shoppingCartService.CalculateTotalPrice(cart);

            // Assert            
            Assert.AreEqual(63.6m, totalPrice);
        }

        [TestMethod]
        public void CalculateTotalPrice_By8Book()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(repo => repo.GetAllDiscounts())
                .Returns(new List<Discount>
                {
                    new Discount { NumberOfBooks = 2, Percentage = 0.05m },
                    new Discount { NumberOfBooks = 3, Percentage = 0.10m },
                    new Discount { NumberOfBooks = 4, Percentage = 0.20m },
                    new Discount { NumberOfBooks = 5, Percentage = 0.25m }
                });

            var shoppingCartService = new ShoppingCartService(mockBookRepository.Object);

            var cart = new ShoppingCart
            {

                Items = new List<ShoppingCartItem>
                {

            new ShoppingCartItem { BookId = 1, Quantity = 2 },
                    new ShoppingCartItem { BookId = 2, Quantity = 2 },
                    new ShoppingCartItem { BookId = 3, Quantity = 2 },
                    new ShoppingCartItem { BookId = 4, Quantity = 1 },
                    new ShoppingCartItem { BookId = 5, Quantity = 1 }
                }
            };

            // Act
            var totalPrice = shoppingCartService.CalculateTotalPrice(cart);

            // Assert            
            Assert.AreEqual(51.6m, totalPrice);
        }
    }
}

