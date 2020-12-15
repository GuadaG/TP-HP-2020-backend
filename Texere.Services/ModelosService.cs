using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                _texereDbContext.Add(model);
                _texereDbContext.SaveChanges();
            }
            catch (Exception)
            {
                //TODO - agregar msj error tipo -> String.Format("Ha ocurrido la siguiente excepción: {0}", e.Message);
                return false;
            }

            return true;
         
        }

        public bool Delete(int id)
        {
            try
            {
                _texereDbContext.Entry(new Modelos { ModeloId = id }).State = EntityState.Deleted;
                _texereDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Modelos Get(int id)
        {
            var result = _texereDbContext.Modelos.Where(m => m.ModeloId == id).FirstOrDefault();

            if(result == null)
            {
                throw new Exception(string.Format("{0} - Cliente no encontrado", System.Net.HttpStatusCode.NotFound));
            }

            return result;
        }

        public IEnumerable<Modelos> GetAll()
        {
            var result =  _texereDbContext.Modelos
                .OrderBy(m => m.DescModelo)
                .Include(m => m.ColoresModelos)
                .Include(m => m.Instituciones)
                .ToList();

            return result;
                
        }

        public bool Update(Modelos model)
        {
            try
            {
                var originalModel = _texereDbContext.Modelos.Single(x =>
                    x.ModeloId == model.ModeloId
                );

                originalModel.DescModelo = model.DescModelo;
                //faltaría la  imagen

                _texereDbContext.Update(originalModel);
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
