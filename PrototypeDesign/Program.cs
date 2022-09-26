using System;

namespace PrototypeDesign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { FirstName="Engin",LastName="Demir",City="Ankara",Id=1};
            Console.WriteLine(customer.FirstName);

            Customer customer2 = (Customer)customer.Clone();//yeni referans oluşur,ikisi de ayrı nesne olur
            customer2.FirstName = "Salih";

            Console.WriteLine(customer.FirstName); 
            Console.WriteLine(customer2.LastName);
        }
    }
    public abstract class Person
    {
        //temel nesneyi prototip haline getirebilmek için , onun soyut bir clone dan besleniyor olması gerekir.
        public abstract Person Clone();  
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();   
        }
    }
    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
