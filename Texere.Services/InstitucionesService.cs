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

        public bool Add(Institucion model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Institucion model)
        {
            throw new NotImplementedException();
        }

        public Institucion Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Institucion> GetAll()
        {
            var result = new List<Institucion>();

            try
            {
                result = _texereDbContext.Instituciones.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
    }
}
