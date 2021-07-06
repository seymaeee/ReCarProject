using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Car> GetAll()
        {

            return _carDal.GetAll();
        }

        public List<Car> GetCarByCarName()
        {
            return _carDal.GetAll().Where(p => p.CarName.Length > 4).ToList();
        }

        public List<Car> GetCarByUnitPrice()
        {
            return _carDal.GetAll();
                //.Where(p => p.UnitPrice > 180).ToList();
        }

        
    }

}


