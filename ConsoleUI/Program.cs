using Business;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
   public class Program
   {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var p in carManager.GetCarDetails())
            {
                Console.WriteLine(p.CarName + " " + p.UnitPrice + " " + p.BrandName +" "+ p.CarId);

            }
        }
    }
}

