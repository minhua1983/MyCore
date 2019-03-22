using Microsoft.AspNetCore.Mvc;
using MyCore.Demo.Models;
using MyCore.Demo.Repositories;
using MyCore.Demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCore.Demo.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {
        EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Route("")]
        public ObjectResult List()
        {
            List<Employee> employeeList = _employeeService.GetModelList();
            return new ObjectResult(employeeList);
        }

        [Route("add")]
        public ObjectResult Add()
        {
            Employee employee = new Employee()
            {
                Name = Guid.NewGuid().ToString().Substring(0, 8)
            };
            _employeeService.Add(employee);
            ApiResult apiResult = new ApiResult()
            {
                ReturnCode = 1,
                ReturnMsg = "成功"
            };
            return new ObjectResult(apiResult);
        }
    }
}
