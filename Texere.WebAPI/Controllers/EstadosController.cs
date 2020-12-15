using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texere.Service.Interfaces;

namespace Texere.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosService _estadosService;

        public EstadosController(IEstadosService estadosService)
        {
            _estadosService = estadosService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var lista = _estadosService.GetAll();
            if (lista == null)
            {
                return NotFound("Error al intentar recuperar la lista de Estados");
            }
            return Ok(lista);
        }
    }
}
