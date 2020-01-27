using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Data.Entities
{
	public class OrderDetail
    {
		[Key]
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		[Key]
		public int GameId { get; set; }
		public virtual Game Game { get; set; }
		[Required]
		public int Quantity { get; set; }
	}
}
