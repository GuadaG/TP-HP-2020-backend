﻿using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.Service.Interfaces
{
    public interface IEstadosService
    {
        IEnumerable<Estados> GetAll();
    }
}
