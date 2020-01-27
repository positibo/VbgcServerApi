using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VbgcServerApi.Data.Entities
{
	public class TransactionStatus
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TransactionStatusId { get; set; }
		[Required]
		public string TransactionStatusName { get; set; }
		//public virtual ICollection<Order> Orders { get; set; }
	}
}
