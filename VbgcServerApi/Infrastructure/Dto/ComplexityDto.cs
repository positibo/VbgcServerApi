using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class ComplexityDto
    {
        public int ComplexityId { get; set; }
        [Required]
		public string ComplexityName { get; set; }
		[Required]
		public string Description { get; set; }
    }
}
