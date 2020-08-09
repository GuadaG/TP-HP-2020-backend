using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;


namespace Texere.Service.Interfaces
{
    public interface IModelosService
    {
        IEnumerable<Modelos> GetAll();
        bool Add(Modelos model);
        bool Delete(int id);
        bool Update(Modelos model);
        Modelos Get(int id);
    }
}
