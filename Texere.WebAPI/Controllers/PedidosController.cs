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
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _pedidosService.GetAll()
            );
        }

        [HttpGet("GetByCliente/{clienteId}")]
        public IActionResult Get(int clienteId)
        {
            var item = _pedidosService.GetByCliente(clienteId);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}

