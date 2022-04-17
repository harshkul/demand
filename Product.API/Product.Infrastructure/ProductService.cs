using Microsoft.EntityFrameworkCore;
using Product.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public class ProductService : IProductService
    {
        private readonly ProductContext _context;
        public ProductService(ProductContext context)
        {
            this._context = context;
        }

        public async Task<Domain.Product> CreateProduct(Domain.Product product)
        {
            product.CreatedDate = DateTime.Now;
            //product.CreatedBy = "";
            product.LastModifiedDate = DateTime.Now;
            //product.LastModifiedBy = "";
            var result = this._context.Products.Add(product);
            await this._context.SaveChangesAsync();
            return result.Entity;

        }

        public async void DeleteProduct(int id)
        {
            var result = await this._context.Products.
                FirstOrDefaultAsync(e => e.Id == id);

            if (result != null)
            {
                this._context.Products.Remove(result);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Domain.Product>> GetAllProducts()
        {
            return await this._context.Products.ToListAsync();
        }

        public async Task<Domain.Product> GetProductById(int id)
        {
            return await this._context.Products.
                  FirstOrDefaultAsync(e => e.Id == id);

        }

        public async Task<Domain.Product> GetProductByName(string name)
        {
            return await this._context.Products.
                  FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<Domain.Product> UpdateProduct(Domain.Product product)
        {
            var result = await this._context.Products.
                FirstOrDefaultAsync(e => e.Id == product.Id);

            if (result != null)
            {
                this._context.Products.Remove(result);
                await this._context.SaveChangesAsync();
            }

            if (result != null)
            {
                
                result.Name = product.Name;
                result.Code= product.Code;
                result.Category = product.Category;
                //result.LastModifiedBy = "";
                result.LastModifiedDate = DateTime.Now;

                await this._context.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
