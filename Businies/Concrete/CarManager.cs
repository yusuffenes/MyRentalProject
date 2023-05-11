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
        return new ErrorDataResult<List<Car>>(_carDal.GetAll(),false);
    }

    public IDataResult<List<CarDetailDto>> GetCarDetail()
    {
        return new ErrorDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),false);
       
    }

    public IDataResult<List<Car>> GetAllByDailyPrice(decimal price)
    {
        throw new NotImplementedException();
    }
    public IResult Add(Car car)
    {
        if (car.Descriptions.Length > 2 || car.DailyPrice > 0)
        {
            _carDal.Add(car);
            return new SuccessResult(true,Messages.CarAdded);
            
        }
        else
        {
            return new ErrorResult(false,Messages.CarNameInvalid);
            
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
        return new SuccessResult(true,Messages.CarToUpdate);
    }
}