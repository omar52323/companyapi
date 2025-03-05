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
        public async Task<bool> RegisterCompany(Company company)
        {
            return await _dbRepository.RegisterCompany(company);
        }

    }
}
