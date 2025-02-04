using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Companyapi.Domain.Entities;
using Companyapi.Domain.Interfaces.Repositories;

namespace Companyapi.Infraestructure.Repositories
{
    public class DbRepository:IDbRepository
    {

        public DbRepository() { }
        public async Task<bool> ValidateLogin(User user)
        {
            return true;
        }

        public async Task<bool> RegisterUser(User user)
        {
            return true;
        }


    }
}
