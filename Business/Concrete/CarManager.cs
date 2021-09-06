using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entity.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
           //IResult result= BusinessRules.Run(CheckofSameName(car.CarName),BrandofSameName(car.BrandId));

           // if (result!=null)
           // {
           //     return result;
           // }
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
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

        public IResult Update(Car car)
        {
            
            _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);

        }








        //private IResult CheckofSameName(string carName)
        //{
        //    var result = _carDal.GetAll(p => p.CarName == carName).Any();

        //    if (result)
        //    {
        //        return new ErrorResult(Messages.CarNameInvalid);
        //    }

        //    return new SuccessResult();
        //}

        //private IResult BrandofSameName(int brandId)
        //{
        //    var result = _brandDal.GetAll(p => p.BrandId == brandId).Count();

        //    if (result >15)
        //    {
        //        return new ErrorResult(Messages.CarNotAdded);
        //    }

        //    return new SuccessResult();
        //}


    }




}


