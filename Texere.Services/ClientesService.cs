using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
                //TODO - agregar msj error tipo -> String.Format("Ha ocurrido la siguiente excepción: {0}", e.Message);
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _texereDbContext.Entry(new Clientes { ClienteId = id }).State = EntityState.Deleted;
                _texereDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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
            try
            {
                var originalModel = _texereDbContext.Clientes.Single(x =>
                    x.ClienteId == model.ClienteId
                );

                originalModel.DniCuit = model.DniCuit;
                originalModel.Email = model.Email;
                originalModel.Domicilio = model.Domicilio;
                originalModel.Telefono = model.Telefono;
                originalModel.NombreApellido = model.NombreApellido;

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
