using System;
using System.Collections;
using System.Collections.Generic;

namespace CompositeDesign//bir kurumda çalışanlar için hiyerarşi modeli 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee engin = new Employee { Name="Engin Demiroğ"};
           
            Employee salih = new Employee { Name = "Salih Demiroğ" };
            engin.AddSubordinate(salih);//engin için alt çalışan salih ekle

            Employee derin=new Employee { Name = "Derin Demiroğ" };
            engin.AddSubordinate(derin); //engin için alt çalışan derin ekle

            Employee ahmet = new Employee { Name = "Ahmet Demiroğ" };
            salih.AddSubordinate(ahmet);//salih'in alt çalışanı ahmet


            Contructor ali = new Contructor();//derin altına ali eklenir
            derin.AddSubordinate(ali);

            Console.WriteLine("{0}", engin.Name);
            foreach (Employee manager in engin)
            {
                Console.WriteLine("--{0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("----{0}", employee.Name);
                }
            }
            Console.ReadLine();
        }
    }
    //IPerson üzerinden çalışmanın avantajı, contructor eklediğimide entegresinin kolay olması
    interface IPerson
    {
        string Name { get; set; }   
    }
    class Contructor : IPerson //contructor derin'e bağlı
    {
        public string Name { get; set; }
    }
    class Employee : IPerson,IEnumerable<IPerson> //foreach ile nesneleri gezebileceğimiz bir yapı IEnumerable
    {
        List<IPerson> _subordinates=new List<IPerson>();     //_subordinates hiyerarşide en alt

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

        public string Name { get ; set ; }

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
