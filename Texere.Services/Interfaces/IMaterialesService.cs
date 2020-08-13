using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IMaterialesService
    {
        IEnumerable<Materiales> GetAll();
        bool Add(Materiales model);
        bool Delete(int id);
        bool Update(Materiales model);
        Materiales Get(int id);
    }
}
