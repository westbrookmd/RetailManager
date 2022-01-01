using Microsoft.AspNet.Identity;
using RMDataManager.Library.Internal.DataAccess;
using RMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        //public List<ProductModel> Get()
        //{
        //    ProductData data = new ProductData();

        //    return data.GetProducts();
        //}
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData();
            string cashierId = RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, cashierId);
        }
    }
}
