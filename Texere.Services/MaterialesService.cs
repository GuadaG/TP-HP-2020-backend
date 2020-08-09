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
   public class MaterialesService : IMaterialesService
    {
        private readonly TexereDbContext _texereDbContext;

        public MaterialesService(
            TexereDbContext texereDbContext
        )
        {
            _texereDbContext = texereDbContext;
        }

        public IEnumerable<Materiales> GetAll()
        {
            var result = new List<Materiales>();

            try
            {
                result = _texereDbContext.Materiales.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public Materiales Get(int id)
        {
            var result = new Materiales();

            try
            {
                result = _texereDbContext.Materiales.Single(x => x.MaterialId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Materiales model)
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

        public bool Update(Materiales model)
        {
            try
            {
                var originalModel = _texereDbContext.Materiales.Single(x =>
                    x.MaterialId == model.MaterialId
                );

                originalModel.DescMaterial = model.DescMaterial;
           

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
                _texereDbContext.Entry(new Materiales { MaterialId = id }).State = EntityState.Deleted; ;
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
