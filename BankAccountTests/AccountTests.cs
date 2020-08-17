using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;
        [TestInitialize]// Run code before EACH TEST
        public void Initialize()
        {
            acc = new Account();
        }

        [TestMethod]
        [TestCategory("Bad Deposit")]
        [DataRow(10_000)]
        [DataRow(11234.12)]
        [DataRow(10000.01)]
        [DataRow(double.MaxValue)] // tests with largest possible double
        public void Deposit_TooLarge_ThrowsArgumentException(double tooLargeDeposit)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(tooLargeDeposit));
        }

        [TestMethod()]
        [TestCategory("Good Deposit")]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(9999.99)]
        public void Deposit_PositiveAmount_AddsToBalance(double initialDeposit)
        {
            // AAA - Arrange|Act|Assert

            // Arrange  - Creating variables/objects
            const double startBalance = 0;

            // Act - Execute method under text
            acc.Deposit(initialDeposit);

            // Assert - Check a condition
            Assert.AreEqual(startBalance + initialDeposit, acc.Balance);
        }

        [TestMethod] //()'s are optional
        [TestCategory("Good Deposit")]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance()
        {
            // Arrange
            double intialBalance = 0;
            double depositAmount = 10.55;

            // Act
            double newBalance = acc.Deposit(depositAmount);

            //Assert
            Assert.AreEqual(intialBalance + depositAmount, newBalance);
        }

        [TestMethod]
        [TestCategory("Good Deposit")]
        public void Deposit_MultipleAmounts_ReturnsAccumulatedBalance()
        {
            // Arrange
            double deposit1 = 10;
            double deposit2 = 25;
            double expectedBalance = deposit1 + deposit2;

            // Act
            double intermediateBalance = acc.Deposit(deposit1);
            double finalBalance = acc.Deposit(deposit2);

            // Assert
            Assert.AreEqual(deposit1, intermediateBalance);
            Assert.AreEqual(expectedBalance, finalBalance);
        }

        [TestMethod]
        [TestCategory("Bad Deposit")]
        public void Deposit_NegativeAmounts_ThrowsArgumentException()
        {
            // Arrange
            double negativeDeposit = -1;

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (
                    () => acc.Deposit(negativeDeposit)
                );
        }

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(50, 50)]
        [DataRow(9.99, 9.99)]
        public void Withdraw_PositiveAmount_SubtractsFromBalance(double initialDeposit, double withdrawAmount)
        {
            double expectedBalance = initialDeposit - withdrawAmount;

            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        public void Withdraw_MoreThanBalance_ThrowsArgumentException()
        {
            // An account with the defalut constructor has a 0 balance
            Account myAccount = new Account();
            double withdrawAmount = 1000;

            Assert.ThrowsException<ArgumentException>(() => myAccount.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            double withdrawAmount = -100;

            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }
    }
}