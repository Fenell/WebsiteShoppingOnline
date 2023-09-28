namespace ShoppingOnline.DAL.Entities.Common;
public abstract class BaseEntity
{
	public Guid Id { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.Now;
	public string? CreatedBy { get; set; }
	public DateTime UpdateAt { get; set; } = DateTime.Now;
	public string? UpdateBy { get; set; }
	public bool IsDeleted { get; set; } = false;
}
