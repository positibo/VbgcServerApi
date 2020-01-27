using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
	public class OrderDto
    {
        public int OrderId { get; set; }
		[Required]
		public bool IsDeliver { get; set; }
		[Required]
		[Range(1, int.MaxValue)]
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public int Quantity { get; set; }
		public string GameName { get; set; }
		[Required]
		[Range(1, int.MaxValue)]
		public int FranchiseId { get; set; }
		public string ReferenceNumber { get; set; }
		public DateTime TransactionDate { get; set; }
		public bool EmailNotificationIsSent { get; set; }
		public int TransactionStatusId { get; set; }
		public string TransactionStatusName { get; set; }
		//public TransactionStatusDto TransactionStatus { get; set; }
		[Required]
		public IEnumerable<OrderDetailDto> OrderDetails { get; set; }
	}
}
