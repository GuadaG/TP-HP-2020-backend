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
    public class ClientesService : IClientesService
    {
        private readonly TexereDbContext _texereDbContext;
        public ClientesService(TexereDbContext texereDbContext)
        {
            _texereDbContext = texereDbContext;
        }

        public bool Add(Clientes model)
        {
            try
            {
                _texereDbContext.Add(model);
                _texereDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Clientes Get(int id)
        {
            var result = new Clientes();

            try
            {
                result = _texereDbContext.Clientes.Single(c => c.ClienteId == id);
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public IEnumerable<Clientes> GetAll()
        {
            var result = new List<Clientes>();

            try
            {
                result = _texereDbContext.Clientes.ToList();
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public bool Update(Clientes model)
        {
            throw new NotImplementedException();
        }
    }
}
