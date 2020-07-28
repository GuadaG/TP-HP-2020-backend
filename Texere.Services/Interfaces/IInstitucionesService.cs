using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IInstitucionesService
    {
        bool Add(Instituciones model);
        bool Delete(int id);
        bool Update(Instituciones model);
        Instituciones Get(int id);
        IEnumerable<Instituciones> GetAll();
    }
}
