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
        public async Task<bool> RegisterBrand(Brand brand)
        {
            try
            {
                var brands = new List<Brand>();
                var brandnew = new Brand();
                brands.Add(brand);
                string Json = JsonConvert.SerializeObject(brands).ToString();
                using (SqlConnection con = new SqlConnection(_settings.ClientConnection))
                {
                    SqlCommand cmd = new SqlCommand("SP_Guardar_Brand", con)
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
                        throw new Exception($"Error error registrando Sucursal en la base de datos de sql server, detail: {cmd.Parameters["@Message"].Value.ToString()}");
                    }
                    //string CompanyJson = cmd.Parameters["@Company"].Value.ToString();
                    //newCompany = JsonConvert.DeserializeObject<Company>(CompanyJson);
                    return response;

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<List<Brand>> GetBrands(string Id_GUID)
        {
            try
            {
                var brands = new List<Brand>();

                using (SqlConnection con = new SqlConnection(_settings.ClientConnection))
                {
                    SqlCommand cmd = new SqlCommand("SP_Listar_Brands", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Id_GUID", SqlDbType.NVarChar, -1).Value = Id_GUID;
                    await con.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var brand = new Brand
                            {
                                Id = reader["Id"] as int?,
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Status = (int)reader["Status"],
                                Id_GUID = reader["Id_GUID"].ToString(),
                                TotalVentas = reader["TotalVentas"] != DBNull.Value ? Convert.ToSingle(reader["TotalVentas"]) : 0
                            };
                            brands.Add(brand);
                        }
                    }
                }
                return brands;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<bool> SaveProduct(Product product)
        {
            try
            {
                    string Json = JsonConvert.SerializeObject(product).ToString();
                    using (SqlConnection con = new SqlConnection(_settings.ClientConnection))
                    {
                        SqlCommand cmd = new SqlCommand("SP_Guardar_Producto", con)
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
                            throw new Exception($"Error error registrando Producto en la base de datos de sql server, detail: {cmd.Parameters["@Message"].Value.ToString()}");
                        }
                        return response;

                    }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Product>> GetProducts(string Id_GUID)
        {
            try
            {
                var products = new List<Product>();

                using (SqlConnection con = new SqlConnection(_settings.ClientConnection))
                {
                    SqlCommand cmd = new SqlCommand("SP_Listar_Productos", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Id_GUID", SqlDbType.NVarChar, -1).Value = Id_GUID;
                    await con.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var producto = new Product
                            {
                                Id = reader["Id"] != DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                                Name = reader["Name"]?.ToString() ?? string.Empty,
                                Description = reader["Description"]?.ToString() ?? string.Empty,
                                Price = reader["Price"] != DBNull.Value ? Convert.ToSingle(reader["Price"]) : 0,
                                Status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : 0,
                                
                            };
                            producto.StatusBrands = await GetBrandsByProduct(producto.Id);
                            products.Add(producto);
                        }
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<Brand>> GetBrandsByProduct(int Id_Product)
        {
            try
            {
                var brands = new List<Brand>();

                using (SqlConnection con = new SqlConnection(_settings.ClientConnection))
                {
                    SqlCommand cmd = new SqlCommand("SP_Listar_Productos_By_Brand", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("@Id_Producto", SqlDbType.Int, -1).Value = Id_Product;
                    await con.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var brand = new Brand
                            {
                                Id = reader["Id"] as int?,
                                Nombre = reader["Nombre"].ToString(),
                                Direccion = reader["Direccion"].ToString(),
                                Status = (int)reader["Status"],
                                TotalVentas = reader["TotalVentas"] != DBNull.Value ? Convert.ToSingle(reader["TotalVentas"]) : 0
                            };
                            brands.Add(brand);
                        }
                    }
                }
                return brands;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
