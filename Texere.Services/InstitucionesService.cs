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

        public bool Add(Instituciones model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Instituciones model)
        {
            throw new NotImplementedException();
        }

        public Instituciones Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Instituciones> GetAll()
        {
            var result = new List<Instituciones>();

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
