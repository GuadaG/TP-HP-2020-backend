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
    public class LineaPedidoService : ILineaPedidoService
    {
        private readonly TexereDbContext _texereDbContext;

        public LineaPedidoService(
            TexereDbContext texereDbContext
        )
        {
            _texereDbContext = texereDbContext;
        }

        public IEnumerable<LineaPedido> GetAll()
        {
            var result = new List<LineaPedido>();

            try
            {
                result = _texereDbContext.LineaPedido.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public LineaPedido Get(int id)
        {
            var result = new LineaPedido();

            try
            {
                result = _texereDbContext.LineaPedido.Single(x => x.LineaPedidoId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(LineaPedido model)
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

        public bool Update(LineaPedido model)
        {
            try
            {
                var originalModel = _texereDbContext.LineaPedido.Single(x =>
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
                _texereDbContext.Entry(new LineaPedido { LineaPedidoId = id }).State = EntityState.Deleted; ;
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
