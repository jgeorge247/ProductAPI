using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductAPI.Controllers
{
    public class ValuesController : ApiController
    {
        NORTHWINDEntities db = new NORTHWINDEntities();

        // GET api/values/5
        public List<string> Get()
        {
            List<Product> products = db.Products.ToList();
            List<string> NameId = new List<string>();

            for (int i = 0; i < products.Count; i++)
            {
                NameId.Add(products[i].ProductID.ToString());
                NameId.Add(products[i].ProductName);
            }
            return NameId;
        }

        public Product GetProductInfo(int id)
        {

            Product product = (from p in db.Products
                                      where p.ProductID == id
                                      select p).Single();
            return product;
        }
    }
}
