using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Utilities.Result;
using RentACar.DataAccess.Abstract;
using RentACar.Entities;
using RentACar.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new ErrorResult(Messages.SuccessAdd);
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Car> GetByBrandId(int BrandId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.SuccessListed);
        }

        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
