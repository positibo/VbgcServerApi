using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
