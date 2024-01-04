namespace newInspire.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDosController : ControllerBase
{
    private readonly ToDosService _toDosService;
    private readonly Auth0Provider _auth0Provider;

    public ToDosController(ToDosService toDosService, Auth0Provider auth0Provider)
    {
        _toDosService = toDosService;
        _auth0Provider = auth0Provider;
    }
}