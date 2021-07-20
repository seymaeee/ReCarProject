using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.CarId equals c.BrandId
                            
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 UnitPrice=p.UnitPrice,
                                 CarName=p.CarName,
                                 BrandName=c.BrandName,
                             };
                return result.ToList();

            }              
        }
    }
}
