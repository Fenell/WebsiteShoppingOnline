using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Enum;
public enum OrderStatus
{
	Success, // Thành công
	Cancel, // Huỷ
	WaitingDelivery, // Chờ giao hàng
	DeliveryFailed, // Giao hàng thất bại
	Returns, // Trả hàng
	SuccessfulDeliveryWithRefund // Giao thành công có hoàn trả
}
