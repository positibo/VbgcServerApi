﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class CustomerDto
    {
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
        public virtual ICollection<OrderDto> Orders { get; set; }
    }
}
