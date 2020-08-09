using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texere.Service.Interfaces;

namespace Texere.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PrecioAccesorio : ControllerBase
    {
        private readonly IPrecioAccesorioService _precioAccesorioService;

        public PrecioAccesorio(IPrecioAccesorioService precioAccesorioService)
        {
            _precioAccesorioService = precioAccesorioService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _precioAccesorioService.GetAll()
            );
        }
    }
}
