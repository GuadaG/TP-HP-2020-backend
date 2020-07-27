using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IInstitucionesService
    {
        bool Add(Institucion model);
        bool Delete(int id);
        bool Update(Institucion model);
        Institucion Get(int id);
        IEnumerable<Institucion> GetAll();
    }
}
