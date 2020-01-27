using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public int GameId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string GameName { get; set; }
    }
}
