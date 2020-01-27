using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;
using VbgcServerApi.Services;

namespace VbgcServerApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SaleDto>> Get()
        {
            var result = saleService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<SaleDto> Get(int id)
        {
            return Ok(saleService.GetByFranchiseId(id));
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<QuarterlySaleDto> GetQuarterlySaleByFranchiseId(int id)
        {
            return Ok(saleService.GetQuarterlySales());
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<MonthlySaleDto> GetMonthlySaleByFranchiseId(int id)
        {
            return Ok(saleService.GetMonthlySales());
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<DailySaleDto> GetDailySaleByFranchiseId(int id)
        {
            return Ok(saleService.GetDailySales(id));
        }
    }
}
