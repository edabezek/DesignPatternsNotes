using System;

namespace ThreadSafeSingleton
{
    internal class Program
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
        static object _Lock = new object();
        private CustomerManager()
        {

        }
        public static CustomerManager CreateAsSingleton()
        {
            lock (_Lock)
            {
                if (_instance == null)//daha önce CustomerManager instance'ı oluşturulmamışsa,bossa oluştur. 
                {
                    _instance=new CustomerManager();
                }
            }            
            return _instance;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}
