using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.TGetListAll());

		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetNotificationByFalse")]
		public IActionResult GetNotificationByFalse()
		{

			return Ok(_notificationService.TGetAllNotificationByFalse());

		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			Notification notification = new Notification()
			{
				Description = createNotificationDto.Description,
				Icon = createNotificationDto.Icon,
				Status = false,
				Type = createNotificationDto.Type,
				Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())


			};
			_notificationService.TAdd(notification);
			return Ok("Ekleme işlemi başarıyla yapıldı");

		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationId = updateNotificationDto.NotificationId,
				Description = updateNotificationDto.Description,
				Icon = updateNotificationDto.Icon,
				Status = false,
				Type = updateNotificationDto.Type,
				Date = updateNotificationDto.Date,
			};
			_notificationService.TUpdate(notification);
			return Ok("Güncelleme işlemi başarıyla yapıldı");


		}

		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationChangeToFalse(id);
			return Ok("Güncelleme yapıldı");
		}
		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationChangeToTrue(id);
			return Ok("Güncelleme yapıldı");
		}
	}
}
