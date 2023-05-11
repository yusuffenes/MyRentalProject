using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ColorManager : IColorService
{
    IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public IDataResult<List<Color>> GetColorList()
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll().ToList(), Messages.ColorListed);
    }

    public IDataResult<List<Color>> GetAllByColorId(int colorId)
    {
        return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == colorId),true);
    }

    public IResult Add(Color color)
    {
        _colorDal.Add(color);
        return new SuccessResult(true, Messages.ColorAdded);
    }

    public IResult Remove(Color color)
    {
        _colorDal.Delete(color);
        return new SuccessResult(true, Messages.ColorDelete);
    }

    public IResult Update(Color color)
    {
        _colorDal.Update(color);
        return new SuccessResult(true, Messages.ColorToUpdate);
    }
}