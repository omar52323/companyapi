using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Companyapi.Domain.Entities;

namespace Companyapi.Domain.Interfaces.Repositories
{
    public interface IDbRepository
    {
        Task<User> ValidateLogin(UserLogin user);
        Task<bool> RegisterUser(User user);
        Task<Company> RegisterCompany(Company Company);
        Task<bool> RegisterBrand(Brand brand);
        Task<List<Brand>> GetBrands(string Id_GUID);
        Task<bool> SaveProduct(Product product);
        Task<List<Product>> GetProducts(string Id_GUID);
    }
}
