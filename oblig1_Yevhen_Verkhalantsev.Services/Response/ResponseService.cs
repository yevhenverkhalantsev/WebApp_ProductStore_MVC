namespace oblig1_Yevhen_Verkhalantsev.Services.Response;

public class ResponseService
{
    public bool IsError { get; set; }
    public string ErrorMessage { get; set; }

    public static ResponseService Ok()
    {
        return new ResponseService()
        {
            IsError = false,
        };
    }

    public static ResponseService Error(string errorMessage)
    {
        return new ResponseService()
        {
            IsError = true,
            ErrorMessage = errorMessage,
        };
    }
}

public class ResponseService<T>
{
    public bool IsError { get; set; }
    public string ErrorMessage { get; set; }
    public T Value { get; set; }

    public static ResponseService<T> Ok(T value)
    {
        return new ResponseService<T>()
        {
            IsError = false,
            Value = value,
        };
    }

    public static ResponseService<T> Error(string errorMessage)
    {
        return new ResponseService<T>()
        {
            IsError = true,
            ErrorMessage = errorMessage
        };
    }
}