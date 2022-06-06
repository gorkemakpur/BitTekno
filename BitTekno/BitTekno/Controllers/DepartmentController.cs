using BitTekno.Business.Repository.Concrete;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitTekno.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DepartmentRepository departmentRepository=new DepartmentRepository();
        BitteknoEntitiess bitteknoEntitiess=new BitteknoEntitiess(); 
        ProductDepartment productDepartment=new ProductDepartment(); 
        ProductDescription productDescription=new ProductDescription(); 
        public ActionResult Index(string d)
        {
            data.Models.Department departments = new data.Models.Department();
            if (!string.IsNullOrEmpty(d))
            {

                departments = bitteknoEntitiess.Department.Where(x=>x.Title.Contains(d.ToLower())).FirstOrDefault();
                if (departments == null)
                {
                    departments = departmentRepository.GetList().FirstOrDefault(x => x.Title == "TumUrunler");
                    return View(departments);

                }
                return View(departments);
            }
            departments =departmentRepository.GetList().FirstOrDefault(x=>x.Title == "TumUrunler");
            return View(departments);

        }
    }
}