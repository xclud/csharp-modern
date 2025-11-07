using Microsoft.AspNetCore.Mvc;

namespace Sepidabr.Controllers;


[ApiController]
[Route("[controller]")]
[Produces("application/grpc-web", "application/grpc")]
public abstract class GrpcController : ControllerBase
{

}