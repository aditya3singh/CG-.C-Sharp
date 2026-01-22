using System;
using System.IO;

class InsufficiantBalExp : Exception
{
    public InsufficiantBalExp(string message) : base(message) { }
}

class BankAccount
{
    public decimal Balance { get; private set; } = 5000;
    public void Withdraw(decimal amt)
    {
        if(amt <= 0)
        {
            throw new ArgumentException("withdrawal amount must be greater than zero.");
        }
        if(amt > Balance)
        {
            throw new InsufficiantBalExp("Insufficient balance for withdrawal.");
        }
        Balance -= amt;
    }
}