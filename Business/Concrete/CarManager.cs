using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==16)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByCarName(string carName)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.CarName==carName)); 
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min,decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.UnitPrice>min && p.UnitPrice< max));
                
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public void Update(Car car)
        {
            throw new NotImplementedException();
        }
    }

}


