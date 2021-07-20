using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
   public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string  CarName{ get; set; }
        public decimal UnitPrice { get; set; }
        public string BrandName { get; set; }
    }
}
