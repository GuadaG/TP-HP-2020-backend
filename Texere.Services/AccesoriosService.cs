using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Texere.DataAccess;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.Service
{
    public class AccesoriosService : IAccesoriosService
    {
        private readonly TexereDbContext _texereDbContext;

        public AccesoriosService(
            TexereDbContext texereDbContext
        )
        {
            _texereDbContext = texereDbContext;
        }

        public IEnumerable<Accesorios> GetAll()
        {
            var result = new List<Accesorios>();

            try
            {
                result = _texereDbContext.Accesorios.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public Accesorios Get(int id)
        {
            var result = new Accesorios();

            try
            {
                result = _texereDbContext.Accesorios.Single(x => x.AccesorioId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Accesorios model)
        {
            try
            {
                _texereDbContext.Add(model);
                _texereDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(Accesorios model)
        {
            try
            {
                var originalModel = _texereDbContext.Accesorios.Single(x =>
                    x.AccesorioId == model.AccesorioId
                );

                originalModel.DescAccesorio = model.DescAccesorio;
             //   originalModel.LastName = model.LastName;
             //   originalModel.Bio = model.Bio;

                _texereDbContext.Update(originalModel);
                _texereDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _texereDbContext.Entry(new Accesorios { AccesorioId = id }).State = EntityState.Deleted; ;
                _texereDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}

