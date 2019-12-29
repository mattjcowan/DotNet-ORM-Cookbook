﻿using Dapper;
using Microsoft.Data.SqlClient;
using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.Dapper.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncRepository : ISingleModelCrudAsyncRepository<EmployeeClassification>
    {
        readonly string m_ConnectionString;

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        /// <remarks>Caller must dispose the connection.</remarks>
        async Task<SqlConnection> OpenConnectionAsync()
        {
            var con = new SqlConnection(m_ConnectionString);
            await con.OpenAsync().ConfigureAwait(false);
            return con;
        }

        public SingleModelCrudAsyncRepository(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                return (int)(await cmd.ExecuteScalarAsync().ConfigureAwait(false));
            }
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }

        public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", employeeClassificationName);
                using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                {
                    if (!(await reader.ReadAsync().ConfigureAwait(false)))
                        return null;

                    return new EmployeeClassification()
                    {
                        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                    };
                }
            }
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync()
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

            var result = new List<EmployeeClassification>();

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            using (var cmd = new SqlCommand(sql, con))
            using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
            {
                while (await reader.ReadAsync().ConfigureAwait(false))
                {
                    result.Add(new EmployeeClassification()
                    {
                        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                    });
                }
                return result;
            }
        }

        public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                {
                    if (!(await reader.ReadAsync().ConfigureAwait(false)))
                        return null;

                    return new EmployeeClassification()
                    {
                        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                    };
                }
            }
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }
    }
}