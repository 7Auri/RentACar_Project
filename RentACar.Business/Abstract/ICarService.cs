using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Core.Utilities.Result;
using RentACar.Entities;
using RentACar.Entities.DTOs;

namespace RentACar.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetByBrandId(int BrandId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
