using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VbgcServerApi.Data.Entities
{
    public class Franchise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FranchiseId { get; set; }
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
