namespace VbgcServerApi.Infrastructure.Dto
{
    public class MonthlySaleDto
    {
        public string Month { get; set; }
        //public List<DailySaleDto> Sales { get; set; }
        public decimal TotalSale { get; set; }
    }
}
