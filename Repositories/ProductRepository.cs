using AdwWorksDapperAPI.Infrastructure;
using AdwWorksDapperAPI.Interfaces;
using AdwWorksDapperAPI.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdwWorksDapperAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdwWorksConfig _adwWorksConfig;
        private IDbConnection Connection
        {
            get { return new SqlConnection(_adwWorksConfig.ConnectionString); }
        }
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
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return dbConnection.QueryFirstOrDefault<Product>("SELECT * FROM [SalesLT].[Product] WHERE ProductID = @productId", new { productId });
        }

        public IEnumerable<Product> GetProducts()
        {
            using IDbConnection dbConnection = Connection;
            dbConnection.Open();
            return dbConnection.Query<Product>("SELECT top 10 * FROM [SalesLT].[Product]");
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
