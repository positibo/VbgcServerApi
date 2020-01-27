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
	public class FranchiseController : ControllerBase
	{
		private IFranchiseService franchiseService;

		public FranchiseController(IFranchiseService franchiseService)
		{
			this.franchiseService = franchiseService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<FranchiseDto>> Get()
		{
			var result = franchiseService.GetAll();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public ActionResult<FranchiseDto> Get(int id)
		{
			return Ok(franchiseService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] FranchiseDto dto)
		{
			return Ok(new { id = franchiseService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] FranchiseDto dto)
		{
			franchiseService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			franchiseService.Delete(id);
			return Ok();
		}
	}
}
