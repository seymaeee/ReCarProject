using Business;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
   public class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarByCarName())
            {
                if(car.UnitPrice > 180)
                {
                    Console.WriteLine(car.CarName);
                    Console.WriteLine(car.UnitPrice);
                }
            }
        }
    }
}
