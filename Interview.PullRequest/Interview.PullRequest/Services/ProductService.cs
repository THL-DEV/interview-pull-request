using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Interview.PullRequest.Entities;

namespace Interview.PullRequest.Services
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Builds a set of products:
        /// 1 Van, 1 table, 2 chairs, one of them is free.
        /// </summary>
        public Product BuildProduct()
        {
            return new Product()
            {
                Code = "Van",
                Category = "Rental Products",
                Id = Guid.NewGuid(),
                price = 100,
                ProductPack = new List<Product>()
                {
                    new Product()
                    {
                        Code = "Table",
                        Category = "Rental Products",
                        Id = Guid.NewGuid(),
                        price = 20
                    },
                    new Product()
                    {
                         Code = "Chair",
                         Category = "Rental Products",
                         Id = Guid.NewGuid(),
                         price = 5
                    },
                    new Product()
                    {
                        Code = "Free Chair",
                        Category = "Rental Products",
                        Id = Guid.NewGuid()
                    },
                }
            };
        }

        // Recursively calculates the price of a product
        public decimal CalculatePrice(Product product)
        {
            decimal? price = product.price;

            if (product.ProductPack != null)
            {
                price = price + product.ProductPack.Select(CalculatePrice).Sum();
            }

            return (decimal)price;
        }
    }
}
