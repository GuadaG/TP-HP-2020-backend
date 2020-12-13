using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Texere.Model;
using Texere.Service.Interfaces;
using Texere.WebAPI.DTOs;

namespace Texere.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionesController : ControllerBase
    {
        private readonly IInstitucionesService _institucionesService;
        private readonly IMapper _mapper;

        public InstitucionesController(IInstitucionesService institucionesService, IMapper mapper)
        {
            _institucionesService = institucionesService;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = _mapper.Map<IEnumerable<InstitucionesDTO>>(_institucionesService.GetAll());
            if (lista == null)
            {
                return NotFound("Error al intentar recuperar el detalle del Pedido");
            }
            return Ok(lista);
        }
    }
}
