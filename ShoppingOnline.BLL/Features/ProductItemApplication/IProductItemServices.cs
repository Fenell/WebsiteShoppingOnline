using ShoppingOnline.BLL.Dtos.ProductItemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.ProductItemApplication;
public interface IProductItemServices
{
	Task<IEnumerable<GetProductItem>> GetProductItems();
	Task<GetProductItem> GetProductItemById(Guid id);
	Task<bool> UpdateProductItem(UpdateProductItem updateProductItem);
	Task<bool> DeleteProductItem(DeleteProductItem deleteProductItem);
}
