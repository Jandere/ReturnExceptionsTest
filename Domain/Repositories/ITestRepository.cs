namespace Domain.Repositories;

public interface ITestRepository
{
    Task<Result<Test>> GetTestObject();

    Task<Result<Test>> GetException();
}