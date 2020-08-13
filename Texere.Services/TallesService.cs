using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Texere.DataAccess;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.Service
{
    public class TallesService : ITallesService
    {
        private readonly TexereDbContext _texereDbContext;
        public TallesService(TexereDbContext texereDbContext)
        {
            _texereDbContext = texereDbContext;
        }

        public bool Add(Talles model)

        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Talles Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Talles> GetAll()
        {
            var result = new List<Talles>();

            try
            {
                result = _texereDbContext.Talles.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Update(Talles model)
        {
            throw new NotImplementedException();
        }
    }
}

