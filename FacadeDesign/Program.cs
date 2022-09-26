using System;

namespace FacadeDesign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine(); 
        }
    }
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();   
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }
    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("User validated");
        }
    }

    internal interface IValidate
    {
        void Validate();
    }

    internal interface IAuthorize
    {
        void CheckUser();   
    }

    class CustomerManager
    {
        private CrossCuttongConcernsFacade _concerns;
        public CustomerManager()
        {    
            _concerns = new CrossCuttongConcernsFacade();   
        }
        public void Save()
        {   
            _concerns.logging.Log();
            _concerns.caching.Cache();
            _concerns.authorize.CheckUser();
            _concerns.validate.Validate();
            Console.WriteLine("Saved!");
        }
    }
    class CrossCuttongConcernsFacade
    {
        public ILogging logging;
        public ICaching caching;
        public IAuthorize authorize;
        public IValidate validate;

        public CrossCuttongConcernsFacade()
        {
            logging = new Logging();
            caching = new Caching();
            authorize = new Authorize();
            validate = new Validation();
        }
    }
}
