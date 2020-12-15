using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Texere.Service.Interfaces;
using Texere.WebAPI.DTOs;

namespace Texere.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesoriosController : ControllerBase
    {
        private readonly IAccesoriosService _accesoriosService;
        private readonly IMapper _mapper;

        public AccesoriosController(IAccesoriosService accesoriosService, IMapper mapper)
        {
            _accesoriosService = accesoriosService;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var lista = _mapper.Map<IEnumerable<AccesoriosDTO>>(_accesoriosService.GetAll());

            if (lista == null)
            {
                return NotFound();
            }

            return Ok(lista);
        }
    }
}
