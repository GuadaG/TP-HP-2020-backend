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

        public IEnumerable<LineasPedido> GetAll()
        {
            var result = new List<LineasPedido>();

            try
            {
                result = _texereDbContext.LineasPedido.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public LineasPedido Get(int id)
        {
            var result = new LineasPedido();

            try
            {
                result = _texereDbContext.LineasPedido.Single(x => x.LineaPedidoId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(LineasPedido model)
        {
            try
            {
                _texereDbContext.Add(model);
                _texereDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(LineasPedido model)
        {
            try
            {
                var originalModel = _texereDbContext.LineasPedido.Single(x =>
                    x.LineaPedidoId == model.LineaPedidoId
                );

                originalModel.Cantidad = model.Cantidad;
                originalModel.Observaciones = model.Observaciones;
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
                _texereDbContext.Entry(new LineasPedido { LineaPedidoId = id }).State = EntityState.Deleted; ;
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
