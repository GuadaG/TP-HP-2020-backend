using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface ILineaPedidoService
    {
        IEnumerable<LineaPedido> GetAll();
        bool Add(LineaPedido model);
        bool Delete(int id);
        bool Update(LineaPedido model);
        LineaPedido Get(int id);
    }
}
