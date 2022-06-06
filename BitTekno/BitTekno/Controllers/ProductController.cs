using BitTekno.Business.Repository.Concrete;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitTekno.Controllers
{
    public class ProductController : Controller
    {
        BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
        ProductDepartment productDepartment = new ProductDepartment();
        ProductDescription productDescription = new ProductDescription();
        ProductDescriptionRepository productDescriptionRepository = new ProductDescriptionRepository();
        ProductRepository productRepository = new ProductRepository();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(int id)
        {
            ProductDescription productDescription =productDescriptionRepository.Get(id);
            var productID=bitteknoEntitiess.Product.FirstOrDefault(x=>x.ProductDescriptionID==id).ProductID;
            Product product = productRepository.Get(productID);
            return View(product);
        }
    }
}