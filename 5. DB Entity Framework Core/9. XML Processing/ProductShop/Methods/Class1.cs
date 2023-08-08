using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Methods
{
    public static class MethodClass
    {
        //var xmlString = File.ReadAllText("../../../Datasets/fileName.xml");
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));
            UserDto[] usersDto = (UserDto[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(x => x.AddProfile(new ProductShopProfile()));
            var mapper = config.CreateMapper();
            var users = mapper.Map<HashSet<User>>(usersDto);

            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {context.Users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("Products"));
            var productDto = (ProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(x => x.AddProfile(new ProductShopProfile()));
            var mapper = config.CreateMapper();
            var products = mapper.Map<HashSet<Product>>(productDto);

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {context.Products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            var categoryiesDto = (CategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(x => x.AddProfile(new ProductShopProfile()));
            var mapper = config.CreateMapper();
            var categories = mapper.Map<HashSet<Category>>(categoryiesDto);

            context.Categories.AddRange(categories.Where(x => x.Name != null));
            context.SaveChanges();
            return $"Successfully imported {context.Categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));
            var categoryiesProductsDto = (CategoryProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var config = new MapperConfiguration(x => x.AddProfile(new ProductShopProfile()));
            var mapper = config.CreateMapper();
            var categoryiesProducts = mapper.Map<HashSet<CategoryProduct>>(categoryiesProductsDto.Where(x => x.CategoryId > 0 && x.ProductId > 0 && x.CategoryId < 12 && x.ProductId < 201));

            context.CategoryProducts.AddRange(categoryiesProducts);
            context.SaveChanges();
            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductsInRangeOutput
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            var selializer = new XmlSerializer(typeof(ProductsInRangeOutput[]), new XmlRootAttribute("Products"));
            var writer = new StringWriter();
            var namespaceXml = new XmlSerializerNamespaces();
            namespaceXml.Add("", "");
            selializer.Serialize(writer, products, namespaceXml);


            return writer.ToString();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new UsersOutput
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProductsSold = x.ProductsSold.Select(p => new SoldProductsOutput { Name = p.Name, Price = p.Price }).ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var selializer = new XmlSerializer(typeof(UsersOutput[]), new XmlRootAttribute("Users"));
            var writer = new StringWriter();
            var namespaceXml = new XmlSerializerNamespaces();
            namespaceXml.Add("", "");
            selializer.Serialize(writer, users, namespaceXml);


            return writer.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(x => new CategoriesByProductsCountOutput
                {
                    Name = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    ProductsAveragePrice = x.CategoryProducts.Average(p => p.Product.Price),
                    ProductsRevenue = x.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(x => x.ProductsCount)
                .ThenBy(x => x.ProductsRevenue)
                .ToArray();

            var selializer = new XmlSerializer(typeof(CategoriesByProductsCountOutput[]), new XmlRootAttribute("Categories"));
            var writer = new StringWriter();
            var namespaceXml = new XmlSerializerNamespaces();
            namespaceXml.Add("", "");
            selializer.Serialize(writer, categories, namespaceXml);


            return writer.ToString();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Any())
                .Include(x => x.ProductsSold)
                .ToList()
                .Select(z => new UsersWithSoldProductOutput
                {
                    FirstName = z.FirstName,
                    LastName = z.LastName,
                    Age = z.Age,
                    ProductList = new ProductListOutput
                    {
                        Count = z.ProductsSold.Count,
                        ProductsSold = z.ProductsSold.Select(p => new SoldProductsOutput
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                           .OrderByDescending(v => v.Price)
                           .ToArray()
                    }
                })
                .OrderByDescending(x => x.ProductList.Count)
                .Take(10)
                .ToArray();

            var result = new UsersWitProductsCountOutput
            {
                Count = context.Users.Where(x => x.ProductsSold.Any()).Count(),
                Users = users
            };

            var serializer = new XmlSerializer(typeof(UsersWitProductsCountOutput), new XmlRootAttribute("Users"));
            var writer = new StringWriter();
            var settings = new XmlSerializerNamespaces();
            settings.Add("", "");
            serializer.Serialize(writer, result, settings);

            return writer.ToString();
        }
    }
}
