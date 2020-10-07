using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface ILineasPedidoService
    {
        IEnumerable<LineasPedido> GetAll(int pedidoId);
        bool Add(LineasPedido model);
        bool Delete(int id);
        bool Update(LineasPedido model);
        LineasPedido Get(int id);
    }
}
