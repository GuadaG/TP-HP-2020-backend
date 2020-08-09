using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Texere.Service.Interfaces;

namespace Texere.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineaPedidoController : ControllerBase
    {
        private readonly ILineaPedidoService _lineaPedidoService;

        public LineaPedidoController(ILineaPedidoService lineaPedidoService)
        {
            _lineaPedidoService = lineaPedidoService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _lineaPedidoService.GetAll()
            );
        }
    }
}

