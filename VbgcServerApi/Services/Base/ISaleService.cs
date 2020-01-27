using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface ISaleService
    {
        SaleDto GetByFranchiseId(int franchiseId);
        IEnumerable<SaleDto> GetAll();

        List<QuarterlySaleDto> GetQuarterlySales();
        List<MonthlySaleDto> GetMonthlySales();
        List<DailySaleDto> GetDailySales(int franchiseId);
    }
}
