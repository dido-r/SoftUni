using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> list;

        public Chainblock()
        {
            list = new Dictionary<int, ITransaction>();
        }
        public int Count => list.Count;

        public void Add(ITransaction tx)
        {
            if (!list.ContainsKey(tx.Id))
            {
                list.Add(tx.Id, tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!list.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            list[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            return list.ContainsKey(tx.Id);
        }

        public bool Contains(int id)
        {
            return list.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return list.Where(a => a.Value.Amount >= lo && a.Value.Amount <= hi).Select(x => x.Value);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return list.OrderByDescending(a => a.Value.Amount).ThenBy(x => x.Key).Select(x => x.Value);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!list.Any(x => x.Value.Status == status))
            {
                throw new InvalidOperationException();
            }

            return list.Where(x => x.Value.Status == status).Select(x => x.Value.To);
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!list.Any(x => x.Value.Status == status))
            {
                throw new InvalidOperationException();
            }

            return list.Where(x => x.Value.Status == status).Select(x => x.Value.From);
        }

        public ITransaction GetById(int id)
        {
            if (!list.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return list[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            if (!list.Any(x => x.Value.To == receiver && x.Value.Amount >= lo && x.Value.Amount < hi))
            {
                throw new InvalidOperationException();
            }

            return list.Where(x => x.Value.To == receiver && x.Value.Amount >= lo && x.Value.Amount < hi).Select(x => x.Value);
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (!list.Any(x => x.Value.To == receiver))
            {
                throw new InvalidOperationException();
            }

            return list.Where(x => x.Value.To == receiver).OrderByDescending(a => a.Value.Amount).ThenBy(x => x.Key).Select(x => x.Value);
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            if (!list.Any(x => x.Value.From == sender && x.Value.Amount > amount))
            {
                throw new InvalidOperationException();
            }

            return list.Where(x => x.Value.From == sender && x.Value.Amount > amount).OrderByDescending(a => a.Value.Amount).Select(x => x.Value);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (!list.Any(x => x.Value.From == sender))
            {
                throw new InvalidOperationException();
            }

            return list.Where(x => x.Value.From == sender).OrderByDescending(x => x.Value.Amount).Select(x => x.Value);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!list.Any(x => x.Value.Status == status))
            {
                throw new InvalidOperationException();
            }

            return list.Where(x => x.Value.Status == status).OrderByDescending(x => x.Value.Amount).Select(x => x.Value);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return list.Where(x => x.Value.Status == status && x.Value.Amount <= amount).OrderByDescending(a => a.Value.Amount).Select(x => x.Value);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item.Value;
            }
        }

        public void RemoveTransactionById(int id)
        {
            if (!list.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            list.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
