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
                model.EstadoId = (int)EstadosEnum.Pendiente;
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
                UpdatePedido(updatedModel);
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

        private void UpdatePedido(LineasPedido updatedModel)
        {
            Pedidos pedido = _texereDbContext.Pedidos.Where(p => p.PedidoId == updatedModel.PedidoId)
                .Include(p => p.LineasPedido)
                .FirstOrDefault();

            switch (updatedModel.EstadoId)
            {
                case (int)EstadosEnum.Pendiente:
                {
                    if (pedido.LineasPedido.All(lp => lp.EstadoId == (int)EstadosEnum.Pendiente))
                        ActualizarPedido(pedido, (int)EstadosEnum.Pendiente);
                    break;
                }
                case (int)EstadosEnum.EnCurso:
                {
                    ActualizarPedido(pedido, (int)EstadosEnum.EnCurso);
                    break;
                }
                case (int)EstadosEnum.Finalizado:
                {
                    if (pedido.LineasPedido.All(lp => lp.EstadoId == (int)EstadosEnum.Finalizado))
                        ActualizarPedido(pedido, (int)EstadosEnum.Finalizado);
                    break;
                }
                case (int)EstadosEnum.Cancelado:
                {
                    if (pedido.LineasPedido.All(lp => lp.EstadoId == (int)EstadosEnum.Cancelado))
                        ActualizarPedido(pedido, (int)EstadosEnum.Cancelado);
                    break;
                }
                default:
                    break;
            }
        }

        private bool ActualizarPedido(Pedidos pedido, int estadoId)
        {
            try
            {
                pedido.EstadoId = estadoId;

                _texereDbContext.Update(pedido);
                _texereDbContext.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}