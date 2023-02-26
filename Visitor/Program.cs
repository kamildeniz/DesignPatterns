using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager engin = new Manager { Name = "Engin", Salary = 1000 };
            Manager kamil = new Manager { Name = "Kamil", Salary = 1100 };
            Worker derin = new Worker { Name = "Derin", Salary = 800 };
            engin.Subordinates.Add(kamil);
            kamil.Subordinates.Add(derin);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(engin);
            PayriseVisitor payriseVisitor = new PayriseVisitor();
            PayrollVisitor payrollVisitor = new PayrollVisitor();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payriseVisitor);
            Console.ReadLine();
        }
    }
    class OrganisationalStructure
    {
        EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitorBase);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }
    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }
    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            //ayrı iş kodlar olduğunu varsayalım.
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            //ayrı iş kodlar olduğunu varsayalım.
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }
    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            //ayrı iş kodlar olduğunu varsayalım.
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary * (decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            //ayrı iş kodlar olduğunu varsayalım.
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }

}
