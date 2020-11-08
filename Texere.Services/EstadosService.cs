using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Texere.DataAccess;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.Service
{
    public class EstadosService : IEstadosService
    {
        private readonly TexereDbContext _texereDbContext;

        public EstadosService(
            TexereDbContext texereDbContext
        )
        {
            _texereDbContext = texereDbContext;
        }

        public IEnumerable<Estados> GetAll()
        {
            var result = new List<Estados>();

            try
            {
                result = _texereDbContext.Estados.ToList();
            }
            catch (Exception)
            {

            }

            return result;
        }
    }
}
