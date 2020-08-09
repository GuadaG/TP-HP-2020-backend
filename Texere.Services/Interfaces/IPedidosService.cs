using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IPedidosService
    {
        IEnumerable<Pedidos> GetAll();
        bool Add(Pedidos model);
        bool Delete(int id);
        bool Update(Pedidos model);
        Pedidos Get(int id);
    }
}
