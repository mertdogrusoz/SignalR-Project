﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);

        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {

            _contactService.TAdd(new Contact()
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                PhoneNumber = createContactDto.PhoneNumber,

            });
            return Ok("Contact başarıyla oluşturuldu");

        }
		[HttpDelete("{id}")]
		public IActionResult DeleteContact(int id)
        {
			var value = _contactService.TGetById(id);
			_contactService.TDelete(value);
			return Ok("İletişim Bilgisi Silindi");


		}
		[HttpGet("{id}")]
		public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);

        }

		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			var value = _mapper.Map<Contact>(updateContactDto);
			_contactService.TUpdate(value);
			return Ok("İletişim Bilgisi Güncellendi");
		}

	}
}
