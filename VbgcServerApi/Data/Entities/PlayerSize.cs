using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VbgcServerApi.Data.Entities
{
	public class PlayerSize
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PlayerSizeId { get; set; }
		[Required]
		public string PlayerSizeName { get; set; }
		[Required]
		public string Description { get; set; }
		public virtual ICollection<Game> Games { get; set; }
	}
}
