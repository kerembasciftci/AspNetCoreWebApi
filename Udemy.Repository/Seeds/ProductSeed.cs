using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Models;

namespace Udemy.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            new Product { Id = 1, CategoryId = 1, Name = "Faber-Castell", Price = 10, Stock = 50 },
            new Product { Id = 2, CategoryId = 1, Name = "Rotring", Price = 7, Stock = 90 },
            new Product { Id = 3, CategoryId = 2, Name = "Hayatın Kaynagi", Price = 30, Stock = 67 },
            new Product { Id = 4, CategoryId = 2, Name = "Ozgurlukten Kacis", Price = 20, Stock = 50 },
            new Product { Id = 5, CategoryId = 3, Name = "Faber-Castell", Price = 15, Stock = 220 });
        }
    }
}
