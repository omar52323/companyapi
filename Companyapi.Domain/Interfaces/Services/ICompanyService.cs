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

        Task<bool> ValidateLogin(User user);

        Task<bool> RegisterUser(User user);
    }
}
