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
    public class ColoresModelos : ControllerBase
    {
        private readonly IColoresModelosService _coloresModelosService;

        public ColoresModelos(IColoresModelosService coloresModelosService)
        {
            _coloresModelosService = coloresModelosService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _coloresModelosService.GetAll()
            );
        }
    }
}
