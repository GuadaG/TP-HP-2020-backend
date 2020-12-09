using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texere.Service.Interfaces;
using Texere.Model;

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
        [HttpGet("{modeloId}")]
        public IActionResult Get(int modeloId)
        {
            return Ok(
                _coloresModelosService.GetAll(modeloId)
            );
        }

        [HttpPost]
        public IActionResult Add([FromBody] Model.ColoresModelos model)
        {
            return Ok(
                _coloresModelosService.Add(model)
            );
        }

        [HttpDelete("modelo/{modeloId}/color/{colorId}")]
        public IActionResult Delete(int modeloId, int colorId)
        {
            return Ok(
                _coloresModelosService.Delete(modeloId, colorId)
            );
        }
    }
}
