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
	public class GameController : ControllerBase
	{
		private IGameService GameService;

		public GameController(IGameService GameService)
		{
			this.GameService = GameService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<GameDto>> Get()
		{
			return Ok(GameService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<GameDto> Get(int id)
		{
			return Ok(GameService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] GameDto dto)
		{
			return Ok(new { id = GameService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] GameDto dto)
		{
			GameService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			GameService.Delete(id);
			return Ok();
		}
	}
}
