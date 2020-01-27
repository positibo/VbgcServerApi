using System.Collections.Generic;

namespace VbgcServerApi.Infrastructure.Dto
{
    public class SaleDto
    {
        public string FranchiseName { get; set; }
        public List<DailySaleDto> DailySales { get; set; }
        public List<MonthlySaleDto> MonthlySales { get; set; }
        public List<QuarterlySaleDto> QuarterlySales { get; set; }
    }
}
