using System;
using System.Threading;

namespace ProxyDEsign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CreditManager creditManager = new CreditManager();  proxy'i eklemeden önce 
            CreditBase creditManager = new CreditManagerProxy();
            Console.WriteLine(creditManager.Calculate());

            Console.WriteLine(creditManager.Calculate());

            Console.ReadLine();
        }
    }
    abstract class CreditBase
    {
        public abstract int Calculate();
    }
    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 0; i < 5; i++)
            {
                result *= i;    
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()//yani burada bekleme süresini tekrar almamak için daha önce newlenmiş mi onu kontrol ediyoruz.
        {
            if (_creditManager==null) //creditManager daha önce hiç çağırılmadıysa, newle
            {
                _creditManager= new CreditManager();    
                _cachedValue = _creditManager.Calculate();
            }
            return _cachedValue;
        }
    }
}
