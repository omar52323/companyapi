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
        Task<bool> ValidateLogin(User user);
        Task<bool> RegisterUser(User user);
    }
}
