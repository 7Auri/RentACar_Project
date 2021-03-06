using RentACar.Core.DataAccess;
using RentACar.Entities;
using RentACar.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Abstract
{
   public interface ICarDal:IEntityRepository<Car>
    {
      
        List<CarDetailDto> GetCarDetails();
    }
}
