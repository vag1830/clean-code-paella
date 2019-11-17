using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Paella.Application.Persistence;
using Paella.Domain.Entities;
using Paella.Infrastructure.Entities;
using Paella.Infrastructure.Exceptions;

namespace Paella.Infrastructure
{
    public class ProductAdoRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductAdoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<Product> GetAll()
        {
            var query = "SELECT * "
                    + "FROM Products "
                    + "WHERE 1 = 1";

            List<ProductDao> queryResult;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    queryResult = ExecuteGetAllCommandAndRead(command);
                }
                catch (Exception ex)
                {
                    throw new InfrastructureException(ex.Message, ex);
                }
            }

            var result = queryResult
                .Select(ToDomainEntity)
                .ToList();

            return result;
        }

        private List<ProductDao> ExecuteGetAllCommandAndRead(SqlCommand command)
        {
            var result = new List<ProductDao>();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var dao = new ProductDao
                {
                    Id = reader.GetGuid(0),
                    Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Description = reader.IsDBNull(2) ? null : reader.GetString(2)
                };

                result.Add(dao);
            }

            reader.Close();

            return result;
        }

        public Product GetById(Guid id)
        {
            var query = "SELECT * "
                    + "FROM Products "
                    + "WHERE id = @id";

            ProductDao queryResult;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                var parameter = new SqlParameter("@id", id);

                command.Parameters.Add(parameter);

                try
                {
                    connection.Open();

                    queryResult = ExecuteGetByIdCommandAndRead(command);
                }
                catch (Exception ex)
                {
                    throw new InfrastructureException(ex.Message, ex);
                }
            }

            return queryResult == null
                ? null
                : ToDomainEntity(queryResult);
        }

        private ProductDao ExecuteGetByIdCommandAndRead(SqlCommand command)
        {
            var reader = command.ExecuteReader();

            reader.Read();

            if (reader.HasRows == false)
            {
                return null;
            }

            var dao = new ProductDao
            {
                Id = reader.GetGuid(0),
                Name = reader.IsDBNull(1) ? null : reader.GetString(1),
                Description = reader.IsDBNull(2) ? null : reader.GetString(2)
            };

            return dao;
        }

        public void Create(Product product)
        {
            var query = "INSERT INTO Products (Id, Name, Description) " +
                "VALUES (@id, @name, @description) ";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            AddParametersToCommand(command, product);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(ex.Message, ex);
            }
        }

        public void Update(Product product)
        {
            var query = "UPDATE Products "
                + "SET Name = @name, Description = @description "
                + "WHERE Id = @id";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            AddParametersToCommand(command, product);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new InfrastructureException(ex.Message, ex);
            }
        }

        private void AddParametersToCommand(SqlCommand command, Product product)
        {
            var id = new SqlParameter("@id", product.Id);
            var name = new SqlParameter("@name", product.Name);
            var description = new SqlParameter("@description", product.Description);

            command.Parameters.Add(id);
            command.Parameters.Add(name);
            command.Parameters.Add(description);
        }

        private Product ToDomainEntity(ProductDao dao)
        {
            return new Product(dao.Id, dao.Name, dao.Description);
        }

        private ProductDao ToDao(Product product)
        {
            return new ProductDao
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description
            };
        }
    }
}