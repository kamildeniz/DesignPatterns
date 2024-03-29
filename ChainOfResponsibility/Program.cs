﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense { Detail="Training", Amount=9825 };
            manager.HandleExpense(expense);
            Console.ReadLine();
        }
    }
    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }
    abstract class ExpenseHanlerBase
    {
        protected ExpenseHanlerBase Succesor;
        public abstract void HandleExpense(Expense expense);
        public void SetSuccessor(ExpenseHanlerBase succesor)
        {
            Succesor = succesor;
        }
    }
    class Manager : ExpenseHanlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if (Succesor!=null)
            {
                Succesor.HandleExpense(expense);
            }
        }
    }
    class VicePresident: ExpenseHanlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=1000)
            {
                Console.WriteLine("VisePresident handled the expense!");
            }
            else if (Succesor != null)
            {
                Succesor.HandleExpense(expense);
            }
        }
    }
    class President : ExpenseHanlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
            
        }
    }
}
