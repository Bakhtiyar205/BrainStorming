
using BrainStorming.Enums;
using BrainStorming.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using static BrainStorming.Enums.StatusEnum;

namespace BrainStorming.Connection
{
    internal class ConnectionWithInsuarence
    {
        private readonly string? _connection;
        public ConnectionWithInsuarence(IConfiguration configuration)
        {
            _connection = configuration.GetSection("InsuarenceDatabase").Value;
        }

        public async Task<List<Insuarence>> GetContracts()
        {
            List<Insuarence> insuarences = new List<Insuarence>();
            using (var connection = new SqlConnection(_connection))
            {
                var sql = "select * from xalqdatabase";
                var policies = await connection.QueryAsync(sql);
                foreach (var policy in policies)
                {
                    Insuarence insuarence = new Insuarence();
                    insuarence.Id = policy.Id;
                    insuarence.CreatedDate = policy.CreatedDate;
                    insuarence.ContractNumber = policy.ContractNumber;
                    insuarence.Person = policy.Person;
                    insuarence.PolicyStatus = (Status)Enum.ToObject(typeof(Status), policy.InsuarenceStatus);
                    insuarences.Add(insuarence);
                }
            }

            return insuarences;
        }
    }
}
