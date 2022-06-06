using BitTekno.Business.Repository.Concrete;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitTekno.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
        ContactRepository contactrepository = new ContactRepository();
        
        public ActionResult Index()
        {
            //var contactlist= contactrepository.GetList(); //liste çekme örnek
            //Contact contact = new Contact();
            //contact.FirstName = "berkay"; // yeni kullanıcı ekleme örnek
            //contactrepository.Add(contact);
            //contactrepository.Delete( 1); // id ye göre silme işlemi
            //var contactlist2 = contactrepository.GetList();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Contact contact)
        {
            var contactcontrol = bitteknoEntitiess.Contact.FirstOrDefault(x => x.Email == contact.Email && x.Password == contact.Password);
            if (contactcontrol == null) {
                return Content("Kullanıcı bulunamadı");
            }
            else
            {
                Session["contact"] = contactcontrol.FirstName + contactcontrol.Lastname;
                Session["contactemail"] = contactcontrol.Email;
                Session["contactId"] = contactcontrol.ContactID;
                var orders = bitteknoEntitiess.Order.Where(x => x.ContactID == contactcontrol.ContactID && x.isBasket.Value == true);
                Session["BasketCount"] = orders !=null ? bitteknoEntitiess.OrderDetail.Where(x => x.OrderID == orders.FirstOrDefault().OrderID).Count() : 0 ;
               return Redirect("~/Home/Index");
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Remove("contact");
            return Redirect("~/Home/Index");
        }

        public ActionResult Aboutus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Contact contact)
        {
            
            contact.RoleID = 2;
            contact.RecordDate = DateTime.Now;
            contactrepository.Add(contact);
            return View();
        }
    }
}