using BrainStorming.Intrefaces;
using BrainStorming.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BrainStorming.Enums.StatusEnum;

namespace BrainStorming.Connection
{
    internal class IsbService : IIsbService
    {
        private readonly IConfiguration _connection;
        public IsbService()
        {
            _connection = new ConfigurationBuilder()
                                    .AddJsonFile("appsetting.json")
                                    .AddEnvironmentVariables()
                                    .Build();
        }


        public async Task<List<ISB>> GetContracts()
        {
            List<ISB> isbDatas = new List<ISB>();
            using (var connection = new SqlConnection(_connection.GetSection("ISBDatabase").Value))
            {
                var sql = "select * from IsbTable";
                var policies = connection.Query(sql);
                foreach (var policy in policies)
                {
                    ISB isbdata = new ISB();
                    isbdata.Id = policy.Id;
                    isbdata.CreatedDate = policy.CreatedDate;
                    isbdata.ContractNumber = policy.ContractNumber;
                    isbdata.Person = policy.Person;
                    isbdata.PolicyStatus = (Status)Enum.ToObject(typeof(Status), policy.InsuarenceStatus);
                    isbDatas.Add(isbdata);
                }
            }
            Console.WriteLine("Salam");
            return isbDatas;
        }
    }
}
