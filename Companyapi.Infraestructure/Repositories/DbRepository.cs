using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Companyapi.Domain.Entities;
using Companyapi.Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Companyapi.Infraestructure.Repositories
{
    public class DbRepository:IDbRepository
    {

        private readonly GlobalSettings _settings;

        public DbRepository(GlobalSettings settings) {
            _settings = settings;
        }
        public async Task<User> ValidateLogin(UserLogin user)
        {
            try
            {
                string Json = JsonConvert.SerializeObject(user).ToString();
                using (SqlConnection con = new SqlConnection(_settings.ClientConnection))
                {
                    SqlCommand cmd = new SqlCommand("SP_Validar_Usuario", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Json", SqlDbType.NVarChar, -1).Value = Json;
                    cmd.Parameters.Add(new SqlParameter("@Response", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                    cmd.Parameters.Add(new SqlParameter("@Message", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output });
                    cmd.Parameters.Add(new SqlParameter("@UserJson", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output });
                    cmd.Parameters.Add(new SqlParameter("@Company", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output });
                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    bool response = (bool)cmd.Parameters["@Response"].Value;

                    if (!response)
                    {
                        throw new Exception($"Error validando usuario en la base de datos de sql server, detail: {cmd.Parameters["@Message"].Value.ToString()}");
                    }

                    string userJson = cmd.Parameters["@UserJson"].Value.ToString();
                    string CompanyJson = cmd.Parameters["@Company"].Value.ToString();
                    var validatedUser = JsonConvert.DeserializeObject<User>(userJson);

                    if (CompanyJson != "")
                    {
                        var Company = JsonConvert.DeserializeObject<Company>(CompanyJson);
                        validatedUser.Company = new List<Company>();
                        validatedUser.Company.Add(Company);
                    }

                    return validatedUser;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            try
            {
                var users = new List<User>();

                users.Add(user);
                string Json = JsonConvert.SerializeObject(users).ToString();
                using (SqlConnection con = new SqlConnection(_settings.ClientConnection))
                {
                    SqlCommand cmd = new SqlCommand("SP_Guardar_Usuario", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Json", SqlDbType.NVarChar, -1).Value = Json;
                    cmd.Parameters.Add(new SqlParameter("@Response", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                    cmd.Parameters.Add(new SqlParameter("@Message", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output });

                    await con.OpenAsync();

                    await cmd.ExecuteNonQueryAsync();

                    bool response = true;

                    response = (bool)cmd.Parameters["@Response"].Value;

                    if (!response)
                    {
                        throw new Exception($"Error error validando usuario en la base de datos de sql server, detail: {cmd.Parameters["@Message"].Value.ToString()}");
                    }

                    return response;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<Company> RegisterCompany(Company Company)
        {
            try
            {
                var companys = new List<Company>();
                var newCompany = new Company();
                companys.Add(Company);
                string Json = JsonConvert.SerializeObject(companys).ToString();
                using (SqlConnection con = new SqlConnection(_settings.ClientConnection))
                {
                    SqlCommand cmd = new SqlCommand("SP_Guardar_Company", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Json", SqlDbType.NVarChar, -1).Value = Json;
                    cmd.Parameters.Add(new SqlParameter("@Response", SqlDbType.Bit) { Direction = ParameterDirection.Output });
                    cmd.Parameters.Add(new SqlParameter("@Message", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output });
                    cmd.Parameters.Add(new SqlParameter("@Company", SqlDbType.NVarChar, -1) { Direction = ParameterDirection.Output });
                    await con.OpenAsync();

                    await cmd.ExecuteNonQueryAsync();

                    bool response = true;

                    response = (bool)cmd.Parameters["@Response"].Value;

                    if (!response)
                    {
                        throw new Exception($"Error error registrando compañia en la base de datos de sql server, detail: {cmd.Parameters["@Message"].Value.ToString()}");
                    }
                    string CompanyJson = cmd.Parameters["@Company"].Value.ToString();
                    newCompany = JsonConvert.DeserializeObject<Company>(CompanyJson);
                    return newCompany;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
