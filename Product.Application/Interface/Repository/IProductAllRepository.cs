﻿using Product.Domain.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interface.Repository
{
    public interface IProductAllRepository
    {
        Task<IList<ProductAll>> Getdata(CancellationToken cancellationToken);
    }
}
