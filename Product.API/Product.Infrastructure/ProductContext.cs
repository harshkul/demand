using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Product.Domain;

namespace Product.Infrastructure
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {

        }
        
        public DbSet<Product.Domain.Product> Products { get; set; }
        public DbSet<ProductMetadata> productMetadatas { get; set; }


    }
}
