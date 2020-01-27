using System;
using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class FranchiseDto
    {
        public int Id { get; set; }
        [Required]
        public string FranchiseName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
