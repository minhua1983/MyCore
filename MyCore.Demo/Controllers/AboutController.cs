using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCore.Demo.Controllers
{
    //下面这种写法，指定route以当前controller名称为RouteData中的controller参数
    //[Route("[controller]")]
    [Route("about")]
    public class AboutController
    {
        
        public AboutController()
        {

        }

        [Route("")]
        public string Phone()
        {
            return "+10086";
        }

        ////下面这种写法，指定route以当前action名称为RouteData中的action参数
        //[Route("[action]")]
        [Route("country")]
        public string Country()
        {
            return "中国";
        }
    }
}
