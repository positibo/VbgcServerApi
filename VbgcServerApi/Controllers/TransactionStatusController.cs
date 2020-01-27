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
	public class TransactionStatusController : ControllerBase
	{
		private ITransactionStatusService TransactionStatusService;

		public TransactionStatusController(ITransactionStatusService TransactionStatusService)
		{
			this.TransactionStatusService = TransactionStatusService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<TransactionStatusDto>> Get()
		{
			return Ok(TransactionStatusService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<TransactionStatusDto> Get(int id)
		{
			return Ok(TransactionStatusService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] TransactionStatusDto dto)
		{
			return Ok(new { id = TransactionStatusService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] TransactionStatusDto dto)
		{
			TransactionStatusService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			TransactionStatusService.Delete(id);
			return Ok();
		}
	}
}
