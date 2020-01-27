using System;
using System.ComponentModel.DataAnnotations;

namespace VbgcServerApi.Infrastructure.Dto
{
	public class GameDto
    {
		public int GameId { get; set; }
		[Required]
		public string GameName { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		[Range(1, int.MaxValue)]
		public int CategoryId { get; set; }
		[Required]
		[Range(1, int.MaxValue)]
		public int ComplexityId { get; set; }
		[Required]
		[Range(1, int.MaxValue)]
		public int PlayerSizeId { get; set; }
	}
}
