using System;

namespace DecoratorDesign//HirePrice'ı belli durumlar için farklı hesaplatacağız
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personalCar=new PersonalCar { Make="BMW",Model="3.20",HirePrice=2500};//buraya ne yazdıysak specialoffer'a o gidecek

            SpecialOffer specialOffer=new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;

            Console.WriteLine("Contrete offer : {0}", personalCar.HirePrice);//normal fiyat
            Console.WriteLine("Special offer : {0}",specialOffer.HirePrice);//special offerdan gelen hireprice

            Console.ReadLine();
        }
    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }    
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }  
    }
    class PersonalCar : CarBase//binek araç
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    class CommercialCar : CarBase//ticari araç
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    //Decorator base
    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }
    //Decorator 
    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carBase) : base(carBase)//Special offer'a hangi araçla çalışacaksak onu göndermiş oluyoruz
        {
            _carBase=carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get
            {
                return _carBase.HirePrice - (_carBase.HirePrice * DiscountPercentage)/100; //yüzde 10 indirim
            }
            set
            {
                _carBase.HirePrice = value; 
            }
        }
    }
}
