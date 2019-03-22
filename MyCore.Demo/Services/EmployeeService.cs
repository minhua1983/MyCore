using MyCore.Demo.Models;
using MyCore.Demo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCore.Demo.Services
{
    public class EmployeeService
    {
        EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Add(Employee model)
        {
            _employeeRepository.Add(model);
        }

        public Employee GetModel(int id)
        {
            return _employeeRepository.GetModel(id);
        }

        public List<Employee> GetModelList()
        {
            return _employeeRepository.GetModelList();
        }
    }
}
