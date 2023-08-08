namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(BookImportModel[]), new XmlRootAttribute("Books"));
            var bookDtos = (BookImportModel[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();

            foreach (var item in bookDtos)
            {
                if (IsValid(item))
                {
                    var book = new Book
                    {
                        Name = item.Name,
                        Genre = (Genre)Enum.GetValues(typeof(Genre)).GetValue(item.Genre - 1),
                        Price = item.Price,
                        Pages = item.Pages,
                        PublishedOn = DateTime.Parse(item.PublishedOn, CultureInfo.InvariantCulture)
                    };

                    context.Books.Add(book);
                    sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDto = JsonConvert.DeserializeObject<HashSet<AuthorImportModel>>(jsonString);
            var sb = new StringBuilder();
            var list = new List<Author>();

            foreach (var item in authorsDto)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (list.Any(x => x.Email == item.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidList = false;

                foreach (var b in item.Books.Where(x => x.Id != null))
                {
                    if (context.Books.Any(x => x.Id == int.Parse(b.Id)))
                    {
                        isValidList = true;
                    }
                }

                if (isValidList)
                {
                    var author = new Author
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Phone = item.Phone,
                        AuthorsBooks = new List<AuthorBook>()
                    };

                    context.Authors.Add(author);

                    foreach (var bookDto in item.Books.Where(x => x.Id != null))
                    {
                        if (context.Books.Any(x => x.Id == int.Parse(bookDto.Id)))
                        {
                            author.AuthorsBooks.Add(new AuthorBook { BookId = int.Parse(bookDto.Id) });
                        }
                    }
                    list.Add(author);

                    sb.AppendLine(string.Format(SuccessfullyImportedAuthor, $"{author.FirstName} {author.LastName}", author.AuthorsBooks.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}