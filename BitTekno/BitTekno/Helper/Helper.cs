using BitTekno.Business.Repository.Concrete;
using BitTekno.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitTekno
{
    public class Helper
    {
        DepartmentRepository departmentRepository = new DepartmentRepository();
        ProductDepartment productDepartment = new ProductDepartment();
        ProductDescription productDescription = new ProductDescription();
        Images ımages = new Images();
        public static List<ProductDescription> ProductDescriptionList(int departmentID)
        {
            BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
            var departmentList = bitteknoEntitiess.ProductDepartment.Where(x => x.DepartmentID == departmentID).ToList();
            List<ProductDescription> productDescriptionList = new List<ProductDescription>();
            foreach (var department in departmentList)
            {
                productDescriptionList.Add(department.ProductDescription);
            }
            return productDescriptionList;
        }
        public static Product GetProductWithDescriptionId(int productDescriptionId)
        {
            BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
            var product = bitteknoEntitiess.Product.FirstOrDefault(x => x.ProductDescriptionID == productDescriptionId);
            return product;
        }

        public static List<Images> GetProductWithImagesId(int productId)
        {
            BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
            List<Images> images = bitteknoEntitiess.Images.Where(x => x.ProductID == productId).ToList();
            return images;
        }


        public static List<ProductComment> GetProductWithProductCommentId(int productId)
        {
            BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
            List<ProductComment> productComment = bitteknoEntitiess.ProductComment.Where(x => x.ProductID == productId).ToList();
            return productComment;
        }

        public static Contact GetContactWithCommentId(int productId)
        {
            BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
            var contact = bitteknoEntitiess.ProductComment.FirstOrDefault(x => x.ProductID == productId).Contact;
            return contact;
        }

        public static ProductFeatures GetProductWithProductFeatures(int productId)
        {
            BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
            ProductFeatures productFeatures = bitteknoEntitiess.Product.FirstOrDefault(x => x.ProductID == productId).ProductFeatures;
            return productFeatures;
        }


        public static Color GetProductWithProductColor(int productId)
        {
            BitteknoEntitiess bitteknoEntitiess = new BitteknoEntitiess();
            Color color = bitteknoEntitiess.Product.FirstOrDefault(x => x.ProductID == productId).Color;
            return color;
        }
    }
 }