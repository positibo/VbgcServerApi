using System;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class OrderTransactionHistoryDto
    {
        public int OrderId { get; set; }
        public string ReferenceNumber { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
