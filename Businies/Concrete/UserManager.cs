using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UserManager : IUserService
{
    IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }
    public IResult Add(User user)
    {
        _userDal.Add(user);
        return new SuccessResult();
    }

    public IResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult();
    }

    public IResult Delete(User user)
    {
        _userDal.Delete(user);
        return new SuccessResult();
    }

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(_userDal.GetAll().ToList(),Messages.UserListed);
    }

    public IDataResult<User> GetById(int id)
    {
        return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
    }
}