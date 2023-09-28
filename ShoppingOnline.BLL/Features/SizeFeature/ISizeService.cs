using ShoppingOnline.BLL.DataTransferObjects.SizeDTO.Models;
using ShoppingOnline.BLL.DataTransferObjects.SizeDTO.Requests;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.BLL.Features.SizeFeature;
public interface ISizeService
{
	Task<List<SizeViewModel>> GetAllSize();
	Task<Size> GetByIdSize(Guid id);
	Task<Guid> CreateSize(SizeCreateRequest request);
	Task UpdateSize(Guid id,SizeUpdateRequest request);
	Task DeleteSize(Guid id);
}
