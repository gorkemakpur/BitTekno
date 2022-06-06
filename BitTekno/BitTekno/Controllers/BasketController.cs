using BitTekno.Business.Repository.Concrete;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitTekno.Controllers
{
    public class BasketController : Controller
    {
        // GET: Basket
        BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
        OrderDetailRepository orderDetailRepository = new OrderDetailRepository();  
        OrderRepository orderRepository = new OrderRepository();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            #region Contact
            var contact = Session["contactemail"];
            int contactId = Convert.ToInt32(Session["contactId"]);
            #endregion
            var orderId = 0;
            var orderControl = bitteknoEntitiess.Order.Where(x => x.ContactID == contactId && x.isBasket.Value == true);
            orderId = orderControl.Count() == 0 ? 0 : orderControl.FirstOrDefault().OrderID;
            if (orderId == 0)
            {
                var order = new Order();
                order.ContactID = contactId != null ? Convert.ToInt32(contactId) : 0;
                order.OrderDate = DateTime.Now;
                order.isBasket = true;
                orderRepository.Add(order);
                orderId = order.OrderID;
            }
            var orderDetail = new OrderDetail();
            orderDetail.OrderID = orderId;
            orderDetail.ProductID = product.ProductID;
            orderDetail.Price = product.PriceOutput;
            orderDetail.Quantity = 1;
            orderDetail.Discount = 0;
            orderDetail.Total = product.PriceOutput;
            orderDetailRepository.Add(orderDetail);

            #region SessionControl
            Session["BasketCount"] = bitteknoEntitiess.OrderDetail.Where(x => x.OrderID == orderId ).Count();
            #endregion


            var OrderID = bitteknoEntitiess.Order.FirstOrDefault(x => x.ContactID == contactId && x.isBasket.Value == true).OrderID;
            var orderDetailList = bitteknoEntitiess.OrderDetail.Where(x => x.OrderID == OrderID).ToList();

            return View("Cart",orderDetailList); //Sepete gidecek
        }

        public ActionResult Cart()
        {
            #region Contact
            var contact = Session["contactemail"];
            var contactId = Convert.ToInt32(Session["contactId"]);
            #endregion
            var OrderID = bitteknoEntitiess.Order.FirstOrDefault(x => x.ContactID == contactId && x.isBasket.Value == true).OrderID;
            var orderDetailList = bitteknoEntitiess.OrderDetail.Where(x => x.OrderID == OrderID).ToList();
            return View(orderDetailList);
        }
        public ActionResult RemoveDetail(int orderDetailId)
        {
            #region Contact
            var contact = Session["contactemail"];
            var contactId = Convert.ToInt32(Session["contactId"]);

            #endregion
            orderDetailRepository.Delete(orderDetailId);
            var OrderID = bitteknoEntitiess.Order.FirstOrDefault(x => x.ContactID == contactId && x.isBasket.Value == true).OrderID;
            var orderDetailList = bitteknoEntitiess.OrderDetail.Where(x => x.OrderID == OrderID).ToList();
            return View("Cart",orderDetailList);
        }
    }
}