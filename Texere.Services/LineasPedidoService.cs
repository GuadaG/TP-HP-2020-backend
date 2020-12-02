using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Texere.DataAccess;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.Service
{
    public class LineasPedidoService : ILineasPedidoService
    {
        private readonly TexereDbContext _texereDbContext;

        public LineasPedidoService(
            TexereDbContext texereDbContext
        )
        {
            _texereDbContext = texereDbContext;
        }

        public IEnumerable<LineasPedido> GetAll(int pedidoId)
        {
            var result = new List<LineasPedido>();

            try
            {
                result = _texereDbContext.LineasPedido
                    .Include(lp => lp.Talle)
                    .Include(lp => lp.Accesorio)
                    .Include(lp => lp.Material)
                    .Include(lp => lp.Modelo)
                    .Include(lp => lp.Estado)
                    .Where(lp => lp.PedidoId == pedidoId).ToList();
            }
            catch (Exception)
            {

            }

            return result;
        }

        public LineasPedido Get(int id)
        {
            LineasPedido result = _texereDbContext.LineasPedido.Where(x => x.LineaPedidoId == id).FirstOrDefault();
            if (result == null)
            {
                throw new Exception(string.Format("{0} - Linea de pedido no encontrada", System.Net.HttpStatusCode.NotFound));
            }

            return result;
        }

        public bool Add(LineasPedido model)
        {
            try
            {
                model.EstadoId = 1;
                _texereDbContext.Add(model);
                _texereDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(LineasPedido updatedModel)
        {
            try
            {
                _texereDbContext.Update(updatedModel);
                _texereDbContext.SaveChanges();
                //UpdatePedido(model.PedidoId);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _texereDbContext.Entry(new LineasPedido { LineaPedidoId = id }).State = EntityState.Deleted; ;
                _texereDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
