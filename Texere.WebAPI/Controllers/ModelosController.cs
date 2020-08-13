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
        public class ModelosController : ControllerBase
        {
            private readonly IModelosService _modelosService;

            public ModelosController(IModelosService modelosService)
            {
                _modelosService = modelosService;
            }

            // GET api/values
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(
                    _modelosService.GetAll()
                );
            }
        }
    }

