using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCore.Demo.Models
{
    public class ApiResult
    {
        public int ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
        public object ReturnData { get; set; }
    }
}
