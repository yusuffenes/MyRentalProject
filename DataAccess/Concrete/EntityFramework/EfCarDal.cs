using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal :EfEntityRepositoryBase<Car,CarContext>, ICarDal
{
    public List<CarDetailDto> GetCarDetails()
    {
        using (CarContext context = new CarContext())
        {
            var result = from x in context.Cars
                join c in context.Colors
                    on x.ColorId equals c.ColorId
                join b in context.Brands
                    on x.BrandId equals b.BrandId
                select new CarDetailDto
                {
                    CarId = x.Id,
                    BrandName = b.BrandName,
                    ColorName = c.ColorName,
                    DailyPrice = x.DailyPrice
                };
            return result.ToList();
        }
    }
}
