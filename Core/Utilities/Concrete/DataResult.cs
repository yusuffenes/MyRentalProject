using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete;

public class DataResult<T> : Result,IDataResult<T>
{
    public DataResult(T data,bool isSuccess, string message) : base(isSuccess, message)
    {
    }

    public DataResult(T data,bool isSuccess) : base(isSuccess)
    {
        Data = data;
    } 
    public T Data { get; }
}