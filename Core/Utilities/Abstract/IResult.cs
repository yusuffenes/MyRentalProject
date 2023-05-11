namespace Core.Utilities.Abstract;

public interface IResult
{
    bool IsSuccess { get; }
    string Message { get; }
}