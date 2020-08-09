using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Texere.DataAccess;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.Service
{
    public class ModelosService : IModelosService
    {
        private readonly TexereDbContext _texereDbContext;
        public ModelosService(TexereDbContext texereDbContext)
        {
            _texereDbContext = texereDbContext;
        }

        public bool Add(Modelos model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Modelos Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelos> GetAll()
        {
            var result = new List<Modelos>();

            try
            {
                result = _texereDbContext.Modelos.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Update(Modelos model)
        {
            throw new NotImplementedException();
        }
    }
}

