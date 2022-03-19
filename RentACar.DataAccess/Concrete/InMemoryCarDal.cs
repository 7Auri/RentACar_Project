using RentACar.DataAccess.Abstract;
using RentACar.Entities;
using RentACar.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1, BrandId=1, ColorId=1, ModelYear="2014",DailyPrice=450,Descriptions="White Toyota"},
            new Car{Id=2, BrandId=1, ColorId=1, ModelYear="2021",DailyPrice=850,Descriptions="White Toyota"},
            new Car{Id=3, BrandId=2, ColorId=2, ModelYear="2018",DailyPrice=750,Descriptions="Black BMW"},
            new Car{Id=4, BrandId=3, ColorId=2, ModelYear="2021",DailyPrice=1250,Descriptions="Gray Volvo"},
            new Car{Id=5, BrandId=4, ColorId=1, ModelYear="2011",DailyPrice=250,Descriptions="White Fiat"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           Car deleteCar= _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(deleteCar);
        }

        public void Update(Car car)
        {
            Car carUpdate =_cars.SingleOrDefault(x => x.Id == car.Id);
            carUpdate.BrandId = car.BrandId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.ColorId = car.ColorId;
            carUpdate.Descriptions = car.Descriptions;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }



        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(x => x.BrandId == brandId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
