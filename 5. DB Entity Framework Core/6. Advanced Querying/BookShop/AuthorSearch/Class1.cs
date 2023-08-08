using BookShop.Data;
using System.Linq;
using System.Text;

namespace AuthorSearch
{
    public static class AuthorSearch
    {
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Select(x => new { x.FirstName, x.LastName })
                .Where(x => x.FirstName.EndsWith(input))
                .OrderBy(x => x.FirstName).ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().Trim();
        }
    }
}
