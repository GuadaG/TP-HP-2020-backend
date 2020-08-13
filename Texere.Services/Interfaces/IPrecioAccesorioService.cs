using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IPrecioAccesorioService
    {
        IEnumerable<PrecioAccesorio> GetAll();
        bool Add(PrecioAccesorio model);
        bool Delete(int id);
        bool Update(PrecioAccesorio model);
        PrecioAccesorio Get(int id);
    }
}
