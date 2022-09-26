using System;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();

            Console.ReadLine(); 
        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);   
    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with log4net");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with nlogger");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);   
    }
    public class MemCache : Caching
    {
        public override void Cache(string message)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string message)
        {
            Console.WriteLine("Cached with RedisCache");
        }
    }
    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    public class ProductManager 
    {
        CrossCuttingConcernsFactory _concernsFactory;
        private Logging _logging;
        private Caching _caching;   
        public ProductManager(CrossCuttingConcernsFactory concernsFactory)
        {
            _concernsFactory = concernsFactory;
            _logging=_concernsFactory.CreateLogger();   
            _caching=_concernsFactory.CreateCaching();  
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Cached");
            Console.WriteLine("Products listed!");
        }
    }
}
