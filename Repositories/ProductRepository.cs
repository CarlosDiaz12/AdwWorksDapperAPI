using AdwWorksDapperAPI.Infrastructure;
using AdwWorksDapperAPI.Interfaces;
using AdwWorksDapperAPI.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace AdwWorksDapperAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdwWorksConfig _adwWorksConfig;
        public ProductRepository(IOptions<AdwWorksConfig> adwWorksConfig)
        {
            _adwWorksConfig = adwWorksConfig.Value;
        }
        public void AddProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Product GetProduct(int productId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public bool ProductExists(int productId)
        {
            throw new System.NotImplementedException();
        }

        public bool Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
