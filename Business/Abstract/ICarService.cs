using Entities.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        List<Car> GetCarByCarName ();
        List<Car> GetCarByUnitPrice ();
        List<CarDetailDto> GetCarDetails();
        

    }
}