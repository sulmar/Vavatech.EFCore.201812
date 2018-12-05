using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vavatech.EFCore.Models;

namespace Vavatech.EFCore.IServices
{
    public interface IProductsService
    {
        IList<Product> Get();
        Product Get(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);

        Task<IList<Product>> GetAsync();
        Task AddAsync(Product product);

    }
}
