using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single checking account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Deposits the amount in the bank account
        /// and returns the new balance
        /// </summary>
        /// <param name="amt">The amount to deposit</param>
        /// <returns></returns>
        public double Deposit(double amt)
        {

            if(amt >= 10000)
            {
                throw new ArgumentException($"{nameof(amt)} must be smaller than 10000");
            }

            if(amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amt)} must be a positive value");
            }

            Balance += amt;
            return Balance;
        }
        /// <summary>
        /// Get the current balance
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Withdraws the amount in the bank account and returns the new balance
        /// </summary>
        /// <param name="amt">The amount to withdraw</param>
        public void Withdraw(double amt)
        {
            if(amt < 0)
            {
                throw new ArgumentException("You cannot withdraw a negative amount.");
            }
            if(amt > Balance)
            {
                throw new ArgumentException("You cannot withdraw more than the account balance.");
            }
            Balance -= amt;
        }

    }
}
