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
        Task<List<Product>> GetProductsByBrand(string Id_GUID, string Id_Brand);
        Task<List<Order>> GetPendingOrders(string Id_GUID, string Id_Brand);
        Task<List<Order>> GetReadyOrders(string Id_GUID, string Id_Brand);
        Task<bool> SaveOrder(Order order);
        Task<bool> ChangeProductByBrand(ProductByBrand productByBrand);
        Task<bool> ChangeOrder(Order order);
        Task<List<BranchSales>> GetSales(SalesFilter salesFilter);
        Task<List<Stats>> GetDaily(string Id_GUID);
        Task<List<Order>> GetRecentOrders(string Id_GUID);
        Task<bool> ChangePassword(User user);
        Task<User> GetUserInfo(string Id_User);
    }
}
