using ShoppingOnline.BLL.Dtos.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.ProductApplication;
public interface IProductServices
{
	Task<IEnumerable<GetProducts>> GetAllProducts();
}
