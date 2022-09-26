using System;
using System.Collections;
using System.Collections.Generic;

namespace CompositeDesign//bir kurumda çalışanlar için model 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    interface IPerson
    {
        string Name { get; set; }   
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
