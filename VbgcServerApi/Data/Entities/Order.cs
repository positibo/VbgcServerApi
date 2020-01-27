using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VbgcServerApi.Data.Entities
{
	public class Order
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }
		[Required]
		public bool IsDeliver { get; set; }
		[Required]
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
		[Required]
		public int TransactionStatusId { get; set; }
		public int FranchiseId { get; set; }
		public string ReferenceNumber { get; set; }
		public DateTime TransactionDate { get; set; }
		public bool EmailNotificationIsSent { get; set; }
		public virtual TransactionStatus TransactionStatus { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
