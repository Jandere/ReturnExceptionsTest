namespace Domain;

public class Result<TObject>
    where TObject : class
{
    public TObject? Item { get; }
    public Exception? Exception { get; }

    private Result(TObject? item, Exception? exception)
    {
        Item = item;
        Exception = exception;
    }

    public static Result<TObject> WithException(Exception exception)
    {
        return new Result<TObject>(null, exception);
    }
    
    public static Result<TObject> New(TObject item)
    {
        return new Result<TObject>(item, null);
    }

    public static implicit operator (TObject? item, Exception? exception)(Result<TObject> result)
    {
        return (result.Item, result.Exception);
    }

    public void Deconstruct(out TObject? item, out Exception? exception)
    {
        item = Item;
        exception = Exception;
    }
}