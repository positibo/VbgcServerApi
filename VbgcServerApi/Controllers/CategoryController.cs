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
	public class CategoryController : ControllerBase
	{
		private ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CategoryDto>> Get()
		{
			var result = categoryService.GetAll();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public ActionResult<CategoryDto> Get(int id)
		{
			return Ok(categoryService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] CategoryDto dto)
		{
			return Ok(new { id = categoryService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] CategoryDto dto)
		{
			categoryService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			categoryService.Delete(id);
			return Ok();
		}
	}
}
