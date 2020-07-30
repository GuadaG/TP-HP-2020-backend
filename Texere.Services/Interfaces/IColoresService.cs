using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IColoresService
    {
        bool Add(Colores model);
        bool Delete(int id);
        bool Update(Colores model);
        Colores Get(int id);
        IEnumerable<Colores> GetAll();
    }
}
