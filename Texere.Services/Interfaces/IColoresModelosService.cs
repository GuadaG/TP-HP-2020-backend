using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IColoresModelosService
    {
        IEnumerable<ColoresModelos> GetAll();
        bool Add(ColoresModelos model);
        bool Delete(int id);
        bool Update(ColoresModelos model);
        ColoresModelos Get(int id);
    }
}
