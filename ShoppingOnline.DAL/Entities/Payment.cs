using ShoppingOnline.DAL.Common;
using ShoppingOnline.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Entities;
public class Payment : BaseDomainEntity
{
	public Guid OrderId { get; set; }
	public string PaymentMethod { get; set; }
	public string TransactionId { get; set; }
	public DateTime TransactionDate { get; set; }
	public decimal Amount { get; set; }
	public PaymentStatus PaymentStatus { get; set; }
	public virtual Order Order { get; set; }
}
