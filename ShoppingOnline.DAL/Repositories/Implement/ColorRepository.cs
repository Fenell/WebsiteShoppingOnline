using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Implement;
public class ColorRepository : GenericRepository<Color>, IColorRepository
{
	public ColorRepository(ApplicationDbContext context) : base(context)
	{
	}

	public bool GetColor(int id)
	{
		throw new NotImplementedException();
	}
}
