using ShoppingOnline.BLL.Dtos.BrandItemViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.BrandFeature;
public interface IBrandServices
{
	Task<IEnumerable<GetBrand>> GetAllBrands();
	Task<GetBrand> GetBrandById(Guid id);
	Task<Guid> CreatedBrand(CreatedBrand brand);
	Task<bool> UpdateBrand(UpdateBrand brand);
	Task<bool> DeleteBrand(GetBrand brand);
}
