using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public string CarName { get; set; }
        public decimal UnitPrice { get; set; }
        public int  BrandId { get; set; }
        public int  ColorId { get; set; }
        public int CarId { get; set; }
      
    }
}
