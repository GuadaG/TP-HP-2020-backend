using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IAccesoriosService
    {
        IEnumerable<Accesorios> GetAll();
        bool Add(Accesorios model);
        bool Delete(int id);
        bool Update(Accesorios model);
        Accesorios Get(int id);
    }
}
