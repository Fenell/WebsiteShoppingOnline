using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingOnline.DAL.Entities;
public class Ratiting : BaseEntity
{
	public Guid ProductId { get; set; }
	public string? UserId { get; set; }
	public string? Content { get; set; }
	public int StartPoint { get; set; }
	public string Status { get; set; } = EntityStatus.Active;
	public virtual Product? Product { get; set; }
}
