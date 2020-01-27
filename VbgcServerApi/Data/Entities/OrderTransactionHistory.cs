using System;
using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Data.Entities
{
    public class OrderTransactionHistory
    {
        [Key]
        public int OrderId { get; set; }
        public string ReferenceNumber { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
