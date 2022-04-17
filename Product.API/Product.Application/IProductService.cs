using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application
{
    public interface IProductService
    {
        Task<IEnumerable<Product.Domain.Product>> GetAllProducts();

        Task< Product.Domain.Product> GetProductById(int id);

        Task< Product.Domain.Product> GetProductByName(string name);

        Task<Product.Domain.Product> CreateProduct(Product.Domain.Product product);

        Task<Product.Domain.Product> UpdateProduct(Product.Domain.Product product);

        void DeleteProduct(int id);
    }
}
