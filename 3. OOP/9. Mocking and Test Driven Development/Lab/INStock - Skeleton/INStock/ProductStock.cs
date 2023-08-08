using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock.Contracts
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> list;
        private IProduct indexer;

        public ProductStock()
        {
            list = new List<IProduct>();
        }
        public IProduct this[int index] { get => indexer; set => indexer = value; }

        public int Count => list.Count;

        public void Add(IProduct product)
        {
            list.Add(product);
        }

        public bool Contains(IProduct product)
        {
            return list.Contains(product);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return list[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            return list.Where(p => p.Price == (decimal)price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            return list.Where(p => p.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            return list.Where(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi).OrderByDescending(x => x);
        }

        public IProduct FindByLabel(string label)
        {
            if (!list.Any(x => x.Label == label))
            {
                throw new ArgumentException();
            }

            return list.First(l => l.Label == label);
        }

        public IProduct FindMostExpensiveProduct()
        {
            return list.First(x => x.Price == list.Max(p => p.Price));
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (IProduct item in list)
            {
                yield return item;
            }
        }

        public bool Remove(IProduct product)
        {
            if (list.Any(x => x.CompareTo(product) == 0))
            {
                list.Remove(product);
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
