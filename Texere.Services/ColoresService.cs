using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Texere.DataAccess;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.Service
{
    public class ColoresService : IColoresService
    {
        private readonly TexereDbContext _texereDbContext;
        public ColoresService(TexereDbContext texereDbContext)
        {
            _texereDbContext = texereDbContext;
        }

        public IEnumerable<Colores> GetAll()
        {
            var result = new List<Colores>();

            try
            {
                result = _texereDbContext.Colores.OrderBy(c => c.Descripcion).ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
    }
}
