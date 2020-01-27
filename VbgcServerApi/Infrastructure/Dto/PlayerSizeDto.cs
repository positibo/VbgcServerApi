using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class PlayerSizeDto
    {
        [Required]
        public string PlayerSizeName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
