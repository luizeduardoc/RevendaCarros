﻿using System.Collections.Generic;
using RevendaCarros.Domain.Entities;

namespace RevendaCarros.Domain.Services.Interfaces
{
    public interface IEstoqueService
    {
        IList<Aluguel> GetAll();
    }
}