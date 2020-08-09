using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{    public interface ITallesService
        {
            IEnumerable<Talles> GetAll();
            bool Add(Talles model);
            bool Delete(int id);
            bool Update(Talles model);
            Talles Get(int id);
        }
    }
