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
	public class ComplexityController : ControllerBase
	{
		private IComplexityService ComplexityService;

		public ComplexityController(IComplexityService ComplexityService)
		{
			this.ComplexityService = ComplexityService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<ComplexityDto>> Get()
		{
			return Ok(ComplexityService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<ComplexityDto> Get(int id)
		{
			return Ok(ComplexityService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] ComplexityDto dto)
		{
			return Ok(new { id = ComplexityService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] ComplexityDto dto)
		{
			ComplexityService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			ComplexityService.Delete(id);
			return Ok();
		}
	}
}
