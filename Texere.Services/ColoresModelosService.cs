using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Texere.DataAccess;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.Service
{
    public class ColoresModelosService : IColoresModelosService
    {
        private readonly TexereDbContext _texereDbContext;
        public ColoresModelosService(TexereDbContext texereDbContext)
        {
            _texereDbContext = texereDbContext;
        }

        public IEnumerable<ColoresModelos> GetAll()
        {
            var result = new List<ColoresModelos>();

            try
            {
                result = _texereDbContext.ColoresModelos.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public ColoresModelos Get(int id)
        {
            var result = new ColoresModelos();

            try
            {
                result = _texereDbContext.ColoresModelos.Single(c => c.ColorId == id);
                result = _texereDbContext.ColoresModelos.Single(m => m.ModeloId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Update(ColoresModelos model)
        {
            try
            {
                var originalModel = _texereDbContext.ColoresModelos.Single(c =>
                    c.ColorId == model.ColorId
                );
               // var originalModel = _texereDbContext.ColoresModelos.Single(m =>
               //     m.ModeloId == model.ModeloId );

                originalModel.ColorId = model.ColorId;
                originalModel.ModeloId = model.ModeloId;


                _texereDbContext.Update(originalModel);
                _texereDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Add(ColoresModelos model)
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

        public bool Delete(int id)
        {
            try
            {
                _texereDbContext.Entry(new ColoresModelos { ColorId = id }).State = EntityState.Deleted;
                _texereDbContext.Entry(new ColoresModelos { ModeloId = id }).State = EntityState.Deleted;
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
