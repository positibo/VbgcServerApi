using System;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class DailySaleDto
    {
        public decimal TotalSale { get; set; }
        public DateTime IssueDate { get; set; }
        public string DaySale { get; set; }
    }
}
