﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Texere.Service.Interfaces;
using Texere.WebAPI.DTOs;
using Texere.Model;

namespace Texere.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;
        private readonly IMapper _mapper;
        private readonly ILineasPedidoService _lineasPedidoService;
        private readonly IPrecioAccesorioService _precioAccesorioService;

        public PedidosController(IPedidosService pedidosService, 
            IMapper mapper, 
            ILineasPedidoService lineasPedidoService,
            IPrecioAccesorioService precioAccesorioService)
        {
            _pedidosService = pedidosService;
            _mapper = mapper;
            _lineasPedidoService = lineasPedidoService;
            _precioAccesorioService = precioAccesorioService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PedidosDTO> lista = _mapper.Map<IEnumerable<PedidosDTO>>(_pedidosService.GetAll());
            if (lista == null)
            {
                return NotFound();
            }

            foreach (var item in lista)
            {
                item.Total = CalcularTotal(item.PedidoId, item.Fecha);
            }
            return Ok(lista);
        }    

        [HttpGet("GetByCliente/{clienteId}")]
        public IActionResult Get(int clienteId)
        {
            var lista = _mapper.Map<IEnumerable<PedidosDTO>>(_pedidosService.GetByCliente(clienteId));
            if (lista == null)
            {
                return NotFound();
            }
            foreach (var item in lista)
            {
                item.Total = CalcularTotal(item.PedidoId, item.Fecha);
            }
            return Ok(lista);
        }

        private float CalcularTotal(int pedidoId, DateTime fecha)
        {
            var lineasPedido = _lineasPedidoService.GetAll(pedidoId);
            float total = 0;
            foreach (var linea in lineasPedido)
            {
                var precio = _precioAccesorioService.GetByDate(linea.AccesorioId, fecha);
                total += linea.Cantidad * precio.Valor;
            }
            return total;
        }


        [HttpPost]
        public IActionResult Add([FromBody] Pedidos model)
        {
            return Ok(
                _pedidosService.Add(model)
            );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
                _pedidosService.Delete(id)
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pedidos model)
        {
            if (id != model.PedidoId)
            {
                return BadRequest();
            }

            try
            {
                _pedidosService.Update(model);
            }
            catch (Exception ex)
            {
                return NotFound(String.Format("Ha ocurrido la siguiente excepción: {0}", ex.Message));
            }

            return NoContent();
        }
    }
}

