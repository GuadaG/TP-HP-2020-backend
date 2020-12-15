using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Texere.Service.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using Texere.WebAPI.DTOs;
using Texere.Model;

namespace Texere.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineasPedidoController : ControllerBase
    {
        private readonly ILineasPedidoService _lineaPedidoService;
        private readonly IMapper _mapper;
        private readonly IPedidosService _pedidosService;
        private readonly IPrecioAccesorioService _precioAccesorioService;

        public LineasPedidoController(ILineasPedidoService lineaPedidoService, 
            IMapper mapper,
            IPedidosService pedidosService,
            IPrecioAccesorioService precioAccesorioService)
        {
            _lineaPedidoService = lineaPedidoService;
            _mapper = mapper;
            _pedidosService = pedidosService;
            _precioAccesorioService = precioAccesorioService;
        }

        // GET api/values
        [HttpGet("{pedidoId}")]
        public IActionResult Get(int pedidoId)
        {
            var lista = _mapper.Map<IEnumerable<LineasPedidoDTO>>(_lineaPedidoService.GetAll(pedidoId));           
            if (lista == null)
            {
                return NotFound("Error al intentar recuperar el detalle del Pedido");
            }
            foreach (var item in lista)
            {
                item.TotalLinea = GetTotal(pedidoId, item);
                if (item.Talle != null)
                    item.Accesorio = String.Format("{0} - {1}", item.Accesorio, item.Talle);
            }
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Add([FromBody] LineasPedido model)
        {
            return Ok(
                _lineaPedidoService.Add(model)
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LineasPedidoDTO model)
        {
            LineasPedido item = _lineaPedidoService.Get(id);
            if (item == null)
            {
                return NotFound(String.Format("Error - No se pudo encontrar el elemento con ID {0}", id));
            }
            item.EstadoId = model.Estado;
            try
            {
                _lineaPedidoService.Update(item);
            }
            catch (Exception ex)
            {
                return BadRequest(String.Format("Error - Ha ocurrido la siguiente excepción: {0}", ex.Message));
            }

            return NoContent();
        }


        private float GetTotal(int pedidoId, LineasPedidoDTO item)
        {
            var pedido = _pedidosService.Get(pedidoId);
            var precio = _precioAccesorioService.GetByDate(item.AccesorioId, pedido.Fecha);
            return item.Cantidad * precio.Valor;
        }
    }
}

