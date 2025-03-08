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
        public async Task<List<Product>> GetProductsByBrand(string Id_GUID,string Id_Product)
        {
            return await _dbRepository.GetProductsByBrand(Id_GUID, Id_Product);
        }

        public async Task<bool> SaveOrder(Order order)
        {
            return await _dbRepository.SaveOrder(order);
        }

        public async Task<List<Order>> GetPendingOrders(string Id_GUID, string Id_Brand)
        {
            return await _dbRepository.GetPendingOrders(Id_GUID,Id_Brand);
        }

        public async Task<List<Order>> GetReadyOrders(string Id_GUID, string Id_Brand)
        {
            return await _dbRepository.GetReadyOrders(Id_GUID,Id_Brand);
        }

        public async Task<bool> ChangeOrder(Order order)
        {
            return await _dbRepository.ChangeOrder(order);
        }
        public async Task<bool> ChangeProductByBrand(ProductByBrand productByBrand)
        {
            return await _dbRepository.ChangeProductByBrand(productByBrand);
        }

        public async Task<List<BranchSales>> GetSales(SalesFilter salesFilter)
        {
            return await _dbRepository.GetSales(salesFilter);
        }

        public async Task<List<Stats>> GetDaily(string Id_GUID)
        {
            return await _dbRepository.GetDaily(Id_GUID);
        }

        public async Task<List<Order>> GetRecentOrders(string Id_GUID)
        {
            return await _dbRepository.GetRecentOrders(Id_GUID);
        }

        public async Task<User> GetUserInfo(string Id_User)
        {
            return await _dbRepository.GetUserInfo(Id_User);
        }

        public async Task<bool> ChangePassword(User user)
        {
            return await _dbRepository.ChangePassword(user);
        }

    }
}
