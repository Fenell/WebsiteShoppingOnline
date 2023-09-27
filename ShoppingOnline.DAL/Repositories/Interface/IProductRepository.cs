using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Interface;
public interface IProductRepository : IGenericRepository<Product>
{
	Task<Guid> CreateProduct(Product product);
	Task<bool> UpdateProduct(Product product);
	Task<bool> DeleteProduct(Product product);
	Task<IEnumerable<Product>> GetAllProducts();
	Task<Product> GetProductById(Guid productId);
}
