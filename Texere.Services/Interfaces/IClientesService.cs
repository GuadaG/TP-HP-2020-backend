using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{   public interface IClientesService
    {
        IEnumerable<Clientes> GetAll();
        bool Add(Clientes model);
        bool Delete(int id);
        bool Update(Clientes model);
        Clientes Get(int id);
    }
}
