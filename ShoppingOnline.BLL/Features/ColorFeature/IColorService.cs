using ShoppingOnline.BLL.DataTransferObjects.Color.Requests;
using ShoppingOnline.BLL.DataTransferObjects.ColorDTO;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.ColorFeature;
public interface IColorService
{
	Task<List<ColorViewModel>> GetAll();
	Task<ColorViewModel> GetById(Guid id);
	Task<Guid> CreateColor(ColorCreateRequest request);
	Task UpdateColor(Guid id, ColorUpdateRequest request);
	Task DeleteColor(Guid id);
}
