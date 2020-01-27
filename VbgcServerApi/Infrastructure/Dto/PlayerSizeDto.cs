using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class PlayerSizeDto
    {
        public int PlayerSizeId { get; set; }
        [Required]
        public string PlayerSizeName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
