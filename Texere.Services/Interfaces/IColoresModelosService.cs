using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IColoresModelosService
    {
        IEnumerable<ColoresModelos> GetAll(int modeloId);
        bool Add(ColoresModelos model);
        bool Delete(int modeloId, int colorId);
        bool Update(ColoresModelos model);
    }
}
