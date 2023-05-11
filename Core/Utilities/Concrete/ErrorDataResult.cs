﻿using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult(T data, string message) : base(data, false, message)
    {
        
    }

    public ErrorDataResult(T data, bool isSuccess) : base(data, false)
    {
    }

    public ErrorDataResult(string message) : base(default, false, message)
    {
        
    }

    public ErrorDataResult() : base(default, false)
    {
    }
}