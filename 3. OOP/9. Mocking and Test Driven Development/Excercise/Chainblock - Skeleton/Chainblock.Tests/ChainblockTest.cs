using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Linq;

namespace Chainblock.Tests
{
    public class ChainblockTest
    {
        private ITransaction tran;
        private ITransaction tran2;
        private IChainblock test;

        [SetUp]
        public void Test_SetUp()
        {
            tran = new Transaction(1111, TransactionStatus.Successfull, "Dido", "Pesho", 250);
            tran2 = new Transaction(2222, TransactionStatus.Unauthorized, "Dimitrichko", "Go6o", 100);
            test = new Chainblock();
            test.Add(tran);
            test.Add(tran2);
        }

        [Test]
        public void Test_Constructor()
        {
            test.Add(new Transaction(5555, TransactionStatus.Successfull, "Simo", "Pesho", 100));
            Assert.AreEqual(3, test.Count);
        }

        [Test]
        public void Test_Contains_By_Id()
        {
            Assert.IsTrue(test.Contains(1111));
            Assert.IsFalse(test.Contains(0000));
        }

        [Test]
        public void Test_Contains_By_ITransaction()
        {
            Assert.IsTrue(test.Contains(tran));
            Assert.IsFalse(test.Contains(new Transaction(123, TransactionStatus.Failed, "Dido", "Pesho", 50)));
        }

        [Test]
        public void Test_ChangeTransactionStatus()
        {
            test.ChangeTransactionStatus(1111, TransactionStatus.Failed);
            Assert.AreEqual(TransactionStatus.Failed, tran.Status);
            Assert.Throws<ArgumentException>(() => test.ChangeTransactionStatus(0000, TransactionStatus.Failed));
        }

        [Test]
        public void Test_Remove_Transaction_By_Id()
        {
            test.RemoveTransactionById(1111);
            Assert.AreEqual(1, test.Count);
            Assert.Throws<InvalidOperationException>(() => test.RemoveTransactionById(0000));
        }

        [Test]
        public void Test_Get_By_Id()
        {
            Assert.AreEqual(tran, test.GetById(1111));
            Assert.Throws<InvalidOperationException>(() => test.GetById(0000));
        }

        [Test]
        public void Test_Get_By_Transaction_Status()
        {
            Assert.Contains(tran, test.GetByTransactionStatus(TransactionStatus.Successfull).ToArray());
            Assert.Throws<InvalidOperationException>(() => test.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void Test_GetAllSendersWithTransactionStatus()
        {
            test.Add(new Transaction(5555, TransactionStatus.Successfull, "Simo", "Pesho", 100));
            Assert.Contains("Dido", test.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToArray());
            Assert.Contains("Simo", test.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToArray());
            Assert.Throws<InvalidOperationException>(() => test.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void Test_GetAllReceiversWithTransactionStatus()
        {
            test.Add(new Transaction(5555, TransactionStatus.Successfull, "Simo", "Lyubo", 100));
            Assert.Contains("Pesho", test.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToArray());
            Assert.Contains("Lyubo", test.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToArray());
            Assert.Throws<InvalidOperationException>(() => test.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void Test_GetAllOrderedByAmountDescendingThenById()
        {
            test.Add(new Transaction(5555, TransactionStatus.Successfull, "Simo", "Lyubo", 150));
            var result = test.GetAllOrderedByAmountDescendingThenById();
            CollectionAssert.AreEqual(test.OrderByDescending(x => x.Amount).ThenBy(x => x.Id), result);
        }

        [Test]
        public void Test_GetBySenderOrderedByAmountDescending()
        {
            test.Add(new Transaction(5555, TransactionStatus.Successfull, "Dido", "Lyubo", 150));
            var result = test.GetBySenderOrderedByAmountDescending("Dido");
            CollectionAssert.AreEqual(test.Where(x => x.From == "Dido").OrderByDescending(x => x.Amount), result);
            Assert.Throws<InvalidOperationException>(() => test.GetBySenderOrderedByAmountDescending("Evgeni"));
        }

        [Test]
        public void Test_GetByReceiverOrderedByAmountThenById()
        {
            test.Add(new Transaction(5555, TransactionStatus.Successfull, "Dido", "Pesho", 150));
            var result = test.GetByReceiverOrderedByAmountThenById("Pesho");
            CollectionAssert.AreEqual(test.Where(x => x.To == "Pesho").OrderByDescending(x => x.Amount).ThenBy(i => i.Id), result);
            Assert.Throws<InvalidOperationException>(() => test.GetByReceiverOrderedByAmountThenById("Evgeni"));
        }

        [Test]
        public void Test_GetByTransactionStatusAndMaximumAmount()
        {
            var tran3 = new Transaction(5555, TransactionStatus.Successfull, "Dido", "Pesho", 150);
            test.Add(tran3);
            var result = test.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 200);
            CollectionAssert.Contains(result, tran3);
            Assert.AreEqual(1, result.Count());
            CollectionAssert.IsEmpty(test.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, 200));
        }

        [Test]
        public void Test_GetBySenderAndMinimumAmountDescending()
        {
            var tran3 = new Transaction(5555, TransactionStatus.Successfull, "Dido", "Pesho", 150);
            test.Add(tran3);
            var result = test.GetBySenderAndMinimumAmountDescending("Dido", 10);
            CollectionAssert.AreEqual(test.Where(x => x.From == "Dido" && x.Amount >= 10), result);
            Assert.Throws<InvalidOperationException>(() => test.GetBySenderAndMinimumAmountDescending("Tosho", 200));
        }

        [Test]
        public void Test_GetByReceiverAndAmountRange()
        {
            var tran3 = new Transaction(5555, TransactionStatus.Successfull, "Dido", "Pesho", 150);
            test.Add(tran3);
            var result = test.GetByReceiverAndAmountRange("Pesho", 10, 300);
            CollectionAssert.AreEqual(test.Where(x => x.From == "Dido" && x.Amount >= 10), result);
            Assert.Throws<InvalidOperationException>(() => test.GetByReceiverAndAmountRange("Evgeni", 10, 200));
        }

        [Test]
        public void Test_GetAllInAmountRange()
        {
            var tran3 = new Transaction(5555, TransactionStatus.Successfull, "Dido", "Pesho", 150);
            test.Add(tran3);
            var result = test.GetAllInAmountRange(90, 160);
            CollectionAssert.AreEqual(test.Where(x => x.Amount >= 90 && x.Amount <= 160), result);
            Assert.Throws<InvalidOperationException>(() => test.GetByReceiverAndAmountRange("Evgeni", 10, 200));
        }
    }
}
