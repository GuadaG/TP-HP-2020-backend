using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Texere.DataAccess;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.Service
{
    public class PedidosService : IPedidosService
    {
        private readonly TexereDbContext _texereDbContext;

        public PedidosService(
            TexereDbContext TexereDbContext
        )
        {
            _texereDbContext = TexereDbContext;
        }

        public IEnumerable<Pedidos> GetAll()
        {
            var result = new List<Pedidos>();

            try
            {
                result = _texereDbContext.Pedidos
                    .Include(p => p.Estado)
                    .Include(p => p.Cliente)
                    .OrderByDescending(p => p.Fecha)
                    .ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public IEnumerable<Pedidos> GetByCliente(int clienteId)
        {
            var result = _texereDbContext.Pedidos.Where(p => p.ClienteId == clienteId)
                .Include(p => p.Estado)
                .ToList();
            return result;
        }

        public Pedidos Get(int id)
        {
            var result = new Pedidos();

            try
            {
                result = _texereDbContext.Pedidos.Single(x => x.PedidoId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Pedidos model)
        {
            try
            {
                model.EstadoId = 1;
                foreach (LineasPedido lp in model.LineasPedido)
                    lp.EstadoId = 1;

                _texereDbContext.Add(model);
                _texereDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(Pedidos model)
        {
            try
            {
                var originalModel = _texereDbContext.Pedidos.Single(x =>
                    x.PedidoId == model.PedidoId
                );

                originalModel.Fecha = model.Fecha;
                originalModel.Estado = model.Estado;
              

                _texereDbContext.Update(originalModel);
                _texereDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _texereDbContext.Entry(new Pedidos { PedidoId = id }).State = EntityState.Deleted; ;
                _texereDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}

