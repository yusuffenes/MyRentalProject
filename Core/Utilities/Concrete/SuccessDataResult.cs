using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete;

public class SuccessDataResult<T> : DataResult<T>,IDataResult<T>
{
    public SuccessDataResult(T data,string message) : base(data, true,message)
    {

    }

    public SuccessDataResult(T data, bool isSuccess) : base(data, true)
    {

    }

    public SuccessDataResult(string message) : base(default, true, message)
    {

    }

    public SuccessDataResult() : base(default, true)
    {

    }
}