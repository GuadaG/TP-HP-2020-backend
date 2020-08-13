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
        public class TallesController : ControllerBase
        {
            private readonly ITallesService _tallesService;

            public TallesController(ITallesService tallesService)
            {
                _tallesService = tallesService;
            }

            // GET api/values
            [HttpGet]
            public IActionResult Get()
            {
                return Ok(
                    _tallesService.GetAll()
                );
            }
        }
    }

