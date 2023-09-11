using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Compostie
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Employee engin = new Employee { Name = "Engin Demiroğ"};
            Employee salih = new Employee { Name = "Salih Demiroğ" };
            engin.AddSubordinate(salih);
            Employee derin = new Employee { Name = "Derin Demiroğ" };
            engin.AddSubordinate(derin);
            Contractor eren = new Contractor { Name = "Eren Özaslan"};
            derin.AddSubordinate(eren);
            Employee utku = new Employee { Name = "Utku Paralı" };
            salih.AddSubordinate(utku);

            Console.WriteLine(engin.Name);
            foreach ( Employee manager in engin)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach(IPerson employee in manager)
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

    class Contractor:IPerson
    {
        public String Name { get; set; }
    }

    class Employee:IPerson,IEnumerable<IPerson>
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
            return GetEnumerator();
        }
    }

}
