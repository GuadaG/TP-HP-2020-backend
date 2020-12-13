using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texere.Service.Interfaces;
using Texere.Model;
using Texere.WebAPI.DTOs;
using AutoMapper;

namespace Texere.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly IModelosService _modelosService;
        private readonly IMapper _mapper;

        public ModelosController(IModelosService modelosService, IMapper mapper)
        {
            _modelosService = modelosService;
            _mapper = mapper;
        }

            // GET api/values
            [HttpGet]
            public IActionResult Get()
            {
            IEnumerable<Modelos> lista = _modelosService.GetAll();
                if (lista == null)
                {
                    return NotFound();
                }

                return Ok(lista);
            }

        [HttpGet("GetWithDetails")]
        public IActionResult GetWithDetails()
        {
            IEnumerable<ModelosDTO> lista = _mapper.Map<IEnumerable<ModelosDTO>>(_modelosService.GetAll());
            if (lista == null)
            {
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Modelos item;
            try
            {
                item = _modelosService.Get(id);
            }
            catch (Exception ex)
            {
                return NotFound(String.Format("Ha ocurrido la siguiente excepción: {0}", ex.Message));
            }

            return Ok(item);
        }
        
        [HttpPost]
        public IActionResult Add([FromBody] ModelosDTO datos)
        {
            Modelos model = new Modelos
            {
                DescModelo = datos.DescModelo,
                Imagen = Convert.FromBase64String(datos.Imagen)
            };
            return Ok(
                _modelosService.Add(model)
            );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _modelosService.Delete(id)
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Modelos model)
        {
            if (id != model.ModeloId)
            {
                return BadRequest();
            }

            try
            {
                _modelosService.Update(model);
            }
            catch (Exception ex)
            {
                return NotFound(String.Format("Ha ocurrido la siguiente excepción: {0}", ex.Message));
            }

            return NoContent();
        }

    }
}
 
