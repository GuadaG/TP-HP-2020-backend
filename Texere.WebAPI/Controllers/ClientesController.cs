using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _clientesService.GetAll()
            );
        }

        // GET api/values
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _clientesService.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Clientes model)
        {
            return Ok(
                _clientesService.Add(model)
            );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _clientesService.Delete(id)
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Clientes model)
        {
            if (id != model.ClienteId)
            {
                return BadRequest();
            }

            try
            {
                _clientesService.Update(model);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
           
            return NoContent();
        }
    }
}
