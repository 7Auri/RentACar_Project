using RentACar.Core.DataAccess.EntityFramework;
using RentACar.DataAccess.Abstract;
using RentACar.Entities;
using RentACar.Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.DataAccess.Concrete.EntityFramework
{

    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from car in context.Cars
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 CarName = car.Descriptions,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }

}
