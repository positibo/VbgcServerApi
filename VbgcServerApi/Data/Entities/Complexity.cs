using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VbgcServerApi.Data.Entities
{
	public class Complexity
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ComplexityId { get; set; }
		[Required]
		public string ComplexityName { get; set; }
		[Required]
		public string Description { get; set; }
		public virtual ICollection<Game> Games { get; set; }
	}
}
