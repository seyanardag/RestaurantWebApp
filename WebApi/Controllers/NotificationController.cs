using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.NotificationDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
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
        public IActionResult NotificationList ()
        {
            var values = _notificationService.TGetAll();
            var result = _mapper.Map<List<ResultNotificationDto>>(values);

            return Ok(values);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetNotificationById (int id)
        {
            var value = _notificationService.TGetById(id);
            var result = _mapper.Map<Notification>(value);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var notification = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(notification);
            return Ok("Notification başarıyla oluşturuldu");
        }

             


        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var notification = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(notification);
            return Ok("Notification güncelleme başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var notificationToDel = _notificationService.TGetById(id);
            _notificationService.TDelete(notificationToDel);
            return Ok("Notification silme başarılı");
        }




    }
}
