﻿using System;
using ProductShop.Data;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureCreated();

            //Console.WriteLine(Method(context));
        }
    }
}