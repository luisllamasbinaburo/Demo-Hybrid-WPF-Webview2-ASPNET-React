using Microsoft.AspNetCore.Mvc;

namespace ServerAspnet.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
    private readonly ILogger<FilesController> _logger;

    public FilesController(ILogger<FilesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetFiles")]
    public IEnumerable<string> Get()
    {
        var path = "C:\\temp";
        return System.IO.Directory.GetFiles(path);
    }
}
