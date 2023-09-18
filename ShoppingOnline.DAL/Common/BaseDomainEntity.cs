using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Common;
public abstract class BaseDomainEntity
{
	public Guid Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime CreatedBy { get; set; }
	public DateTime UpdateAt { get; set; }
	public DateTime UpdateBy { get; set; }
}
