namespace Domain.Shared.OperationalResult;

public class OperationResult<T>
{
    public bool IsSuccess { get; init; }
    public T? Value { get; init; }
    public string? Error { get; init; }

    public static OperationResult<T> Ok(T value) =>
        new OperationResult<T> { IsSuccess = true, Value = value };

    public static OperationResult<T> Fail(string error) =>
        new OperationResult<T> { IsSuccess = false, Error = error };
}