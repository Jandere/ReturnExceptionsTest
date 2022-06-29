using Domain;
using Domain.Repositories;

namespace Infrastructure.Repositories;

public class TestRepository : ITestRepository
{
    public Task<Result<Test>> GetTestObject()
    {
        return Task.FromResult(Result<Test>.New(new Test()));
    }

    public Task<Result<Test>> GetException()
    {
        return Task.FromResult(Result<Test>.WithException(new ArgumentException("Something bad happened")));
    }
}