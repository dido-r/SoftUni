using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => portfolio.Count;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            portfolio = new List<Stock>();
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && stock.PricePerShare <= MoneyToInvest)
            {
                portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!portfolio.Any(x => x.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }
            
            var currentStock = portfolio.First(y => y.CompanyName == companyName);

            if (sellPrice < currentStock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            MoneyToInvest += sellPrice;
            portfolio.Remove(currentStock);
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            return portfolio.FirstOrDefault(x => x.MarketCapitalization == portfolio.Max(y => y.MarketCapitalization));
        }

        public string InvestorInformation()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in portfolio)
            {
                info.AppendLine($"{stock}");
            }
            return info.ToString().Trim();
        }
    }
}
