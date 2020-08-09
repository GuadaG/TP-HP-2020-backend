﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Texere.DataAccess;
using Texere.Model;
using Texere.Service.Interfaces;

namespace Texere.Service
{
    public class PrecioAccesorioService : IPrecioAccesorioService

    {         private readonly TexereDbContext _texereDbContext;
    public PrecioAccesorioService(TexereDbContext texereDbContext)
    {
        _texereDbContext = texereDbContext;
    }

    public bool Add(PrecioAccesorio model)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public PrecioAccesorio Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PrecioAccesorio> GetAll()
    {
        var result = new List<PrecioAccesorio>();

        try
        {
            result = _texereDbContext.PrecioAccesorio.ToList();
        }
        catch (System.Exception)
        {

        }

        return result;
    }

    public bool Update(PrecioAccesorio model)
    {
        throw new NotImplementedException();
    }
}     

    
}
