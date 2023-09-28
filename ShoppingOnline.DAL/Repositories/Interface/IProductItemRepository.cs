using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Interface;
public interface IProductItemRepository : IGenericRepository<ProductItem>
{
	Task<IEnumerable<ProductItem>> GetProductItem();
	Task<ProductItem> GetProductItemById(Guid id);
	Task<bool> UpdateProductItem(ProductItem productItem);
	Task<bool> DeleteProductItem(ProductItem productItem);
}
