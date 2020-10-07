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
    public class LineasPedidoController : ControllerBase
    {
        private readonly ILineasPedidoService _lineaPedidoService;

        public LineasPedidoController(ILineasPedidoService lineaPedidoService)
        {
            _lineaPedidoService = lineaPedidoService;
        }

        // GET api/values
        [HttpGet("{pedidoId}")]
        public IActionResult Get(int pedidoId)
        {
            var list = _lineaPedidoService.GetAll(pedidoId);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
    }
}

