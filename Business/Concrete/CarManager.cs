using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {

            return _carDal.GetAll();
        }

        public List<Car> GetCarByCarName()
        {
            return _carDal.GetAll(); // Where(p => p.CarName == "renault").ToList();
        }

        public List<Car> GetCarByUnitPrice()
        {
            return _carDal.GetAll();
                //.Where(p => p.UnitPrice > 180).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }

}


