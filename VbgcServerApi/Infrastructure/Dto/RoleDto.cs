using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
