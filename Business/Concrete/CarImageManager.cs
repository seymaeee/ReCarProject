using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImage(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImage(carImage.CarId));
            if (result != null)
            {
                return null;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId (int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageExist(carId));

            if (result != null)
            {
                return null; 
            }

            _carImageDal.GetAll();

            return new SuccessDataResult<List<CarImage>>(Messages.CarsListed);
        }

        public IResult Update(CarImage carImage)
        {
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarUpdated);
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarImageExist (int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Any();// CARID si eşit olan araba Var MI?
            if (!result)
            {
                return new ErrorDataResult<CarImage>(new CarImage { CarId = carId, ImagePath = DefaultImage.DefaultPicture, Date = DateTime.Now }, Messages.CarImagesNot);

            }

            return new SuccessResult();
        }
    }
}
