using INStock.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace INStock
{
    public class Product : IProduct
    {
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }
        public string Label { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CompareTo([AllowNull] IProduct other)
        {
            int result = Label.CompareTo(other.Label);

            if (result == 0)
            {
                result = Price.CompareTo(other.Price);

                if (result == 0)
                {
                    result = Quantity.CompareTo(other.Quantity);
                }
            }

            return result;
        }
    }
}
