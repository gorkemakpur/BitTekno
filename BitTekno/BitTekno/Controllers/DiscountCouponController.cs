using BitTekno.Business.Repository.Concrete;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitTekno.Controllers
{
    public class DiscountCouponController : Controller
    {
        // GET: DiscountCoupon
        BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
        OrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        OrderRepository orderRepository = new OrderRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Apply(string Coupon)
        {
            #region Contact
            var contact = Session["contactemail"];
            var contactId = Convert.ToInt32(Session["contactId"]);
            #endregion
            var available = bitteknoEntitiess.Coupon.Any(x => x.ContactID == contactId && x.CouponCode.Contains(Coupon) && x.IsUsed==false);
            if (available)
            {
                var OrderID = bitteknoEntitiess.Order.FirstOrDefault(x => x.ContactID == contactId && x.isBasket.Value == true).OrderID;
                var orderDetailList = bitteknoEntitiess.OrderDetail.Where(x => x.OrderID == OrderID).ToList();
                var CouponCode = bitteknoEntitiess.Coupon.FirstOrDefault(x => x.ContactID == contactId && x.CouponCode.Contains(Coupon));
                var discount = CouponCode.Discount / orderDetailList.Count();
                foreach (var item in orderDetailList)
                {
                    item.Discount += discount;
                    bitteknoEntitiess.OrderDetail.Attach(item);
                    bitteknoEntitiess.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    bitteknoEntitiess.SaveChanges();
                }
                // TODO : Repository yazılıp oradan çekilecek 
                CouponCode.IsUsed = true;
                bitteknoEntitiess.Coupon.Attach(CouponCode);
                bitteknoEntitiess.Entry(CouponCode).State = System.Data.Entity.EntityState.Modified;
                bitteknoEntitiess.SaveChanges();

            }
            var LastOrderID = bitteknoEntitiess.Order.FirstOrDefault(x => x.ContactID == contactId && x.isBasket.Value == true).OrderID;
            var LastorderDetailList = bitteknoEntitiess.OrderDetail.Where(x => x.OrderID == LastOrderID).ToList();
            return RedirectToAction("Cart", "Basket", LastorderDetailList);
        }
    }
}