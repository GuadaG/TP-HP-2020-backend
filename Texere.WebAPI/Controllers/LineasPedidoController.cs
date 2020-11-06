using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Texere.Service.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using Texere.WebAPI.DTOs;

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
                return NotFound();
            }
            foreach (var item in lista)
            {
                item.TotalLinea = GetTotal(pedidoId, item);
                if (item.Talle != null)
                    item.Accesorio = String.Format("{0} - {1}", item.Accesorio, item.Talle);
            }
            return Ok(lista);
        }

        private float GetTotal(int pedidoId, LineasPedidoDTO item)
        {
            var pedido = _pedidosService.Get(pedidoId);
            var precio = _precioAccesorioService.GetByDate(item.AccesorioId, pedido.Fecha);
            return item.Cantidad * precio.Valor;
        }
    }
}

