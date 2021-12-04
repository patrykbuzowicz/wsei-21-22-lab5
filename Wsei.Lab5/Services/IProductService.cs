using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab5.Entities;
using Wsei.Lab5.Models;

namespace Wsei.Lab5.Services
{
    public interface IProductService
    {
        Task Add(ProductModel product);

        Task<IEnumerable<ProductEntity>> GetAll(string name);
    }
}
