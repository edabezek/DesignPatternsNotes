using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            //yapılacak işlemler
            customerManager.Save();
        }
    }
    class CustomerManager//constructor'u olan ama dışarıdan erişilmeyen
    {
        private static CustomerManager _instance;   
        private CustomerManager()
        {
                
        }
        public static CustomerManager CreateAsSingleton()
        {
            if (_instance == null)//daha önce CustomerManager instance'ı oluşturulmamışsa,bossa oluştur. 
            {
                _instance = new CustomerManager();  
            }
            return _instance;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}
