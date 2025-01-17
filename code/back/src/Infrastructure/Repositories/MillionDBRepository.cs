using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Mapper;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MillionDBRepository : IMillionDBRepository
    {
        private readonly IDbConnection _dbConnection;
        public MillionDBRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<PropertyFilterResultEntity>> GetFilteredPropertiesAsync(PropertyFilterRequestEntity filter)
        {
            try
            {
                var query = BuildBaseQuery();
                var parameters = BuildQueryParametersFilter(filter, ref query);
                var result = await ExecuteQueryAsync(query, parameters);
                return PropertyFilterResultMapper.MapModelToEntity(result);
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("Error al obtener las propiedades filtradas.", ex);
            }
        }

        public async Task<IEnumerable<PropertyFilterResultEntity>> GetTopPropertiesAsync(int top)
        {
            try
            {
                var query = BuildBaseQueryTOP();
                var parameters = new DynamicParameters();
                parameters.Add("@Top", top);
                var result = await ExecuteQueryAsync(query, parameters);
                return PropertyFilterResultMapper.MapModelToEntity(result);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener el top {" + top + "} las propiedades.", ex);
            }
        }

        private string BuildBaseQuery()
        {
            return @" SELECT 
                            o.""IdOwner"",
                            o.""Name"" AS OwnerName,
                            p.""Name"" AS PropertyName,
                            p.""Address"" AS PropertyAddress,
                            p.""Price"",
                            img.""FileImage"" AS ImageUrl
                        FROM ""Property"" p
                        INNER JOIN ""Owner"" o ON p.""IdOwner"" = o.""IdOwner""
                        LEFT JOIN ""PropertyImage"" pi ON p.""IdProperty"" = pi.""IdProperty""
                        LEFT JOIN ""Image"" img ON pi.""IdPropertyImage"" = img.""IdImage""
                        WHERE 1=1 ";
        }

        private string BuildBaseQueryTOP()
        {
            return @" SELECT o.""IdOwner"",
                            o.""Name"" AS OwnerName,
                            p.""Name"" AS PropertyName,
                            p.""Address"" AS PropertyAddress,
                            p.""Price"",
                            img.""FileImage"" AS ImageUrl
                        FROM ""Property"" p
                        INNER JOIN ""Owner"" o ON p.""IdOwner"" = o.""IdOwner""
                        LEFT JOIN ""PropertyImage"" pi ON p.""IdProperty"" = pi.""IdProperty""
                        LEFT JOIN ""Image"" img ON pi.""IdPropertyImage"" = img.""IdImage""
                        ORDER BY p.""IdProperty"" DESC
                        LIMIT @Top;";
        }

        private DynamicParameters BuildQueryParametersFilter(PropertyFilterRequestEntity filter, ref string query)
        {
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query += " AND p.\"Name\" ILIKE @Name";
                parameters.Add("Name", $"%{filter.Name}%");
            }

            if (!string.IsNullOrEmpty(filter.Address))
            {
                query += " AND p.\"Address\" ILIKE @Address";
                parameters.Add("Address", $"%{filter.Address}%");
            }

            if (filter.MinPrice.HasValue)
            {
                query += " AND p.\"Price\" >= @MinPrice";
                parameters.Add("MinPrice", filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query += " AND p.\"Price\" <= @MaxPrice";
                parameters.Add("MaxPrice", filter.MaxPrice.Value);
            }

            query += " ORDER BY p.\"Created_at\" DESC";

            return parameters;
        }

        private async Task<IEnumerable<PropertyFilterResultModel>> ExecuteQueryAsync(string query, DynamicParameters parameters)
        {
            return await _dbConnection.QueryAsync<PropertyFilterResultModel>(query, parameters);
        }

    }
}
