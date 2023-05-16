 using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Color = System.Drawing.Color;

namespace Business.Concrete;

public class CarManager : ICarService
{
    ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }
    public IDataResult<List<Car>> GetAll()
    {
        return new SuccessDataResult<List<Car>>(_carDal.GetAll());
    }

    public IDataResult<List<CarDetailDto>> GetCarDetail()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
       
    }
    public IResult Add(Car car)
    {
        if (car.Description.Length > 2 || car.DailyPrice > 0)
        {
            _carDal.Add(car);
            return new SuccessResult(true,Messages.Added);
            
        }
        else
        {
            return new ErrorResult(false,Messages.NameInvalid);
            
        }
        
    }

    public IResult Remove(Car car)
    {
        _carDal.Delete(car);
        return  new SuccessResult();
    }

    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(true,Messages.Updated);
    }
}