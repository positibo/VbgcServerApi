using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VbgcServerApi.Data.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public bool? EmailNotificationIsSent { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
