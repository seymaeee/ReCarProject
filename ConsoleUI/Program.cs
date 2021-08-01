using Business;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entity.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
   public class Program
   {

        static void Main(string[] args)
        {
            RentalManagerGETALL();

            RentalManagerADD();
        }

        private static void RentalManagerADD()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { RentalId = 1, CarId = 3, CustomerId = 4, ReturnDate = new DateTime(2021, 08, 10), RentDate = new DateTime(2021, 07, 10) });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalManagerGETALL()
        {

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var p in result.Data)
            {
                Console.WriteLine("Araba Id :" + p.CarId + "Müşteri Id:" + p.CustomerId + "Arabanın Teslim Tarihi:" + p.ReturnDate + "Arabanın alış Tarihi" + p.RentDate);
            }
        }
        
    }
}

