using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class TransactionStatusDto
    {
        public int TransactionStatusId { get; set; }
        [Required]
        public string TransactionStatusName { get; set; }
    }
}
