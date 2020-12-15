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

        public IEnumerable<ColoresModelos> GetAll(int modeloId)
        {
            var result = new List<ColoresModelos>();

            try
            {
                result = _texereDbContext.ColoresModelos.Where(cm => cm.ModeloId == modeloId).OrderBy(cm => cm.Orden).ToList();
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
                ColoresModelos originalModel = _texereDbContext.ColoresModelos.Single(cm =>
                    cm.ColorId == model.ColorId && cm.ModeloId == model.ModeloId
                );

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

        public bool Delete(int modeloId, int colorId)
        {
            try
            {
                ColoresModelos model = _texereDbContext.ColoresModelos.First(cm =>
                    cm.ColorId == colorId && cm.ModeloId == modeloId
                );
                _texereDbContext.ColoresModelos.Remove(model);
                _texereDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
