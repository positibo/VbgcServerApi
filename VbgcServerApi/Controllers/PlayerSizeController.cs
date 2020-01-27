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
	public class PlayerSizeController : ControllerBase
	{
		private IPlayerSizeService PlayerSizeService;

		public PlayerSizeController(IPlayerSizeService PlayerSizeService)
		{
			this.PlayerSizeService = PlayerSizeService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<PlayerSizeDto>> Get()
		{
			return Ok(PlayerSizeService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<PlayerSizeDto> Get(int id)
		{
			return Ok(PlayerSizeService.GetById(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] PlayerSizeDto dto)
		{
			return Ok(new { id = PlayerSizeService.Create(dto) });
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] PlayerSizeDto dto)
		{
			PlayerSizeService.Update(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			PlayerSizeService.Delete(id);
			return Ok();
		}
	}
}
