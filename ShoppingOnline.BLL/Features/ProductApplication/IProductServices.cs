using ShoppingOnline.BLL.Dtos.ProductViewModel;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.ProductApplication;
public interface IProductServices
{
	Task<IEnumerable<GetProducts>> GetAllProducts();
	Task<Guid> CreateProduct(CreateProduct create);
	Task<bool> UpdateProduct(UpdateProduct update);
	Task<bool> DeleteProduct(Product delete);
	Task<GetProducts> GetProductById(Guid productId);
}
