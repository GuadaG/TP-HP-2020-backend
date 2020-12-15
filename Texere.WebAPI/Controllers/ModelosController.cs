using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Texere.Service.Interfaces;
using Texere.WebAPI.DTOs;

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
                var lista = _mapper.Map<IEnumerable<ModelosDTO>>(_modelosService.GetAll());

                if (lista == null)
                {
                    return NotFound();
                }

                return Ok(lista);
            }
        }
    }
