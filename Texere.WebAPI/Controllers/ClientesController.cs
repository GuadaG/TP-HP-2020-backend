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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Clientes item;
            try
            {
                item = _clientesService.Get(id);
            }
            catch (Exception ex)
            {
                return NotFound(String.Format("Ha ocurrido la siguiente excepción: {0}", ex.Message));
            }

            return Ok(item);
        }

        [HttpGet("GetByDni/{dni}")]
        public IActionResult GetByDni(string dni)
        {
            Clientes item;
            try
            {
                item = _clientesService.GetByDni(dni);
            }
            catch (Exception ex)
            {
                return NotFound(String.Format("Ha ocurrido la siguiente excepción: {0}", ex.Message));
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
            try
            {
                var result = _clientesService.Delete(id);
                if (!result)
                    throw new Exception("No fue posible eliminar el registro");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Clientes model)
        {
            Clientes cliente = _clientesService.Get(id);
            if (cliente == null)
            {
                return NotFound(String.Format("No se encontró al cliente con ID {0}", id));
            }
            model.ClienteId = id;
            try
            {
                _clientesService.Update(model);
            }
            catch (Exception ex)
            {
                return BadRequest(String.Format("Error - Ha ocurrido la siguiente excepción: {0}", ex.Message));
            }
           
            return NoContent();
        }
    }
}
