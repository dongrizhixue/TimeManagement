using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TimeManagementServer.Controllers
{
    public class UserInfoController : ApiController
    {

        public IEnumerable<Models.Product> GetProducts()
        {
            List<Models.Product> list = new List<Models.Product>();
            list.Add(new Models.Product { Name = "王先生", Price = 6000, Category = "白领" });
            list.Add(new Models.Product { Name = "郭先生", Price = 8000, Category = "程序员" });
            return list;
        }

        //public List<Models.Product> GetProducts2()
        //{
        //    List<Models.Product> list = new List<Models.Product>();
        //    list.Add(new Models.Product { Name = "王先生2", Price = 6000, Category = "白领2" });
        //    list.Add(new Models.Product { Name = "郭先生2", Price = 8000, Category = "程序员2" });
        //    return list;
        //}
    }
}
