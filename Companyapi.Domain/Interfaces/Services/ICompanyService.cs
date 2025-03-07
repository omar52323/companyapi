using Companyapi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Companyapi.Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<User> ValidateLogin(UserLogin user);
        Task<bool> RegisterUser(User user);
        Task<Company> RegisterCompany(Company company);
        Task<bool> RegisterBrand(Brand brand);
        Task<List<Brand>> GetBrands(string Id_GUID);
        Task<List<Product>> GetProducts(string Id_GUID);
        Task<bool> SaveProduct(Product product);
    }
}
