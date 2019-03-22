using MyCore.Demo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MyCore.Demo.Utils;

namespace MyCore.Demo.Repositories
{
    public class EmployeeRepository
    {
        string _connectionString;

        public EmployeeRepository()
        {
            _connectionString = AppSettingsUtil.Get("ConnectionStrings:Default");
        }

        public void Add(Employee model)
        {
            using (IDbConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Execute("insert into employee(name) values(@name)", model);
            }
        }

        public Employee GetModel(int id)
        {
            Employee employee = null;
            using (IDbConnection conn = new MySqlConnection(_connectionString))
            {
                employee = conn.Query<Employee>("select * from employee where id=@id", new
                {
                    Id = id
                }).FirstOrDefault();
            }
            return employee;
        }

        public List<Employee> GetModelList()
        {
            List<Employee> employeeList = null;
            using (IDbConnection conn = new MySqlConnection(_connectionString))
            {
                employeeList = conn.Query<Employee>("select * from employee").ToList();
            }
            return employeeList;
        }
    }
}
