using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ReturnExceptionsTest.Controllers;

public class TestController : BaseController
{
    private readonly ITestRepository _testRepository;

    public TestController(ITestRepository testRepository)
    {
        _testRepository = testRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetItem()
    {
        return Handle(await _testRepository.GetTestObject());
    }

    [HttpGet]
    public async Task<IActionResult> GetItemWihtoutHandle()
    {
        var (item, ex) = await _testRepository.GetTestObject();

        if (ex != null)
            return BadRequest(ex.Message);

        return Ok(item);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetException()
    {
        return Handle(await _testRepository.GetException());
    }
}