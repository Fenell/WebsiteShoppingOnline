using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Repositories.Interface;
public interface IColorRepository : IGenericRepository<Entities.Color>
{
	bool GetColor(int id);
}
