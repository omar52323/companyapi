using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Companyapi.Domain.Entities;
using Companyapi.Domain.Interfaces.Services;
using Companyapi.Domain.Interfaces.Repositories;
namespace Companyapi.Core.Services
{
    public class CompanyService:ICompanyService
    {

        private readonly IDbRepository _dbRepository;
        public CompanyService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
        public async Task<User> ValidateLogin(UserLogin user)
        {

            return await _dbRepository.ValidateLogin(user);

        }

        public async Task<bool> RegisterUser(User user)
        {
            return await _dbRepository.RegisterUser(user);
        }
        public async Task<Company> RegisterCompany(Company company)
        {
            return await _dbRepository.RegisterCompany(company);
        }

        public async Task<bool> RegisterBrand(Brand brand)
        {
            return await _dbRepository.RegisterBrand(brand);
        }
        public async Task<List<Brand>> GetBrands(string Id_GUID)
        {
            return await _dbRepository.GetBrands(Id_GUID);
        }
        public async Task<bool> SaveProduct(Product product)
        {
            return await _dbRepository.SaveProduct(product);
        }

        public async Task<List<Product>> GetProducts(string Id_GUID)
        {
            return await _dbRepository.GetProducts(Id_GUID);
        }
    }
}
