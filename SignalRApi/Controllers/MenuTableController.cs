using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTableController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

		public MenuTableController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}

		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}
		[HttpGet("GetMenuTable")]
		public IActionResult GetMenuTable()
		{
			return Ok(_menuTableService.TGetListAll());
		}
		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{
			MenuTable menutable = new MenuTable()
			{
				Name = createMenuTableDto.Name,
				Status = createMenuTableDto.Status,
				
			};
			_menuTableService.TAdd(menutable);
			return Ok("Masa Başarılı Bir Şekilde Eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			_menuTableService.TDelete(value);
			return Ok("Başarıyla Silindi");
		}

		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			MenuTable menutable = new MenuTable()
			{
				Name = updateMenuTableDto.Name,
				Status = updateMenuTableDto.Status,
				MenuTableId= updateMenuTableDto.MenuTableId,

			};
			_menuTableService.TUpdate(menutable);
			return Ok("Masa Bilgileri Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetMenuTable(int id)
		{
			var value = _menuTableService.TGetById(id);
			return Ok(value);
		}
	}
}
