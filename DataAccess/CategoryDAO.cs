﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var list = new List<Category>();
            try
            {
                using (var context = new MyDbContext())
                {
                    list = context.Categories.ToList();
                }
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
    }
}
