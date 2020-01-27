using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VbgcServerApi.Data.Entities
{
	public class Game
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GameId { get; set; }
		[Required]
		public string GameName { get; set; }
		[Required]
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public int ComplexityId { get; set; }
		public virtual Complexity Complexity { get; set; }
		[Required]
		public int PlayerSizeId { get; set; }
		public virtual PlayerSize PlayerSize { get; set; }
		public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	}
}
