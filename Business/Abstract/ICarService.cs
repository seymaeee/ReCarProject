using Core.Utilities.Results;
using Entities.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        IDataResult<List<Car>> GetAll(); //İşlem sonucu,message,ve araba listesini döndürücek.
        IDataResult<List<Car>> GetByCarName (string carName);
        IDataResult<List<Car>> GetByUnitPrice (decimal min,decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        
        
    }
}