/*
 Create a BankAccount class with a private balance and methods to deposit and withdraw.
 
 */

using System;

class BankAcc
{
    private int balance;

    public void Deposit(int amt)
    {
        balance += amt;

    }

    public void withdraw(int amt)
    {
        if (amt > 0)
        {
            Console.WriteLine("amount withdraw");
            balance -= amt;
        }
    }
      
}