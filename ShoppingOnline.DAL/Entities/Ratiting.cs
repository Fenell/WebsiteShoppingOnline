using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities;
[Table("Ratiting")]
public class Ratiting : BaseDomainEntity
{
	public Guid ProductId { get; set; }
	public string? UserId { get; set; }
	public string Content { get; set; }
	public string StartPoint { get; set; }
	public Status Status { get; set; }
	public virtual Product Product { get; set; }
}
