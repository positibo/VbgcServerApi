using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VbgcServerApi.Data.Entities
{
	public class Category
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; }
		[Required]
		public string CategoryName { get; set; }
		public virtual ICollection<Game> Games { get; set; }
	}
}
