using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var list = new List<Product>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.Products.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public static Product FindProductById(int id)
        {
            var p = new Product();
            try
            {
                using (var context = new MyDbContext())
                {
                    p = context.Products.SingleOrDefault(p => p.ProductId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return p;
        }

        public static void SaveProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();  
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Product>(product).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProduct(Product product)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p1 = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
