using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Auth0Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Auth0TestController : ControllerBase
{
    private readonly string _auth0UserInfo;

    public Auth0TestController(IConfiguration configuration)
    {
        _auth0UserInfo = $"Auth0:Authority -> {configuration["Auth0:Authority"]}";
    }

    [HttpGet]
    [Route("GetWithoutAuth")]
    public string GetWithoutAuth()
    {
        return _auth0UserInfo;
    }

    [Authorize]
    [HttpGet]
    [Route("GetWithAuth")]
    public string GetWithAuth()
    {
        return _auth0UserInfo;
    }

    [Authorize(Policy = "NeedPolicty")]
    [HttpGet]
    [Route("GetWithAuthAndPolicy")]
    public string GetWithAuthAndPolicy()
    {
        return _auth0UserInfo;
    }
}