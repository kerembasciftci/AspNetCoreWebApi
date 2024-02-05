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
    internal class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasData(
                new ProductFeature { Id = 1, ProductId = 1, Color = "Black" },
                new ProductFeature { Id = 2, ProductId = 2, Color = "Blue" },
                new ProductFeature { Id = 3, ProductId = 3, Color = "Green" },
                new ProductFeature { Id = 4, ProductId = 4, Color = "Yellow" }
                );
        }
    }
}
