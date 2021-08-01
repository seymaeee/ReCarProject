using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll(); //İşlem sonucu,message,ve araba listesini döndürücek.
        IDataResult<List<Rental>> GetByRentalId (int id);
      
    }
}
