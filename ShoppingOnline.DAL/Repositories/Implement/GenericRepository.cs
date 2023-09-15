using ShoppingOnline.DAL.Entities.Common;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.DAL.Repositories.Implement;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
}