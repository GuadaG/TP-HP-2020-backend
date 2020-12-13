using Microsoft.EntityFrameworkCore;
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
    public class InstitucionesService : IInstitucionesService
    {
        private readonly TexereDbContext _texereDbContext;
        public InstitucionesService(TexereDbContext texereDbContext)
        {
            _texereDbContext = texereDbContext;
        }

        public IEnumerable<Instituciones> GetAll()
        {
            var result = new List<Instituciones>();

            try
            {
                result = _texereDbContext.Instituciones       
                    .OrderBy(i => i.Descripcion)
                    .Include(i => i.Modelo)
                    .ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
    }
}
