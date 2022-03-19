using RentACar.Business.Concrete;
using RentACar.DataAccess.Concrete.EntityFramework;
using System;

namespace RentACar.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            
        }

        private static void Bolum2()
        {
            /*CarManager carManager = new CarManager(new EfCarDal());*/
           
        }

        private static void DtoUsing(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Rengi: " + car.ColorName + " \nMarkası: " + car.BrandName +
                                " \nAraba Hakkında:" + car.CarName + " \nGünlük Ücreti: " + car.DailyPrice);
                Console.WriteLine("---------------------");
            }
        }

        
    }
}
