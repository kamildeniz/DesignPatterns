using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee kamil = new Employee { Name = "Kamil" };
            Employee ozgur = new Employee{Name = "Özgür"};
            Employee arif = new Employee { Name = "Arif" };
            arif.AddSubordinate(kamil);
            arif.AddSubordinate(ozgur);
            Contractor dursun = new Contractor { Name="Dursun"};
            ozgur.AddSubordinate(dursun);
            Console.WriteLine(arif.Name);
            foreach (Employee manager in arif)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }
            Console.ReadLine();
        }
    }
    interface IPerson
    {
        string Name { get; set; }
    }
    class Contractor : IPerson
    {
        public string Name { get; set; }
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
